using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using TK_ParkServer.Park;

namespace TK_ParkServer.Park
{
    class WindPark
    {
        System.Timers.Timer myUpdateTimer;

        // park communication statistics
        public UInt16 ParkComTransmitted;
        public UInt16 ParkComReceived;
        public UInt16 ParkComErrors;

        public UInt16 NumOfTurbinesInPark;
        public WindTurbine[] myTurbines;

        //public int NumOfTurbinesConnected;         // shows the number of turbines connected to grid

        // park measurement values
        public float WindSpeed;                     // wind speed in windpark(usually based on average from all turbines)
        public float WindDirection;                 // wind direction in windpark(usually based on average from all turbines)
        public int ActivePower;
        public int ReactivePower;
        public int Voltage;
        public float Current;
        //public int ActivePowerCapability;          // potential active power based on current wind speed
        //public int ReactivePowerCapability;        // potential reactive power capability, based on current active power

        // park statistics values
        //public long TotalActiveProduction;         // total produced kWh; sum of all turbines
        //public long TotalHours;                    // total hours in production

        // park control values
        // get/set functions are used to detect the need and call control functions
        private int activePowerMax;
        public int ActivePowerMax
        {
            get { return activePowerMax; }
            set
            {
                if (value != activePowerMax)
                {
                    activePowerMax = value;

                    // if setpoints are higher than new max power
                    local_ActivePowerSetpoint = ClampActivePowerSetpoint(local_ActivePowerSetpoint);
                    tso_ActivePowerSetpoint = ClampActivePowerSetpoint(tso_ActivePowerSetpoint);
                    market_ActivePowerSetpoint = ClampActivePowerSetpoint(market_ActivePowerSetpoint);
                    ApplyActivePowerSetpointMode();

                    TK_ParkServer.Settings.Park.ParkMaxPower = (ushort)activePowerMax;
                    TK_ParkServer.Settings.Park.Local_ActivePowerSetpoint = (ushort)local_ActivePowerSetpoint;
                    TK_ParkServer.Settings.Park.TSO_ActivePowerSetpoint = (ushort)tso_ActivePowerSetpoint;
                    TK_ParkServer.Settings.Park.Market_ActivePowerSetpoint = (ushort)market_ActivePowerSetpoint;
                    TK_ParkServer.Settings.Park.Save();
                }
            }
        }
        private int activePowerSetpoint;
        private int ActivePowerSetpoint
        {
            get { return activePowerSetpoint; }
            set
            {
                if (value != activePowerSetpoint) //if value changed
                {
                    activePowerSetpoint = ClampActivePowerSetpoint(value);
                    SetActivePower();
                }
            }
        }
        private int local_ActivePowerSetpoint;
        public int Local_ActivePowerSetpoint
        {
            get { return local_ActivePowerSetpoint; }
            set
            {
                if (value != local_ActivePowerSetpoint) //if value changed
                {
                    local_ActivePowerSetpoint = ClampActivePowerSetpoint(value);
                    ApplyActivePowerSetpointMode();

                    TK_ParkServer.Settings.Park.Local_ActivePowerSetpoint = (ushort)local_ActivePowerSetpoint;
                    TK_ParkServer.Settings.Park.Save();
                }
            }
        }
        private int tso_ActivePowerSetpoint;
        public int TSO_ActivePowerSetpoint
        {
            get { return tso_ActivePowerSetpoint; }
            set
            {
                if (value != tso_ActivePowerSetpoint) //if value changed
                {
                    tso_ActivePowerSetpoint = ClampActivePowerSetpoint(value);
                    ApplyActivePowerSetpointMode();

                    TK_ParkServer.Settings.Park.TSO_ActivePowerSetpoint = (ushort)tso_ActivePowerSetpoint;
                    TK_ParkServer.Settings.Park.Save();
                }
            }
        }
        private int market_ActivePowerSetpoint;
        public int Market_ActivePowerSetpoint
        {
            get { return market_ActivePowerSetpoint; }
            set
            {
                if (value != market_ActivePowerSetpoint) //if value changed
                {
                    market_ActivePowerSetpoint = ClampActivePowerSetpoint(value);
                    ApplyActivePowerSetpointMode();

                    TK_ParkServer.Settings.Park.Market_ActivePowerSetpoint = (ushort)market_ActivePowerSetpoint;
                    TK_ParkServer.Settings.Park.Save();
                }
            }
        }

