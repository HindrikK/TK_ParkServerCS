using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eleon_SCADA.Forms
{

    public partial class Form_Main : Form
    {
        public bool ClosingConfirmation = true;     // if closing confirmation TRUE then ask confirmation each time before closing form
        const string USER_ADMIN = "admin";
        const string PSWD_ADMIN = "admin8811";
        const string USER_SERVICE = "service";
        const string PSWD_SERVICE = "service1188";
        const string USER_DEVELOPER = "developer";
        const string PSWD_DEVELOPER = "ELEONDeveloper";


        public Form_Main()
        {
            InitializeComponent();

            LogOut();

            timer_AutoLogOff.Interval = Eleon_SCADA.Settings.Application.AutoLogoutTime * 1000;
        }


        #region TIMER_FUNCTIONS

        // refresh values on screen
        private void timer_Update_fast_Tick(object sender, EventArgs e)
        {
            RefreshScreen_Fast();
        }

        private void timer_Update_slow_Tick(object sender, EventArgs e)
        {
            RefreshScreen_Slow();
        }

        // Automatically log off service user after some time period
        private void timer_AutoLogOff_Tick(object sender, EventArgs e)
        {
            timer_AutoLogOff.Enabled = false;
            LogOut();
        }

        #endregion TIMER_FUNCTIONS



        // Refresh values on screen
        private void RefreshScreen_Fast()
        {
            try
            {
                // Top banner
                label_ParkActivePower.Text = Program.myPark.ActivePower.ToString();
                //label_ParkReactivePower.Text = Program.myPark.ReactivePower.ToString();
                label_ParkWindSpeed.Text = Program.myPark.WindSpeed.ToString("F1");
                //label_ParkWindDirection.Text = Program.myPark.WindDirection.ToString();

                // Overview
                label_Power_01.Text = Program.myPark.myTurbines[1].Active_Power.ToString();
                label_Wind_01.Text = Program.myPark.myTurbines[1].Windspeed.ToString("F1");
                //label_WindDirectionOverview_01.Text = Program.myPark.myTurbines[1].Wind_Direction.ToString("F1");
                label_PitchAngle_01.Text = Program.myPark.myTurbines[1].Pitch_Angle.ToString("F1");
                label_RPM_gen_01.Text = Program.myPark.myTurbines[1].Gen_RPM.ToString();
                label_StateCode_01.Text = Program.myPark.myTurbines[1].State.ToString();
                label_ErrorCode_01.Text = Program.myPark.myTurbines[1].Error_Code.ToString();

                label_OperationState.Text = Program.myPark.myTurbines[1].OperationState.ToString();
                label_PendOperationState.Text = Program.myPark.myTurbines[1].PendOperationState.ToString();

                //label_VDF_Triggered.Text = Program.myPark.myTurbines[1].VDF_Triggered.ToString();

                // Electrical
                label_Power_1s.Text = Program.myPark.myTurbines[1].Active_Power_1s.ToString();
                label_CosPhi.Text = Program.myPark.myTurbines[1].CosPhi.ToString("F2");
                label_Frequency.Text = Program.myPark.myTurbines[1].Frequency.ToString("F2");
                label_Voltage_L1.Text = Program.myPark.myTurbines[1].Voltage_L1.ToString();
                label_Voltage_L2.Text = Program.myPark.myTurbines[1].Voltage_L3.ToString();
                label_Voltage_L3.Text = Program.myPark.myTurbines[1].Voltage_L2.ToString();
                label_Current_L1.Text = Program.myPark.myTurbines[1].Current_L1.ToString();
                label_Current_L2.Text = Program.myPark.myTurbines[1].Current_L2.ToString();
                label_Current_L3.Text = Program.myPark.myTurbines[1].Current_L3.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message + "\n( Form_Main - RefreshScreen_Fast )", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Refresh values on screen
        private void RefreshScreen_Slow()
        {
            try
            {
                // Top banner
                label_ParkProduction.Text = Program.myPark.myTurbines[1].Production.ToString();

                // Overview TAB
                if (Program.myPark.myTurbines[1].ServiceState) label_ServiceState.Text = "Service state active";
                else label_ServiceState.Text = "Service state unactive";
                if (Program.myPark.myTurbines[1].YawCW) label_YawStatus.Text = "Yawing CW";
                else if (Program.myPark.myTurbines[1].YawCCW) label_YawStatus.Text = "Yawing CCW";
                else label_YawStatus.Text = "Yaw stopped";
                if (Program.myPark.myTurbines[1].RemoteControl) label_RemoteControl.Text = "Remote control enabled";
                else label_RemoteControl.Text = "Remote control disabled";
                label_YawState.Text = Program.myPark.myTurbines[1].YawState.ToString();
                if (Program.myPark.myTurbines[1].TurbineAvailable) label_TurbineAvailable.Text = "Turbine available";
                else label_TurbineAvailable.Text = "Turbine not available";
                if (Program.myPark.myTurbines[1].G1_Connected) label_G_Connected.Text = "G1 connected";
                else if (Program.myPark.myTurbines[1].G2_Connected) label_G_Connected.Text = "G2 connected";
                else if (Program.myPark.myTurbines[1].G2_Connected && Program.myPark.myTurbines[1].G2_Connected) label_G_Connected.Text = "Gen connected";
                else label_G_Connected.Text = "Gen not connected";
                if (Program.myPark.myTurbines[1].CommunicationStatus)
                {
                    tabControl_Main.TabPages[0].BackColor = Color.SteelBlue;
                    label_CommStatus_01.Text = "Turbine communication OK";
                    label_CommStatus_01.BackColor = Color.Green;
                }
                else
                {
                    tabControl_Main.TabPages[0].BackColor = Color.Red;
                    label_CommStatus_01.Text = "No communication to turbine";
                    label_CommStatus_01.BackColor = Color.Red;
                }

                label_StateTxt.Text = Program.myPark.myTurbines[1].State_Txt;
                label_Error_Txt.Text = Program.myPark.myTurbines[1].Error_Txt;
                label_OpStateTxt.Text = Program.myPark.myTurbines[1].OperationState_Txt;
                label_PendOpStateTxt.Text = Program.myPark.myTurbines[1].PendOperationState_Txt;
                label_YawStateTxt.Text = Program.myPark.myTurbines[1].YawState_Txt;


                // Electrical TAB
                label_Production.Text = Program.myPark.myTurbines[1].Production.ToString();
                label_PowerControllerSetpoint.Text = Program.myPark.myTurbines[1].ActivePowerRegulatorSetpoint.ToString();
                label_PowerSetpoint.Text = Program.myPark.myTurbines[1].ActivePowerSetpoint.ToString();
                label_ReactivePowerSetpoint.Text = Program.myPark.myTurbines[1].ReactivePowerSetpoint.ToString();

                // Wind TAB
                //label_WindDirection_01.Text = Program.myPark.myTurbines[1].Wind_Direction.ToString("F1");
                //label_RelativeWindDirection_01.Text = Program.myPark.myTurbines[1].RelativeWind_Direction.ToString("F1");
                //label_NacelleDirection_01.Text = Program.myPark.myTurbines[1].Nacelle_Direction.ToString("F1");


                if (Program.myPark.ActivePowerSetpoint_Mode == 0)
                {
                    StatusLabel_SetpointMode.Text = "No setpoint";
                    StatusLabel_PowerSetpoint.Text = Program.myPark.ActivePowerMax + " kW";
                }
                else if (Program.myPark.ActivePowerSetpoint_Mode == 1)
                {
                    StatusLabel_SetpointMode.Text = "Local setpoint";
                    StatusLabel_PowerSetpoint.Text = Program.myPark.Local_ActivePowerSetpoint + " / "
                        + Program.myPark.ActivePowerMax + " kW";
                }
                else if (Program.myPark.ActivePowerSetpoint_Mode == 2)
                {
                    StatusLabel_SetpointMode.Text = "Remote setpoint";
                    StatusLabel_PowerSetpoint.Text = Program.myPark.Remote_ActivePowerSetpoint + " / "
                        + Program.myPark.ActivePowerMax + " kW";
                }


                // Temperatures TAB
                label_Temp_Hydraulic.Text = Program.myPark.myTurbines[1].Temp_Hydraulic.ToString();
                label_Temp_Environment.Text = Program.myPark.myTurbines[1].Temp_Environment.ToString();
                label_Temp_Gear.Text = Program.myPark.myTurbines[1].Temp_Gear.ToString();
                label_Temp_Generator.Text = Program.myPark.myTurbines[1].Temp_Generator.ToString();
                label_Temp_SlipringVCS.Text = Program.myPark.myTurbines[1].Temp_SlipringVCS.ToString();
                label_Temp_GearBearing.Text = Program.myPark.myTurbines[1].Temp_GearBearing.ToString();
                label_Temp_HubController.Text = Program.myPark.myTurbines[1].Temp_HubController.ToString();
                label_Temp_Nacelle.Text = Program.myPark.myTurbines[1].Temp_Nacelle.ToString();
                label_Temp_TopController.Text = Program.myPark.myTurbines[1].Temp_TopController.ToString();
                label_Temp_BusBar.Text = Program.myPark.myTurbines[1].Temp_BusBar.ToString();
                label_Temp_Spinner.Text = Program.myPark.myTurbines[1].Temp_Spinner.ToString();
                label_Temp_HVTransformerL1.Text = Program.myPark.myTurbines[1].Temp_HVTransformerL1.ToString();
                label_Temp_HVTransformerL2.Text = Program.myPark.myTurbines[1].Temp_HVTransformerL2.ToString();
                label_Temp_HVTransformerL3.Text = Program.myPark.myTurbines[1].Temp_HVTransformerL3.ToString();
                label_Temp_GeneratorBearing.Text = Program.myPark.myTurbines[1].Temp_GeneratorBearing.ToString();
                label_Temp_CoolWaterVCS.Text = Program.myPark.myTurbines[1].Temp_CoolWaterVCS.ToString();


                // Control TAB
                label_ActivePowerSetpoint_1.Text = Program.myPark.myTurbines[1].ActivePowerSetpoint.ToString();
                label_ReactivePowerSetpoint_1.Text = Program.myPark.myTurbines[1].ReactivePowerSetpoint.ToString();


                // Bottom status bar
                UpdateParkCommStatus();
                UpdateIEC104ServerStatus();
                Update_DatabaseStatus();

                // Alarm announcement function switching
                if (Program.myAlarmDispatch.IsActive)
                {
                    button_AlarmAnnouncementEnable.ImageLocation = "AlarmMessage_Run.bmp";
                    myToolTip.ToolTipTitle = "ENABLED";
                }
                else
                {
                    button_AlarmAnnouncementEnable.ImageLocation = "AlarmMessage_Stop.bmp";
                    myToolTip.ToolTipTitle = "DISABLED";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message + "\n( Form_Main - RefreshScreen_Slow )", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        #region MENU_BUTTON_ACTIONS

        private void button_AlarmAnnouncementEnable_Click(object sender, EventArgs e)
        {
            if (Program.myAlarmDispatch.IsActive)
            {
                Program.myAlarmDispatch.Stop();
                button_AlarmAnnouncementEnable.ImageLocation = "AlarmMessage_Stop.bmp";
                myToolTip.ToolTipTitle = "DISABLED";
            }
            else
            {
                Program.myAlarmDispatch.Start();
                button_AlarmAnnouncementEnable.ImageLocation = "AlarmMessage_Run.bmp";
                myToolTip.ToolTipTitle = "ENABLED";
            }
        }

        private void connectParkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.myVestasController.PortIsOpen)
            {
                DialogResult answer = MessageBox.Show("Are you sure you want to close\nthe connection to turbine ?",
                    "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (answer == DialogResult.Yes)
                {
                    try
                    {
                        Program.myVestasController.ClosePort();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            else
            {
                try
                {
                    Program.myVestasController.OpenPort(Eleon_SCADA.Settings.VestasDriver.PortName, Eleon_SCADA.Settings.VestasDriver.Baudrate);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            UpdateParkCommStatus();
        }

        private void IEC104ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.myIEC104Server.ServerStatus == IEC104Server.IEC104_ServerStatus.RUNNING)
            {
                DialogResult answer = MessageBox.Show("Are you sure you want to stop\nthe IEC-104 server ?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (answer == DialogResult.Yes)
                {
                    try
                    {
                        Program.myIEC104Server.Stop();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            else
            {
                try
                {
                    Program.myIEC104Server.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            UpdateIEC104ServerStatus();
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Settings.Form_Preferences form_Preferences;
            form_Preferences = new Forms.Settings.Form_Preferences();
            form_Preferences.ShowDialog(this);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Dialog_About form_About;
            form_About = new Forms.Dialog_About();
            form_About.ShowDialog(this);
        }

        private void debugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Form_Developer form_Debug;
            form_Debug = new Forms.Form_Developer();
            form_Debug.Show(Program.form_Main);
        }

        private void databaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Settings.Form_DatabaseSettings form_DatabaseSettings = new Settings.Form_DatabaseSettings();
            form_DatabaseSettings.Show(this);
        }

        private void toolStripMenuItem_File_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void statusCodesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Form_ErrorLogs myForm = new Form_ErrorLogs();
            myForm.Show(this);
        }

        private void dataChartsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Form_DataCharts myForm = new Form_DataCharts();
            myForm.Show(this);
        }

        private void productionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Form_Production myForm = new Form_Production();
            myForm.Show(this);
        }

        private void iEC104ServerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Forms.Settings.Form_IEC104Settings form_IEC104Settings = new Settings.Form_IEC104Settings();
            form_IEC104Settings.Show(this);
        }

        private void alarmDispatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Form_AlarmAnnouncement form_AlarmAnnouncement;
            form_AlarmAnnouncement = new Forms.Form_AlarmAnnouncement();
            form_AlarmAnnouncement.ShowDialog(this);
        }

        private void powerControlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Settings.Form_TurbineSettings form_PowerControl;
            form_PowerControl = new Forms.Settings.Form_TurbineSettings();
            form_PowerControl.Show();
        }

        private void vestasControllerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Forms.Form_ParkSettings form_EnerconPark = new Form_ParkSettings();
            form_EnerconPark.Show(this);
        }

        private void vestasCOMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Settings.Form_TurbineCommunication form_TurbineCommunication = new Forms.Settings.Form_TurbineCommunication();
            form_TurbineCommunication.Show(this);
        }

        private void iEC104InterfaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_IEC104Interface form_IEC104Server = new Form_IEC104Interface();
            form_IEC104Server.Show(this);
        }

        private void StatusLabel_ParkConnection_Click(object sender, EventArgs e)
        {
            Form_CommStats form_CommStats = new Form_CommStats();
            form_CommStats.Show(this);
            // place the form to the bottom left corner on top of main form
            System.Drawing.Point location = new Point();
            location.X = this.Location.X;
            location.Y = this.Location.Y + this.Height - 40;
            form_CommStats.Location = location;
        }

        private void button_ParameterTool_Click(object sender, EventArgs e)
        {
            Form_VestasParameterTool form_VestasParameterTool = new Form_VestasParameterTool();
            form_VestasParameterTool.Show();
        }

        private void label_UserLevel_Click(object sender, EventArgs e)
        {
            if (Users.User_Level > Users.UserLevel.USER_LEVEL_0)
            {
                LogOut();
            }
            else
            {
                LogIn();
            }
        }

        private void licenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dialog_License myDialog = new Dialog_License();
            myDialog.ShowDialog(this);
        }

        #endregion MENU_BUTTON_ACTIONS



        #region USER_INTERFACE_FUNCTIONS

        public void UpdateParkCommStatus()
        {
            if (Program.myVestasController.PortIsOpen)
            {
                if (Program.myPark.myTurbines[1].CommunicationStatus)
                {
                    StatusLabel_ParkConnection.Text = "Connected";
                    StatusLabel_ParkConnection.BackColor = Color.LightSteelBlue;
                    if (Users.User_Level > Users.UserLevel.USER_LEVEL_0)
                    {
                        ToolStripMenuItem_Control.Enabled = true;
                    }
                }
                else
                {
                    StatusLabel_ParkConnection.Text = "Comm Error";
                    StatusLabel_ParkConnection.BackColor = Color.Red;
                }
                ToolStripMenuItem_ParkConnect.Text = "Disconnect turbine";
            }
            else
            {
                StatusLabel_ParkConnection.Text = "Disconnected";
                StatusLabel_ParkConnection.BackColor = Color.LightSteelBlue;
                ToolStripMenuItem_ParkConnect.Text = "Connect turbine";
                ToolStripMenuItem_Control.Enabled = false;
            }
        }

        public void UpdateIEC104ServerStatus()
        {
            switch (Program.myIEC104Server.ServerStatus)
            {
                case IEC104Server.IEC104_ServerStatus.STOPPED:
                    StatusLabel_IEC104.Text = "IEC104 server stopped";
                    StatusLabel_IEC104.BackColor = Color.LightSteelBlue;
                    StatusLabel_IEC104.ForeColor = Color.Black;
                    IEC104ToolStripMenuItem.Text = "Start IEC-104 server";
                    break;

                case IEC104Server.IEC104_ServerStatus.STARTING:
                    StatusLabel_IEC104.Text = "IEC104 server starting...";
                    StatusLabel_IEC104.BackColor = Color.Yellow;
                    StatusLabel_IEC104.ForeColor = Color.Black;
                    IEC104ToolStripMenuItem.Text = "Stop IEC-104 server";
                    break;

                case IEC104Server.IEC104_ServerStatus.ERROR_STARTING:
                    StatusLabel_IEC104.Text = "IEC104 starting error";
                    StatusLabel_IEC104.BackColor = Color.Red;
                    StatusLabel_IEC104.ForeColor = Color.Black;
                    IEC104ToolStripMenuItem.Text = "Stop IEC-104 server";
                    break;

                case IEC104Server.IEC104_ServerStatus.WAITING_RESTART:
                    StatusLabel_IEC104.Text = "IEC104 reconn. in: " + Program.myIEC104Server.ReconnectTimer.ToString() + " s";
                    StatusLabel_IEC104.BackColor = Color.Yellow;
                    StatusLabel_IEC104.ForeColor = Color.Black;
                    IEC104ToolStripMenuItem.Text = "Stop IEC-104 server";
                    break;

                case IEC104Server.IEC104_ServerStatus.RUNNING:
                    StatusLabel_IEC104.Text = "IEC104 server running (" + Program.myIEC104Server.NoOfClients.ToString() + " clients)";
                    StatusLabel_IEC104.BackColor = Color.Green;
                    StatusLabel_IEC104.ForeColor = Color.White;
                    IEC104ToolStripMenuItem.Text = "Stop IEC-104 server";
                    break;

                default:
                    StatusLabel_IEC104.Text = "IEC104 unknown status";
                    StatusLabel_IEC104.BackColor = Color.Yellow;
                    StatusLabel_IEC104.ForeColor = Color.Black;
                    IEC104ToolStripMenuItem.Text = "Start IEC-104 server";
                    break;
            }
        }

        public void Update_StatusLabel_Power(int _power)
        {
            StatusLabel_PowerSetpoint.Text = _power.ToString() + " kW";
        }

        private void Update_DatabaseStatus()
        {
            try
            {
                if (Program.myDatabases.DatabaseConnected) { StatusLabel_DatabaseStatus.Text = "Database online"; }
                else { StatusLabel_DatabaseStatus.Text = "Database offline"; }
            }
            catch { StatusLabel_DatabaseStatus.Text = "Database offline"; }
        }


        // USER LEVEL functions
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void LogIn()
        {
            string user = "";
            string password = "";

            LogInDialog myLogInDialog = new LogInDialog();
            DialogResult result = myLogInDialog.ShowDialog(ref user, ref password);

            // check if pressed OK
            if (result != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            // CHECK FOR USER
            if (user == USER_ADMIN)
            {
                // CHECK FOR PASSWORD
                if (password == PSWD_ADMIN)
                {
                    LogInAdmin();
                }
                else
                {
                    MessageBox.Show(this, "Wrong password", "Fault", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (user == USER_SERVICE)
            {
                // CHECK FOR PASSWORD
                if (password == PSWD_SERVICE)
                {
                    LogInService();
                }
                else
                {
                    MessageBox.Show(this, "Wrong password", "Fault", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (user == USER_DEVELOPER)
            {
                // CHECK FOR PASSWORD
                if (password == PSWD_DEVELOPER)
                {
                    LogInProgrammer();
                }
                else
                {
                    MessageBox.Show(this, "Wrong password", "Fault", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(this, "Wrong user", "Fault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // reload auto log off timer interval from settings
            timer_AutoLogOff.Interval = Eleon_SCADA.Settings.Application.AutoLogoutTime * 1000;
        }

        private void LogOut()
        {
            // disable Admin functionality
            ToolStripMenuItem_Control.Enabled = false;
            tabControl_Turbine_T01.TabPages.Remove(tabPage_Control);

            // disable Service functionality
            groupBox_Service_T01.Enabled = false;

            // disable Programmer functionality
            toolStripMenuItem_Tools.DropDownItems.Remove(debugToolStripMenuItem);


            Users.User_Level = Users.UserLevel.USER_LEVEL_0;
            label_UserLevel.Text = "LOGIN";
            label_UserLevel.BackColor = Color.DarkGray;
            label_UserLevel.ForeColor = Color.White;

            timer_AutoLogOff.Enabled = false;
        }

        private void LogInAdmin()
        {
            if (Program.myPark.myTurbines[1].CommunicationStatus)
            {
                ToolStripMenuItem_Control.Enabled = true;
            }

            tabControl_Turbine_T01.TabPages.Add(tabPage_Control);

            Users.User_Level = Users.UserLevel.USER_LEVEL_ADMIN;
            label_UserLevel.Text = "ADMINISTRATOR";
            label_UserLevel.BackColor = Color.Gold;
            label_UserLevel.ForeColor = Color.Black;
            timer_AutoLogOff.Enabled = true;
        }

        private void LogInService()
        {
            LogInAdmin();

            groupBox_Service_T01.Enabled = true;

            Users.User_Level = Users.UserLevel.USER_LEVEL_SERVICE;
            label_UserLevel.Text = "SERVICE";
            label_UserLevel.BackColor = Color.Gold;
            label_UserLevel.ForeColor = Color.Black;
            timer_AutoLogOff.Enabled = true;
        }

        private void LogInProgrammer()
        {
            LogInService();

            toolStripMenuItem_Tools.DropDownItems.Add(debugToolStripMenuItem);

            Users.User_Level = Users.UserLevel.USER_LEVEL_DEVELOPER;
            label_UserLevel.Text = "DEVELOPER";
            label_UserLevel.BackColor = Color.Gold;
            label_UserLevel.ForeColor = Color.Black;
            timer_AutoLogOff.Enabled = true;
        }
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        #endregion USER_INTERFACE_FUNCTIONS


        #region COMMANDS

        private void startParkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to\nstart the park ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) { Program.myPark.StartPark(); }
        }

        private void stopParkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to\nstop the park ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) { Program.myPark.StopPark(); }
        }


        private void powerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Dialog_VestasPowerControl form_PowerControl = new Dialog_VestasPowerControl();
            form_PowerControl.ShowDialog(this);
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to\nstart the turbines ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (result == DialogResult.Yes) { Program.myVestasController.StartPark(); }
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to\nstop the turbines ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (result == DialogResult.Yes) { Program.myVestasController.StopPark(); }
        }

        private void button_Start_T01_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Are you sure you want to stat the turbine ?",
                    "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                try
                {
                    Program.myPark.myTurbines[1].Start_Turbine();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        private void button_Pause_T01_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Are you sure you want to stop the turbine ?",
                    "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                try
                {
                    Program.myPark.myTurbines[1].Stop_Turbine();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        private void button_Ack_T01_Click(object sender, EventArgs e)
        {
            try
            {
                Program.myPark.myTurbines[1].Reset_Turbine();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void button_ActivePowerSetpointSend_Click(object sender, EventArgs e)
        {
            short Setpoint;
            try
            {
                Setpoint = Convert.ToInt16(textBox_ActivePowerSetpoint.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid input data - " + ex.Message, "Exception");
                return;
            }

            try
            {
                Program.myVestasController.Set_ActivePowerSetpoint(1, Setpoint);
                MessageBox.Show("Setpoint sent", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            // clear setpoint textbox after procedure
            textBox_ActivePowerSetpoint.Text = "";
        }

        private void button_ReactivePowerSetpointSend_Click(object sender, EventArgs e)
        {
            short Setpoint;

            try
            {
                Setpoint = Convert.ToInt16(textBox_ReactivePowerSetpoint.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid input data - " + ex.Message, "Exception");
                return;
            }

            try
            {
                Program.myVestasController.Set_ReactivePowerSetpoint(1, Setpoint);
                MessageBox.Show("Setpoint sent", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            // clear setpoint textbox after procedure
            textBox_ReactivePowerSetpoint.Text = "";
        }
        #endregion COMMANDS

        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            // if closing confirmation control active then ask confirmation before closing
            if (ClosingConfirmation)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to close application ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes) { e.Cancel = true; }
            }
        }
    }
}