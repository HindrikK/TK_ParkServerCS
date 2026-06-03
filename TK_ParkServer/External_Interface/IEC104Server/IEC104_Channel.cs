using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK_ParkServer.IEC104Server
{
    class IEC104Channel
    {
        // This IEC 104 servers standard settings settings:
        //  ASDU address lenghth - 2 (internally uses only 1 byte(ASDU 0-255) )
        //  IOA length - 3
        //  COT lenght - 2
        //  sends command activation confirmation and termination messages

        IEC104Server myIEC104Server;                    // reference the main IEC 104 server which this channel belongs to
        IEC104_Database myIECDatabase;                  // reference the database used by this channel
        System.Net.Sockets.TcpClient myTCPClient;       // references the TCP client which represents the actual IEC 104 client
        System.Net.Sockets.NetworkStream myIEC104ChannelStream;

        // buffers for logging raw received and sent data packets
        public FiFoList IEC104_Received_Data = new FiFoList(20);
        public FiFoList IEC104_Sent_Data = new FiFoList(20);


        //System.Threading.Thread myCyclicDataThread;     // thread for auto cyclic data

        public int channelID;
        public string channelSrcAdr;
        bool StartDT;                       // checks if STARTDT command received and allowed to transmit
        byte ASDU = 3;                      // default ASDU address used for all channels here is 3
        byte originatorAdr = 4;             // originator address
        UInt16 SendSequence;                // counts sent frames; bit 0 is always zero - basically needs to be incremented by 2
        UInt16 ReceiveSequence;             // counts received frames; bit 0 is always zero - basically needs to be incremented by 2
        UInt16 clientReceiveSequence;       // received frame count reported by client; S-Frame
        bool periodicTransmission = false;
        int periodicPeriod = 5000;          // sets time period[ms] for automatic periodic data sending;

        bool processing;                    // receiving or sending operation in progress


        /// <summary>
        /// Create IEC-104 channel instance
        /// </summary>
        /// <param name="_myIEC104Server">Main IEC-104 server which owns this IEC-104 client/channel></param>
        /// <param name="_myIECDatabase">Database used for this IEC-104 client/channel></param>
        /// <param name="_myTCPClient">System TCP client used for this IEC-104 client/channel</param>
        /// <param name="_channelID">ID used for this IEC-104 client/channel in system</param>
        public IEC104Channel(IEC104Server _myIEC104Server, IEC104_Database _myIECDatabase, System.Net.Sockets.TcpClient _myTCPClient, int _channelID)
        {
            ASDU = Convert.ToByte(TK_ParkServer.Settings.TSOInterface.ASDU);
            periodicTransmission = TK_ParkServer.Settings.TSOInterface.periodicTransmission;
            periodicPeriod = TK_ParkServer.Settings.TSOInterface.periodicPeriod;
            channelID = _channelID;

            myTCPClient = _myTCPClient;
            myIEC104Server = _myIEC104Server;
            channelSrcAdr = _myTCPClient.Client.RemoteEndPoint.ToString();
            myIECDatabase = _myIECDatabase;

            myIEC104Server.NoOfClients++;
        }

        // periodically send data
        private void myPeriodicTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (StartDT)
            {
                if (processing) { return; }     // wait for any active process to end
                try
                {
                    Send_CyclicData();
                }
                catch
                {
                    //System.Windows.Forms.MessageBox.Show("Cyclic data sending Error");
                }
            }
        }

        private void Close()
        {
            //System.Threading.Thread.Sleep(200);
            myIEC104Server.NoOfClients--;
            myIEC104ChannelStream.Dispose();
            myIEC104Server.Channels[channelID] = null;          // erase this client from clients array
        }

        public void CloseChannel()
        {
            myIEC104ChannelStream.Dispose();
        }



        /// <summary>
        /// Processes communication with a IEC104 client/channel.
        /// Requires to be called on a separate thread
        /// </summary>
        public void Work()
        {
            myIEC104ChannelStream = myTCPClient.GetStream();

            byte[] data = new byte[64];
            int bytesRead;

            // if set, start cyclic data
            if (periodicTransmission)
            {
                System.Timers.Timer myPeriodicTimer = new System.Timers.Timer();
                myPeriodicTimer.Elapsed += myPeriodicTimer_Elapsed;
                myPeriodicTimer.Interval = periodicPeriod;
                myPeriodicTimer.Enabled = true;
            }

            SendSequence = 0;
            ReceiveSequence = 0;
            clientReceiveSequence = 0;


            while (true)
            {
                bytesRead = 0;

                try
                {
                    bytesRead = myIEC104ChannelStream.Read(data, 0, 64);
                    processing = true;
                    if (bytesRead != 0)
                    {
                        byte[] request = new byte[bytesRead];
                        string frame = "";
                        for (int i = 0; i < bytesRead; i++)
                        {
                            request[i] = data[i];
                            frame += data[i].ToString("X2") + " ";
                        }
                        IEC104_Received_Data.Add_WithTime(frame);
                        ManageRequest(myIEC104ChannelStream, request);
                    }
                }
                catch
                {
                    //System.Windows.Forms.MessageBox.Show(ex.Message, "Exception");
                    break;
                }

                if (bytesRead == 0)
                {
                    break;
                }
                processing = false;
            }

            Close();
        }



        public void ManageRequest(System.Net.Sockets.NetworkStream _networkstream, byte[] _request)
        {
            processing = true;

            if (_request[0] == 0x68)
            {
                //ReceiveSequence += 2;

                // if fixed length telegram(4 bytes: S-Format or I-Format)
                if (_request[1] == 4)
                {
                    // if STARTDT request
                    if (_request[2] == 0x07)
                    {
                        Send_STARTDT_Reply();
                        StartDT = true;
                    }
                    // if STOPDT request
                    else if (_request[2] == 0x19)
                    {
                        Send_STOPDT_Reply();
                        StartDT = false;
                    }
                    // if TESTFR request
                    else if (_request[2] == 0x43)
                    {
                        Send_TESTFR_Reply();
                    }
                    // if S-Format received
                    else if (_request[2] == 0x01)
                    {
                        //Send_SFrame();
                    }
                }
                // if not fixed length telegram
                else if (_request.Count() > 6)
                {
                    if (StartDT)     // check if start transmission is set to allow transmission
                    {
                        ReceiveSequence += 2;

                        if (_request[10] == ASDU)
                        {

                            // interrogation command
                            if (_request[6] == (byte)TypeID.C_IC_NA_1)
                            {
                                Send_Interrogation_Reply(_request);
                            }
                            // read value command
                            else if (_request[6] == (byte)TypeID.C_RD_NA_1)
                            {
                                try { GetValue_Command(_request); }
                                catch (Exception ex)
                                {
                                    if (ex.Message == "IOA unknown") Send_UnknownIOA_Reply(_request);
                                    return;
                                }
                            }
                            // set C_SC_NA value commad
                            else if (_request[6] == (byte)TypeID.C_SC_NA_1)
                            {
                                try { C_SC_NA_Command(_request); }
                                catch (Exception ex)
                                {
                                    if (ex.Message == "IOA unknown") Send_UnknownIOA_Reply(_request);
                                    return;
                                }
                            }
                            // set C_DC_NA value commad
                            else if (_request[6] == (byte)TypeID.C_DC_NA_1)
                            {
                                try { C_DC_NA_Command(_request); }
                                catch (Exception ex)
                                {
                                    if (ex.Message == "IOA unknown") Send_UnknownIOA_Reply(_request);
                                    return;
                                }
                            }
                            // set C_SE_NA value command
                            else if (_request[6] == (byte)TypeID.C_SE_NA_1)
                            {
                                try { C_SE_NA_Command(_request); }
                                catch (Exception ex)
                                {
                                    if (ex.Message == "IOA unknown") Send_UnknownIOA_Reply(_request);
                                    return;
                                }
                            }
                            // set C_SE_NB value command
                            else if (_request[6] == (byte)TypeID.C_SE_NB_1)
                            {
                                try { C_SE_NB_Command(_request); }
                                catch (Exception ex)
                                {
                                    if (ex.Message == "IOA unknown") Send_UnknownIOA_Reply(_request);
                                    return;
                                }
                            }
                            // set C_SE_NC value command
                            else if (_request[6] == (byte)TypeID.C_SE_NC_1)
                            {
                                try { C_SE_NC_Command(_request); }
                                catch (Exception ex)
                                {
                                    if (ex.Message == "IOA unknown") Send_UnknownIOA_Reply(_request);
                                    return;
                                }
                            }
                            else
                            {
                                Send_UnknownType_Reply(_request);
                            }
                        }
                        else
                        {
                            Send_Unknown_ASDU_Reply(_request);
                        }
                    }
                    else
                    {
                        // send no reply, because no STARTDT command received
                    }
                }
            }
            processing = false;
        }




        #region REQUESTS_REPLIES

        public void Send_UnknownType_Reply(byte[] _request)
        {
            _request[1] = Convert.ToByte(_request.Count() - 2);
            _request[2] = Convert.ToByte(SendSequence & 0xFF);
            _request[3] = Convert.ToByte(SendSequence >> 8);
            _request[4] = Convert.ToByte(ReceiveSequence & 0xFF);
            _request[5] = Convert.ToByte(ReceiveSequence >> 8);
            _request[8] = 0x40 | (byte)COTType.eIEC870_COT_UNKNOWN_TYPE;      // COT with negative confirmation(0x40)
            myIEC104ChannelStream.Write(_request, 0, _request.Count());

            string frame = "";
            for (int i = 0; i < _request.Count(); i++)
            {
                frame += _request[i].ToString("X2") + " ";
            }
            IEC104_Sent_Data.Add_WithTime(frame);
            SendSequence += 2;
        }

        public void Send_Unknown_Cause_Reply(byte[] _request)
        {
            _request[1] = Convert.ToByte(_request.Count() - 2);
            _request[2] = Convert.ToByte(SendSequence & 0xFF);
            _request[3] = Convert.ToByte(SendSequence >> 8);
            _request[4] = Convert.ToByte(ReceiveSequence & 0xFF);
            _request[5] = Convert.ToByte(ReceiveSequence >> 8);
            _request[8] = 0x40 | (byte)COTType.eIEC870_COT_UNKNOWN_CAUSE;      // COT with negative confirmation(0x40)
            myIEC104ChannelStream.Write(_request, 0, _request.Count());

            string frame = "";
            for (int i = 0; i < _request.Count(); i++)
            {
                frame += _request[i].ToString("X2") + " ";
            }
            IEC104_Sent_Data.Add_WithTime(frame);
            SendSequence += 2;
        }

        public void Send_Unknown_ASDU_Reply(byte[] _request)
        {
            _request[1] = Convert.ToByte(_request.Count() - 2);
            _request[2] = Convert.ToByte(SendSequence & 0xFF);
            _request[3] = Convert.ToByte(SendSequence >> 8);
            _request[4] = Convert.ToByte(ReceiveSequence & 0xFF);
            _request[5] = Convert.ToByte(ReceiveSequence >> 8);
            _request[8] = 0x40 | (byte)COTType.eIEC870_COT_UNKNOWN_ASDU_ADDRESS;      // COT with negative confirmation(0x40)
            myIEC104ChannelStream.Write(_request, 0, _request.Count());

            string frame = "";
            for (int i = 0; i < _request.Count(); i++)
            {
                frame += _request[i].ToString("X2") + " ";
            }
            IEC104_Sent_Data.Add_WithTime(frame);
            SendSequence += 2;
        }

        public void Send_UnknownIOA_Reply(byte[] _request)
        {
            _request[1] = Convert.ToByte(_request.Count() - 2);
            _request[2] = Convert.ToByte(SendSequence & 0xFF);
            _request[3] = Convert.ToByte(SendSequence >> 8);
            _request[4] = Convert.ToByte(ReceiveSequence & 0xFF);
            _request[5] = Convert.ToByte(ReceiveSequence >> 8);
            _request[8] = 0x40 | (byte)COTType.eIEC870_COT_UNKNOWN_OBJECT_ADDRESS;      // COT with negative confirmation(0x40)
            myIEC104ChannelStream.Write(_request, 0, _request.Count());

            string frame = "";
            for (int i = 0; i < _request.Count(); i++)
            {
                frame += _request[i].ToString("X2") + " ";
            }
            IEC104_Sent_Data.Add_WithTime(frame);
            SendSequence += 2;
        }

        public void Send_STARTDT_Reply()
        {
            byte[] message = { 0x68, 0x04, 0x0B, 0x00, 0x00, 0x00 };
            myIEC104ChannelStream.Write(message, 0, 6);

            string frame = "";
            for (int i = 0; i < message.Count(); i++)
            {
                frame += message[i].ToString("X2") + " ";
            }
            IEC104_Sent_Data.Add_WithTime(frame);
        }

        public void Send_STOPDT_Reply()
        {
            // STOP data transmission
            byte[] message = { 0x68, 0x04, 0x31, 0x00, 0x00, 0x00 };
            myIEC104ChannelStream.Write(message, 0, 6);

            string frame = "";
            for (int i = 0; i < message.Count(); i++)
            {
                frame += message[i].ToString("X2") + " ";
            }
            IEC104_Sent_Data.Add_WithTime(frame);
        }

        public void Send_TESTFR_Reply()
        {
            byte[] message = { 0x68, 0x04, 0x83, 0x00, 0x00, 0x00 };
            myIEC104ChannelStream.Write(message, 0, 6);

            string frame = "";
            for (int i = 0; i < message.Count(); i++)
            {
                frame += message[i].ToString("X2") + " ";
            }
            IEC104_Sent_Data.Add_WithTime(frame);
        }

        public void Send_SFrame()
        {
            // send supervisory S-Frame (ReceiveSequence)
            byte[] message = { 0x68, 0x04, 0x01, 0x00, 0x00, 0x00 };
            message[4] = Convert.ToByte(ReceiveSequence & 0xFF);
            message[5] = Convert.ToByte(ReceiveSequence >> 8);
            myIEC104ChannelStream.Write(message, 0, message.Count());

            string frame = "";
            for (int i = 0; i < message.Count(); i++)
            {
                frame += message[i].ToString("X2") + " ";
            }
            IEC104_Sent_Data.Add_WithTime(frame);
        }

        public void Send_Interrogation_Reply(byte[] _request)
        {
            byte[] message = _request;

            // send "Acknowledgement of command activation"
            message[2] = Convert.ToByte(SendSequence & 0xFF);
            message[3] = Convert.ToByte(SendSequence >> 8);
            message[4] = Convert.ToByte(ReceiveSequence & 0xFF);
            message[5] = Convert.ToByte(ReceiveSequence >> 8);
            message[8] = (byte)COTType.eIEC870_COT_ACT_CON;
            message[10] = ASDU;     // set ASDU address
            myIEC104ChannelStream.Write(message, 0, 16);
            SendSequence += 2;

            string frame = "";
            for (int i = 0; i < message.Count(); i++)
            {
                frame += message[i].ToString("X2") + " ";
            }
            IEC104_Sent_Data.Add_WithTime(frame);




            int dataCount;

            // send singles data
            dataCount = myIECDatabase.M_SP_NA_data.Count();
            byte[] data1 = new byte[12 + dataCount * 4];
            data1[0] = 0x68;
            data1[1] = Convert.ToByte(data1.Count() - 2);
            data1[2] = Convert.ToByte(SendSequence & 0xFF);
            data1[3] = Convert.ToByte(SendSequence >> 8);
            data1[4] = Convert.ToByte(ReceiveSequence & 0xFF);
            data1[5] = Convert.ToByte(ReceiveSequence >> 8);
            data1[6] = (byte)TypeID.M_SP_NA_1;
            data1[7] = Convert.ToByte(dataCount);                           // set number of objects
            data1[8] = (byte)COTType.eIEC870_COT_INROGEN;
            data1[9] = originatorAdr;                                       // originator address
            data1[10] = ASDU;                                               // ASDU LSB
            data1[11] = 0x00;                                               // ASDU MSB

            for (int i = 0; i < dataCount; i++)
            {
                int ioa = myIECDatabase.M_SP_NA_data.GetIOA(i);
                bool value = myIECDatabase.M_SP_NA_data.GetValue(i);
                data1[12 + i * 4] = Convert.ToByte(ioa & 0xFF);           // IOA byte 1
                data1[13 + i * 4] = Convert.ToByte((ioa >> 8) & 0xFF);    // IOA byte 2
                data1[14 + i * 4] = Convert.ToByte(ioa >> 16);            // IOA byte 3
                data1[15 + i * 4] = Convert.ToByte(value);                // value
            }
            //try
            //{
            myIEC104ChannelStream.Write(data1, 0, data1.Count());
            SendSequence += 2;

            frame = "";
            for (int i = 0; i < data1.Count(); i++)
            {
                frame += data1[i].ToString("X2") + " ";
            }
            IEC104_Sent_Data.Add_WithTime(frame);
            //}
            //catch (Exception ex) { System.Windows.Forms.MessageBox.Show(ex.Message); }


            // send analog data
            dataCount = myIEC104Server.myIECDatabase.M_ME_NC_data.Count();
            byte[] data2 = new byte[12 + dataCount * 8];
            data2[0] = 0x68;
            data2[1] = Convert.ToByte(data2.Count() - 2);
            data2[2] = Convert.ToByte(SendSequence & 0xFF);
            data2[3] = Convert.ToByte(SendSequence >> 8);
            data2[4] = Convert.ToByte(ReceiveSequence & 0xFF);
            data2[5] = Convert.ToByte(ReceiveSequence >> 8);
            data2[6] = (byte)TypeID.M_ME_NC_1;
            data2[7] = Convert.ToByte(dataCount);                       // set number of objects
            data2[8] = (byte)COTType.eIEC870_COT_INROGEN;
            data2[9] = originatorAdr;                                   // originator address
            data2[10] = ASDU;                                           // ASDU LSB
            data2[11] = 0x00;                                           // ASDU MSB
            for (int i = 0; i < dataCount; i++)
            {
                int ioa = myIECDatabase.M_ME_NC_data.GetIOA(i);
                float value = myIECDatabase.M_ME_NC_data.GetValue(i);
                byte[] floatBytes = BitConverter.GetBytes(value);
                data2[12 + i * 8] = Convert.ToByte(ioa & 0xFF);         // IOA byte 1
                data2[13 + i * 8] = Convert.ToByte((ioa >> 8) & 0xFF);  // IOA byte 2
                data2[14 + i * 8] = Convert.ToByte(ioa >> 16);          // IOA byte 3
                data2[15 + i * 8] = floatBytes[0];                      // value LSB
                data2[16 + i * 8] = floatBytes[1];
                data2[17 + i * 8] = floatBytes[2];
                data2[18 + i * 8] = floatBytes[3];                      // value MSB
                data2[19 + i * 8] = 0x00;                               // ???
            }
            //try
            //{
            myIEC104ChannelStream.Write(data2, 0, data2.Count());
            SendSequence += 2;

            frame = "";
            for (int i = 0; i < data2.Count(); i++)
            {
                frame += data2[i].ToString("X2") + " ";
            }
            IEC104_Sent_Data.Add_WithTime(frame);
            //}
            //catch (Exception ex) { System.Windows.Forms.MessageBox.Show(ex.Message); }


            // send "Termination of command activation"
            message[2] = Convert.ToByte(SendSequence & 0xFF);
            message[3] = Convert.ToByte(SendSequence >> 8);
            message[4] = Convert.ToByte(ReceiveSequence & 0xFF);
            message[5] = Convert.ToByte(ReceiveSequence >> 8);
            message[8] = (byte)COTType.eIEC870_COT_ACT_TERM;
            message[10] = ASDU;     // set ASDU address
            myIEC104ChannelStream.Write(message, 0, 16);
            SendSequence += 2;

            frame = "";
            for (int i = 0; i < message.Count(); i++)
            {
                frame += message[i].ToString("X2") + " ";
            }
            IEC104_Sent_Data.Add_WithTime(frame);
        }

        public void Send_M_SP_NA_1_Reply(int ioa)
        {
            bool value;
            try
            {
                value = myIECDatabase.M_SP_NA_data.Get(ioa);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            // send singles data
            byte[] data1 = new byte[16];
            data1[0] = 0x68;
            data1[1] = Convert.ToByte(data1.Count() - 2);
            data1[2] = Convert.ToByte(SendSequence & 0xFF);
            data1[3] = Convert.ToByte(SendSequence >> 8);
            data1[4] = Convert.ToByte(ReceiveSequence & 0xFF);
            data1[5] = Convert.ToByte(ReceiveSequence >> 8);
            data1[6] = (byte)TypeID.M_SP_NA_1;
            data1[7] = 0x01;                                            // set number of objects
            data1[8] = (byte)COTType.eIEC870_COT_INROGEN;
            data1[9] = originatorAdr;                                   // originator address
            data1[10] = ASDU;                                           // ASDU LSB
            data1[11] = 0x00;                                           // ASDU MSB

            data1[12] = Convert.ToByte(ioa & 0xFF);                     // IOA byte 1
            data1[13] = Convert.ToByte((ioa >> 8) & 0xFF);              // IOA byte 2
            data1[14] = Convert.ToByte(ioa >> 16);                      // IOA byte 3
            data1[15] = Convert.ToByte(value);                          // value
            //try
            //{
            myIEC104ChannelStream.Write(data1, 0, data1.Count());
            SendSequence += 2;

            string frame = "";
            for (int i = 0; i < data1.Count(); i++)
            {
                frame += data1[i].ToString("X2") + " ";
            }
            IEC104_Sent_Data.Add_WithTime(frame);
            //}
            //catch (Exception ex) { System.Windows.Forms.MessageBox.Show(ex.Message); }
        }

        public void Send_M_DP_NA_1_Reply(int ioa)
        {
            byte value;
            try
            {
                value = myIECDatabase.M_DP_NA_data.Get(ioa);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            // send singles data
            byte[] data1 = new byte[16];
            data1[0] = 0x68;
            data1[1] = Convert.ToByte(data1.Count() - 2);
            data1[2] = Convert.ToByte(SendSequence & 0xFF);
            data1[3] = Convert.ToByte(SendSequence >> 8);
            data1[4] = Convert.ToByte(ReceiveSequence & 0xFF);
            data1[5] = Convert.ToByte(ReceiveSequence >> 8);
            data1[6] = (byte)TypeID.M_DP_NA_1;
            data1[7] = 0x01;                                            // set number of objects
            data1[8] = (byte)COTType.eIEC870_COT_INROGEN;
            data1[9] = originatorAdr;                                   // originator address
            data1[10] = ASDU;                                           // ASDU LSB
            data1[11] = 0x00;                                           // ASDU MSB

            data1[12] = Convert.ToByte(ioa & 0xFF);                     // IOA byte 1
            data1[13] = Convert.ToByte((ioa >> 8) & 0xFF);              // IOA byte 2
            data1[14] = Convert.ToByte(ioa >> 16);                      // IOA byte 3
            data1[15] = value;                                          // value
            //try
            //{
            myIEC104ChannelStream.Write(data1, 0, data1.Count());
            SendSequence += 2;

            string frame = "";
            for (int i = 0; i < data1.Count(); i++)
            {
                frame += data1[i].ToString("X2") + " ";
            }
            IEC104_Sent_Data.Add_WithTime(frame);
            //}
            //catch (Exception ex) { System.Windows.Forms.MessageBox.Show(ex.Message); }
        }

        public void Send_M_ME_NA_1_Reply(int ioa)
        {
            /*
            Int16 value;
            try
            {
                value = myIECDatabase.M_ME_NA_data.Get(ioa);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            byte[] data1 = new byte[18];
            data1[0] = 0x68;
            data1[1] = Convert.ToByte(data1.Count() - 2);
            data1[2] = Convert.ToByte(SendSequence & 0xFF);
            data1[3] = Convert.ToByte(SendSequence >> 8);
            data1[4] = Convert.ToByte(ReceiveSequence & 0xFF);
            data1[5] = Convert.ToByte(ReceiveSequence >> 8);
            data1[6] = (byte)TypeID.M_ME_NA_1;
            data1[7] = 0x01;                                            // set number of objects
            data1[8] = (byte)COTType.eIEC870_COT_INROGEN;
            data1[9] = originatorAdr;                                   // originator address
            data1[10] = ASDU;                                           // ASDU LSB
            data1[11] = 0x00;                                           // ASDU MSB

            data1[12] = Convert.ToByte(ioa & 0xFF);                     // IOA byte 1
            data1[13] = Convert.ToByte((ioa >> 8) & 0xFF);              // IOA byte 2
            data1[14] = Convert.ToByte(ioa >> 16);                      // IOA byte 3
            data1[15] = Convert.ToByte(value & 0xFF);                   // value LSB
            data1[16] = Convert.ToByte(value >> 8);                     // value MSB
            data1[17] = 0x00;                                           // ???
            //try
            //{
            myIEC104ChannelStream.Write(data1, 0, data1.Count());
            SendSequence += 2;

            string frame = "";
            for (int i = 0; i < data1.Count(); i++)
            {
                frame += data1[i].ToString("X2") + " ";
            }
            IEC104_Sent_Data.Add_WithTime(frame);
            //}
            //catch (Exception ex) { System.Windows.Forms.MessageBox.Show(ex.Message); }
            */
        }

        public void Send_M_ME_NC_1_Reply(int ioa)
        {
            float value;
            
            try
            {
                value = myIECDatabase.M_ME_NC_data.Get(ioa);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            // send singles data
            byte[] data1 = new byte[20];
            data1[0] = 0x68;
            data1[1] = Convert.ToByte(data1.Count() - 2);
            data1[2] = Convert.ToByte(SendSequence & 0xFF);
            data1[3] = Convert.ToByte(SendSequence >> 8);
            data1[4] = Convert.ToByte(ReceiveSequence & 0xFF);
            data1[5] = Convert.ToByte(ReceiveSequence >> 8);
            data1[6] = (byte)TypeID.M_ME_NC_1;
            data1[7] = 0x01;                                            // set number of objects
            data1[8] = (byte)COTType.eIEC870_COT_INROGEN;
            data1[9] = originatorAdr;                                   // originator address
            data1[10] = ASDU;                                           // ASDU LSB
            data1[11] = 0x00;                                           // ASDU MSB

            byte[] floatBytes = BitConverter.GetBytes(value);
            data1[12] = Convert.ToByte(ioa & 0xFF);                     // IOA byte 1
            data1[13] = Convert.ToByte((ioa >> 8) & 0xFF);              // IOA byte 2
            data1[14] = Convert.ToByte(ioa >> 16);                      // IOA byte 3
            data1[15] = floatBytes[0];                                  // value LSB
            data1[16] = floatBytes[1];
            data1[17] = floatBytes[2];
            data1[18] = floatBytes[3];                                  // value MSB
            data1[19] = 0x00;                                           // ???
            //try
            //{
            myIEC104ChannelStream.Write(data1, 0, data1.Count());
            SendSequence += 2;

            string frame = "";
            for (int i = 0; i < data1.Count(); i++)
            {
                frame += data1[i].ToString("X2") + " ";
            }
            IEC104_Sent_Data.Add_WithTime(frame);
        }

        #endregion REQUESTS_REPLIES



        #region COMMANDS

        // Single command
        public void C_SC_NA_Command(byte[] _command)
        {
            int _IOA = (_command[14] << 16) + (_command[13] << 8) + _command[12];
            bool _value = Convert.ToBoolean(_command[15] & 0x01);
            try { myIECDatabase.C_SC_NA_data.Set(_IOA, _value); }
            catch (Exception ex) { throw ex; }

            // send reply
            _command[0] = 0x68;
            _command[1] = Convert.ToByte(_command.Count() - 2);
            _command[2] = Convert.ToByte(SendSequence & 0xFF);
            _command[3] = Convert.ToByte(SendSequence >> 8);
            _command[4] = Convert.ToByte(ReceiveSequence & 0xFF);
            _command[5] = Convert.ToByte(ReceiveSequence >> 8);
            _command[6] = (byte)TypeID.C_SC_NA_1;
            _command[7] = 0x01;                                            // set number of objects
            _command[8] = (byte)COTType.eIEC870_COT_ACT_CON;
            _command[9] = originatorAdr;                                   // originator address
            _command[10] = ASDU;                                           // ASDU LSB
            _command[11] = 0x00;                                           // ASDU MSB
            myIEC104ChannelStream.Write(_command, 0, _command.Count());
            SendSequence += 2;

            string frame = "";
            for (int i = 0; i < _command.Count(); i++)
            {
                frame += _command[i].ToString("X2") + " ";
            }
            IEC104_Sent_Data.Add_WithTime(frame);
        }


        // Double command
        public void C_DC_NA_Command(byte[] _command)
        {
            int _IOA = (_command[14] << 16) + (_command[13] << 8) + _command[12];
            byte _value = (byte)(_command[15] & 0x03);
            try { myIECDatabase.C_DC_NA_data.Set(_IOA, _value); }
            catch (Exception ex) { throw ex; }

            // send reply
            _command[0] = 0x68;
            _command[1] = Convert.ToByte(_command.Count() - 2);
            _command[2] = Convert.ToByte(SendSequence & 0xFF);
            _command[3] = Convert.ToByte(SendSequence >> 8);
            _command[4] = Convert.ToByte(ReceiveSequence & 0xFF);
            _command[5] = Convert.ToByte(ReceiveSequence >> 8);
            _command[6] = (byte)TypeID.C_DC_NA_1;
            _command[7] = 0x01;                                            // set number of objects
            _command[8] = (byte)COTType.eIEC870_COT_ACT_CON;
            _command[9] = originatorAdr;                                   // originator address
            _command[10] = ASDU;                                           // ASDU LSB
            _command[11] = 0x00;                                           // ASDU MSB
            myIEC104ChannelStream.Write(_command, 0, _command.Count());
            SendSequence += 2;

            string frame = "";
            for (int i = 0; i < _command.Count(); i++)
            {
                frame += _command[i].ToString("X2") + " ";
            }
            IEC104_Sent_Data.Add_WithTime(frame);
        }

        
        // Set-point Command, normalized value
        public void C_SE_NA_Command(byte[] _command)
        {
            int _IOA = (_command[14] << 16) + (_command[13] << 8) + _command[12];
            Int16 _value = Convert.ToInt16((_command[16] << 8) + _command[15]);
            try { myIECDatabase.C_SE_NA_data.Set(_IOA, (short)_value); }
            catch (Exception ex) { throw ex; }

            // send reply
            _command[0] = 0x68;
            _command[1] = Convert.ToByte(_command.Count() - 2);
            _command[2] = Convert.ToByte(SendSequence & 0xFF);
            _command[3] = Convert.ToByte(SendSequence >> 8);
            _command[4] = Convert.ToByte(ReceiveSequence & 0xFF);
            _command[5] = Convert.ToByte(ReceiveSequence >> 8);
            _command[6] = (byte)TypeID.C_SE_NA_1;
            _command[7] = 0x01;                                            // set number of objects
            _command[8] = (byte)COTType.eIEC870_COT_ACT_CON;
            _command[9] = originatorAdr;                                   // originator address
            _command[10] = ASDU;                                           // ASDU LSB
            _command[11] = 0x00;                                           // ASDU MSB
            myIEC104ChannelStream.Write(_command, 0, _command.Count());
            SendSequence += 2;

            string frame = "";
            for (int i = 0; i < _command.Count(); i++)
            {
                frame += _command[i].ToString("X2") + " ";
            }
            IEC104_Sent_Data.Add_WithTime(frame);
        }
        

        // Set-point Command, scaled value
        public void C_SE_NB_Command(byte[] _command)
        {
            throw new Exception("IOA unknown");
            /*
            int _IOA = (_command[14] << 16) + (_command[13] << 8) + _command[12];
            Int16 _value = Convert.ToInt16((_command[16] << 8) + _command[15]);
            try { myIECDatabase.C_SE_NA_data.Set(_IOA, _value); }
            catch (Exception ex) { throw ex; }

            // send reply
            _command[0] = 0x68;
            _command[1] = Convert.ToByte(_command.Count() - 2);
            _command[2] = Convert.ToByte(SendSequence & 0xFF);
            _command[3] = Convert.ToByte(SendSequence >> 8);
            _command[4] = Convert.ToByte(ReceiveSequence & 0xFF);
            _command[5] = Convert.ToByte(ReceiveSequence >> 8);
            _command[6] = (byte)TypeID.C_SE_NB_1;
            _command[7] = 0x01;                                            // set number of objects
            _command[8] = (byte)COTType.eIEC870_COT_ACT_CON;
            _command[9] = originatorAdr;                                   // originator address
            _command[10] = ASDU;                                           // ASDU LSB
            _command[11] = 0x00;                                           // ASDU MSB
            myIEC104ChannelStream.Write(_command, 0, _command.Count());
            SendSequence += 2;

            string frame = "";
            for (int i = 0; i < _command.Count(); i++)
            {
                frame += _command[i].ToString("X2") + " ";
            }
            IEC104_Sent_Data.Add(frame);
            */
        }

        // Set-point Command, short floating point number
        public void C_SE_NC_Command(byte[] _command)
        {
            throw new Exception("IOA unknown");
            /*
            int _IOA = (_command[14] << 16) + (_command[13] << 8) + _command[12];
            float _value = BitConverter.ToSingle(_command, 15);
            try{ myIECDatabase.C_SE_NA_data.Set(_IOA, _value); }
            catch (Exception ex) { throw ex; }

            // send reply
            _command[0] = 0x68;
            _command[1] = Convert.ToByte(_command.Count() - 2);
            _command[2] = Convert.ToByte(SendSequence & 0xFF);
            _command[3] = Convert.ToByte(SendSequence >> 8);
            _command[4] = Convert.ToByte(ReceiveSequence & 0xFF);
            _command[5] = Convert.ToByte(ReceiveSequence >> 8);
            _command[6] = (byte)TypeID.C_SE_NC_1;
            _command[7] = 0x01;                                            // set number of objects
            _command[8] = (byte)COTType.eIEC870_COT_ACT_CON;
            _command[9] = originatorAdr;                                   // originator address
            _command[10] = ASDU;                                           // ASDU LSB
            _command[11] = 0x00;                                           // ASDU MSB
            myIEC104ChannelStream.Write(_command, 0, _command.Count());
            SendSequence += 2;

            string frame = "";
            for (int i = 0; i < _command.Count(); i++)
            {
                frame += _command[i].ToString("X2") + " ";
            }
            IEC104_Sent_Data.Add(frame);
            */
        }

        public void GetValue_Command(byte[] _command)
        {
            int ioa = (_command[14] << 16) + (_command[13] << 8) + _command[12];
            int type = myIECDatabase.GetType(ioa);

            if (type == (byte)TypeID.M_SP_NA_1)
            {
                try { Send_M_SP_NA_1_Reply(ioa); }
                catch (Exception ex)
                {
                    if (ex.Message == "IOA unknown") Send_UnknownIOA_Reply(_command);
                    return;
                }
            }
            else if (type == (byte)TypeID.M_DP_NA_1)
            {
                try { Send_M_DP_NA_1_Reply(ioa); }
                catch (Exception ex)
                {
                    if (ex.Message == "IOA unknown") Send_UnknownIOA_Reply(_command);
                    return;
                }
            }
            else if (type == (byte)TypeID.M_ME_NA_1)
            {
                try { Send_M_ME_NA_1_Reply(ioa); }
                catch (Exception ex)
                {
                    if (ex.Message == "IOA unknown") Send_UnknownIOA_Reply(_command);
                    return;
                }
            }
            else if (type == (byte)TypeID.M_ME_NC_1)
            {
                try { Send_M_ME_NC_1_Reply(ioa); }
                catch (Exception ex)
                {
                    if (ex.Message == "IOA unknown") Send_UnknownIOA_Reply(_command);
                    return;
                }
            }
        }

        #endregion COMMANDS



        public void Send_CyclicData()
        {
            int dataCount;

            // send singles data
            dataCount = myIECDatabase.M_SP_NA_data.Count();
            byte[] data1 = new byte[12 + dataCount * 4];
            data1[0] = 0x68;
            data1[1] = Convert.ToByte(data1.Count() - 2);
            data1[2] = Convert.ToByte(SendSequence & 0xFF);
            data1[3] = Convert.ToByte(SendSequence >> 8);
            data1[4] = Convert.ToByte(ReceiveSequence & 0xFF);
            data1[5] = Convert.ToByte(ReceiveSequence >> 8);
            data1[6] = (byte)TypeID.M_SP_NA_1;
            data1[7] = Convert.ToByte(dataCount);                           // set number of objects
            data1[8] = (byte)COTType.eIEC870_COT_CYCLIC;
            data1[9] = originatorAdr;                                       // originator address
            data1[10] = ASDU;                                               // ASDU LSB
            data1[11] = 0x00;                                               // ASDU MSB

            for (int i = 0; i < dataCount; i++)
            {
                int ioa = myIECDatabase.M_SP_NA_data.GetIOA(i);
                bool value = myIECDatabase.M_SP_NA_data.GetValue(i);
                data1[12 + i * 4] = Convert.ToByte(ioa & 0xFF);           // IOA byte 1
                data1[13 + i * 4] = Convert.ToByte((ioa >> 8) & 0xFF);    // IOA byte 2
                data1[14 + i * 4] = Convert.ToByte(ioa >> 16);            // IOA byte 3
                data1[15 + i * 4] = Convert.ToByte(value);                // value
            }
            //try
            //{
            myIEC104ChannelStream.Write(data1, 0, data1.Count());
            SendSequence += 2;

            string frame = "";
            for (int i = 0; i < data1.Count(); i++)
            {
                frame += data1[i].ToString("X2") + " ";
            }
            IEC104_Sent_Data.Add_WithTime(frame);
            //}
            //catch (Exception ex) { System.Windows.Forms.MessageBox.Show(ex.Message); }


            // send analog data
            dataCount = myIEC104Server.myIECDatabase.M_ME_NC_data.Count();
            byte[] data2 = new byte[12 + dataCount * 8];
            data2[0] = 0x68;
            data2[1] = Convert.ToByte(data2.Count() - 2);
            data2[2] = Convert.ToByte(SendSequence & 0xFF);
            data2[3] = Convert.ToByte(SendSequence >> 8);
            data2[4] = Convert.ToByte(ReceiveSequence & 0xFF);
            data2[5] = Convert.ToByte(ReceiveSequence >> 8);
            data2[6] = (byte)TypeID.M_ME_NC_1;
            data2[7] = Convert.ToByte(dataCount);                       // set number of objects
            data2[8] = (byte)COTType.eIEC870_COT_CYCLIC;
            data2[9] = originatorAdr;                                   // originator address
            data2[10] = ASDU;                                           // ASDU LSB
            data2[11] = 0x00;                                           // ASDU MSB
            for (int i = 0; i < dataCount; i++)
            {
                int ioa = myIECDatabase.M_ME_NC_data.GetIOA(i);
                float value = myIECDatabase.M_ME_NC_data.GetValue(i);
                byte[] floatBytes = BitConverter.GetBytes(value);
                data2[12 + i * 8] = Convert.ToByte(ioa & 0xFF);         // IOA byte 1
                data2[13 + i * 8] = Convert.ToByte((ioa >> 8) & 0xFF);  // IOA byte 2
                data2[14 + i * 8] = Convert.ToByte(ioa >> 16);          // IOA byte 3
                data2[15 + i * 8] = floatBytes[0];                      // value LSB
                data2[16 + i * 8] = floatBytes[1];
                data2[17 + i * 8] = floatBytes[2];
                data2[18 + i * 8] = floatBytes[3];                      // value MSB
                data2[19 + i * 8] = 0x00;                               // ???
            }
            //try
            //{
            myIEC104ChannelStream.Write(data2, 0, data2.Count());
            SendSequence += 2;

            frame = "";
            for (int i = 0; i < data2.Count(); i++)
            {
                frame += data2[i].ToString("X2") + " ";
            }
            IEC104_Sent_Data.Add_WithTime(frame);
            //}
            //catch (Exception ex) { System.Windows.Forms.MessageBox.Show(ex.Message); }
        }
    }
}
