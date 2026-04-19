using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Eleon_SCADA.IEC104_Interface
{
    /// <summary>
    /// Connects IEC-104 client to park server
    /// </summary>
    class IEC104_Interface
    {
        System.Timers.Timer myIEC104MappingTimer;
        public bool Simulation_Mode;    // In simulation mode IEC104 interface will be mapped to simulation variables and not to the
        // variables that are connected to the park controller


        #region INTERFACE_VARIABLES
        // Here are all the variables/values that are connected to the park controller
        // All the interactions between park server and IEC interface variables are specified here

        // CONTROL values for IEC104 access
        public bool EmLimit80_Ctrl;
        public bool EmLimit60_Ctrl;
        public bool EmLimit40_Ctrl;
        public bool EmLimit20_Ctrl;
        public bool ParkStartStop_Ctrl;
        public int ActivePowerSetpoint_Ctrl;
        public bool SecondaryRegulation_Ctrl;


        // MONITORING values for IEC104 access
        public bool ParkOperation_Mon
        {
            get
            {
                return Program.myPark.GridConnected;
            }
        }
        public bool ParkMVBreaker_Mon;
        public bool SecondaryRegulation_Mon;
        public bool EmLimit80_Mon;
        public bool EmLimit60_Mon;
        public bool EmLimit40_Mon;
        public bool EmLimit20_Mon;
        public int ActivePowerSetpoint_Mon;
        public float WindSpeed_Mon
        {
            get
            {
                return (float)Program.myPark.WindSpeed;
            }
        }
        public float Voltage_Mon            // unit [1 kV]
        {
            get
            {
                // round value up to 0,01 kV
                return (float)(int)(Program.myPark.Voltage / 10) / 100;
            }
        }
        public float ActivePower_Mon        // unit [1 MW]
        {
            get
            {
                return (float)Program.myPark.ActivePower / 1000;
            }
        }
        public float ReactivePower_Mon      // unit [1 MVar]
        {
            get
            {
                return (float)Program.myPark.ReactivePower / 1000;
            }
        }
        public float Current_Mon            // unit [1 A]
        {
            get
            {
                return (float)Program.myPark.Current;
            }
        }



        // THESE VARIABLES/VALUES ARE USED IN SIMULATION MODE
        //*********************************************************************
        // control values
        public bool EmLimit80_Ctrl_Sim;
        public bool EmLimit60_Ctrl_Sim;
        public bool EmLimit40_Ctrl_Sim;
        public bool EmLimit20_Ctrl_Sim;
        public bool ParkStartStop_Ctrl_Sim;
        public int ActivePowerSetpoint_Ctrl_Sim;
        public bool SecondaryRegulation_Sim;

        // monitoring values
        public bool ParkOperation_Mon_Sim;
        public bool ParkMVBreaker_Mon_Sim;
        public bool SecondaryRegulation_Mon_Sim;
        public bool EmLimit80_Mon_Sim;
        public bool EmLimit60_Mon_Sim;
        public bool EmLimit40_Mon_Sim;
        public bool EmLimit20_Mon_Sim;
        public int ActivePowerSetpoint_Mon_Sim;
        public float WindSpeed_Mon_Sim;
        public float Voltage_Mon_Sim;
        public float ActivePower_Mon_Sim;
        public float ReactivePower_Mon_Sim;
        public float Current_Mon_Sim;
        //*********************************************************************

        #endregion INTERFACE_VARIABLES


        // Initiates the mapping procedure
        private void myIEC104MappingTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            UpdateValues();
        }


        // constructor
        public IEC104_Interface()
        {
            // initialize variables
            this.ParkMVBreaker_Mon = true;
            this.ActivePowerSetpoint_Ctrl = Eleon_SCADA.Settings.Park.Remote_ActivePowerSetpoint / 100;
            this.ActivePowerSetpoint_Mon = ActivePowerSetpoint_Ctrl;
            Program.myIEC104Server.myIECDatabase.Set(6201, (short)this.ActivePowerSetpoint_Ctrl);

            // start mapping with specified rate
            myIEC104MappingTimer = new System.Timers.Timer(100);
            myIEC104MappingTimer.Elapsed += myIEC104MappingTimer_Elapsed;
            myIEC104MappingTimer.Start();

            // Set IEC104 database events
            Program.myIEC104Server.myIECDatabase.C_SC_NA_data.ValueChanged += C_SC_NA_data_ValueChanged;
            Program.myIEC104Server.myIECDatabase.C_SC_NA_data.ValueUpdated += C_SC_NA_data_ValueUpdated;
            Program.myIEC104Server.myIECDatabase.C_SE_NA_data.ValueChanged += C_SE_NA_data_ValueChanged;
        }

        private void C_SE_NA_data_ValueChanged(object source, IEC104Server.IEC104_Database_EventArgs e)
        {
            // Secondary regulation power setpoint
            if (e.IOA == 6201)
            {
                ActivePowerSetpoint_Mon = (short)e.NewValue;
                if (SecondaryRegulation_Mon)
                {
                    Program.myPark.Remote_ActivePowerSetpoint = ActivePowerSetpoint_Mon * 100;
                }
            }
        }

        private void C_SC_NA_data_ValueUpdated(object source, IEC104Server.IEC104_Database_EventArgs e)
        {
            // Park Start/Stop command
            if (e.IOA == 5)
            {
                if ((bool)(e.NewValue))
                {
                    try
                    {
                        Program.myPark.StartPark();
                    }
                    catch { }
                }
                else
                {
                    try
                    {
                        Program.myPark.StopPark();
                    }
                    catch { }
                }
            }
        }

        void C_SC_NA_data_ValueChanged(object sender, IEC104Server.IEC104_Database_EventArgs e)
        {
            // Check which IOA has changed and act accordingly
            switch (e.IOA)
            {
                // EM limit 80% command
                case 1:
                    if (Simulation_Mode)
                    {
                        EmLimit80_Mon_Sim = (bool)(e.NewValue);
                    }
                    else
                    {
                        if ((bool)e.NewValue)      // activate
                        {
                            EmLimit80_Mon = true;

                            EmLimit20_Mon = false;
                            EmLimit40_Mon = false;
                            EmLimit60_Mon = false;

                            Program.myIEC104Server.myIECDatabase.C_SC_NA_data.Set(2, false);
                            Program.myIEC104Server.myIECDatabase.C_SC_NA_data.Set(3, false);
                            Program.myIEC104Server.myIECDatabase.C_SC_NA_data.Set(4, false);

                            Program.myPark.Remote_ActivePowerSetpoint = (int)(0.8 * Program.myPark.ActivePowerMax);
                        }
                        else    // deactivate
                        {
                            EmLimit80_Mon = false;
                            if (SecondaryRegulation_Ctrl)    // if secondary regulation is activated
                            {
                                Program.myPark.Remote_ActivePowerSetpoint = (int)(ActivePowerSetpoint_Ctrl * 100);
                            }
                            else    // if secondary regulation is not active
                            {
                                Program.myPark.Remote_ActivePowerSetpoint = (int)Program.myPark.ActivePowerMax;
                            }
                        }
                    }
                    break;

                // EM limit 60% command
                case 2:
                    if (Simulation_Mode)
                    {
                        EmLimit60_Mon_Sim = (bool)(e.NewValue);
                    }
                    else
                    {
                        if ((bool)e.NewValue)      // activate
                        {
                            EmLimit60_Mon = true;

                            EmLimit20_Mon = false;
                            EmLimit40_Mon = false;
                            EmLimit80_Mon = false;

                            Program.myIEC104Server.myIECDatabase.C_SC_NA_data.Set(1, false);
                            Program.myIEC104Server.myIECDatabase.C_SC_NA_data.Set(3, false);
                            Program.myIEC104Server.myIECDatabase.C_SC_NA_data.Set(4, false);

                            Program.myPark.Remote_ActivePowerSetpoint = (int)(0.6 * Program.myPark.ActivePowerMax);
                        }
                        else    // deactivate
                        {
                            EmLimit60_Mon = false;
                            if (SecondaryRegulation_Ctrl)    // if secondary regulation is activated
                            {
                                Program.myPark.Remote_ActivePowerSetpoint = (int)(ActivePowerSetpoint_Ctrl * 100);
                            }
                            else    // if secondary regulation is not active
                            {
                                Program.myPark.Remote_ActivePowerSetpoint = (int)Program.myPark.ActivePowerMax;
                            }
                        }
                    }
                    break;

                // EM limit 40% command
                case 3:
                    if (Simulation_Mode)
                    {
                        EmLimit40_Mon_Sim = (bool)(e.NewValue);
                    }
                    else
                    {
                        if ((bool)e.NewValue)      // activate
                        {
                            EmLimit40_Mon = true;

                            EmLimit20_Mon = false;
                            EmLimit60_Mon = false;
                            EmLimit80_Mon = false;

                            Program.myIEC104Server.myIECDatabase.C_SC_NA_data.Set(1, false);
                            Program.myIEC104Server.myIECDatabase.C_SC_NA_data.Set(2, false);
                            Program.myIEC104Server.myIECDatabase.C_SC_NA_data.Set(4, false);

                            Program.myPark.Remote_ActivePowerSetpoint = (int)(0.4 * Program.myPark.ActivePowerMax);
                        }
                        else    // deactivate
                        {
                            EmLimit40_Mon = false;
                            if (SecondaryRegulation_Ctrl)    // if secondary regulation is activated
                            {
                                Program.myPark.Remote_ActivePowerSetpoint = (int)(ActivePowerSetpoint_Ctrl * 100);
                            }
                            else    // if secondary regulation is not active
                            {
                                Program.myPark.Remote_ActivePowerSetpoint = (int)Program.myPark.ActivePowerMax;
                            }
                        }
                    }
                    break;

                // EM limit 20% command
                case 4:
                    if (Simulation_Mode)
                    {
                        EmLimit20_Mon_Sim = (bool)(e.NewValue);
                    }
                    else
                    {
                        if ((bool)e.NewValue)      // activate
                        {
                            EmLimit20_Mon = true;

                            EmLimit40_Mon = false;
                            EmLimit60_Mon = false;
                            EmLimit80_Mon = false;

                            Program.myIEC104Server.myIECDatabase.C_SC_NA_data.Set(1, false);
                            Program.myIEC104Server.myIECDatabase.C_SC_NA_data.Set(2, false);
                            Program.myIEC104Server.myIECDatabase.C_SC_NA_data.Set(3, false);

                            Program.myPark.Remote_ActivePowerSetpoint = (int)(0.2 * Program.myPark.ActivePowerMax);
                        }
                        else    // deactivate
                        {
                            EmLimit20_Mon = false;
                            if (SecondaryRegulation_Ctrl)    // if secondary regulation is activated
                            {
                                Program.myPark.Remote_ActivePowerSetpoint = (int)(ActivePowerSetpoint_Ctrl * 100);
                            }
                            else    // if secondary regulation is not active
                            {
                                Program.myPark.Remote_ActivePowerSetpoint = (int)Program.myPark.ActivePowerMax;
                            }
                        }
                    }
                    break;

                // Secondary regulation command
                case 6:
                    if (Simulation_Mode)
                    {
                        SecondaryRegulation_Mon_Sim = (bool)(e.NewValue);
                    }
                    else
                    {
                        if ((bool)e.NewValue)
                        {
                            Program.myPark.Remote_ActivePowerSetpoint = (int)(ActivePowerSetpoint_Ctrl * 100);
                            SecondaryRegulation_Mon = true;
                        }
                        else
                        {
                            Program.myPark.Remote_ActivePowerSetpoint = Program.myPark.ActivePowerMax;
                            SecondaryRegulation_Mon = false;
                        }
                    }
                    break;

                default:
                    return;
            }
        }


        private void UpdateValues()
        {
            // connect to different set of variables in case of simulation mode
            UpdateControlData();
            UpdateMonitoringData();
        }


        private void UpdateControlData()
        {
            lock (this)
            {
                if (Simulation_Mode)
                {
                    Program.myIEC104_Interface.EmLimit80_Ctrl_Sim = Program.myIEC104Server.myIECDatabase.C_SC_NA_data.Get(1);
                    Program.myIEC104_Interface.EmLimit60_Ctrl_Sim = Program.myIEC104Server.myIECDatabase.C_SC_NA_data.Get(2);
                    Program.myIEC104_Interface.EmLimit40_Ctrl_Sim = Program.myIEC104Server.myIECDatabase.C_SC_NA_data.Get(3);
                    Program.myIEC104_Interface.EmLimit20_Ctrl_Sim = Program.myIEC104Server.myIECDatabase.C_SC_NA_data.Get(4);
                    Program.myIEC104_Interface.ParkStartStop_Ctrl_Sim = Program.myIEC104Server.myIECDatabase.C_SC_NA_data.Get(5);
                    Program.myIEC104_Interface.SecondaryRegulation_Sim = Program.myIEC104Server.myIECDatabase.C_SC_NA_data.Get(6);
                    Program.myIEC104_Interface.ActivePowerSetpoint_Ctrl_Sim = Program.myIEC104Server.myIECDatabase.C_SE_NA_data.Get(6201);
                }
                else
                {
                    Program.myIEC104_Interface.EmLimit80_Ctrl = Program.myIEC104Server.myIECDatabase.C_SC_NA_data.Get(1);
                    Program.myIEC104_Interface.EmLimit60_Ctrl = Program.myIEC104Server.myIECDatabase.C_SC_NA_data.Get(2);
                    Program.myIEC104_Interface.EmLimit40_Ctrl = Program.myIEC104Server.myIECDatabase.C_SC_NA_data.Get(3);
                    Program.myIEC104_Interface.EmLimit20_Ctrl = Program.myIEC104Server.myIECDatabase.C_SC_NA_data.Get(4);
                    Program.myIEC104_Interface.ParkStartStop_Ctrl = Program.myIEC104Server.myIECDatabase.C_SC_NA_data.Get(5);
                    Program.myIEC104_Interface.SecondaryRegulation_Ctrl = Program.myIEC104Server.myIECDatabase.C_SC_NA_data.Get(6);
                    Program.myIEC104_Interface.ActivePowerSetpoint_Ctrl = Program.myIEC104Server.myIECDatabase.C_SE_NA_data.Get(6201);
                }
            }
        }

        private void UpdateMonitoringData()
        {
            lock (this)
            {
                if (Simulation_Mode)
                {
                    Program.myIEC104Server.myIECDatabase.M_ME_NC_data.Set(1001, Program.myIEC104_Interface.WindSpeed_Mon_Sim);
                    Program.myIEC104Server.myIECDatabase.M_ME_NC_data.Set(1002, Program.myIEC104_Interface.Voltage_Mon_Sim);
                    Program.myIEC104Server.myIECDatabase.M_ME_NC_data.Set(1003, Program.myIEC104_Interface.ActivePower_Mon_Sim);
                    Program.myIEC104Server.myIECDatabase.M_ME_NC_data.Set(1004, Program.myIEC104_Interface.ReactivePower_Mon_Sim);
                    Program.myIEC104Server.myIECDatabase.M_ME_NC_data.Set(1005, Program.myIEC104_Interface.Current_Mon_Sim);
                    Program.myIEC104Server.myIECDatabase.M_ME_NC_data.Set(1006, Program.myIEC104_Interface.ActivePowerSetpoint_Mon_Sim);

                    Program.myIEC104Server.myIECDatabase.M_SP_NA_data.Set(2001, Program.myIEC104_Interface.ParkOperation_Mon_Sim);
                    Program.myIEC104Server.myIECDatabase.M_SP_NA_data.Set(2002, Program.myIEC104_Interface.ParkMVBreaker_Mon_Sim);
                    Program.myIEC104Server.myIECDatabase.M_SP_NA_data.Set(2003, Program.myIEC104_Interface.SecondaryRegulation_Mon_Sim);
                    Program.myIEC104Server.myIECDatabase.M_SP_NA_data.Set(2004, Program.myIEC104_Interface.EmLimit80_Mon_Sim);
                    Program.myIEC104Server.myIECDatabase.M_SP_NA_data.Set(2005, Program.myIEC104_Interface.EmLimit60_Mon_Sim);
                    Program.myIEC104Server.myIECDatabase.M_SP_NA_data.Set(2006, Program.myIEC104_Interface.EmLimit40_Mon_Sim);
                    Program.myIEC104Server.myIECDatabase.M_SP_NA_data.Set(2007, Program.myIEC104_Interface.EmLimit20_Mon_Sim);
                }
                else
                {
                    Program.myIEC104Server.myIECDatabase.M_ME_NC_data.Set(1001, Program.myIEC104_Interface.WindSpeed_Mon);
                    Program.myIEC104Server.myIECDatabase.M_ME_NC_data.Set(1002, Program.myIEC104_Interface.Voltage_Mon);
                    Program.myIEC104Server.myIECDatabase.M_ME_NC_data.Set(1003, Program.myIEC104_Interface.ActivePower_Mon);
                    Program.myIEC104Server.myIECDatabase.M_ME_NC_data.Set(1004, Program.myIEC104_Interface.ReactivePower_Mon);
                    Program.myIEC104Server.myIECDatabase.M_ME_NC_data.Set(1005, Program.myIEC104_Interface.Current_Mon);
                    Program.myIEC104Server.myIECDatabase.M_ME_NC_data.Set(1006, Program.myIEC104_Interface.ActivePowerSetpoint_Mon);

                    Program.myIEC104Server.myIECDatabase.M_SP_NA_data.Set(2001, Program.myIEC104_Interface.ParkOperation_Mon);
                    Program.myIEC104Server.myIECDatabase.M_SP_NA_data.Set(2002, Program.myIEC104_Interface.ParkMVBreaker_Mon);
                    Program.myIEC104Server.myIECDatabase.M_SP_NA_data.Set(2003, Program.myIEC104_Interface.SecondaryRegulation_Mon);
                    Program.myIEC104Server.myIECDatabase.M_SP_NA_data.Set(2004, Program.myIEC104_Interface.EmLimit80_Mon);
                    Program.myIEC104Server.myIECDatabase.M_SP_NA_data.Set(2005, Program.myIEC104_Interface.EmLimit60_Mon);
                    Program.myIEC104Server.myIECDatabase.M_SP_NA_data.Set(2006, Program.myIEC104_Interface.EmLimit40_Mon);
                    Program.myIEC104Server.myIECDatabase.M_SP_NA_data.Set(2007, Program.myIEC104_Interface.EmLimit20_Mon);
                }
            }
        }
    }
}
