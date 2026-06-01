using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Eleon_SCADA.Park
{
    class VestasRCS
    {
        const int RCV_BUF_SIZE = 128;               // size of serial data receive buffer
        WindPark _Park;
        VestasTurbine turbine;
        public FiFoList ErrorLog = new FiFoList(20);
        public FiFoList TerminalSentLog = new FiFoList(25);
        public FiFoList TerminalReceivedLog = new FiFoList(25);
        public bool TerminalLogging;

        System.IO.Ports.SerialPort myVestasSerialPort = new System.IO.Ports.SerialPort();
        Thread VestasDriverThread;
        byte[] receiveBuffer = new byte[RCV_BUF_SIZE];
        bool WaitingReply;

        System.Timers.Timer[] CommStatus_Timer;     // array of Communication status timers(timer for each turbine)
        System.Timers.Timer Poll1_Timer;            // Fast rate polling timer
        bool Poll1_TimerElapsed_Flag;               // is set to true each time the timer has elapsed
        System.Timers.Timer Poll2_Timer;            // Slow rate polling timer
        bool Poll2_TimerElapsed_Flag;               // is set to true each time the timer has elapsed
        System.Timers.Timer Poll10s_Timer;          // 10 s polling timer
        bool Poll10s_TimerElapsed_Flag;             // is set to true each time the timer has elapsed
        System.Timers.Timer Timeout_Timer;
        public bool PortIsOpen;

        System.Timers.ElapsedEventHandler CommStatusTimerElapsed;
        System.Timers.ElapsedEventHandler Poll1TimerElapsed;
        System.Timers.ElapsedEventHandler Poll2TimerElapsed;
        System.Timers.ElapsedEventHandler Poll10sTimerElapsed;
        System.Timers.ElapsedEventHandler TimeoutTimerElapsed;

        System.Timers.Timer AutoErrorAck_Timer;
        System.Timers.ElapsedEventHandler AutoErrorAckTimerElapsed;
        int errorCode_Prev;



        // CONSTRUCTOR
        public VestasRCS(WindPark _park, VestasTurbine _turbine)
        {
            try
            {
                _Park = _park;
                this.turbine = _turbine;
                this.turbine.SetVestasController(this);

                // set up timers
                CommStatus_Timer = new System.Timers.Timer[_Park.NumOfTurbinesInPark];
                for (uint i = 0; i < _Park.NumOfTurbinesInPark; i++)
                {
                    CommStatus_Timer[i] = new System.Timers.Timer();
                    CommStatus_Timer[i].AutoReset = false;
                }
                Poll1_Timer = new System.Timers.Timer();
                Poll1_Timer.AutoReset = false;
                Poll2_Timer = new System.Timers.Timer();
                Poll2_Timer.AutoReset = false;
                Poll10s_Timer = new System.Timers.Timer();
                Poll10s_Timer.AutoReset = false;
                Timeout_Timer = new System.Timers.Timer();
                Timeout_Timer.AutoReset = false;

                AutoErrorAck_Timer = new System.Timers.Timer();
                AutoErrorAck_Timer.AutoReset = false;

                // set event handlers
                CommStatusTimerElapsed = new System.Timers.ElapsedEventHandler(CommStatus_Timer_Elapsed);
                //for (uint i = 1; i <= _Park.NumOfTurbinesInPark; i++)
                //{
                //    CommStatusTimerElapsed[i] = new System.Timers.ElapsedEventHandler(CommStatus_Timer_Elapsed);
                //}
                Poll1TimerElapsed = new System.Timers.ElapsedEventHandler(Poll1_Timer_Elapsed);
                Poll2TimerElapsed = new System.Timers.ElapsedEventHandler(Poll2_Timer_Elapsed);
                Poll10sTimerElapsed = new System.Timers.ElapsedEventHandler(Poll10s_Timer_Elapsed);
                TimeoutTimerElapsed = new System.Timers.ElapsedEventHandler(TimeoutTimer_Elapsed);

                AutoErrorAckTimerElapsed = new System.Timers.ElapsedEventHandler(AutoErrorAckTimer_Elapsed);

                // register event handlers
                for (uint i = 0; i < _Park.NumOfTurbinesInPark; i++)
                {
                    CommStatus_Timer[i].Elapsed += CommStatusTimerElapsed;
                }
                Poll1_Timer.Elapsed += Poll1TimerElapsed;
                Poll2_Timer.Elapsed += Poll2TimerElapsed;
                Poll10s_Timer.Elapsed += Poll10sTimerElapsed;
                Timeout_Timer.Elapsed += TimeoutTimerElapsed;
                AutoErrorAck_Timer.Elapsed += AutoErrorAckTimerElapsed;

                VestasDriverThread = new Thread(Main_Loop);
                VestasDriverThread.IsBackground = true;
                VestasDriverThread.Start();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message + "\n( VestasDriver - Constructor )", "Exception", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }


        #region TIMER_FUNCTIONS

        // this function should be modified to detect which turbine has no communication
        private void CommStatus_Timer_Elapsed(object sender, System.EventArgs e)
        {
            // Send alarm message only if local mode request is not active and communication status is lost first time
            if (!turbine.LocalModeRequest && turbine.CommunicationStatus)
            {
                string message = "System alarm - No communication to turbine T01";
                Program.myAlarmDispatch.SendToAll(message);
            }

            CommStatus_Timer[0].Enabled = false;
            turbine.CommunicationStatus = false;   // this line must be located after IF case above(to detect and send alarm only in first occurance of comm loss)
        }

        public void Poll1_Timer_Elapsed(object sender, System.EventArgs e)
        {
            Poll1_TimerElapsed_Flag = true;
        }

        public void Poll2_Timer_Elapsed(object sender, System.EventArgs e)
        {
            Poll2_TimerElapsed_Flag = true;
        }

        public void Poll10s_Timer_Elapsed(object sender, System.EventArgs e)
        {
            Poll10s_TimerElapsed_Flag = true;
        }

        private void TimeoutTimer_Elapsed(object sender, System.EventArgs e)
        {
            Timeout_Timer.Stop();
            WaitingReply = false;
        }

        private void AutoErrorAckTimer_Elapsed(object sender, System.EventArgs e)
        {
            AutoErrorAck_Timer.Stop();

            // if that code is listed in Auto Reset list - send reset and start commands
            if (Eleon_SCADA.Settings.T01.AutoResetError.Exists(x => x == turbine.StatusCode))
            {
                try
                {
                    Program.myAlarmDispatch.SendAnnouncement("hindrik@eleon.ee", "Auto reset for error: " + errorCode_Prev);
                    turbine.Reset_Turbine();
                    Thread.Sleep(100);  // create 100 ms pause between reset and start commands just to be safe
                    turbine.Start_Turbine();
                }
                catch { }
            }
        }

        #endregion TIMER_FUNCTIONS


        #region COMMUNICATION_FUNCTIONS

        public void OpenPort(string _PortName, int _Baudrate)
        {
            if(!Eleon_SCADA.Licensing.CheckLicense())
            {
                throw new Exception("Vestas controller disabled - No license");
            }

            try
            {
                myVestasSerialPort = new System.IO.Ports.SerialPort(_PortName, _Baudrate);

                // set parity
                if (Settings.VestasDriver.Parity == "Even")
                {
                    myVestasSerialPort.Parity = System.IO.Ports.Parity.Even;
                }
                else if (Settings.VestasDriver.Parity == "Mark")
                {
                    myVestasSerialPort.Parity = System.IO.Ports.Parity.Mark;
                }
                else if (Settings.VestasDriver.Parity == "Odd")
                {
                    myVestasSerialPort.Parity = System.IO.Ports.Parity.Odd;
                }
                else if (Settings.VestasDriver.Parity == "Space")
                {
                    myVestasSerialPort.Parity = System.IO.Ports.Parity.Space;
                }
                else
                {
                    myVestasSerialPort.Parity = System.IO.Ports.Parity.None;
                }

                try { myVestasSerialPort.Open(); }
                catch (Exception ex) { throw ex; }
                PortIsOpen = true;

                // clear communication statistics
                _Park.ParkComErrors = 0;
                _Park.ParkComTransmitted = 0;
                _Park.ParkComReceived = 0;
                for (uint i = 1; i <= _Park.NumOfTurbinesInPark; i++)
                {
                    turbine.TurbineComErrors = 0;
                    turbine.TurbineComTransmitted = 0;
                    turbine.TurbineComReceived = 0;
                }

                // load timer intervals
                for (uint i = 0; i < _Park.NumOfTurbinesInPark; i++)
                {
                    CommStatus_Timer[i].Interval = Eleon_SCADA.Settings.VestasDriver.CommStatusTimeout;
                }
                Poll1_Timer.Interval = Eleon_SCADA.Settings.VestasDriver.PollInterval1;
                Poll2_Timer.Interval = Eleon_SCADA.Settings.VestasDriver.PollInterval2;
                Poll10s_Timer.Interval = 10000;
                Timeout_Timer.Interval = Eleon_SCADA.Settings.VestasDriver.CommTimeout;

                // start timers
                Poll1_Timer.Start();
                Poll2_Timer.Start();
                Poll10s_Timer.Start();

                _Park.SetActivePower();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message + "\n( VestasDriver - OpenPort )", "Exception", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        public void ClosePort()
        {
            // clear comm status for all turbines
            for (uint i = 1; i <= _Park.NumOfTurbinesInPark; i++)
            {
                turbine.CommunicationStatus = false;
            }
            PortIsOpen = false;
            Poll1_Timer.Stop();
            Poll2_Timer.Stop();
            Poll10s_Timer.Stop();
            Thread.Sleep(1000);     // give time for all processes to finish before really closing port

            try
            {
                myVestasSerialPort.Close();
            }
            catch (Exception ex)
            {
                Program.myAlarmDispatch.SendAnnouncement("Program exception\n\nVestasDriver - ClosePort");
                System.Windows.Forms.MessageBox.Show(ex.Message + "\n( VestasDriver - ClosePort )", "Exception", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private int Receive(byte[] Buffer)
        {
            int bytesReceived = 0;
            WaitingReply = true;
            //Timeout_Timer.Stop();
            Timeout_Timer.Start();

            // wait for all data to arrive and if no new bytes, break the loop
            while (WaitingReply && PortIsOpen)
            {
                if (bytesReceived == myVestasSerialPort.BytesToRead && bytesReceived > 0)
                {
                    Timeout_Timer.Stop();
                    break;
                }
                bytesReceived = myVestasSerialPort.BytesToRead;
                if (bytesReceived > 0 && Timeout_Timer.Enabled) Timeout_Timer.Stop();   // stop timeout timer if bytes are being received  

                System.Threading.Thread.Sleep(20);      // takes a pause to wait for more bytes to arrive
            }

            if (bytesReceived > RCV_BUF_SIZE) return -2;    // receive buffer overflow
            try
            {
                myVestasSerialPort.Read(Buffer, 0, bytesReceived);
            }
            catch { return -1; }    // error
            return bytesReceived;
        }

        
        /// <summary>
        /// Carry out RCS protocol Send and Receive operations in one function and return the number of bytes received
        /// Includes RCS protocol specific ERROR handling
        /// </summary>
        /// <param name="_turbineID"></param>
        /// <param name="SendBuffer"></param>
        /// <param name="Telegram">Expected Y-Telegram type of reply. If empty string, then type not checked</param>
        /// <param name="Length">Expected length of reply. If 0, then length not checked</param>
        /// <returns></returns>
        private int Transceive_RCS(int _turbineID, byte[] SendBuffer, string Telegram, ushort Length)
        {
            int dataLen = SendBuffer.Length;
            byte[] data1 = new byte[dataLen + 2];
            byte[] crc = ComputeCRC_16_bytes(SendBuffer, 3, dataLen - 3);
            SendBuffer.CopyTo(data1, 0);
            data1[dataLen] = crc[0];        // MSB of CRC
            data1[dataLen + 1] = crc[1];    // LSB of CRC

            try
            {
                myVestasSerialPort.DiscardInBuffer();
                // Send data
                myVestasSerialPort.Write(data1, 0, data1.Length);
            }
            catch (Exception ex)
            {
                CommStatus_Timer[_turbineID - 1].Enabled = true;    // Activate communication status timeout countdown for this turbine
                throw new Exception("Sending error - " + ex.Message);
            }

            // increase data Tx counters
            _Park.ParkComTransmitted++;
            turbine.TurbineComTransmitted++;

            // Add frame to terminal log
            if (TerminalLogging)
            {
                string frame = "";
                for (int i = 0; i < data1.Count(); i++)
                {
                    frame += data1[i].ToString("X2") + " ";
                }
                TerminalSentLog.Add_WithTime(turbine.TurbineComTransmitted + "-  " + frame);
            }

            // receive data
            int bytesReceived = Receive(receiveBuffer);

            if (bytesReceived > 0)
            {
                // increase data Rx counters
                _Park.ParkComReceived++;
                turbine.TurbineComReceived++;

                // Add frame to terminal log
                if (TerminalLogging)
                {
                    string frame = "";
                    for (int i = 0; i < bytesReceived; i++)
                    {
                        frame += receiveBuffer[i].ToString("X2") + " ";
                    }
                    TerminalReceivedLog.Add_WithTime(turbine.TurbineComReceived + "-  " + frame);
                }



                //+++++++++ ERROR HANDLING +++++++++

                // Compare checksum
                ushort checksum = (ushort)(receiveBuffer[bytesReceived - 2] * 256 + receiveBuffer[bytesReceived - 1]);
                if (checksum != ComputeCRC_16(receiveBuffer, 3, receiveBuffer[5] + 4))
                {
                    CommStatus_Timer[_turbineID - 1].Enabled = true;    // Activate communication status timeout countdown for this turbine
                    throw new Exception("Checksum error");
                }

                // Check if data from correct turbine
                if (receiveBuffer[3] != _turbineID)
                {
                    CommStatus_Timer[_turbineID - 1].Enabled = true;    // Activate communication status timeout countdown for this turbine
                    throw new Exception("Wrong ID (" + receiveBuffer[3] + ")");
                }


                // From this point, we are sure that turbine has replied to our request, so we set CommunicationStatus to TRUE and
                // deactivate communication status timeout countdown
                turbine.CommunicationStatus = true;
                CommStatus_Timer[_turbineID - 1].Enabled = false;


                // Check for U-telegram reply
                if (receiveBuffer[6] == (byte)'u')
                {
                    // Unknown Request
                    if (receiveBuffer[7] == 0 && receiveBuffer[8] == 0)
                    {
                        throw new Exception("Unknown Request");
                    }
                    else
                    {
                        throw new Exception("Data Not Ready");
                    }
                }

                // check message length
                if (receiveBuffer[5] != Length)
                {
                    if (Length != 0)
                    {
                        throw new Exception("Wrong message length");
                    }
                }

                // check Y-Telegram message type
                if (Telegram.Count() == 2)
                {
                    char[] telegram = new char[2];
                    telegram[0] = (char)receiveBuffer[6];
                    telegram[1] = (char)receiveBuffer[7];
                    string Y_Telegram = new string(telegram);
                    if (Y_Telegram != Telegram)
                    {
                        if (Telegram != "")
                        {
                            throw new Exception("Wrong telegram");
                        }
                    }
                }
                else if (Telegram.Count() == 3)
                {
                    char[] telegram = new char[3];
                    telegram[0] = (char)receiveBuffer[6];
                    telegram[1] = (char)receiveBuffer[7];
                    telegram[2] = (char)receiveBuffer[9];
                    string Y_Telegram = new string(telegram);
                    if (Y_Telegram != Telegram)
                    {
                        if (Telegram != "")
                        {
                            throw new Exception("Wrong telegram");
                        }
                    }
                }
                else
                {
                    throw new Exception("Invalid telegram reference");
                }
            }
            else if (bytesReceived == -1)
            {
                // increase data Rx counters
                _Park.ParkComReceived++;
                turbine.TurbineComReceived++;

                // Add frame to terminal log
                if (TerminalLogging)
                {
                    string frame = "";
                    for (int i = 0; i < bytesReceived; i++)
                    {
                        frame += receiveBuffer[i].ToString("X2") + " ";
                    }
                    TerminalReceivedLog.Add_WithTime(turbine.TurbineComReceived + "-  " + frame);
                }

                CommStatus_Timer[_turbineID - 1].Enabled = true;    // Activate communication status timeout countdown for this turbine
                throw new Exception("Receive buffer overflow");
            }
            else
            {
                CommStatus_Timer[_turbineID - 1].Enabled = true;    // Activate communication status timeout countdown for this turbine
                throw new Exception("No reply");
            }

            return bytesReceived;
        }

        #endregion COMMUNICATION_FUNCTIONS




        public void Main_Loop()
        {
            while (true)
            {
                try
                {
                    if (PortIsOpen)
                    {
                        while (!(Poll1_TimerElapsed_Flag || Poll2_TimerElapsed_Flag))      // wait for polling timers
                        {
                            Thread.Sleep(20);
                        }

                        if (Poll1_TimerElapsed_Flag)
                        {
                            Get_Overview(1);

                            // update status texts
                            turbine.State_Txt = Get_State_Txt(turbine.State);
                            turbine.OperationState_Txt = Get_OperationState_Txt(turbine.OperationState);
                            turbine.PendOperationState_Txt = Get_OperationState_Txt(turbine.PendOperationState);
                            turbine.YawState_Txt = Get_YawState_Txt(turbine.YawState);

                            Get_WindData(1);
                            Get_ElectricalData(1);

                            // calculate reactive power value from CosPhi and Active Power
                            // COS PHI CAN NOT BE USED for this since it seems to be INCORRECT and ALSO DOES NOT INDICATE +/- reactive power value
                            //_Turbines[_turbineID].Reactive_Power = (int)(float)(_Turbines[_turbineID].Active_Power_1s / _Turbines[_turbineID].CosPhi - _Turbines[_turbineID].Active_Power_1s);
                        }

                        if (Poll2_TimerElapsed_Flag)
                        {
                            Poll2_Timer.Start();    // restart timer
                            Poll2_TimerElapsed_Flag = false;

                            // check if new error code received
                            if (errorCode_Prev != turbine.StatusCode)
                            {
                                errorCode_Prev = turbine.StatusCode;

                                // if that code is listed in Auto Reset list - send reset and start commands automatically
                                if (Eleon_SCADA.Settings.T01.AutoResetError.Exists(x => x == turbine.StatusCode))
                                {
                                    try
                                    {
                                        AutoErrorAck_Timer.Stop();
                                        AutoErrorAck_Timer.Interval = Eleon_SCADA.Settings.T01.AutoErrorAckDelay * 1000;
                                        AutoErrorAck_Timer.Start();
                                    }
                                    catch { }
                                }
                            }

                            // update status texts
                            turbine.StatusCode_Txt = Get_ErrorStatus_Txt(turbine.StatusCode);

                            Get_TemperatureData(1);
                            Get_PowerSetpointData(1);
                            Get_ReactivePowerSetpoint(1);
                            // set reactive power value from setpoint
                            turbine.Reactive_Power = turbine.ReactivePowerSetpoint;
                        }

                        if (Poll10s_TimerElapsed_Flag)
                        {
                            Poll10s_Timer.Start();  // restart timer
                            Poll10s_TimerElapsed_Flag = false;

                            Get_ProductionData(1);
                        }
                    }
                }
                catch (Exception) { }
            }
        }


        #region DATAREQUEST_FUNCTIONS

        private void Get_Overview(int _turbineID)
        {
            lock (Program.myVestasController)
            {
                byte[] data = { 0xE5, 0xA7, 0xCD, 0, (byte)_turbineID, 4, (byte)'Y', (byte)'1', (byte)'0', (byte)'@' };

                try
                {
                    Transceive_RCS(_turbineID, data, "y1@", 0);

                    Extract_StateData(_turbineID, receiveBuffer[8], receiveBuffer[10]);

                    turbine.Active_Power = (short)(receiveBuffer[17] * 256 + receiveBuffer[18]) / 10;
                    turbine.Gen_RPM = (ushort)(receiveBuffer[19] * 256 + receiveBuffer[20]);
                    turbine.Rotor_RPM = (float)(ushort)(receiveBuffer[21] * 256 + receiveBuffer[22]) / 10;
                    turbine.Wind_Speed = (float)(ushort)(receiveBuffer[23] * 256 + receiveBuffer[24]) / 10;
                    turbine.Pitch_Angle = (float)(short)(receiveBuffer[25] * 256 + receiveBuffer[26]) / 10;
                    turbine.State = (int)(receiveBuffer[27] * 256 + receiveBuffer[28]);
                    if (receiveBuffer[5] == 28)     //read error code only if it is received(longer message)
                    {
                        turbine.StatusCode = (int)(receiveBuffer[29] * 256 + receiveBuffer[30]);
                    }
                    else
                    {
                        turbine.StatusCode = 0;
                    }
                }
                catch (Exception ex)
                {
                    _Park.ParkComErrors++;
                    turbine.TurbineComErrors++;
                    ErrorLog.Add_WithTime(turbine.TurbineName + " - Overview data - " + ex.Message);
                    return;
                }
            }
        }

        private void Get_WindData(int _turbineID)
        {
            lock (Program.myVestasController)
            {
                byte[] data = { 0xE5, 0xA7, 0xCD, 0, (byte)_turbineID, 4, (byte)'Y', (byte)'1', (byte)'0', (byte)'D' };

                try
                {
                    Transceive_RCS(_turbineID, data, "y1D", 12);

                    Extract_StateData(_turbineID, receiveBuffer[8], receiveBuffer[10]);

                    turbine.Windspeed_1s = (float)(ushort)(receiveBuffer[11] * 256 + receiveBuffer[12]) / 10;
                    float relDir = (float)(short)(receiveBuffer[13] * 256 + receiveBuffer[14]) / 10;
                    turbine.RelativeWind_Direction = Misc_Functions.CalcAngleDistanceBetween(0, relDir);
                    turbine.Wind_Direction = (float)(short)(receiveBuffer[15] * 256 + receiveBuffer[16]) / 10;
                    turbine.Nacelle_Direction = (float)(short)(receiveBuffer[17] * 256 + receiveBuffer[18]) / 10;
                }
                catch (Exception ex)
                {
                    _Park.ParkComErrors++;
                    turbine.TurbineComErrors++;
                    ErrorLog.Add_WithTime(turbine.TurbineName + " - Wind data - " + ex.Message);
                    return;
                }
            }
        }

        private void Get_ElectricalData(int _turbineID)
        {
            lock (Program.myVestasController)
            {
                byte[] data = { 0xE5, 0xA7, 0xCD, 0, (byte)_turbineID, 4, (byte)'Y', (byte)'5', (byte)'0', (byte)'@' };

                try
                {
                    Transceive_RCS(_turbineID, data, "y5@", 28);

                    Extract_StateData(_turbineID, receiveBuffer[8], receiveBuffer[10]);

                    turbine.Active_Power_1s = (short)(receiveBuffer[11] * 256 + receiveBuffer[12]) / 10;
                    turbine.CosPhi = (float)(ushort)(receiveBuffer[13] * 256 + receiveBuffer[14]) / 100;
                    turbine.Frequency = (float)(ushort)(receiveBuffer[15] * 256 + receiveBuffer[16]) / 100;
                    turbine.Voltage_L1 = (ushort)(receiveBuffer[17] * 256 + receiveBuffer[18]) / 10;
                    turbine.Voltage_L2 = (ushort)(receiveBuffer[19] * 256 + receiveBuffer[20]) / 10;
                    turbine.Voltage_L3 = (ushort)(receiveBuffer[21] * 256 + receiveBuffer[22]) / 10;
                    turbine.Current_L1 = (ushort)(receiveBuffer[23] * 256 + receiveBuffer[24]) / 10;
                    turbine.Current_L2 = (ushort)(receiveBuffer[25] * 256 + receiveBuffer[26]) / 10;
                    turbine.Current_L3 = (ushort)(receiveBuffer[27] * 256 + receiveBuffer[28]) / 10;
                }
                catch (Exception ex)
                {
                    _Park.ParkComErrors++;
                    turbine.TurbineComErrors++;
                    ErrorLog.Add_WithTime(turbine.TurbineName + " - El data - " + ex.Message);
                    return;
                }
            }
        }

        public void Get_ReactivePowerSetpoint(int _turbineID)
        {
            Parameter_Info Value = new Parameter_Info();

            // read currently active reactive power setpoint value
            Value = Read_Parameter(_turbineID, 7, 21);

            turbine.ReactivePowerSetpoint = Value.Value;
        }

        private void Get_TemperatureData(int _turbineID)
        {
            lock (Program.myVestasController)
            {
                byte[] data = { 0xE5, 0xA7, 0xCD, 0, (byte)_turbineID, 4, (byte)'Y', (byte)'6', (byte)'0', (byte)'@' };

                try
                {
                    Transceive_RCS(_turbineID, data, "y6@", 44);

                    Extract_StateData(_turbineID, receiveBuffer[8], receiveBuffer[10]);

                    turbine.Temp_Hydraulic = (short)(receiveBuffer[17] * 256 + receiveBuffer[18]);
                    turbine.Temp_Environment = (short)(receiveBuffer[19] * 256 + receiveBuffer[20]);
                    turbine.Temp_Gear = (short)(receiveBuffer[21] * 256 + receiveBuffer[22]);
                    turbine.Temp_Generator = (short)(receiveBuffer[23] * 256 + receiveBuffer[24]);
                    turbine.Temp_SlipringVCS = (short)(receiveBuffer[25] * 256 + receiveBuffer[26]);
                    turbine.Temp_GearBearing = (short)(receiveBuffer[27] * 256 + receiveBuffer[28]);
                    turbine.Temp_HubController = (short)(receiveBuffer[29] * 256 + receiveBuffer[30]);
                    turbine.Temp_Nacelle = (short)(receiveBuffer[31] * 256 + receiveBuffer[32]);
                    turbine.Temp_TopController = (short)(receiveBuffer[35] * 256 + receiveBuffer[36]);
                    turbine.Temp_BusBar = (short)(receiveBuffer[37] * 256 + receiveBuffer[38]);
                    turbine.Temp_Spinner = (short)(receiveBuffer[39] * 256 + receiveBuffer[40]);
                    turbine.Temp_HVTransformerL1 = (short)(receiveBuffer[41] * 256 + receiveBuffer[42]);
                    turbine.Temp_HVTransformerL2 = (short)(receiveBuffer[43] * 256 + receiveBuffer[44]);
                    turbine.Temp_HVTransformerL3 = (short)(receiveBuffer[45] * 256 + receiveBuffer[46]);
                    turbine.Temp_GeneratorBearing = (short)(receiveBuffer[47] * 256 + receiveBuffer[48]);
                    turbine.Temp_CoolWaterVCS = (short)(receiveBuffer[49] * 256 + receiveBuffer[50]);
                }
                catch (Exception ex)
                {
                    _Park.ParkComErrors++;
                    turbine.TurbineComErrors++;
                    ErrorLog.Add_WithTime(turbine.TurbineName + " - Temperature data - " + ex.Message);
                    return;
                }
            }
        }

        private void Get_PowerSetpointData(int _turbineID)
        {
            lock (Program.myVestasController)
            {
                byte[] data = { 0xE5, 0xA7, 0xCD, 0, (byte)_turbineID, 2, (byte)'Y', (byte)'@' };

                try
                {
                    Transceive_RCS(_turbineID, data, "y@", 8);

                    //_Turbines[_turbineID].ActivePowerSetpoint = (short)(receiveBuffer[11] * 256 + receiveBuffer[12]);
                    //_Turbines[_turbineID].NominalPower = (short)(receiveBuffer[13] * 256 + receiveBuffer[14]);
                    turbine.ActivePowerRegulatorSetpoint = (short)(receiveBuffer[11] * 256 + receiveBuffer[12]);
                    turbine.ActivePowerSetpoint = (short)(receiveBuffer[13] * 256 + receiveBuffer[14]);
                }
                catch (Exception ex)
                {
                    _Park.ParkComErrors++;
                    turbine.TurbineComErrors++;
                    ErrorLog.Add_WithTime(turbine.TurbineName + " - Power setpoint data - " + ex.Message);
                    return;
                }
            }
        }

        private void Get_ProductionData(int _turbineID)
        {
            lock (Program.myVestasController)
            {
                byte[] data = { 0xE5, 0xA7, 0xCD, 0, (byte)_turbineID, 4, (byte)'Y', (byte)'2', (byte)'0', (byte)'@' };

                try
                {
                    Transceive_RCS(_turbineID, data, "y2@", 44);

                    Extract_StateData(_turbineID, receiveBuffer[8], receiveBuffer[10]);

                    turbine.Production = (int)((receiveBuffer[29] << 24) + (receiveBuffer[30] << 16)
                        + (receiveBuffer[31] << 8) + receiveBuffer[32]);
                    //_Turbines[_turbineID].Production = BitConverter.ToUInt32(receiveBuffer, 28);
                }
                catch (Exception ex)
                {
                    _Park.ParkComErrors++;
                    turbine.TurbineComErrors++;
                    ErrorLog.Add_WithTime(turbine.TurbineName + " - Production data - " + ex.Message);
                    return;
                }
            }
        }

        private void Get_VGMSOverviewData(int _turbineID)
        {
            lock (Program.myVestasController)
            {
                byte[] data = { 0xE5, 0xA7, 0xCD, 0, (byte)_turbineID, 4, (byte)'Y', (byte)'a', (byte)'0', (byte)'@' };

                try
                {
                    Transceive_RCS(_turbineID, data, "ya@", 34);

                    Extract_StateData(_turbineID, receiveBuffer[8], receiveBuffer[10]);

                    turbine.Reactive_Power = (int)(receiveBuffer[21] << 24) + (receiveBuffer[22] << 16) + (receiveBuffer[23] << 8) + receiveBuffer[24];
                }
                catch (Exception ex)
                {
                    _Park.ParkComErrors++;
                    turbine.TurbineComErrors++;
                    ErrorLog.Add_WithTime(turbine.TurbineName + " - VGMSOverview data - " + ex.Message);
                    return;
                }
            }
        }

        public List<Log_Record> Get_AlarmLog(int _turbineID)
        {
            lock (Program.myVestasController)
            {
                //byte[] _numOfLogs = BitConverter.GetBytes(numOfLogs);

                byte[] data = { 0xE5, 0xA7, 0xCD, 0, (byte)_turbineID, 4, (byte)'Y', (byte)'9', (byte)'0', 0 };//, _numOfLogs[0], _numOfLogs[1] };

                try
                {
                    int bytesReceived = 0;

                    bytesReceived = Transceive_RCS(_turbineID, data, "y90", 0);

                    Extract_StateData(_turbineID, receiveBuffer[8], receiveBuffer[10]);

                    // check how many log lines received from controller
                    int numOfLogsReceived = (bytesReceived - 13) / 10;
                    // check if numOfLogsReceived is correct number - 10 bytes for each log
                    if (!(((bytesReceived - 13) % numOfLogsReceived) == 10))
                    {
                        throw new Exception("Invalid number of logs received");
                    }

                    List<Log_Record> Alarm_Log = new List<Log_Record>();
                    Log_Record log_Line = new Log_Record();

                    for (int i = 0; i < numOfLogsReceived; i++)
                    {
                        log_Line.LogNumber = (ushort)(receiveBuffer[11 + i * 10] * 256 + receiveBuffer[12 + i * 10]);
                        log_Line.timeStamp_1 = (ushort)(receiveBuffer[13 + i * 10] * 256 + receiveBuffer[14 + i * 10]);
                        log_Line.timeStamp_2 = (ushort)(receiveBuffer[15 + i * 10] * 256 + receiveBuffer[16 + i * 10]);
                        log_Line.LogParameter1 = (short)(receiveBuffer[17 + i * 10] * 256 + receiveBuffer[18 + i * 10]);
                        log_Line.LogParameter2 = (short)(receiveBuffer[19 + i * 10] * 256 + receiveBuffer[20 + i * 10]);

                        Alarm_Log.Add(log_Line);
                    }

                    return Alarm_Log;
                }
                catch (Exception ex)
                {
                    _Park.ParkComErrors++;
                    turbine.TurbineComErrors++;
                    ErrorLog.Add_WithTime(turbine.TurbineName + " - Alarm Log - " + ex.Message);
                    throw new Exception(ex.Message);
                }
            }
        }

        #endregion DATAREQUEST_FUNCTIONS


        #region CONTROL_FUNCTIONS

        private void Send_Command(int _turbineID, char command)
        {
            lock (Program.myVestasController)
            {
                // use Overview request telegram to send command
                byte[] data = { 0xE5, 0xA7, 0xCD, 0, (byte)_turbineID, 4, (byte)'Y', (byte)'1', (byte)command, (byte)'@' };

                try
                {
                    Transceive_RCS(_turbineID, data, "y1@", 0);

                    Extract_StateData(_turbineID, receiveBuffer[8], receiveBuffer[10]);

                    // check result
                    if (turbine.CommandAccepted)
                    {
                        return;
                    }
                    else
                    {
                        throw new Exception("Command not accepted");
                    }
                }
                catch (Exception ex)
                {
                    _Park.ParkComErrors++;
                    turbine.TurbineComErrors++;
                    ErrorLog.Add_WithTime(turbine.TurbineName + " - Send Command - " + ex.Message);
                    return;
                }
            }
        }

        public void Start_Turbine(int _turbineID)
        {
            Send_Command(_turbineID, 'O');
        }

        public void Pause_Turbine(int _turbineID)
        {
            Send_Command(_turbineID, 'P');
        }

        public void Ack_Errors(int _turbineID)
        {
            Send_Command(_turbineID, 'N');
        }

        // PARAMETER 12.30 "Enable Remote Pwr Ctrl" MUST BE 0 for this command to work
        public void Set_ActivePowerSetpoint(int _turbineID, short setpoint)
        {
            lock (Program.myVestasController)
            {
                byte setpointH = (byte)(setpoint / 256);
                byte setpointL = (byte)(setpoint - setpointH * 256);
                byte[] data = { 0xE5, 0xA7, 0xCD, 0, (byte)_turbineID, 5, (byte)'Y', (byte)'=', (byte)'0', setpointH, setpointL };

                try
                {
                    Transceive_RCS(_turbineID, data, "y=", 5);

                    // Check result
                    if (receiveBuffer[11] == 1)
                    {
                        return;
                    }
                    else
                    {
                        throw new Exception("Failed to set power");
                    }
                }
                catch (Exception ex)
                {
                    _Park.ParkComErrors++;
                    turbine.TurbineComErrors++;
                    ErrorLog.Add_WithTime(turbine.TurbineName + " - Set power setpoint - " + ex.Message);
                    return;
                }
            }
        }

        // set power limit using parameter 4.71
        /*
        public void Set_ActivePowerSetpoint_1(int _turbineID, short setpoint)
        {
            Parameter_Info oldPowerLimit = new Parameter_Info();

            // read currently active power limit value in parameter 4.71
            oldPowerLimit = Read_Parameter(_turbineID, 4, 71);
            // set new power limit value
            Change_Parameter(_turbineID, 4, 71, oldPowerLimit.Value, setpoint);
        }
        */

        // set reactive power setpoint using parameter 7.21
        // when using this command - Ext. Reactive Power Ref. must be ENABLED in turbine (PARAMETER 7.23 MUST BE 1)
        public void Set_ReactivePowerSetpoint(int _turbineID, short setpoint)
        {
            Parameter_Info oldValue = new Parameter_Info();

            // read currently active reactive power setpoint value
            oldValue = Read_Parameter(_turbineID, 7, 21);
            // set new power limit value
            Change_Parameter(_turbineID, 7, 21, oldValue.Value, setpoint);
        }

        public void TestCommand_1(int _turbineID, char command, int setpoint)
        {
            lock (Program.myVestasController)
            {
                byte setpointH = (byte)(setpoint / 256);
                byte setpointL = (byte)(setpoint - setpointH * 256);
                byte[] data = { 0xE5, 0xA7, 0xCD, 0, (byte)_turbineID, 5, (byte)'Y', (byte)command, (byte)'0', setpointH, setpointL };

                try
                {
                    Transceive_RCS(_turbineID, data, "y=", 0);

                    // Check result
                    if (receiveBuffer[11] == 1)
                    {
                        return;
                    }
                    else
                    {
                        throw new Exception("Failed to set power");
                    }
                }
                catch (Exception ex)
                {
                    _Park.ParkComErrors++;
                    turbine.TurbineComErrors++;
                    ErrorLog.Add_WithTime(turbine.TurbineName + " - Set reactive power setpoint - " + ex.Message);
                    return;
                }
            }
        }

        public void Change_Parameter(int _turbineID, int Group, int Index, short oldValue, short newValue)
        {
            lock (Program.myVestasController)
            {
                byte GroupH = (byte)(Group / 256);
                byte GroupL = (byte)(Group - GroupH * 256);

                byte IndexH = (byte)(Index / 256);
                byte IndexL = (byte)(Index - IndexH * 256);

                byte[] oldValuebytes = BitConverter.GetBytes(oldValue);
                byte[] newValuebytes = BitConverter.GetBytes(newValue);

                byte[] data = { 0xE5, 0xA7, 0xCD, 0, (byte)_turbineID, 22, (byte)'Y', (byte)',', (byte)'0', (byte)'C', 
                              (byte)'2', (byte)'4', (byte)'6', 0, 0, 0, 0, 0, 0, 0, 
                              GroupL, GroupH, IndexL, IndexH, oldValuebytes[0], oldValuebytes[1], newValuebytes[0], newValuebytes[1] };

                try
                {
                    Transceive_RCS(_turbineID, data, "y,C", 11);

                    // check for result
                    if (receiveBuffer[15] != 0)
                    {
                        if (receiveBuffer[15] == 1)
                        {
                            throw new Exception("Illegal group or index");
                        }
                        else if (receiveBuffer[15] == 2)
                        {
                            throw new Exception("Wrong password");
                        }
                        else if (receiveBuffer[15] == 3)
                        {
                            throw new Exception("Wrong old parameter value");
                        }
                        else if (receiveBuffer[15] == 4)
                        {
                            throw new Exception("Parameter is read-only from remote");
                        }
                        else if (receiveBuffer[15] == 5)
                        {
                            throw new Exception("Illegal parameter value");
                        }
                        else
                        {
                            throw new Exception("Unknown error code received: " + receiveBuffer[15]);
                        }
                    }

                    return;
                }
                catch (Exception ex)
                {
                    _Park.ParkComErrors++;
                    turbine.TurbineComErrors++;
                    ErrorLog.Add_WithTime(turbine.TurbineName + " - Change parameter - " + ex.Message);
                    throw new Exception(ex.Message);
                }
            }
        }

        public Parameter_Info Read_Parameter(int _turbineID, int Group, int Index)
        {
            lock (Program.myVestasController)
            {
                byte GroupH = (byte)(Group / 256);
                byte GroupL = (byte)(Group - GroupH * 256);

                byte IndexH = (byte)(Index / 256);
                byte IndexL = (byte)(Index - IndexH * 256);

                byte[] data = { 0xE5, 0xA7, 0xCD, 0, (byte)_turbineID, 8, (byte)'Y', (byte)',', (byte)'0', (byte)'B',
                              GroupL, GroupH, IndexL, IndexH };

                try
                {
                    Transceive_RCS(_turbineID, data, "y,B", 41);

                    // check for result: Success or Illegal parameter group/index
                    if (receiveBuffer[15] != 0)
                    {
                        throw new Exception("Illegal group or index");
                    }

                    // Extracting received data
                    Parameter_Info ParamInfo = new Parameter_Info();
                    ParamInfo.Group = (ushort)(receiveBuffer[12] * 256 + receiveBuffer[11]);
                    ParamInfo.Index = (ushort)(receiveBuffer[14] * 256 + receiveBuffer[13]);
                    ParamInfo.Value = BitConverter.ToInt16(receiveBuffer, 16);
                    char[] text = new char[30];
                    for (int i = 0; i < 30; i++)
                    {
                        text[i] = (char)receiveBuffer[18 + i];
                    }
                    ParamInfo.Text = new string(text);

                    return ParamInfo;
                }
                catch (Exception ex)
                {
                    _Park.ParkComErrors++;
                    turbine.TurbineComErrors++;
                    ErrorLog.Add_WithTime(turbine.TurbineName + " - Read parameter - " + ex.Message);
                    throw new Exception(ex.Message);
                }
            }
        }

        #endregion CONTROL_FUNCTIONS


        #region TEXT_FUNCTIONS

        public string Get_State_Txt(int Code)
        {
            switch (Code)
            {
                case 0:
                    return "Normal";

                case 1:
                    return "Wind direction check";

                case 2:
                    return "Outyawing active";

                case 3:
                    return "Countdown for autostart";

                case 4:
                    return "Error";

                case 5:
                    return "Error (watchdog)";

                case 6:
                    return "Low wind";

                case 7:
                    return "Heating slipring";

                case 8:
                    return "Low temp hydraulic oil";

                case 9:
                    return "Block heating";

                case 10:
                    return "Low gear oil or Nacelle temperature";

                case 11:
                    return "Mechanical gear heat on";

                case 12:
                    return "VAMS Connection request";

                default:
                    return "Unknown state";
            }
        }

        public string Get_OperationState_Txt(int Code)
        {
            switch (Code)
            {
                case 0:
                    return "Emergency";

                case 1:
                    return "Stop";

                case 2:
                    return "Pause";

                case 3:
                    return "Run";

                default:
                    return "Unknown state";
            }
        }

        public string Get_YawState_Txt(int Code)
        {
            switch (Code)
            {
                case 0:
                    return "Not active";

                case 1:
                    return "Manual yaw";

                case 2:
                    return "Outyawing";

                case 3:
                    return "Auto yaw";

                default:
                    return "Unknown state";
            }
        }

        public string Get_ErrorStatus_Txt(int Code)
        {
            switch (Code)
            {
                case 0: return "No error";
                case 1: return "Illegal InitVal data in PROM";
                case 2: return "Conflict: Rack/Turbinetype";
                case 3: return "Hub CT____ missing (pos.__)";
                case 4: return "Top CT____ missing (pos.__)";
                case 5: return "Wrong ARCNet node no.";
                case 6: return "Serial communication not init.";
                case 7: return "CT3218 initialization error";
                case 8: return "CT3220 initial. error pos.__";
                case 9: return "Initialisation of ArcNet";
                case 10: return "CT3232 initialization error";
                case 11: return "Unexpected interrupt";
                case 12: return "Too many digital filters";
                case 13: return "Too many sublogics";
                case 14: return "Too many DecOpState routines";
                case 15: return "Too many IncOpState routines";
                case 16: return "Too many WriteProlog routines";
                case 17: return "Too many interval timers";
                case 18: return "Too many sec timers";
                case 19: return "Too many msec timers";
                case 20: return "Too many event timers";
                case 21: return "Interval timer not initialized";
                case 22: return "Sec timer not initialized";
                case 23: return "mSec timer not initialized";
                case 24: return "Event timer not initialized";
                case 25: return "Error Parameter Checksum";
                case 26: return "Illegal parameter group";
                case 27: return "Run Auto long Turbine Illegal text no.:______,__";
                case 28: return "Illegal picture no.";
                case 29: return "Too many square filters";
                case 30: return "Internal sublogic error";
                case 31: return "OpSt change: Run -> Run";
                case 32: return "Out of ArcNet xmit pools";
                case 33: return "TelegramRcv resource too small";
                case 34: return "Bad telegram xmit format";
                case 35: return "Bad ArcNet sub address";
                case 36: return "No communication with Top";
                case 37: return "No communication with VCPM";
                case 38: return "No comm. with Hub";
                case 39: return "Too many log slaves";
                case 40: return "SW versionconflict GND/HUB";
                case 41: return "Telegram not sent";
                case 42: return "Aviation light error";
                case 43: return "Ground:ServiceHandler called";
                case 44: return "SW versionconflict GND/TOP";
                case 45: return "SW versionconflict GND/VCPM";
                case 46: return "CT____ illegal version __.__";
                case 47: return "CT 3218 data error _,__";
                case 48: return "Too many ArcNet retransmiss.";
                case 49: return "Too many ArcNet reconf._____";
                case 50: return "No communication with CT3251";
                case 51: return "Feedback table full";
                case 52: return "ZeroCross interrupt missing _";
                case 53: return "Error in CT3232";
                case 54: return "VDI telegram xmit error";
                case 55: return "Telegram lost during reception";
                case 56: return "Telegram lost during xmission";
                case 57: return "ArcNet reconfiguration";
                case 58: return "Time constant (thau) is zero";
                case 59: return "Top fan__, Temp:___°C";
                case 60: return "VDI telegram format error";
                case 61: return "Illegal VDI subscription";
                case 62: return "Ground status report timeout";
                case 63: return "Power telegraph timeout";
                case 64: return "VCPMstate queue overflow";
                case 65: return "Unused Opcode";
                case 66: return "Hub fan__, Temp:___°C";
                case 67: return "Gen. ext. vent. _, temp:___°C";
                case 68: return "HV Trafo. vent. _, temp:___°C";
                case 69: return "Gen. int. vent. _, temp:___°C";
                case 70: return "Nacelle position reset: ___._°";
                case 71: return "Feedback=_, Int.Gen.Fan S___A";
                case 72: return "Feedback=_, Int.Gen.Fan S___B";
                case 73: return "Feedback=_, Ext.Gen.Fan S____";
                case 74: return "PitchA pos:__._° vel:___._°/s";
                case 75: return "PitchB pos:__._° vel:___._°/s";
                case 76: return "PitchC pos:__._° vel:___._°/s";
                case 77: return "Low processor temp. in Nacelle";
                case 78: return "Low processor temp. in Hub";
                case 79: return "Max. Yaw error: ___._°";
                case 80: return "Low gear oil pressure";
                case 81: return "Pitch B ref:__._°, Act.:__._°";
                case 82: return "Pitch C ref:__._°, Act.:__._°";
                case 83: return "B Ctrl:___.__V P.Vel:___._°/s";
                case 84: return "C Ctrl:___.__V P.Vel:___._°/s";
                case 85: return "B CtrlV.STD _.___V MEAN__.___V";
                case 86: return "C CtrlV.STD _.___V MEAN__.___V";
                case 87: return "Pitch dev. min:__._° max:__._°";
                case 88: return "Hydr. temperature low: ___°C";
                case 89: return "Trip F60 L_: ___ °C";
                case 90: return "System error (1)";
                case 91: return "System error (2)";
                case 92: return "System error (3)";
                case 93: return "Low supply voltage CT3503";
                case 94: return "Frequency reg: __.__Hz _____kW";
                case 95: return "Com.err: Address ____:____";
                case 96: return "Crash no. 0";
                case 97: return "Gnd.err. Address______:______";
                case 98: return "Top.err. Address______:______";
                case 99: return "VCPM.err. Address______:______";
                case 100: return "Too many auto-restarts:_____";
                case 101: return "Emerg.-> Stop, EMC not conn.";
                case 102: return "Emergency circuit open";
                case 103: return "PhaseSequence error";
                case 104: return "Phasesequence not measured";
                case 105: return "Phase sequence check timed out";
                case 106: return "Top OpSt.change timeout (_)";
                case 107: return "VCPM OpSt.change timeout (_)";
                case 108: return "Illegal gen.cmd.: _ in state _";
                case 109: return "Thermistor fail oil conditio.";
                case 110: return "Pressure fail oil condition.";
                case 111: return "Max runtime without oilcondi.";
                case 112: return "Oil filter error";
                case 113: return "Error Smoke Detector";
                case 114: return "Generator _ in";
                case 115: return "Generator _ out";
                case 116: return "Emerg. --> Stop, Output active";
                case 117: return "Anemom.error:__._m/s,____._RPM";
                case 118: return "Anemom.error:__._m/s,____._kW";
                case 119: return "Extrem frequency: ___.__ Hz";
                case 120: return "Low curr.L1:____A,Others:____A";
                case 121: return "Low curr.L2:____A,Others:____A";
                case 122: return "Low curr.L3:____A,Others:____A";
                case 123: return "High curr Gen0 L_: ____ A";
                case 124: return "Extr.high curr.Gen1 L_: ____ A";
                case 125: return "Extr.high curr.Gen2 L_: ____ A";
                case 126: return "Extr. high volt. L_: ___ V";
                case 127: return "Extr. low voltage L_: ___V";
                case 128: return "Trip Q8 L_: ___ V";
                case 129: return "Frequency error: ___.__ Hz";
                case 130: return "Max power Gen_: ____._ kW";
                case 131: return "Negative power Gen_: ____._ kW";
                case 132: return "Leak current ____A";
                case 133: return "Power: ____._ kW, OpSt<Run";
                case 134: return "High voltage L_: ___ V";
                case 135: return "Low voltage L_: ___ V";
                case 136: return "Asym.currL1:____A,Others:____A";
                case 137: return "Asym.currL2:____A,Others:____A";
                case 138: return "Asym.currL3:____A,Others:____A";
                case 139: return "Asym.voltL1:____V,Others:____V";
                case 140: return "Asym.voltL2:____V,Others:____V";
                case 141: return "Asym.voltL3:____V,Others:____V";
                case 142: return "High curr Gen1 L_: ____ A";
                case 143: return "High curr Gen2 L_: ____ A";
                case 144: return "Ambient High windspeed: __._ m/s";
                case 145: return "Low processor temp. in top";
                case 146: return "Ambient Ambient temperature low: ___°C";
                case 147: return "High gear temperature:____°C";
                case 148: return "High temperature Gen_: ___°C";
                case 149: return "High temperature T53: ___°C L_";
                case 150: return "High temp.Gear bearing _:___°C";
                case 151: return "High temp. Gen bearing _:___°C";
                case 152: return "Emerg. --> Stop,Rot:___._ RPM";
                case 153: return "Turbine Max generator RPM: ____._ RPM";
                case 154: return "Max rotor RPM: __._ RPM";
                case 155: return "High Gen.SlipRTemp:___°C ____A";
                case 156: return "Chock sensor trigged:____._RPM";
                case 157: return "Gen.RPM: ____._ RPM, OpSt<Run";
                case 158: return "Rotor:__._RPM, Gen.:____._ RPM";
                case 159: return "External RPM guard, ____ RPM";
                case 160: return "High temperature brake disc";
                case 161: return "Max time hydr. pumping:___ sec";
                case 162: return "Safety-pressostat brake";
                case 163: return "Low workingpressure: ___._ bar";
                case 164: return "Press.drop hydr. filter ___°C";
                case 165: return "Low oil-level, hydraulic";
                case 166: return "Thermoerror hydraulicmotor";
                case 167: return "Hydr. temperature high: ___°C";
                case 168: return "High temp top ctrl.: ___°C";
                case 169: return "Thermoerror nacelle fan F___";
                case 170: return "Thermoerr. gearoil cooler F___";
                case 171: return "Max no of pitchconnect cmd";
                case 172: return "Feedback=_, Nacelle fan S___";
                case 173: return "Feedback=_, Gearoil cool S___";
                case 174: return "Feedback = _,:Hydraulicmotor";
                case 175: return "High temp. bus bar section";
                case 176: return "Error on all wind sensors";
                case 177: return "Low processor temp. in ground";
                case 178: return "Def. fuse,lightn. prot.(F9-11)";
                case 179: return "Error, yawcontrol: _____ (_)";
                case 180: return "No yawpulses _____, ____ s";
                case 181: return "Feedback = _, yawing CW _";
                case 182: return "Feedback = _, yawing CCW _";
                case 183: return "Max autoyawtime ____ sec.";
                case 184: return "Max outyawtime superceeded";
                case 185: return "Outyawing too much, S___ activ";
                case 186: return "Thermoerror yawmotor F___";
                case 187: return "External 24 V power supply";
                case 188: return "External 24 V power supply eq.";
                case 189: return "Feedback = _, Brake";
                case 190: return "Pitch A ref:__._°, Act.:__._°";
                case 191: return "A Ctrl:___.__V P.Vel:___._°/s";
                case 192: return "A CtrlV.STD _.___V MEAN__.___V";
                case 193: return "PowerSTD____._kW MEAN____._kW";
                case 194: return "Pitch too low: __._° < __._°";
                case 195: return "PowerError ____._ kW";
                case 196: return "Max generator RPM: ____._ RPM";
                case 197: return "Yaw activity not detected";
                case 198: return "Yaw position is changed";
                case 199: return "Thermo table full";
                case 200: return "Yaw speed error ___._° in __ s";
                case 201: return "Low temperature Gen_:___°C";
                case 202: return "Frequency error 1: ___.__ Hz";
                case 203: return "Frequency error 2: ___.__ Hz";
                case 204: return "Frequency error 3: ___.__ Hz";
                case 205: return "Frequency error 4: ___.__ Hz";
                case 206: return "Feedback=_, Hydroilcool S___";
                case 209: return "Missing VAMS permission _";
                case 210: return "Low gear temp: _, ___°C";
                case 211: return "Gear oil quality";
                case 212: return "Error temp.sensor R___, ____°C";
                case 213: return "Error temp.sensor R___ blade _";
                case 214: return "Low gear oil level";
                case 215: return "Press.drop hydr.filt.Hub ___°C";
                case 216: return "Oil leakage in Hub";
                case 217: return "Thermoerror Int.Gen.Fan F___A";
                case 218: return "Thermoerror Int.Gen.Fan F___B";
                case 219: return "Thermoerror Ext.Gen.Fan F____";
                case 220: return "New SERVICE state: _, ____";
                case 221: return "ERROR:";
                case 222: return "Emergency";
                case 223: return "Stop";
                case 224: return "Pause";
                case 225: return "Run";
                case 226: return "Power cutout";
                case 227: return "Power cutin";
                case 228: return "SysState _.___ set to ______";
                case 229: return "Parameter __.___ set to ______";
                case 230: return "Auto-restart after ____ sec";
                case 231: return "Restart not possible";
                case 232: return "Power up after System error";
                case 233: return "WATCHDOG trigging disabled";
                case 234: return "Miss. error ack.before restart";
                case 235: return "Error ___ ackd. over RCS";
                case 236: return "Error ___ acknowledged manual.";
                case 237: return "WATCHDOG was not trigged";
                case 238: return "Busbarvent._, Power: ____._kW";
                case 239: return "Lightning blade _: ___ kA";
                case 240: return "Lightning blade _: ___ kA";
                case 241: return "GPS reciever out of order";
                case 242: return "Light. det. error ___ ___";
                case 243: return "Hot generator ___°C ______kW";
                case 244: return "Hot gear___°C ______kW";
                case 245: return "Hot HV trafo ___°C ______kW";
                case 246: return "High voltage ___V ______kW";
                case 247: return "Wind:__._m/s derate to:_____kW";
                case 248: return "User power setpoint _____kW";
                case 249: return "Too many warnings in queue _";
                case 250: return "No space in warning log";
                case 251: return "Alarm low oil lubrication flow";
                case 252: return "Warn. low oil lubrication flow";
                case 253: return "Alarm diff. press rough filter";
                case 254: return "Warn. diff. press rough filter";
                case 255: return "Manual, signal:___,chg.:_";
                case 256: return "Stop Auto long Ambient Too low nacel temp ____°C";
                case 257: return "Start hydr. motor, ___._ bar";
                case 258: return "Stop hydr. motor, ___._ bar";
                case 259: return "SW versionconflict GND/GRID";
                case 260: return "Log reset by user";
                case 261: return "Alarmlog reset by user";
                case 262: return "GndSystemState reset by user";
                case 263: return "TopSystemState reset by user";
                case 264: return "VCPMSystemState reset by user";
                case 265: return "Wind:___._ m/s Gen:____._ RPM";
                case 266: return "Pitch: __._° Power: ____._ kW";
                case 267: return "ComSystemState reset by user";
                case 268: return "Pitchtest nr. __ param.:______";
                case 269: return "Pitchtest nr. __";
                case 270: return "Nac.vent.0, nac/gear:___/___°C";
                case 271: return "Nac.vent.1, nac/gear:___/___°C";
                case 272: return "Nac.vent.2, nac/gear:___/___°C";
                case 273: return "E.Wind:__._m/s Nac.Dir:____._°";
                case 274: return "Nac.vent.3, nac/gear:___/___°C";
                case 275: return "Start auto-outyawing CW";
                case 276: return "Start auto-outyawing CCW";
                case 277: return "Start autoyawing CW";
                case 278: return "Start autoyawing CCW";
                case 279: return "Stop autoyawing";
                case 280: return "Yawcontr. from:_____ to:_____";
                case 281: return "Start manual yawing CCW";
                case 282: return "Yawing manually stopped";
                case 283: return "Start manual yawing CW";
                case 284: return "Stop auto-outyawing";
                case 285: return "Stop yawing at twiststop(S104)";
                case 286: return "Alarm diff. press fine filter";
                case 287: return "Warn. diff. press fine filter";
                case 288: return "Standby heating _, gen: ___°C";
                case 289: return "Gearoilheater _, gear: ___°C";
                case 290: return "VDF data lost. Code_____,_____";
                case 291: return "CT3251 OpSt.change timeout (_)";
                case 292: return "GearoilCooler _, gear: ___°C";
                case 293: return "Frequency controller started";
                case 294: return "Frequency controller stopped";
                case 295: return "VMP halted: Program upload";
                case 296: return "Tow. acc. X, Alarm:__.__ m/s^2";
                case 297: return "Tow. acc. Y, Alarm:__.__ m/s^2";
                case 298: return "Tow. acc. X, Warn.:__.__ m/s^2";
                case 299: return "Tow. acc. Y, Warn.:__.__ m/s^2";
                case 300: return "Aviation Lamp error";
                case 301: return "Aviation Lamp shift";
                case 302: return "Thermo error, hydr. oilcooler";
                case 303: return "Marine Lamp error";
                case 304: return "Marine Lamp shift";
                case 305: return "Timeout comm. Tower acc.";
                case 306: return "Operation log reestablished";
                case 307: return "Alarm log reestablished";
                case 308: return "System log reestablished";
                case 309: return "Pause over RCS";
                case 310: return "Run over RCS";
                case 311: return "Trip Q8 Feedback error";
                case 312: return "Thermo error, ventilators T53";
                case 313: return "Ambient Ambient temperature high: __°C";
                case 314: return "Trip Q8 high current L_ ____ A";
                case 315: return "ExEx low voltage L_: ___V";
                case 316: return "Cont.=___ Feedback s.failed: _";
                case 317: return "Cont.=___ Feedback r.failed: _";
                case 318: return "Can not syncronize ____ RPM";
                case 319: return "Long DC charge time ___s ____V";
                case 320: return "High temp. Rotor Inv.L_:___°C";
                case 321: return "Ext. high temp. RInv.L_:___°C";
                case 322: return "High temp. Grid Inv.L_:___°C";
                case 323: return "Ext. high temp. GInv.L_:___°C";
                case 324: return "High temp. VCP Board ___°C";
                case 325: return "High temp. VCS System ___°C";
                case 326: return "High temp. Aux. ___°C";
                case 327: return "Grid inv. HW error L_";
                case 328: return "Rotor inv. HW error L_";
                case 329: return "DC Overvoltage: ____V";
                case 330: return "Ext. high DC voltage ____V";
                case 331: return "DC Undervoltage: ____V";
                case 332: return "Ext. low DC voltage ____V";
                case 333: return "High cur.rotor inv. L_:____A";
                case 334: return "High cur.grid inv. L_:____A";
                case 335: return "ExtHighIRotorInv phase: _";
                case 336: return "Ext. High cur. Grid inv. L_";
                case 337: return "Overtemp charging DC, ____V";
                case 338: return "Slip:____ above limits _";
                case 339: return "Phase L:_ failure";
                case 340: return "OVP active _____V";
                case 341: return "OVPHwErr";
                case 342: return "Encoder hardware error";
                case 343: return "Encoder signal error _:_____";
                case 344: return "MDSP to VCPM Comm. timeout";
                case 345: return "VCPM to MDSP Comm. timeout";
                case 346: return "DSP _ checksum err.";
                case 347: return "DSP _mat. overflow";
                case 348: return "DSP _internal error ____";
                case 349: return "Error in Cal Val on VCPM";
                case 350: return "PFC breaker open";
                case 351: return "VCS Low water level";
                case 352: return "Q7 breaker open";
                case 353: return "Q8 breaker open";
                case 354: return "Par. __.___ set to ______ rem.";
                case 355: return "WS1 Dir Frozen __._m/s ___._ø";
                case 356: return "Ambient Extreme winddir __._m/s __._ø";
                case 357: return "Lightning detected";
                case 358: return "Lightn. detect. power supplied";
                case 359: return "Lightn. det. emergency suppl.";
                case 360: return "Warning log reestablished";
                case 361: return "Pending warning in log";
                case 362: return "De-Ice System overtemp _-_";
                case 363: return "De-Ice System timeout";
                case 364: return "De-Ice curr.dev. _, ____A";
                case 365: return "De-Ice feedback=0 _-_";
                case 366: return "De-Ice feedback=1 _-_";
                case 367: return "De-Ice temp. feedback _-_";
                case 368: return "Ice sensor error";
                case 369: return "De-ice event: System ON";
                case 370: return "De-ice event: System OFF";
                case 371: return "De-ice event: Ice detected";
                case 372: return "De-ice event: Mass unbalance";
                case 373: return "De-ice event: Power loss";
                case 374: return "De-ice event: Ice climate";
                case 375: return "Ice safety stop";
                case 376: return "Lightning detected (stopped)";
                case 377: return "Error on US, change to 0/90°";
                case 378: return "De-Ice: Feedback = _, K1064";
                case 379: return "No comm. with DeIce";
                case 380: return "WS1 invalid data: _";
                case 381: return "WS1 timeout err.";
                case 382: return "SlipR ext. fan__, Temp:___°C";
                case 383: return "Gen SlipR. Fan: __, Temp:___°C";
                case 384: return "Thermo error Gen.Slip Ring Fan";
                case 385: return "Feedback = _,:SlipR fan S____";
                case 386: return "Feedback = _,:VCS fan S____";
                case 387: return "VCS water pump ON";
                case 388: return "VCS water pump OFF";
                case 389: return "IGBT pump ON Top:___ Wa:___";
                case 390: return "IGBT pump OFF Top:___ Wa:___";
                case 391: return "VCS int.fan ON Nac:___ Wa:___";
                case 392: return "VCS int.fan OFF Nac:___ Wa:___";
                case 393: return "VCS external vent. ON";
                case 394: return "VCS external vent. OFF";
                case 395: return "IGBT fan ON Nac:___ Am:___";
                case 396: return "IGBT fan OFF Nac:___ Am:___";
                case 397: return "Thermoerror Int. VCS Fan F____";
                case 398: return "Thermoerror ext. VCS Fan F____";
                case 399: return "Thermoerror IGBT pump F___";
                case 400: return "Thermoerror IGBT fan F____";
                case 401: return "Smoke detected";
                case 402: return "NRMS sector __, wind: __._m/s";
                case 403: return "RCS disconnected due to ___";
                case 404: return "RCS reconnected";
                case 405: return "Gen SlipR. Heat: __, t:____°C";
                case 406: return "Low temp. slipring: ___°C";
                case 407: return "Low delta temp. slipr: ___°C";
                case 408: return "User defined alarm 1";
                case 409: return "User defined alarm 2";
                case 410: return "CT3234 init error P__ S___";
                case 411: return "Feedback = _, SlipR heat S___";
                case 412: return "WS2 invalid data: _";
                case 413: return "WS2 timeout err.";
                case 414: return "EMCValv. Pitch A vel.:__._°/s";
                case 415: return "EMCValv. Pitch B vel.:__._°/s";
                case 416: return "EMCValv. Pitch C ver.:__._°/s";
                case 417: return "EMCV. Pitch min:__._°max:__._°";
                case 418: return "Timeout generator reconnecting";
                case 419: return "VDI Transmit resource Low";
                case 420: return "High hydr. pressure ___._ bar";
                case 421: return "Yaw Curve Error point _._=_._";
                case 422: return "Too low nacelle temp. ___°C";
                case 423: return "Blocking run, nacelle ___°C";
                case 424: return "CT3223 init error";
                case 425: return "Event __ in ConvCtrl state __";
                case 426: return "Event __ in KxxCtrl state __";
                case 427: return "Event __ in StDlCtrl state __";
                case 428: return "Event __ in ConvCtrl state __";
                case 429: return "Max warnings gen-_ reconnects";
                case 430: return "Transm. osc. ____ RPM, __ m/s";
                case 431: return "MDSP-SDSP Comm. timeout";
                case 432: return "Wrong LSI Version: _____";
                case 433: return "Noise setting changed to: _";
                case 434: return "Warninglog reset by user";
                case 435: return "Start yawing to reset CW";
                case 436: return "Start yawing to reset CCW";
                case 437: return "Hot bearing ___°C ______kW";
                case 438: return "Hot top ctrl. ___°C ______kW";
                case 439: return "Hot IGBTs ___°C ______kW";
                case 440: return "Hot VRCC water ___°C ______kW";
                case 441: return "Derated at __°C ambi by __";
                case 442: return "Remote power setpoint _____kW";
                case 478: return "VCMS: Net error";
                case 479: return "VCMS:Node___ Initialize error";
                case 480: return "VCMS:Node___ Comm. error";
                case 481: return "VCMS:Node___ Selftest error";
                case 482: return "VCMS:Node___ Acc. Low level";
                case 483: return "VCMS:Node___ Ping error";
                case 484: return "VCMS:Node___ Warn. :Temp=___°C";
                case 485: return "VCMS:Node___ Alarm :Temp=___°C";
                case 486: return "VCMS:SEW11 V=_____um/s, ____kW";
                case 487: return "VCMS:SEW11 A=_____mm/s2,____kW";
                case 488: return "VCMS:SEA11 V=_____um/s, ____kW";
                case 489: return "VCMS:SEA11 A=_____mm/s2,____kW";
                case 490: return "VCMS:FEW11 V=_____um/s, ____kW";
                case 491: return "VCMS:FEW11 A=_____mm/s2,____kW";
                case 492: return "VCMS:FEA11 V=_____um/s, ____kW";
                case 493: return "VCMS:FEA11 A=_____mm/s2,____kW";
                case 494: return "VCMS:AMA11 A=_____mm/s2,____kW";
                case 495: return "VCMS:SEW12 V=_____um/s, ____kW";
                case 496: return "VCMS:SEW12 A=_____mm/s2,____kW";
                case 497: return "VCMS:SEA12 V=_____um/s, ____kW";
                case 498: return "VCMS:SEA12 A=_____mm/s2,____kW";
                case 499: return "VCMS:FEW12 V=_____um/s, ____kW";
                case 500: return "VCMS:FEW12 A=_____mm/s2,____kW";
                case 501: return "VCMS:FEA12 V=_____um/s, ____kW";
                case 502: return "VCMS:FEA12 A=_____mm/s2,____kW";
                case 503: return "VCMS:AMA12 A=_____mm/s2,____kW";
                case 504: return "VCMS:SEW13 V=_____um/s, ____kW";
                case 505: return "VCMS:SEW13 A=_____mm/s2,____kW";
                case 506: return "VCMS:SEA13 V=_____um/s, ____kW";
                case 507: return "VCMS:SEA13 A=_____mm/s2,____kW";
                case 508: return "VCMS:FEW13 V=_____um/s, ____kW";
                case 509: return "VCMS:FEW13 A=_____mm/s2,____kW";
                case 510: return "VCMS:FEA13 V=_____um/s, ____kW";
                case 511: return "VCMS:FEA13 A=_____mm/s2,____kW";
                case 512: return "VCMS:AMA13 A=_____mm/s2,____kW";
                case 513: return "VCMS:SEW14 V=_____um/s, ____kW";
                case 514: return "VCMS:SEW14 A=_____mm/s2,____kW";
                case 515: return "VCMS:SEA14 V=_____um/s, ____kW";
                case 516: return "VCMS:SEA14 A=_____mm/s2,____kW";
                case 517: return "VCMS:FEW14 V=_____um/s, ____kW";
                case 518: return "VCMS:FEW14 A=_____mm/s2,____kW";
                case 519: return "VCMS:FEA14 V=_____um/s, ____kW";
                case 520: return "VCMS:FEA14 A=_____mm/s2,____kW";
                case 521: return "VCMS:AMA14 A=_____mm/s2,____kW";
                case 522: return "VCMS:SEW15 V=_____um/s, ____kW";
                case 523: return "VCMS:SEW15 A=_____mm/s2,____kW";
                case 524: return "VCMS:SEA15 V=_____um/s, ____kW";
                case 525: return "VCMS:SEA15 A=_____mm/s2,____kW";
                case 526: return "VCMS:FEW15 V=_____um/s, ____kW";
                case 527: return "VCMS:FEW15 A=_____mm/s2,____kW";
                case 528: return "VCMS:FEA15 V=_____um/s, ____kW";
                case 529: return "VCMS:FEA15 A=_____mm/s2,____kW";
                case 530: return "VCMS:AMA15 A=_____mm/s2,____kW";
                case 531: return "VCMS:SEW31 V=_____um/s, ____kW";
                case 532: return "VCMS:SEW31 A=_____mm/s2,____kW";
                case 533: return "VCMS:SEA31 V=_____um/s, ____kW";
                case 534: return "VCMS:SEA31 A=_____mm/s2,____kW";
                case 535: return "VCMS:FEW31 V=_____um/s, ____kW";
                case 536: return "VCMS:FEW31 A=_____mm/s2,____kW";
                case 537: return "VCMS:FEA31 V=_____um/s, ____kW";
                case 538: return "VCMS:FEA31 A=_____mm/s2,____kW";
                case 539: return "VCMS:AMA31 V=_____um/s, ____kW";
                case 540: return "VCMS:SEW32 V=_____um/s, ____kW";
                case 541: return "VCMS:SEW32 A=_____mm/s2,____kW";
                case 542: return "VCMS:SEA32 V=_____um/s, ____kW";
                case 543: return "VCMS:SEA32 A=_____mm/s2,____kW";
                case 544: return "VCMS:FEW32 V=_____um/s, ____kW";
                case 545: return "VCMS:FEW32 A=_____mm/s2,____kW";
                case 546: return "VCMS:FEA32 V=_____um/s, ____kW";
                case 547: return "VCMS:FEA32 A=_____mm/s2,____kW";
                case 548: return "VCMS:AMA32 V=_____um/s, ____kW";
                case 549: return "VCMS:Element warn. bearing #__";
                case 550: return "VCMS:Element alarm bearing #__";
                case 551: return "VCMS:Undefined error code";
                case 552: return "VCMS:Unknown Command received";
                case 553: return "VCMS:Error in INI file";
                case 554: return "VCMS:Timer is inactive";
                case 560: return "VCMS:File open error";
                case 561: return "Memory allocation failed";
                case 562: return "SW versionconflict GND/VCMS";
                case 563: return "No communication with VCMS";
                case 564: return "Shortcircuitindicator1 Active";
                case 565: return "Shortcircuitindicator2 Active";
                case 566: return "SF6 Pressure low";
                case 567: return "Close Gridbreaker 1";
                case 568: return "Gridbreaker 1 closed";
                case 569: return "Open Gridbreaker 1";
                case 570: return "Gridbreaker 1 open";
                case 571: return "Gridbreaker 1 grounded";
                case 572: return "Close Gridbreaker 2";
                case 573: return "Gridbreaker 2 closed";
                case 574: return "Open Gridbreaker 2";
                case 575: return "Gridbreaker 2 open";
                case 576: return "Gridbreaker 2 grounded";
                case 577: return "Current Limiter Feedback error";
                case 578: return "CL.active ____ms ____kJ/ê";
                case 579: return "CL.time exceeded____ms____kJ/ê";
                case 580: return "Current Limiter Voltage inval.";
                case 581: return "Current Limiter temp. high R";
                case 582: return "Current Limiter Run Error";
                case 583: return "Current Limiter Timeout";
                case 584: return "CL Capacitor under voltage";
                case 585: return "Q7 Close via RCS";
                case 586: return "Q8 Close via RCS";
                case 587: return "Q16 Close via RCS";
                case 588: return "User ____ primary access";
                case 589: return "Obsolete";
                case 590: return "Obsolete";
                case 591: return "User ____ Access denied";
                case 592: return "New global account";
                case 593: return "New local account";
                case 594: return "Hoist mode failure";
                case 595: return "Help button activated";
                case 596: return "Hoist mode active";
                case 597: return "Reverse Yaw";
                case 598: return "Circuit breaker open";
                case 599: return "Error in UPS";
                case 600: return "UPS battery activated";
                case 601: return "Wind estimate dev. __._m/s";
                case 602: return "Error in ColdBoot file";
                case 603: return "3218.bin File missing";
                case 604: return "Remote Reboot";
                case 605: return "Brush on gen.slip ring is worn";
                case 606: return "Item_____ Updated by user_____";
                case 607: return "Control of LT blocked";
                case 608: return "STOP through RCS";
                case 609: return "Auto Yaw blocked";
                case 610: return "Error Slip Ring Fan Diff:___°C";
                case 611: return "External error : __, ___";
                case 614: return "Contactor switching, max";
                case 615: return "Err_____ Rem. Ack by user_____";
                case 616: return "Bypass miss. before phasecomp_";
                case 617: return "Feedback = _, Phasecomp__";
                case 618: return "Fuse phasecomp + Gen2 cut";
                case 619: return "Logic error phase compensation";
                case 620: return "Phasecomp.:__ in";
                case 621: return "Phasecomp.:__ out";
                case 622: return "Phasecomp temp.disconn.:____ V";
                case 623: return "Awaiting delay in phasecomp:_";
                case 624: return "PComp. dis. avr____ step ____V";
                case 625: return "Command to VCMS failed";
                case 626: return "RCC CRC error";
                case 627: return "RCC Timeout";
                case 628: return "CRC/Timeout error to RCC";
                case 629: return "RCC status error:______";
                case 630: return "RCC header error";
                case 631: return "RCC IVCE error _";
                case 632: return "RCC ILIM error _";
                case 633: return "RCC temperature error _";
                case 634: return "RCC voltage error ___";
                case 635: return "RCC RAM error";
                case 636: return "RCC communication error";
                case 637: return "RCC error in master prom _";
                case 638: return "RCC NAK during upload.";
                case 639: return "RCC NAK start appl._____,_____";
                case 640: return "Unknown RCC log message ___";
                case 641: return "RCC upload _. Result: _";
                case 642: return "RCC CE overvoltage: ____ V";
                case 643: return "RCC OVP active: ____ V";
                case 644: return "RCC high temperature _";
                case 645: return "RCC low temperature _";
                case 646: return "RCC high voltage ___";
                case 647: return "RCC low voltage ___";
                case 648: return "Illegal RCCState";
                case 649: return "VRCC.bin File missing";
                case 650: return "No satelites tracked";
                case 651: return "One satelite tracked";
                case 652: return "Current Limiter temp. high Thy";
                case 653: return "CL VMP Timeout";
                case 654: return "VCMS:theApp is suspended";
                case 655: return "FeedBack = _, VRCC Pump S___";
                case 656: return "FeedBack = _, VRCC Fan S___A";
                case 657: return "FeedBack = _, VRCC Fan S___B";
                case 658: return "Low level VRCC cool water";
                case 659: return "High temp.VRCC coolwater:___°C";
                case 660: return "Thermoerror VRCC Pump F___";
                case 661: return "Thermoerror VRCC fan low F___A";
                case 662: return "Thermoerr. VRCC fan High F___B";
                case 663: return "VCMS, error in historic DB";
                case 664: return "VCMS, historic DB disabled";
                case 665: return "Feedback = _, Bypass contactor";
                case 666: return "Feedback = _, Generator_";
                case 667: return "Stop error during thyr. firing";
                case 668: return "Commencing thyristor-in";
                case 669: return "Commencing thyristor-out";
                case 670: return "Thyristors stopped";
                case 671: return "Thyristor firing interrupted";
                case 672: return "Commence thyristor test Gen_";
                case 673: return "End thyristor test Gen_";
                case 674: return "Commence motorstart Gen_";
                case 675: return "End motorstart Gen_";
                case 676: return "Bypass missing before gen_";
                case 677: return "Generatorbreaker open";
                case 678: return "Illegal GenLogicState";
                case 679: return "CT316 driver fail";
                case 680: return "VCMS: No top communication";
                case 681: return "VCMS: No gnd communication";
                case 682: return "VCMS: No hub communication";
                case 683: return "VCMS: No VCPM communication";
                case 684: return "VCMS: Parameter mismatch";
                case 685: return "RCCPRM.bin File missing";
                case 686: return "RCC.bin File missing";
                case 687: return "Hub Top Sync timeout";
                case 688: return "VCMS:Error in RS INI file";
                case 689: return "Remote AP Crash";
                case 690: return "Signal operatinal.";
                case 691: return "Signal error. __,__";
                case 692: return "Signal error. pause (a) __,__";
                case 693: return "Signal error. pause __,__";
                case 694: return "Signal error. STOP __,__";
                case 695: return "Signal error. EMERGENCY __,__";
                case 696: return "CAN API error.";
                case 697: return "CAN SDO error.";
                case 698: return "CAN emergency error.";
                case 699: return "Low Battry CT291";
                case 700: return "Low Battry CT3601 Nacelle";
                case 701: return "Low Battry CT3601 Hub";
                case 702: return "VCP detects Q8 feedback missin";
                case 703: return "RT Dip exc.lim.:___%:_____e-2s";
                case 704: return "Ch High res. load C_ Load:___%";
                case 705: return "Ch High IGBT load C_ Load:___%";
                case 706: return "Ch High res. dev. C_ R:_.__Ohm";
                case 707: return "Ch hardware error C_";
                case 708: return "RT High Rotor Current L_:____A";
                case 709: return "RT Ext. High Rot.Cur. L_:____A";
                case 710: return "RT Rotor HW Error L_:____A";
                case 711: return "RT Number:__,LastRT time_____s";
                case 712: return "Ch active D Load C1___% C2___%";
                case 716: return "Hoist failure -low brake press";
                case 717: return "SMTP client failed";
                case 718: return "Hoist failure - max gen. rpm";
                case 719: return "Close Gridbreaker 3";
                case 720: return "Gridbreaker 3 closed";
                case 721: return "Open Gridbreaker 3";
                case 722: return "Gridbreaker 3 open";
                case 723: return "Obsolete";
                case 724: return "Obsolete";
                case 725: return "No RT, High Rotor Cur L_:____A";
                case 726: return "No RT, Ex.Hig.Rot.Cur L_:____A";
                case 727: return "No RT, Rotor HW.Error L_:____A";
                case 728: return "Dip detec. V:___%,t:_____e-2s";
                case 729: return "EMCPitchSelfTest ___s";
                case 730: return "No error High wind EMC Pitchtest ___m/s";
                case 731: return "_ EMC pitchAccu failed __°";
                case 732: return "EMC pitchtest deviation __°";
                case 733: return "Blade _ EMC pitchSystem Err. _";
                case 734: return "Error EMC pitch blade _ ___°";
                case 735: return "Long EMCpitch time bladeX_ __s";
                case 736: return "Blade _ pitch react. time___s";
                case 737: return "Close F60";
                case 738: return "F60 closed";
                case 739: return "Fog horn inactive";
                case 740: return "Fog horn active";
                case 741: return "Ext. 24V persistent in Hub";
                case 742: return "Test:__________, __________";
                case 743: return "EMC Pitch Accu Test Started";
                case 744: return "EMC Pitch Accu Test Stopped";
                case 745: return "EMC Pitch Accu Test Blade _";
                case 746: return "EMC Pitch Accu Test Aborted";
                case 747: return "EMC Pitch Accu Test Failed";
                case 748: return "Too many contactor supervis.";
                case 749: return "Extra info. Err:___ P:____._kW";
                case 750: return "Coldboot parameters lost";
                case 751: return "Parameters not recovered";
                case 752: return "Automatic reestablish failed";
                case 753: return "Automatic reestablish OK";
                case 754: return "no RT, Dip no __,___e-2";
                case 755: return "VCMS:AMA11 V=_____um/s, ____kW";
                case 756: return "VCMS:AMA12 V=_____um/s, ____kW";
                case 757: return "VCMS:AMA13 V=_____um/s, ____kW";
                case 758: return "VCMS:AMA14 V=_____um/s, ____kW";
                case 759: return "VCMS:AMA15 V=_____um/s, ____kW";
                case 760: return "VCMS:AMA31 A=_____mm/s2,____kW";
                case 761: return "VCMS:AMA32 A=_____mm/s2,____kW";
                case 762: return "VCMS:SEW51 V=_____um/s, ____kW";
                case 763: return "VCMS:SEW51 A=_____mm/s2,____kW";
                case 764: return "VCMS:SEA51 V=_____um/s, ____kW";
                case 765: return "VCMS:SEA51 A=_____mm/s2,____kW";
                case 766: return "VCMS:FEW51 V=_____um/s, ____kW";
                case 767: return "VCMS:FEW51 A=_____mm/s2,____kW";
                case 768: return "VCMS:FEA51 V=_____um/s, ____kW";
                case 769: return "VCMS:FEA51 A=_____mm/s2,____kW";
                case 770: return "VCMS:AMA51 A=_____mm/s2,____kW";
                case 771: return "VCMS:AMA51 V=_____um/s, ____kW";
                case 772: return "VCMS:SEW52 V=_____um/s, ____kW";
                case 773: return "VCMS:SEW52 A=_____mm/s2,____kW";
                case 774: return "VCMS:SEA52 V=_____um/s, ____kW";
                case 775: return "VCMS:SEA52 A=_____mm/s2,____kW";
                case 776: return "VCMS:FEW52 V=_____um/s, ____kW";
                case 777: return "VCMS:FEW52 A=_____mm/s2,____kW";
                case 778: return "VCMS:FEA52 V=_____um/s, ____kW";
                case 779: return "VCMS:FEA52 A=_____mm/s2,____kW";
                case 780: return "VCMS:AMA52 A=_____mm/s2,____kW";
                case 781: return "VCMS:AMA52 V=_____um/s, ____kW";
                case 782: return "VCMS:SEW53 V=_____um/s, ____kW";
                case 783: return "VCMS:SEW53 A=_____mm/s2,____kW";
                case 784: return "VCMS:SEA53 V=_____um/s, ____kW";
                case 785: return "VCMS:SEA53 A=_____mm/s2,____kW";
                case 786: return "VCMS:FEW53 V=_____um/s, ____kW";
                case 787: return "VCMS:FEW53 A=_____mm/s2,____kW";
                case 788: return "VCMS:FEA53 V=_____um/s, ____kW";
                case 789: return "VCMS:FEA53 A=_____mm/s2,____kW";
                case 790: return "VCMS:AMA53 A=_____mm/s2,____kW";
                case 791: return "VCMS:AMA53 V=_____um/s, ____kW";
                case 792: return "VCMS:Node __ overload error";
                case 793: return "VCMS:Node __ reset error";
                case 794: return "VCMS:Assertion failure";
                case 795: return "VCMS:Socket error";
                case 796: return "VCMS:Start client __ error";
                case 797: return "RT,NotReady during next __min.";
                case 798: return "Phasecomp temp.disc.:___.__ Hz";
                case 799: return "PComp. dis. avr____ step ____A";
                case 800: return "PComp. dis. step__.__/__.__Hz";
                case 801: return "Thermoerror Hydr. cool F___";
                case 802: return "Pitch Lubricate Motion ___._ °";
                case 803: return "GenRpm error measurem. ____rpm";
                case 804: return "Invalid Turbine ID-number";
                case 805: return "VCMS:Node __ defect";
                case 806: return "Time changed more than __sec,_";
                case 807: return "Too many interval usec timers";
                case 808: return "Interval usec timer not init.";
                case 809: return "VCMS:__ nodes not responding";
                case 810: return "VCMS:Net jammed!";
                case 811: return "RT not allowed. Dip no __";
                case 812: return "Feedback = _, Phasecomp. 1";
                case 813: return "Feedback = _, Phasecomp. 2";
                case 814: return "Feedback = _, Phasecomp. 3";
                case 815: return "Feedback = _, Phasecomp. 4";
                case 816: return "Feedback = _, Phasecomp. 5";
                case 817: return "Feedback = _, Phasecomp. 6";
                case 818: return "Feedback = _, Phasecomp. 7";
                case 819: return "Feedback = _, Phasecomp. 8";
                case 820: return "Feedback = _, Phasecomp. 9";
                case 821: return "Feedback = _, Phasecomp. 10";
                case 822: return "Feedback = _, Phasecomp. 11";
                case 823: return "Feedback = _, Phasecomp. 12";
                case 824: return "Max. Ph. Comp. FB. warnings";
                case 825: return "Ph. C. low reac. pow _____hVAr";
                case 826: return "Gridstate queue overflow";
                case 827: return "Nac Heaters __, Temp:___°C";
                case 828: return "Frequency error:___.__Hz";
                case 829: return "Timeout Start Frequency error";
                case 830: return "External power ref.:____kW";
                case 831: return "Ambient SWDS High Wind:__._m/s dir:___";
                case 832: return "Remote service panel taken _ _";
                case 833: return "Main WS switch from WS_ to WS_";
                case 834: return "Remote service panel free _ _";
                case 835: return "RT, UnexpAGO2Event C__ S __";
                case 836: return "RT, IntAGO2CtrlErr C__ S __";
                case 837: return "RT AGO2Sta.Cyc. Count_,____V";
                case 838: return "Q8 contactor in state: ___";
                case 839: return "VCS/VCRS dummy alarm1 ____ ___";
                case 840: return "VCS/VCRS dummy alarm2 ____ ___";
                case 841: return "VCS/VCRS dummy alarm3 ____ ___";
                case 842: return "VCS/VCRS dummy alarm4 ____ ___";
                case 843: return "VCS/VCRS dummy alarm5 ____ ___";
                case 844: return "VCS/VCRS dummy warn1 ____ ____";
                case 845: return "VCS/VCRS dummy warn2 ____ ____";
                case 846: return "VCS/VCRS dummy warn3 ____ ____";
                case 847: return "VCS/VCRS dummy warn4 ____ ____";
                case 848: return "VCS/VCRS dummy warn5 ____ ____";
                case 849: return "RT DC Undervoltage: ____V";
                case 850: return "No RT, DC Undervoltage: ____V";
                case 851: return "Low temp. Gen bearing _:___°C";
                case 852: return "Extr Extr high volt. L_: ___ V";
                case 853: return "Puls Pause gearoil cool activ";
                case 854: return "Puls Paus gearoil cool inactiv";
                case 855: return "Nacelle reset not found";
                case 856: return "No ParameterDefinition file";
                case 857: return "SW/Param def. vers. conflict";
                case 858: return "Error in ParameterDef. file";
                case 859: return "Error in Param. def. parser";
                case 860: return "No ParameterValues file";
                case 861: return "SW/Param value vers. conflict";
                case 862: return "Error in ParameterValue. file";
                case 863: return "Error in Param. Value parser";
                case 864: return "Cmd scan suspended ____ ____";
                case 865: return "WS2 Dir Frozen __._m/s ___._ø";
                case 866: return "WS1 checksum err.";
                case 867: return "WS2 checksum err.";
                case 868: return "Gear temp. diff. ___øC ___øC";
                case 869: return "Prepare Reconnecttimeout";
                case 870: return "Gen_ Speed Control Connect";
                case 871: return "LSO Timeout State __";
                case 872: return "Running up timeout";
                case 874: return "RCC not ready at gen. Connect";
                case 875: return "Timeout comm. Tower acc.";
                case 876: return "AGO timeout state:__ * ______";
                case 877: return "Grid Power drop: _____ -> _____ kW";

                default:
                    return "Unknown code";
            }
        }

        #endregion TEXT_FUNCTIONS


        #region ADDITIONAL_FUNCTIONS

        private void Extract_StateData(int _turbineID, byte state1, byte state2)
        {
            // extract State1 data
            turbine.OperationState = state1 & 0x03;
            turbine.PendOperationState = (state1 & 0x0C) >> 2;
            turbine.ServiceState = Convert.ToBoolean(state1 & 0x10);
            turbine.YawCW = Convert.ToBoolean(state1 & 0x20);
            turbine.YawCCW = Convert.ToBoolean(state1 & 0x40);
            turbine.CommandAccepted = Convert.ToBoolean(state1 & 0x80);

            // extract State2 data
            turbine.RemoteControl = Convert.ToBoolean(state2 & 0x01);
            turbine.YawState = (state2 & 0x06) >> 1;
            turbine.TurbineAvailable = Convert.ToBoolean(state2 & 0x08);
            turbine.VDF_Triggered = Convert.ToBoolean(state2 & 0x10);
            turbine.LocalModeRequest = Convert.ToBoolean(state2 & 0x20);
            turbine.G1_Connected = Convert.ToBoolean(state2 & 0x40);
            turbine.G2_Connected = Convert.ToBoolean(state2 & 0x80);
            // update general Generator connection status
            turbine.G_Connected = turbine.G1_Connected | turbine.G2_Connected;
        }

        public byte[] ComputeCRC_16_bytes(byte[] val, int offset, int count)
        {
            UInt16 sum = 0;
            byte[] crc = new byte[2];

            try
            {
                for (int i = offset; i < offset + count; i++)
                {
                    sum += val[i];
                }

                crc[0] = (byte)(sum / 256);     // MSB of CRC
                crc[1] = (byte)(sum & 0xFF);    // LSB of CRC
                return crc;
            }
            catch (Exception ex)
            {
                throw new Exception("ComputeCRC_16_bytes error - " + ex.Message);
            }
        }

        public ushort ComputeCRC_16(byte[] val, int offset, int count)
        {
            ushort crc = 0;

            try
            {
                for (int i = offset; i < offset + count; i++)
                {
                    crc += val[i];
                }

                return crc;
            }
            catch (Exception ex)
            {
                throw new Exception("ComputeCRC_16 error - " + ex.Message);
            }
        }

        #endregion ADITTIONAL_FUNCTIONS
    }

    public struct Parameter_Info
    {
        public ushort Group;
        public ushort Index;
        public short Value;
        public string Text;
    }

    public class Log_Record
    {
        public ushort LogNumber;
        private DateTime timeStamp;
        public DateTime TimeStamp
        {
            get
            {
                return timeStamp;
            }
        }
        public ushort timeStamp_1
        {
            set
            {
                ConvertTimeStamp_T4_2_W1(value);
            }
        }
        public ushort timeStamp_2
        {
            set
            {
                ConvertTimeStamp_T4_2_W2(value);
            }
        }
        public short LogParameter1;
        public short LogParameter2;


        public void ConvertTimeStamp_T4_2_W1(ushort data)
        {
            /*
            timeStamp.Year = ;
            timeStamp.Month = ;
            timeStamp.Day = ;
            */
        }

        public void ConvertTimeStamp_T4_2_W2(ushort data)
        {
            /*
            timeStamp.Hour = ;
            timeStamp.Minute = ;
            timeStamp.Second = ;
            */
        }
    }
}
