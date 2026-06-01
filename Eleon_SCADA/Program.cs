using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Net.Sockets;
using System.Net;
using Eleon_SCADA.Park;


namespace Eleon_SCADA
{
    static class Program
    {
        public static Park.WindPark myPark;
        public static Park.VestasRCS myVestasController;
        public static Alarm_Dispatch myAlarmDispatch;
        public static Logging.Databases myDatabases;
        public static IEC104Server.IEC104Server myIEC104Server;
        public static IEC104_Interface.IEC104_Interface myIEC104_Interface;
        public static ModbusIntegration myModbusServer;
        public static InteropServices myInteropServices;
        public static PowerCurve PowerCurve_V80;

        public static Forms.Form_Main form_Main;


        [STAThread]
        static void Main()
        {
            bool createdNew = true;
            using (Mutex mutex = new Mutex(true, "Eleon_SCADA", out createdNew))
            {
                // make sure that the program does not run already
                if (createdNew)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    Forms.Form_Startup myForm = new Forms.Form_Startup();
                    myForm.Show();

                    Application.ApplicationExit += myApplicationExit;
                    System.Timers.Timer NoLicenseTimer;
                    

                    // Check License
                    if (!Licensing.CheckLicense())
                    {
                        NoLicenseTimer = new System.Timers.Timer(60000);
                        NoLicenseTimer.Elapsed += NoLicenseTimer_Elapsed;
                        NoLicenseTimer.Start();
                        MessageBox.Show("Software runs without license. Some functionality has been disabled.\nProgram will close in 1 min", "No license", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    try
                    {
                        Settings.Settings.Load();
                        MarketInterfaceLog.Load();
                        PowerCurve_V80 = new PowerCurve("PowerCurve_V80.txt");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    myPark = new Park.WindPark();
                    myPark.AddTurbines(1, "Vestas V80");
                    myVestasController = new Park.VestasRCS(myPark, (VestasTurbine)myPark.myTurbines[1]);
                    if (!Eleon_SCADA.Settings.MarketInterface.MarketIfEnable)
                    {
                        myPark.Market_ActivePowerSetpoint = myPark.ActivePowerMax;
                    }
                    myAlarmDispatch = new Alarm_Dispatch(myPark);
                    myAlarmDispatch.Start();
                    myIEC104Server = new IEC104Server.IEC104Server();
                    myIEC104_Interface = new IEC104_Interface.IEC104_Interface();
                    if (Eleon_SCADA.Settings.MarketInterface.MarketIfEnable)
                    {
                        try
                        {
                            myModbusServer = new ModbusIntegration();
                            myModbusServer.Start();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error starting Market Interface server\n" + ex.Message, "Error");
                            myModbusServer = null;
                        }
                    }
                    myInteropServices = new InteropServices();


                    // create instance of logging Database
                    #region
                    try
                    {
                        myDatabases = new Logging.Databases(myPark);
                        myDatabases.StartLogging();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error starting database process\n" + ex.Message, "Error");
                    }
                    #endregion


                    // auto connection of park
                    #region
                    if (Eleon_SCADA.Settings.Application.AutoConnectPark)
                    {
                        try
                        {
                            myVestasController.OpenPort(Eleon_SCADA.Settings.VestasDriver.PortName, Eleon_SCADA.Settings.VestasDriver.Baudrate);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    #endregion

                    // auto start IEC-104 server
                    #region
                    if (Eleon_SCADA.Settings.Application.AutoStartIEC104)
                    {
                        try
                        {
                            myIEC104Server.Start();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Eleon_SCADA.Settings.Application.AutoStartIEC104 = false;
                            Eleon_SCADA.Settings.Application.Save();
                        }
                    }
                    #endregion

                    myForm.Dispose();

                    form_Main = new Forms.Form_Main();
                    Application.Run(form_Main);
                }
                else    // quit if another instance of this program already runs
                {
                    return;
                }
            }
        }

        static void NoLicenseTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            form_Main.ClosingConfirmation = false;  // disable main form closing confirmation for noLicense closing action
            Application.Exit();
        }


        private static void myApplicationExit(object sender, EventArgs e)
        {
            try
            {
                if (myModbusServer != null)
                {
                    myModbusServer.Stop();
                }
                MarketInterfaceLog.Stop();
            }
            catch { }

            try
            {
                myInteropServices.Dispose();
            }
            catch { }
        }
    }




    public class PowerCurve
    {
        private string FilePath;            // file path for current Power curve file(.txt)
        private float windspeed_1;
        public float Windspeed_1            // first(lowest) windspeed value in power curve
        {
            get
            {
                return windspeed_1;
            }
            set
            {
                windspeed_1 = value;
                CalcNumOfValues();
            }
        }
        private float windspeed_2;
        public float Windspeed_2            // last(highest) windspeed value in power curve
        {
            get
            {
                return windspeed_2;
            }
            set
            {
                windspeed_2 = value;
                CalcNumOfValues();
            }
        }
        private float windspeedStep;
        public float WindspeedStep          // resolution/precision of windspeed values
        {
            get
            {
                return windspeedStep;
            }
            set
            {
                windspeedStep = value;
                CalcNumOfValues();
            }
        }
        public int NumOfValues;
        public int[] Power;


        public PowerCurve()
        {
        }

        public PowerCurve(string PowerCurveFilePath)
        {
            FilePath = PowerCurveFilePath;
            try
            {
                Load();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }


        // read the data from power curve file
        public void Load()
        {
            if (System.IO.File.Exists(FilePath))
            {
                // read data from file
                try
                {
                    string[] lines = System.IO.File.ReadAllLines(FilePath);
                    string[] data;// = new string[lines.Count()];

                    //Get smallest windspeed, highest windspeed and windspeed step values from file
                    data = lines[0].Split('-');
                    windspeed_1 = Convert.ToSingle(data[0]);
                    data = lines[lines.Count() - 1].Split('-');
                    windspeed_2 = Convert.ToSingle(data[0]);
                    data = lines[1].Split('-');
                    windspeedStep = Convert.ToSingle(data[0]) - windspeed_1;
                    //NumOfValues = lines.Count();
                    CalcNumOfValues();

                    for (int i = 0; i < lines.Count(); i++)
                    {
                        data = lines[i].Split('-');
                        Power[i] = Convert.ToInt32((string)data[1]);
                        //Power[i] = Convert.ToInt32(lines[i].Split('-')[1]);
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("Error loading settings.\n" + ex.Message);
                }
            }
            else
            {
                throw new Exception("Could not find settings file.");
            }
        }

        private void CalcNumOfValues()
        {
            int num = (int)((windspeed_2 - windspeed_1) / windspeedStep) + 1;
            if (num != NumOfValues)
            {
                if (Power == null)      // first time allocation of variable
                {
                    Power = new int[num];
                }

                try
                {
                    int[] _power = new int[num];

                    // copy array
                    for (int i = 0; i < num; i++)
                    {
                        if (i < NumOfValues)
                        {
                            _power[i] = Power[i];
                        }
                        else
                        {
                            _power[i] = 0;
                        }
                    }

                    Power = _power;
                    NumOfValues = num;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in \"CalcNumOfValues()\"\n" + ex.Message);
                }
            }
        }

        // save data to power curve file
        public void Save()
        {
            string[] lines = new string[NumOfValues];

            for (int i = 0; i < NumOfValues; i++)
            {
                lines[i] = (windspeed_1 + windspeedStep * i).ToString("F1") + "-" + Power[i];
            }

            try
            {
                System.IO.File.WriteAllLines(FilePath, lines);
            }
            catch (Exception ex)
            {
                throw new Exception("Error saving powercurve data");
            }
        }

        public void Copy(PowerCurve powerCurve)
        {
            powerCurve.windspeed_1 = windspeed_1;
            powerCurve.windspeed_2 = windspeed_2;
            powerCurve.WindspeedStep = windspeedStep;
            powerCurve.NumOfValues = NumOfValues;
            Power.CopyTo(powerCurve.Power, 0);
        }

        public int GetPower(float windspeed)
        {
            if (windspeed >= Windspeed_1)
            {
                if (windspeed <= Windspeed_2)
                {
                    int index = (int)((windspeed - Windspeed_1) / WindspeedStep);
                    return Power[index];
                }
                else
                {
                    return Power[NumOfValues - 1];
                }
            }
            else
            {
                return 0;
            }
        }
    }
}