        private int activePowerSetpoint_Mode;
        public int ActivePowerSetpoint_Mode
        {
            get { return activePowerSetpoint_Mode; }
            set
            {
                if (value != activePowerSetpoint_Mode)   //if value has changed
                {
                    if (value < 0 || value > 3)
                    {
                        throw new Exception("Invalid active power setpoint mode");
                    }

                    activePowerSetpoint_Mode = value;
                    ApplyActivePowerSetpointMode();

                    TK_ParkServer.Settings.Park.ActivePowerSetpoint_Mode = activePowerSetpoint_Mode;
                    TK_ParkServer.Settings.Park.Save();
                }
            }
        }
        //public int ActivePowerRampUpLimit;         // manual max active power increasing rate
        //public int ActivePowerRampUpLimitRemote;   // max active power increasind rate received from remote interface
        //public int ActivePowerRampDown;
        //public int ActivePowerRampDownRemote;

        // park status values
        public bool GridConnected;                   // TRUE when at least one turbine is connected
        //public bool StoppedRemotely;               // TRUE when stop command is received from remote interface
        //public bool StoppedLocally;                // TRUE when all turbines stopped locally in turbine or in park controller
        //public bool GridError;                     // TRUE when park stopped by grid error
        //public bool ReactivePowerSetpoint_Mode;
        //public bool ActivePowerRampingMode;        // indicates if remote active power ramping values are used for park control




        // constructor
        public WindPark()
        {
            this.local_ActivePowerSetpoint = TK_ParkServer.Settings.Park.Local_ActivePowerSetpoint;
            this.tso_ActivePowerSetpoint = TK_ParkServer.Settings.Park.TSO_ActivePowerSetpoint;
            this.market_ActivePowerSetpoint = TK_ParkServer.Settings.Park.Market_ActivePowerSetpoint;
            this.activePowerMax = TK_ParkServer.Settings.Park.ParkMaxPower;
            this.activePowerSetpoint_Mode = TK_ParkServer.Settings.Park.ActivePowerSetpoint_Mode;

            myTurbines = new WindTurbine[1];
            myUpdateTimer = new System.Timers.Timer(100);
            myUpdateTimer.Elapsed += new System.Timers.ElapsedEventHandler(myUpdateTimer_Elapsed);
            myUpdateTimer.Start();

            ApplyActivePowerSetpointMode();
        }

        void myUpdateTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            UpdateData();
        }

        // Update/calculate park specific values based on data from all turbines
        private void UpdateData()
        {
            try
            {
                ActivePower = GetActivePower();
                ReactivePower = GetReactivePower();
                WindSpeed = GetWindSpeed();
                WindDirection = GetWindDirection();
                Voltage = GetVoltage();
                Current = GetCurrent();
                GridConnected = GetGridConnected();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message + "\n( WindPark - UpdateData )", "Exception", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }



        #region CONTROL_FUNCTIONS

        private int ClampActivePowerSetpoint(int value)
        {
            if (value < 0)
            {
                return 0;
            }

            if (value > ActivePowerMax)
            {
                return ActivePowerMax;
            }

            return value;
        }

        private int GetAutomaticActivePowerSetpoint()
        {
            return Math.Min(ActivePowerMax,
                Math.Min(Local_ActivePowerSetpoint,
                    Math.Min(TSO_ActivePowerSetpoint, Market_ActivePowerSetpoint)));
        }

        private void ApplyActivePowerSetpointMode()
        {
            if (ActivePowerSetpoint_Mode == 0)
            {
                ActivePowerSetpoint = GetAutomaticActivePowerSetpoint();
            }
            else if (ActivePowerSetpoint_Mode == 1)
            {
                ActivePowerSetpoint = Local_ActivePowerSetpoint;
            }
            else if (ActivePowerSetpoint_Mode == 2)
            {
                ActivePowerSetpoint = TSO_ActivePowerSetpoint;
            }
            else if (ActivePowerSetpoint_Mode == 3)
            {
                ActivePowerSetpoint = Market_ActivePowerSetpoint;
            }
        }

        // calculate and send active power setpoints to all turbines in park to control park's total active power output
        public void SetActivePower()
        {
            try
            {
                if (Program.myPark == null ||
                    Program.myVestasController == null ||
                    Program.myPark.myTurbines == null ||
                    Program.myPark.myTurbines.Length <= 1 ||
                    Program.myPark.myTurbines[1] == null)
                {
                    return;
                }

                // set T01 power
                Program.myPark.myTurbines[1].Set_PowerSetpoint((short)activePowerSetpoint);
            }
            catch { }
        }

        // Start all turbines in park
        public void StartPark()
        {
            Program.myPark.myTurbines[1].Start_Turbine();
        }

        // Stop all turbines in park
        public void StopPark()
        {
            Program.myPark.myTurbines[1].Stop_Turbine();
        }

        #endregion CONTROL_FUNCTIONS

        
        #region ADDITIONAL_FUNCTIONS

        private bool GetGridConnected()
        {
            try
            {
                for (int i = 1; i <= NumOfTurbinesInPark; i++)
                {
                    if (((VestasTurbine)myTurbines[i]).G_Connected)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message + "\n( WindPark - GetGridConnected )", "Exception", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        private int GetActivePower()
        {
            try
            {
                int activePower = 0;
                for (int i = 1; i <= NumOfTurbinesInPark; i++)
                {
                    activePower += ((VestasTurbine)myTurbines[i]).Active_Power;
                }
                return activePower;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message + "\n( WindPark - GetActivePower )", "Exception", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return 0;
            }
        }

        private int GetReactivePower()
        {
            try
            {
                int reactivePower = 0;
                for (int i = 1; i <= NumOfTurbinesInPark; i++)
                {
                    reactivePower += ((VestasTurbine)myTurbines[i]).Reactive_Power;
                }
                return reactivePower;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message + "\n( WindPark - GetActivePower )", "Exception", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return 0;
            }
        }

        private float GetWindSpeed()
        {
            try
            {
                float windSpeed = 0;

                for (int i = 1; i <= NumOfTurbinesInPark; i++)
                {
                    windSpeed += ((VestasTurbine)myTurbines[i]).Wind_Speed;
                }
                windSpeed = (float)windSpeed / NumOfTurbinesInPark;
                return windSpeed;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message + "\n( WindPark - GetWindSpeed )", "Exception", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return 0;
            }
        }

        private int GetWindDirection()
        {
            try
            {
                int WindDirection = 0;
                //for (int i = 1; i <= NumOfTurbinesInPark; i++)
                //{
                //    windDirection += myTurbines[i].WindDirection;
                //}
                //windDirection = windDirection / NumOfTurbinesInPark;
                WindDirection = (int)((VestasTurbine)myTurbines[1]).Wind_Direction;
                return WindDirection;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message + "\n( WindPark - GetWindDirection )", "Exception", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return 0;
            }
        }

        // calculate windpark MV level (10,5 kV) voltage
        private int GetVoltage()
        {
            int voltage = (int)(float)((((VestasTurbine)Program.myPark.myTurbines[1]).Voltage_L1 + ((VestasTurbine)Program.myPark.myTurbines[1]).Voltage_L2 +
                ((VestasTurbine)Program.myPark.myTurbines[1]).Voltage_L3) / 3 * 26.25);

            return voltage;
        }

        // calculate windpark MV level (10,5 kV) current
        private float GetCurrent()
        {
            // round value up to 0,1 A
            //return (float)(int)((float)(Program.myPark.myTurbines[1].Active_Power * 1000 / Voltage / Math.Sqrt(3) * 10)) / 10;
            if (Voltage > 0)    // prevent dividing by zero
            {
                //return (float)(int)((float)(Program.myPark.myTurbines[1].Active_Power * 1000 / Voltage * 10)) / 10;
                return (float)(int)((float)((VestasTurbine)Program.myPark.myTurbines[1]).Active_Power * 1000 / Voltage / Math.Sqrt(3) * 10) / 10;
            }
            else return 0;
        }

        // add one new turbine to park
        //public void AddTurbine(string _turbineType)
        //{
        //    NumOfTurbinesInPark++;
        //    myTurbines[NumOfTurbinesInPark] = new VestasTurbine(NumOfTurbinesInPark, ("T"
        //        + NumOfTurbinesInPark.ToString("D2")), _turbineType);
        //}

        // add a number of new turbines to park
        public void AddTurbines(int _NumOfTurbinesToAdd, string _turbineType)
        {
            for (int i = 0; i < _NumOfTurbinesToAdd; i++)
            {
                NumOfTurbinesInPark++;
                if (myTurbines.Length <= NumOfTurbinesInPark)
                {
                    Array.Resize(ref myTurbines, NumOfTurbinesInPark + 1);
                }

                myTurbines[NumOfTurbinesInPark] = new VestasTurbine(NumOfTurbinesInPark, ("T"
                    + (NumOfTurbinesInPark).ToString("D2")), _turbineType);
            }
        }

        #endregion ADDITIONAL_FUNCTIONS
    }
}
