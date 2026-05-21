namespace Eleon_SCADA.Forms
{
    partial class Form_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.label_BannerBackground = new System.Windows.Forms.Label();
            this.toolStripMenuItem_Application = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_ParkConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.TSOLinkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_File_Close = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Settings = new System.Windows.Forms.ToolStripMenuItem();
            this.ParkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.turbinesControlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSOInterfaceToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.marketIfToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.alarmDispatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.communicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vestasCOMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addInterfaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Info = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.licenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem_Tools = new System.Windows.Forms.ToolStripMenuItem();
            this.dataLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusCodesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataChartsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSOInterfaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Control = new System.Windows.Forms.ToolStripMenuItem();
            this.startParkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopParkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer_Update_fast = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel_ParkConnection = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLabel_DatabaseStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLabel_SetpointMode = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLabel_PowerSetpoint = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLabel_Market = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLabel_TSOLink = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer_Update_slow = new System.Windows.Forms.Timer(this.components);
            this.tabControl_Main = new System.Windows.Forms.TabControl();
            this.tabPage_T01 = new System.Windows.Forms.TabPage();
            this.tabControl_Turbine_T01 = new System.Windows.Forms.TabControl();
            this.tabPage_Overview = new System.Windows.Forms.TabPage();
            this.label_CommStatus_01 = new System.Windows.Forms.Label();
            this.label_RemoteControl = new System.Windows.Forms.Label();
            this.label_ServiceState = new System.Windows.Forms.Label();
            this.label_G_Connected = new System.Windows.Forms.Label();
            this.label_TurbineAvailable = new System.Windows.Forms.Label();
            this.label_YawStatus = new System.Windows.Forms.Label();
            this.label_Error_Txt = new System.Windows.Forms.Label();
            this.label_YawStateTxt = new System.Windows.Forms.Label();
            this.label_PendOpStateTxt = new System.Windows.Forms.Label();
            this.label_OpStateTxt = new System.Windows.Forms.Label();
            this.label_StateTxt = new System.Windows.Forms.Label();
            this.label_YawState = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label_PendOperationState = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label_OperationState = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label_PitchAngle_01 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label_ErrorCode_01 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_Power_01 = new System.Windows.Forms.Label();
            this.label_StateCode_01 = new System.Windows.Forms.Label();
            this.label_Power = new System.Windows.Forms.Label();
            this.label_RPM_avg = new System.Windows.Forms.Label();
            this.label_RPM_gen_01 = new System.Windows.Forms.Label();
            this.label_StateCode = new System.Windows.Forms.Label();
            this.label_Wind_01 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage_Electrical = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label_ReactivePowerSetpoint = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label_PowerSetpoint = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label_PowerControllerSetpoint = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.label_Production = new System.Windows.Forms.Label();
            this.label83 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label_Current_L3 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label_Current_L2 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label_Current_L1 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label_Voltage_L3 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label_Voltage_L2 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label_Voltage_L1 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label_Frequency = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label_CosPhi = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label_Power_1s = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tabPage_Temperatures = new System.Windows.Forms.TabPage();
            this.label79 = new System.Windows.Forms.Label();
            this.label_Temp_CoolWaterVCS = new System.Windows.Forms.Label();
            this.label81 = new System.Windows.Forms.Label();
            this.label82 = new System.Windows.Forms.Label();
            this.label_Temp_GeneratorBearing = new System.Windows.Forms.Label();
            this.label84 = new System.Windows.Forms.Label();
            this.label85 = new System.Windows.Forms.Label();
            this.label_Temp_HVTransformerL3 = new System.Windows.Forms.Label();
            this.label87 = new System.Windows.Forms.Label();
            this.label88 = new System.Windows.Forms.Label();
            this.label_Temp_HVTransformerL2 = new System.Windows.Forms.Label();
            this.label90 = new System.Windows.Forms.Label();
            this.label91 = new System.Windows.Forms.Label();
            this.label_Temp_HVTransformerL1 = new System.Windows.Forms.Label();
            this.label93 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.label_Temp_Spinner = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.label_Temp_BusBar = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.label_Temp_TopController = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.label_Temp_Nacelle = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.label_Temp_HubController = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label_Temp_GearBearing = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label_Temp_SlipringVCS = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label_Temp_Generator = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label_Temp_Gear = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label_Temp_Environment = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label_Temp_Hydraulic = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.tabPage_Control = new System.Windows.Forms.TabPage();
            this.groupBox_Service_T01 = new System.Windows.Forms.GroupBox();
            this.textBox_ReactivePowerSetpoint = new System.Windows.Forms.TextBox();
            this.textBox_ActivePowerSetpoint = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label_ActivePowerSetpoint_1 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.button_ReactivePowerSetpointSend = new System.Windows.Forms.Button();
            this.button_ActivePowerSetpointSend = new System.Windows.Forms.Button();
            this.label_ReactivePowerSetpoint_1 = new System.Windows.Forms.Label();
            this.button_ParameterTool = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.button_Ack_T01 = new System.Windows.Forms.Button();
            this.button_Start_T01 = new System.Windows.Forms.Button();
            this.button_Pause_T01 = new System.Windows.Forms.Button();
            this.label_ParkActivePower = new System.Windows.Forms.Label();
            this.label_ParkWindSpeed = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label_ParkProduction = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.timer_AutoLogOff = new System.Windows.Forms.Timer(this.components);
            this.label_UserLevel = new System.Windows.Forms.Label();
            this.button_AlarmAnnouncementEnable = new System.Windows.Forms.PictureBox();
            this.myToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.marketIfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControl_Main.SuspendLayout();
            this.tabPage_T01.SuspendLayout();
            this.tabControl_Turbine_T01.SuspendLayout();
            this.tabPage_Overview.SuspendLayout();
            this.tabPage_Electrical.SuspendLayout();
            this.tabPage_Temperatures.SuspendLayout();
            this.tabPage_Control.SuspendLayout();
            this.groupBox_Service_T01.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.button_AlarmAnnouncementEnable)).BeginInit();
            this.SuspendLayout();
            // 
            // label_BannerBackground
            // 
            this.label_BannerBackground.BackColor = System.Drawing.Color.SteelBlue;
            this.label_BannerBackground.Location = new System.Drawing.Point(13, 24);
            this.label_BannerBackground.Name = "label_BannerBackground";
            this.label_BannerBackground.Size = new System.Drawing.Size(800, 40);
            this.label_BannerBackground.TabIndex = 147;
            // 
            // toolStripMenuItem_Application
            // 
            this.toolStripMenuItem_Application.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_ParkConnect,
            this.TSOLinkToolStripMenuItem,
            this.preferencesToolStripMenuItem,
            this.toolStripMenuItem_File_Close});
            this.toolStripMenuItem_Application.Name = "toolStripMenuItem_Application";
            this.toolStripMenuItem_Application.Size = new System.Drawing.Size(81, 20);
            this.toolStripMenuItem_Application.Text = "Application";
            // 
            // ToolStripMenuItem_ParkConnect
            // 
            this.ToolStripMenuItem_ParkConnect.Name = "ToolStripMenuItem_ParkConnect";
            this.ToolStripMenuItem_ParkConnect.Size = new System.Drawing.Size(164, 22);
            this.ToolStripMenuItem_ParkConnect.Text = "Connect turbine";
            this.ToolStripMenuItem_ParkConnect.Click += new System.EventHandler(this.connectParkToolStripMenuItem_Click);
            // 
            // TSOLinkToolStripMenuItem
            // 
            this.TSOLinkToolStripMenuItem.Name = "TSOLinkToolStripMenuItem";
            this.TSOLinkToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.TSOLinkToolStripMenuItem.Text = "Start TSO link";
            this.TSOLinkToolStripMenuItem.Click += new System.EventHandler(this.IEC104ToolStripMenuItem_Click);
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.preferencesToolStripMenuItem.Text = "Preferences...";
            this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
            // 
            // toolStripMenuItem_File_Close
            // 
            this.toolStripMenuItem_File_Close.Name = "toolStripMenuItem_File_Close";
            this.toolStripMenuItem_File_Close.Size = new System.Drawing.Size(164, 22);
            this.toolStripMenuItem_File_Close.Text = "Close";
            this.toolStripMenuItem_File_Close.Click += new System.EventHandler(this.toolStripMenuItem_File_Close_Click);
            // 
            // ToolStripMenuItem_Settings
            // 
            this.ToolStripMenuItem_Settings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ParkToolStripMenuItem,
            this.turbinesControlToolStripMenuItem,
            this.TSOInterfaceToolStripMenuItem1,
            this.marketIfToolStripMenuItem1,
            this.alarmDispatchToolStripMenuItem,
            this.communicationToolStripMenuItem,
            this.databaseToolStripMenuItem});
            this.ToolStripMenuItem_Settings.Name = "ToolStripMenuItem_Settings";
            this.ToolStripMenuItem_Settings.Size = new System.Drawing.Size(65, 20);
            this.ToolStripMenuItem_Settings.Text = "Settings";
            // 
            // ParkToolStripMenuItem
            // 
            this.ParkToolStripMenuItem.Name = "ParkToolStripMenuItem";
            this.ParkToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.ParkToolStripMenuItem.Text = "Park";
            this.ParkToolStripMenuItem.Click += new System.EventHandler(this.vestasControllerToolStripMenuItem1_Click);
            // 
            // turbinesControlToolStripMenuItem
            // 
            this.turbinesControlToolStripMenuItem.Name = "turbinesControlToolStripMenuItem";
            this.turbinesControlToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.turbinesControlToolStripMenuItem.Text = "Turbines";
            this.turbinesControlToolStripMenuItem.Click += new System.EventHandler(this.powerControlToolStripMenuItem_Click);
            // 
            // TSOInterfaceToolStripMenuItem1
            // 
            this.TSOInterfaceToolStripMenuItem1.Name = "TSOInterfaceToolStripMenuItem1";
            this.TSOInterfaceToolStripMenuItem1.Size = new System.Drawing.Size(194, 22);
            this.TSOInterfaceToolStripMenuItem1.Text = "TSO Interface";
            this.TSOInterfaceToolStripMenuItem1.Click += new System.EventHandler(this.iEC104ServerToolStripMenuItem1_Click);
            // 
            // marketIfToolStripMenuItem1
            // 
            this.marketIfToolStripMenuItem1.Name = "marketIfToolStripMenuItem1";
            this.marketIfToolStripMenuItem1.Size = new System.Drawing.Size(194, 22);
            this.marketIfToolStripMenuItem1.Text = "Market Interface";
            this.marketIfToolStripMenuItem1.Click += new System.EventHandler(this.marketIfToolStripMenuItem_Click);
            // 
            // alarmDispatchToolStripMenuItem
            // 
            this.alarmDispatchToolStripMenuItem.Name = "alarmDispatchToolStripMenuItem";
            this.alarmDispatchToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.alarmDispatchToolStripMenuItem.Text = "Alarm announcement";
            this.alarmDispatchToolStripMenuItem.Click += new System.EventHandler(this.alarmDispatchToolStripMenuItem_Click);
            // 
            // communicationToolStripMenuItem
            // 
            this.communicationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vestasCOMToolStripMenuItem,
            this.addInterfaceToolStripMenuItem});
            this.communicationToolStripMenuItem.Name = "communicationToolStripMenuItem";
            this.communicationToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.communicationToolStripMenuItem.Text = "Communication";
            // 
            // vestasCOMToolStripMenuItem
            // 
            this.vestasCOMToolStripMenuItem.Name = "vestasCOMToolStripMenuItem";
            this.vestasCOMToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.vestasCOMToolStripMenuItem.Text = "Vestas COM";
            this.vestasCOMToolStripMenuItem.Click += new System.EventHandler(this.vestasCOMToolStripMenuItem_Click);
            // 
            // addInterfaceToolStripMenuItem
            // 
            this.addInterfaceToolStripMenuItem.Enabled = false;
            this.addInterfaceToolStripMenuItem.Name = "addInterfaceToolStripMenuItem";
            this.addInterfaceToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.addInterfaceToolStripMenuItem.Text = "Add Interface...";
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.databaseToolStripMenuItem.Text = "Database";
            this.databaseToolStripMenuItem.Click += new System.EventHandler(this.databaseToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem_Info
            // 
            this.ToolStripMenuItem_Info.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.licenseToolStripMenuItem});
            this.ToolStripMenuItem_Info.Name = "ToolStripMenuItem_Info";
            this.ToolStripMenuItem_Info.Size = new System.Drawing.Size(42, 20);
            this.ToolStripMenuItem_Info.Text = "Info";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // licenseToolStripMenuItem
            // 
            this.licenseToolStripMenuItem.Name = "licenseToolStripMenuItem";
            this.licenseToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.licenseToolStripMenuItem.Text = "License";
            this.licenseToolStripMenuItem.Click += new System.EventHandler(this.licenseToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_Application,
            this.toolStripMenuItem_Tools,
            this.ToolStripMenuItem_Settings,
            this.ToolStripMenuItem_Control,
            this.ToolStripMenuItem_Info});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(824, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem_Tools
            // 
            this.toolStripMenuItem_Tools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataLogsToolStripMenuItem,
            this.TSOInterfaceToolStripMenuItem,
            this.marketIfToolStripMenuItem,
            this.debugToolStripMenuItem});
            this.toolStripMenuItem_Tools.Name = "toolStripMenuItem_Tools";
            this.toolStripMenuItem_Tools.Size = new System.Drawing.Size(47, 20);
            this.toolStripMenuItem_Tools.Text = "Tools";
            // 
            // dataLogsToolStripMenuItem
            // 
            this.dataLogsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusCodesToolStripMenuItem,
            this.dataChartsToolStripMenuItem,
            this.productionToolStripMenuItem});
            this.dataLogsToolStripMenuItem.Name = "dataLogsToolStripMenuItem";
            this.dataLogsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.dataLogsToolStripMenuItem.Text = "Logs";
            // 
            // statusCodesToolStripMenuItem
            // 
            this.statusCodesToolStripMenuItem.Name = "statusCodesToolStripMenuItem";
            this.statusCodesToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.statusCodesToolStripMenuItem.Text = "Status logs";
            this.statusCodesToolStripMenuItem.Click += new System.EventHandler(this.statusCodesToolStripMenuItem_Click);
            // 
            // dataChartsToolStripMenuItem
            // 
            this.dataChartsToolStripMenuItem.Name = "dataChartsToolStripMenuItem";
            this.dataChartsToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.dataChartsToolStripMenuItem.Text = "Data charts";
            this.dataChartsToolStripMenuItem.Click += new System.EventHandler(this.dataChartsToolStripMenuItem_Click);
            // 
            // productionToolStripMenuItem
            // 
            this.productionToolStripMenuItem.Name = "productionToolStripMenuItem";
            this.productionToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.productionToolStripMenuItem.Text = "Production";
            this.productionToolStripMenuItem.Click += new System.EventHandler(this.productionToolStripMenuItem_Click);
            // 
            // TSOInterfaceToolStripMenuItem
            // 
            this.TSOInterfaceToolStripMenuItem.Name = "TSOInterfaceToolStripMenuItem";
            this.TSOInterfaceToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.TSOInterfaceToolStripMenuItem.Text = "TSO Interface";
            this.TSOInterfaceToolStripMenuItem.Click += new System.EventHandler(this.iEC104InterfaceToolStripMenuItem_Click);
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.debugToolStripMenuItem.Text = "Developer";
            this.debugToolStripMenuItem.Click += new System.EventHandler(this.debugToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem_Control
            // 
            this.ToolStripMenuItem_Control.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startParkToolStripMenuItem,
            this.stopParkToolStripMenuItem});
            this.ToolStripMenuItem_Control.Enabled = false;
            this.ToolStripMenuItem_Control.Name = "ToolStripMenuItem_Control";
            this.ToolStripMenuItem_Control.Size = new System.Drawing.Size(60, 20);
            this.ToolStripMenuItem_Control.Text = "Control";
            // 
            // startParkToolStripMenuItem
            // 
            this.startParkToolStripMenuItem.Name = "startParkToolStripMenuItem";
            this.startParkToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.startParkToolStripMenuItem.Text = "Start park";
            this.startParkToolStripMenuItem.Click += new System.EventHandler(this.startParkToolStripMenuItem_Click);
            // 
            // stopParkToolStripMenuItem
            // 
            this.stopParkToolStripMenuItem.Name = "stopParkToolStripMenuItem";
            this.stopParkToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.stopParkToolStripMenuItem.Text = "Stop park";
            this.stopParkToolStripMenuItem.Click += new System.EventHandler(this.stopParkToolStripMenuItem_Click);
            // 
            // timer_Update_fast
            // 
            this.timer_Update_fast.Enabled = true;
            this.timer_Update_fast.Interval = 300;
            this.timer_Update_fast.Tick += new System.EventHandler(this.timer_Update_fast_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel_ParkConnection,
            this.StatusLabel_DatabaseStatus,
            this.StatusLabel_SetpointMode,
            this.StatusLabel_PowerSetpoint,
            this.StatusLabel_Market,
            this.toolStripStatusLabel2,
            this.StatusLabel_TSOLink});
            this.statusStrip1.Location = new System.Drawing.Point(0, 473);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(824, 25);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 58;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabel_ParkConnection
            // 
            this.StatusLabel_ParkConnection.AutoSize = false;
            this.StatusLabel_ParkConnection.BackColor = System.Drawing.Color.LightSteelBlue;
            this.StatusLabel_ParkConnection.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.StatusLabel_ParkConnection.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.StatusLabel_ParkConnection.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.StatusLabel_ParkConnection.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
            this.StatusLabel_ParkConnection.Name = "StatusLabel_ParkConnection";
            this.StatusLabel_ParkConnection.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.StatusLabel_ParkConnection.Size = new System.Drawing.Size(110, 20);
            this.StatusLabel_ParkConnection.Text = "Disconnected";
            this.StatusLabel_ParkConnection.Click += new System.EventHandler(this.StatusLabel_ParkConnection_Click);
            // 
            // StatusLabel_DatabaseStatus
            // 
            this.StatusLabel_DatabaseStatus.AutoSize = false;
            this.StatusLabel_DatabaseStatus.BackColor = System.Drawing.Color.LightSteelBlue;
            this.StatusLabel_DatabaseStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.StatusLabel_DatabaseStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.StatusLabel_DatabaseStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.StatusLabel_DatabaseStatus.Margin = new System.Windows.Forms.Padding(20, 3, 0, 2);
            this.StatusLabel_DatabaseStatus.Name = "StatusLabel_DatabaseStatus";
            this.StatusLabel_DatabaseStatus.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.StatusLabel_DatabaseStatus.Size = new System.Drawing.Size(120, 20);
            this.StatusLabel_DatabaseStatus.Text = "No data logging";
            // 
            // StatusLabel_SetpointMode
            // 
            this.StatusLabel_SetpointMode.AutoSize = false;
            this.StatusLabel_SetpointMode.BackColor = System.Drawing.Color.LightSteelBlue;
            this.StatusLabel_SetpointMode.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.StatusLabel_SetpointMode.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.StatusLabel_SetpointMode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.StatusLabel_SetpointMode.Margin = new System.Windows.Forms.Padding(20, 3, 0, 2);
            this.StatusLabel_SetpointMode.Name = "StatusLabel_SetpointMode";
            this.StatusLabel_SetpointMode.Size = new System.Drawing.Size(110, 20);
            this.StatusLabel_SetpointMode.Text = "Automatic setpoint";
            // 
            // StatusLabel_PowerSetpoint
            // 
            this.StatusLabel_PowerSetpoint.AutoSize = false;
            this.StatusLabel_PowerSetpoint.BackColor = System.Drawing.Color.LightSteelBlue;
            this.StatusLabel_PowerSetpoint.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.StatusLabel_PowerSetpoint.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.StatusLabel_PowerSetpoint.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.StatusLabel_PowerSetpoint.Name = "StatusLabel_PowerSetpoint";
            this.StatusLabel_PowerSetpoint.Size = new System.Drawing.Size(100, 20);
            this.StatusLabel_PowerSetpoint.Text = "2000 / 2000 kW";
            // 
            // StatusLabel_Market
            // 
            this.StatusLabel_Market.AutoSize = false;
            this.StatusLabel_Market.BackColor = System.Drawing.Color.LightGray;
            this.StatusLabel_Market.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.StatusLabel_Market.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.StatusLabel_Market.ForeColor = System.Drawing.SystemColors.ControlText;
            this.StatusLabel_Market.Margin = new System.Windows.Forms.Padding(20, 3, 0, 2);
            this.StatusLabel_Market.Name = "StatusLabel_Market";
            this.StatusLabel_Market.Size = new System.Drawing.Size(130, 20);
            this.StatusLabel_Market.Text = "Market Ctrl Off";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(9, 20);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // StatusLabel_TSOLink
            // 
            this.StatusLabel_TSOLink.AutoSize = false;
            this.StatusLabel_TSOLink.BackColor = System.Drawing.Color.LightGray;
            this.StatusLabel_TSOLink.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.StatusLabel_TSOLink.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.StatusLabel_TSOLink.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.StatusLabel_TSOLink.ForeColor = System.Drawing.SystemColors.ControlText;
            this.StatusLabel_TSOLink.Name = "StatusLabel_TSOLink";
            this.StatusLabel_TSOLink.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.StatusLabel_TSOLink.Size = new System.Drawing.Size(160, 20);
            this.StatusLabel_TSOLink.Text = "IEC-104 server stopped";
            // 
            // timer_Update_slow
            // 
            this.timer_Update_slow.Enabled = true;
            this.timer_Update_slow.Interval = 1000;
            this.timer_Update_slow.Tick += new System.EventHandler(this.timer_Update_slow_Tick);
            // 
            // tabControl_Main
            // 
            this.tabControl_Main.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl_Main.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl_Main.Controls.Add(this.tabPage_T01);
            this.tabControl_Main.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl_Main.Location = new System.Drawing.Point(12, 64);
            this.tabControl_Main.Multiline = true;
            this.tabControl_Main.Name = "tabControl_Main";
            this.tabControl_Main.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabControl_Main.SelectedIndex = 0;
            this.tabControl_Main.Size = new System.Drawing.Size(800, 406);
            this.tabControl_Main.TabIndex = 129;
            // 
            // tabPage_T01
            // 
            this.tabPage_T01.BackColor = System.Drawing.Color.SteelBlue;
            this.tabPage_T01.Controls.Add(this.tabControl_Turbine_T01);
            this.tabPage_T01.Location = new System.Drawing.Point(4, 30);
            this.tabPage_T01.Name = "tabPage_T01";
            this.tabPage_T01.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_T01.Size = new System.Drawing.Size(792, 372);
            this.tabPage_T01.TabIndex = 1;
            this.tabPage_T01.Text = "T01 - Vestas V80";
            // 
            // tabControl_Turbine_T01
            // 
            this.tabControl_Turbine_T01.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl_Turbine_T01.Controls.Add(this.tabPage_Overview);
            this.tabControl_Turbine_T01.Controls.Add(this.tabPage_Electrical);
            this.tabControl_Turbine_T01.Controls.Add(this.tabPage_Temperatures);
            this.tabControl_Turbine_T01.Controls.Add(this.tabPage_Control);
            this.tabControl_Turbine_T01.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl_Turbine_T01.Location = new System.Drawing.Point(-4, 0);
            this.tabControl_Turbine_T01.Name = "tabControl_Turbine_T01";
            this.tabControl_Turbine_T01.SelectedIndex = 0;
            this.tabControl_Turbine_T01.Size = new System.Drawing.Size(800, 376);
            this.tabControl_Turbine_T01.TabIndex = 128;
            // 
            // tabPage_Overview
            // 
            this.tabPage_Overview.BackColor = System.Drawing.Color.SlateGray;
            this.tabPage_Overview.Controls.Add(this.label_CommStatus_01);
            this.tabPage_Overview.Controls.Add(this.label_RemoteControl);
            this.tabPage_Overview.Controls.Add(this.label_ServiceState);
            this.tabPage_Overview.Controls.Add(this.label_G_Connected);
            this.tabPage_Overview.Controls.Add(this.label_TurbineAvailable);
            this.tabPage_Overview.Controls.Add(this.label_YawStatus);
            this.tabPage_Overview.Controls.Add(this.label_Error_Txt);
            this.tabPage_Overview.Controls.Add(this.label_YawStateTxt);
            this.tabPage_Overview.Controls.Add(this.label_PendOpStateTxt);
            this.tabPage_Overview.Controls.Add(this.label_OpStateTxt);
            this.tabPage_Overview.Controls.Add(this.label_StateTxt);
            this.tabPage_Overview.Controls.Add(this.label_YawState);
            this.tabPage_Overview.Controls.Add(this.label31);
            this.tabPage_Overview.Controls.Add(this.label_PendOperationState);
            this.tabPage_Overview.Controls.Add(this.label13);
            this.tabPage_Overview.Controls.Add(this.label_OperationState);
            this.tabPage_Overview.Controls.Add(this.label11);
            this.tabPage_Overview.Controls.Add(this.label7);
            this.tabPage_Overview.Controls.Add(this.label_PitchAngle_01);
            this.tabPage_Overview.Controls.Add(this.label10);
            this.tabPage_Overview.Controls.Add(this.label_ErrorCode_01);
            this.tabPage_Overview.Controls.Add(this.label8);
            this.tabPage_Overview.Controls.Add(this.label5);
            this.tabPage_Overview.Controls.Add(this.label4);
            this.tabPage_Overview.Controls.Add(this.label3);
            this.tabPage_Overview.Controls.Add(this.label_Power_01);
            this.tabPage_Overview.Controls.Add(this.label_StateCode_01);
            this.tabPage_Overview.Controls.Add(this.label_Power);
            this.tabPage_Overview.Controls.Add(this.label_RPM_avg);
            this.tabPage_Overview.Controls.Add(this.label_RPM_gen_01);
            this.tabPage_Overview.Controls.Add(this.label_StateCode);
            this.tabPage_Overview.Controls.Add(this.label_Wind_01);
            this.tabPage_Overview.Controls.Add(this.label1);
            this.tabPage_Overview.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage_Overview.Location = new System.Drawing.Point(4, 25);
            this.tabPage_Overview.Name = "tabPage_Overview";
            this.tabPage_Overview.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Overview.Size = new System.Drawing.Size(792, 347);
            this.tabPage_Overview.TabIndex = 0;
            this.tabPage_Overview.Text = "Overview";
            // 
            // label_CommStatus_01
            // 
            this.label_CommStatus_01.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_CommStatus_01.BackColor = System.Drawing.Color.Red;
            this.label_CommStatus_01.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_CommStatus_01.ForeColor = System.Drawing.Color.White;
            this.label_CommStatus_01.Location = new System.Drawing.Point(0, 0);
            this.label_CommStatus_01.Name = "label_CommStatus_01";
            this.label_CommStatus_01.Size = new System.Drawing.Size(792, 23);
            this.label_CommStatus_01.TabIndex = 180;
            this.label_CommStatus_01.Text = "No communication";
            this.label_CommStatus_01.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_RemoteControl
            // 
            this.label_RemoteControl.BackColor = System.Drawing.Color.DimGray;
            this.label_RemoteControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_RemoteControl.ForeColor = System.Drawing.Color.White;
            this.label_RemoteControl.Location = new System.Drawing.Point(470, 131);
            this.label_RemoteControl.Name = "label_RemoteControl";
            this.label_RemoteControl.Size = new System.Drawing.Size(289, 23);
            this.label_RemoteControl.TabIndex = 179;
            this.label_RemoteControl.Text = "Remote control disabled";
            // 
            // label_ServiceState
            // 
            this.label_ServiceState.BackColor = System.Drawing.Color.DimGray;
            this.label_ServiceState.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ServiceState.ForeColor = System.Drawing.Color.White;
            this.label_ServiceState.Location = new System.Drawing.Point(470, 106);
            this.label_ServiceState.Name = "label_ServiceState";
            this.label_ServiceState.Size = new System.Drawing.Size(289, 23);
            this.label_ServiceState.TabIndex = 178;
            this.label_ServiceState.Text = "Service state unactive";
            // 
            // label_G_Connected
            // 
            this.label_G_Connected.BackColor = System.Drawing.Color.DimGray;
            this.label_G_Connected.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_G_Connected.ForeColor = System.Drawing.Color.White;
            this.label_G_Connected.Location = new System.Drawing.Point(470, 81);
            this.label_G_Connected.Name = "label_G_Connected";
            this.label_G_Connected.Size = new System.Drawing.Size(289, 23);
            this.label_G_Connected.TabIndex = 177;
            this.label_G_Connected.Text = "Gen not connected";
            // 
            // label_TurbineAvailable
            // 
            this.label_TurbineAvailable.BackColor = System.Drawing.Color.DimGray;
            this.label_TurbineAvailable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TurbineAvailable.ForeColor = System.Drawing.Color.White;
            this.label_TurbineAvailable.Location = new System.Drawing.Point(470, 56);
            this.label_TurbineAvailable.Name = "label_TurbineAvailable";
            this.label_TurbineAvailable.Size = new System.Drawing.Size(289, 23);
            this.label_TurbineAvailable.TabIndex = 176;
            this.label_TurbineAvailable.Text = "Turbine available";
            // 
            // label_YawStatus
            // 
            this.label_YawStatus.BackColor = System.Drawing.Color.LightSlateGray;
            this.label_YawStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_YawStatus.ForeColor = System.Drawing.Color.White;
            this.label_YawStatus.Location = new System.Drawing.Point(470, 292);
            this.label_YawStatus.Name = "label_YawStatus";
            this.label_YawStatus.Size = new System.Drawing.Size(289, 23);
            this.label_YawStatus.TabIndex = 175;
            this.label_YawStatus.Text = "Yaw stopped";
            // 
            // label_Error_Txt
            // 
            this.label_Error_Txt.BackColor = System.Drawing.Color.LightSlateGray;
            this.label_Error_Txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Error_Txt.ForeColor = System.Drawing.Color.White;
            this.label_Error_Txt.Location = new System.Drawing.Point(470, 194);
            this.label_Error_Txt.Name = "label_Error_Txt";
            this.label_Error_Txt.Size = new System.Drawing.Size(289, 23);
            this.label_Error_Txt.TabIndex = 174;
            this.label_Error_Txt.Text = "Error description";
            // 
            // label_YawStateTxt
            // 
            this.label_YawStateTxt.BackColor = System.Drawing.Color.LightSlateGray;
            this.label_YawStateTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_YawStateTxt.ForeColor = System.Drawing.Color.White;
            this.label_YawStateTxt.Location = new System.Drawing.Point(470, 269);
            this.label_YawStateTxt.Name = "label_YawStateTxt";
            this.label_YawStateTxt.Size = new System.Drawing.Size(289, 23);
            this.label_YawStateTxt.TabIndex = 173;
            this.label_YawStateTxt.Text = "State description";
            // 
            // label_PendOpStateTxt
            // 
            this.label_PendOpStateTxt.BackColor = System.Drawing.Color.LightSlateGray;
            this.label_PendOpStateTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_PendOpStateTxt.ForeColor = System.Drawing.Color.White;
            this.label_PendOpStateTxt.Location = new System.Drawing.Point(470, 244);
            this.label_PendOpStateTxt.Name = "label_PendOpStateTxt";
            this.label_PendOpStateTxt.Size = new System.Drawing.Size(289, 23);
            this.label_PendOpStateTxt.TabIndex = 172;
            this.label_PendOpStateTxt.Text = "State description";
            // 
            // label_OpStateTxt
            // 
            this.label_OpStateTxt.BackColor = System.Drawing.Color.LightSlateGray;
            this.label_OpStateTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_OpStateTxt.ForeColor = System.Drawing.Color.White;
            this.label_OpStateTxt.Location = new System.Drawing.Point(470, 219);
            this.label_OpStateTxt.Name = "label_OpStateTxt";
            this.label_OpStateTxt.Size = new System.Drawing.Size(289, 23);
            this.label_OpStateTxt.TabIndex = 171;
            this.label_OpStateTxt.Text = "State description";
            // 
            // label_StateTxt
            // 
            this.label_StateTxt.BackColor = System.Drawing.Color.LightSlateGray;
            this.label_StateTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_StateTxt.ForeColor = System.Drawing.Color.White;
            this.label_StateTxt.Location = new System.Drawing.Point(470, 169);
            this.label_StateTxt.Name = "label_StateTxt";
            this.label_StateTxt.Size = new System.Drawing.Size(289, 23);
            this.label_StateTxt.TabIndex = 170;
            this.label_StateTxt.Text = "State description";
            // 
            // label_YawState
            // 
            this.label_YawState.BackColor = System.Drawing.Color.Silver;
            this.label_YawState.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_YawState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_YawState.Location = new System.Drawing.Point(433, 269);
            this.label_YawState.Name = "label_YawState";
            this.label_YawState.Size = new System.Drawing.Size(33, 23);
            this.label_YawState.TabIndex = 153;
            this.label_YawState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label31.Location = new System.Drawing.Point(356, 270);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(74, 18);
            this.label31.TabIndex = 152;
            this.label31.Text = "Yaw State";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_PendOperationState
            // 
            this.label_PendOperationState.BackColor = System.Drawing.Color.Silver;
            this.label_PendOperationState.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_PendOperationState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_PendOperationState.Location = new System.Drawing.Point(433, 244);
            this.label_PendOperationState.Name = "label_PendOperationState";
            this.label_PendOperationState.Size = new System.Drawing.Size(33, 23);
            this.label_PendOperationState.TabIndex = 141;
            this.label_PendOperationState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label13.Location = new System.Drawing.Point(278, 245);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(149, 18);
            this.label13.TabIndex = 140;
            this.label13.Text = "Pend Operation State";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_OperationState
            // 
            this.label_OperationState.BackColor = System.Drawing.Color.Silver;
            this.label_OperationState.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_OperationState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_OperationState.Location = new System.Drawing.Point(433, 219);
            this.label_OperationState.Name = "label_OperationState";
            this.label_OperationState.Size = new System.Drawing.Size(33, 23);
            this.label_OperationState.TabIndex = 139;
            this.label_OperationState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label11.Location = new System.Drawing.Point(316, 220);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(111, 18);
            this.label11.TabIndex = 138;
            this.label11.Text = "Operation State";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label7.Location = new System.Drawing.Point(211, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 16);
            this.label7.TabIndex = 137;
            this.label7.Text = "deg";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_PitchAngle_01
            // 
            this.label_PitchAngle_01.BackColor = System.Drawing.Color.Silver;
            this.label_PitchAngle_01.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_PitchAngle_01.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_PitchAngle_01.Location = new System.Drawing.Point(143, 118);
            this.label_PitchAngle_01.Name = "label_PitchAngle_01";
            this.label_PitchAngle_01.Size = new System.Drawing.Size(62, 29);
            this.label_PitchAngle_01.TabIndex = 136;
            this.label_PitchAngle_01.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label10.Location = new System.Drawing.Point(93, 123);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 20);
            this.label10.TabIndex = 135;
            this.label10.Text = "Pitch";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_ErrorCode_01
            // 
            this.label_ErrorCode_01.BackColor = System.Drawing.Color.Silver;
            this.label_ErrorCode_01.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_ErrorCode_01.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_ErrorCode_01.Location = new System.Drawing.Point(433, 194);
            this.label_ErrorCode_01.Name = "label_ErrorCode_01";
            this.label_ErrorCode_01.Size = new System.Drawing.Size(33, 23);
            this.label_ErrorCode_01.TabIndex = 134;
            this.label_ErrorCode_01.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label8.Location = new System.Drawing.Point(344, 197);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 20);
            this.label8.TabIndex = 133;
            this.label8.Text = "Error code";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label5.Location = new System.Drawing.Point(211, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 16);
            this.label5.TabIndex = 131;
            this.label5.Text = "rpm";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label4.Location = new System.Drawing.Point(211, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 16);
            this.label4.TabIndex = 130;
            this.label4.Text = "m/s";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label3.Location = new System.Drawing.Point(211, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 16);
            this.label3.TabIndex = 129;
            this.label3.Text = "kW";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Power_01
            // 
            this.label_Power_01.BackColor = System.Drawing.Color.Silver;
            this.label_Power_01.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_Power_01.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_Power_01.Location = new System.Drawing.Point(143, 56);
            this.label_Power_01.Name = "label_Power_01";
            this.label_Power_01.Size = new System.Drawing.Size(62, 29);
            this.label_Power_01.TabIndex = 106;
            this.label_Power_01.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_StateCode_01
            // 
            this.label_StateCode_01.BackColor = System.Drawing.Color.Silver;
            this.label_StateCode_01.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_StateCode_01.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_StateCode_01.Location = new System.Drawing.Point(433, 169);
            this.label_StateCode_01.Name = "label_StateCode_01";
            this.label_StateCode_01.Size = new System.Drawing.Size(33, 23);
            this.label_StateCode_01.TabIndex = 126;
            this.label_StateCode_01.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Power
            // 
            this.label_Power.AutoSize = true;
            this.label_Power.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_Power.Location = new System.Drawing.Point(84, 61);
            this.label_Power.Name = "label_Power";
            this.label_Power.Size = new System.Drawing.Size(53, 20);
            this.label_Power.TabIndex = 7;
            this.label_Power.Text = "Power";
            this.label_Power.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_RPM_avg
            // 
            this.label_RPM_avg.AutoSize = true;
            this.label_RPM_avg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_RPM_avg.Location = new System.Drawing.Point(49, 92);
            this.label_RPM_avg.Name = "label_RPM_avg";
            this.label_RPM_avg.Size = new System.Drawing.Size(88, 20);
            this.label_RPM_avg.TabIndex = 10;
            this.label_RPM_avg.Text = "Gen speed";
            this.label_RPM_avg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_RPM_gen_01
            // 
            this.label_RPM_gen_01.BackColor = System.Drawing.Color.Silver;
            this.label_RPM_gen_01.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RPM_gen_01.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_RPM_gen_01.Location = new System.Drawing.Point(143, 87);
            this.label_RPM_gen_01.Name = "label_RPM_gen_01";
            this.label_RPM_gen_01.Size = new System.Drawing.Size(62, 29);
            this.label_RPM_gen_01.TabIndex = 116;
            this.label_RPM_gen_01.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_StateCode
            // 
            this.label_StateCode.AutoSize = true;
            this.label_StateCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_StateCode.Location = new System.Drawing.Point(340, 172);
            this.label_StateCode.Name = "label_StateCode";
            this.label_StateCode.Size = new System.Drawing.Size(87, 20);
            this.label_StateCode.TabIndex = 39;
            this.label_StateCode.Text = "State code";
            this.label_StateCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Wind_01
            // 
            this.label_Wind_01.BackColor = System.Drawing.Color.Silver;
            this.label_Wind_01.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_Wind_01.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_Wind_01.Location = new System.Drawing.Point(143, 149);
            this.label_Wind_01.Name = "label_Wind_01";
            this.label_Wind_01.Size = new System.Drawing.Size(62, 29);
            this.label_Wind_01.TabIndex = 111;
            this.label_Wind_01.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label1.Location = new System.Drawing.Point(44, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 82;
            this.label1.Text = "Wind speed";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage_Electrical
            // 
            this.tabPage_Electrical.BackColor = System.Drawing.Color.SlateGray;
            this.tabPage_Electrical.Controls.Add(this.label2);
            this.tabPage_Electrical.Controls.Add(this.label_ReactivePowerSetpoint);
            this.tabPage_Electrical.Controls.Add(this.label15);
            this.tabPage_Electrical.Controls.Add(this.label50);
            this.tabPage_Electrical.Controls.Add(this.label_PowerSetpoint);
            this.tabPage_Electrical.Controls.Add(this.label56);
            this.tabPage_Electrical.Controls.Add(this.label18);
            this.tabPage_Electrical.Controls.Add(this.label_PowerControllerSetpoint);
            this.tabPage_Electrical.Controls.Add(this.label44);
            this.tabPage_Electrical.Controls.Add(this.label76);
            this.tabPage_Electrical.Controls.Add(this.label_Production);
            this.tabPage_Electrical.Controls.Add(this.label83);
            this.tabPage_Electrical.Controls.Add(this.label40);
            this.tabPage_Electrical.Controls.Add(this.label_Current_L3);
            this.tabPage_Electrical.Controls.Add(this.label42);
            this.tabPage_Electrical.Controls.Add(this.label43);
            this.tabPage_Electrical.Controls.Add(this.label_Current_L2);
            this.tabPage_Electrical.Controls.Add(this.label45);
            this.tabPage_Electrical.Controls.Add(this.label46);
            this.tabPage_Electrical.Controls.Add(this.label_Current_L1);
            this.tabPage_Electrical.Controls.Add(this.label48);
            this.tabPage_Electrical.Controls.Add(this.label37);
            this.tabPage_Electrical.Controls.Add(this.label_Voltage_L3);
            this.tabPage_Electrical.Controls.Add(this.label39);
            this.tabPage_Electrical.Controls.Add(this.label32);
            this.tabPage_Electrical.Controls.Add(this.label_Voltage_L2);
            this.tabPage_Electrical.Controls.Add(this.label36);
            this.tabPage_Electrical.Controls.Add(this.label26);
            this.tabPage_Electrical.Controls.Add(this.label_Voltage_L1);
            this.tabPage_Electrical.Controls.Add(this.label30);
            this.tabPage_Electrical.Controls.Add(this.label16);
            this.tabPage_Electrical.Controls.Add(this.label_Frequency);
            this.tabPage_Electrical.Controls.Add(this.label24);
            this.tabPage_Electrical.Controls.Add(this.label_CosPhi);
            this.tabPage_Electrical.Controls.Add(this.label20);
            this.tabPage_Electrical.Controls.Add(this.label9);
            this.tabPage_Electrical.Controls.Add(this.label_Power_1s);
            this.tabPage_Electrical.Controls.Add(this.label14);
            this.tabPage_Electrical.Location = new System.Drawing.Point(4, 25);
            this.tabPage_Electrical.Name = "tabPage_Electrical";
            this.tabPage_Electrical.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Electrical.Size = new System.Drawing.Size(792, 347);
            this.tabPage_Electrical.TabIndex = 1;
            this.tabPage_Electrical.Text = "Electrical";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label2.Location = new System.Drawing.Point(724, 259);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 16);
            this.label2.TabIndex = 198;
            this.label2.Text = "kVar";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_ReactivePowerSetpoint
            // 
            this.label_ReactivePowerSetpoint.BackColor = System.Drawing.Color.Silver;
            this.label_ReactivePowerSetpoint.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_ReactivePowerSetpoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_ReactivePowerSetpoint.Location = new System.Drawing.Point(656, 250);
            this.label_ReactivePowerSetpoint.Name = "label_ReactivePowerSetpoint";
            this.label_ReactivePowerSetpoint.Size = new System.Drawing.Size(62, 29);
            this.label_ReactivePowerSetpoint.TabIndex = 197;
            this.label_ReactivePowerSetpoint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label15.Location = new System.Drawing.Point(472, 255);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(179, 20);
            this.label15.TabIndex = 196;
            this.label15.Text = "Reactive power setpoint";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label50.Location = new System.Drawing.Point(724, 227);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(27, 16);
            this.label50.TabIndex = 195;
            this.label50.Text = "kW";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_PowerSetpoint
            // 
            this.label_PowerSetpoint.BackColor = System.Drawing.Color.Silver;
            this.label_PowerSetpoint.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_PowerSetpoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_PowerSetpoint.Location = new System.Drawing.Point(656, 218);
            this.label_PowerSetpoint.Name = "label_PowerSetpoint";
            this.label_PowerSetpoint.Size = new System.Drawing.Size(62, 29);
            this.label_PowerSetpoint.TabIndex = 194;
            this.label_PowerSetpoint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label56.Location = new System.Drawing.Point(537, 223);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(114, 20);
            this.label56.TabIndex = 193;
            this.label56.Text = "Power setpoint";
            this.label56.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label18.Location = new System.Drawing.Point(724, 196);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(27, 16);
            this.label18.TabIndex = 192;
            this.label18.Text = "kW";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_PowerControllerSetpoint
            // 
            this.label_PowerControllerSetpoint.BackColor = System.Drawing.Color.Silver;
            this.label_PowerControllerSetpoint.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_PowerControllerSetpoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_PowerControllerSetpoint.Location = new System.Drawing.Point(656, 187);
            this.label_PowerControllerSetpoint.Name = "label_PowerControllerSetpoint";
            this.label_PowerControllerSetpoint.Size = new System.Drawing.Size(62, 29);
            this.label_PowerControllerSetpoint.TabIndex = 191;
            this.label_PowerControllerSetpoint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label44.Location = new System.Drawing.Point(467, 192);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(183, 20);
            this.label44.TabIndex = 190;
            this.label44.Text = "Power controller setpoint";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label76.Location = new System.Drawing.Point(724, 70);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(34, 16);
            this.label76.TabIndex = 158;
            this.label76.Text = "kWh";
            this.label76.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Production
            // 
            this.label_Production.BackColor = System.Drawing.Color.Silver;
            this.label_Production.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_Production.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_Production.Location = new System.Drawing.Point(580, 61);
            this.label_Production.Name = "label_Production";
            this.label_Production.Size = new System.Drawing.Size(138, 29);
            this.label_Production.TabIndex = 157;
            this.label_Production.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label83.Location = new System.Drawing.Point(489, 66);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(85, 20);
            this.label83.TabIndex = 156;
            this.label83.Text = "Production";
            this.label83.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label40.Location = new System.Drawing.Point(406, 258);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(16, 16);
            this.label40.TabIndex = 155;
            this.label40.Text = "A";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Current_L3
            // 
            this.label_Current_L3.BackColor = System.Drawing.Color.Silver;
            this.label_Current_L3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_Current_L3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_Current_L3.Location = new System.Drawing.Point(338, 249);
            this.label_Current_L3.Name = "label_Current_L3";
            this.label_Current_L3.Size = new System.Drawing.Size(62, 29);
            this.label_Current_L3.TabIndex = 154;
            this.label_Current_L3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label42.Location = new System.Drawing.Point(248, 254);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(84, 20);
            this.label42.TabIndex = 153;
            this.label42.Text = "Current L3";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label43.Location = new System.Drawing.Point(406, 227);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(16, 16);
            this.label43.TabIndex = 152;
            this.label43.Text = "A";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Current_L2
            // 
            this.label_Current_L2.BackColor = System.Drawing.Color.Silver;
            this.label_Current_L2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_Current_L2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_Current_L2.Location = new System.Drawing.Point(338, 218);
            this.label_Current_L2.Name = "label_Current_L2";
            this.label_Current_L2.Size = new System.Drawing.Size(62, 29);
            this.label_Current_L2.TabIndex = 151;
            this.label_Current_L2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label45.Location = new System.Drawing.Point(248, 223);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(84, 20);
            this.label45.TabIndex = 150;
            this.label45.Text = "Current L2";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label46.Location = new System.Drawing.Point(406, 196);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(16, 16);
            this.label46.TabIndex = 149;
            this.label46.Text = "A";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Current_L1
            // 
            this.label_Current_L1.BackColor = System.Drawing.Color.Silver;
            this.label_Current_L1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_Current_L1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_Current_L1.Location = new System.Drawing.Point(338, 187);
            this.label_Current_L1.Name = "label_Current_L1";
            this.label_Current_L1.Size = new System.Drawing.Size(62, 29);
            this.label_Current_L1.TabIndex = 148;
            this.label_Current_L1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label48.Location = new System.Drawing.Point(248, 192);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(84, 20);
            this.label48.TabIndex = 147;
            this.label48.Text = "Current L1";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label37.Location = new System.Drawing.Point(197, 258);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(16, 16);
            this.label37.TabIndex = 146;
            this.label37.Text = "V";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Voltage_L3
            // 
            this.label_Voltage_L3.BackColor = System.Drawing.Color.Silver;
            this.label_Voltage_L3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_Voltage_L3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_Voltage_L3.Location = new System.Drawing.Point(129, 249);
            this.label_Voltage_L3.Name = "label_Voltage_L3";
            this.label_Voltage_L3.Size = new System.Drawing.Size(62, 29);
            this.label_Voltage_L3.TabIndex = 145;
            this.label_Voltage_L3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label39.Location = new System.Drawing.Point(37, 254);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(86, 20);
            this.label39.TabIndex = 144;
            this.label39.Text = "Voltage L3";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label32.Location = new System.Drawing.Point(197, 227);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(16, 16);
            this.label32.TabIndex = 143;
            this.label32.Text = "V";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Voltage_L2
            // 
            this.label_Voltage_L2.BackColor = System.Drawing.Color.Silver;
            this.label_Voltage_L2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_Voltage_L2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_Voltage_L2.Location = new System.Drawing.Point(129, 218);
            this.label_Voltage_L2.Name = "label_Voltage_L2";
            this.label_Voltage_L2.Size = new System.Drawing.Size(62, 29);
            this.label_Voltage_L2.TabIndex = 142;
            this.label_Voltage_L2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label36.Location = new System.Drawing.Point(37, 223);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(86, 20);
            this.label36.TabIndex = 141;
            this.label36.Text = "Voltage L2";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label26.Location = new System.Drawing.Point(197, 196);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(16, 16);
            this.label26.TabIndex = 140;
            this.label26.Text = "V";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Voltage_L1
            // 
            this.label_Voltage_L1.BackColor = System.Drawing.Color.Silver;
            this.label_Voltage_L1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_Voltage_L1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_Voltage_L1.Location = new System.Drawing.Point(129, 187);
            this.label_Voltage_L1.Name = "label_Voltage_L1";
            this.label_Voltage_L1.Size = new System.Drawing.Size(62, 29);
            this.label_Voltage_L1.TabIndex = 139;
            this.label_Voltage_L1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label30.Location = new System.Drawing.Point(37, 192);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(86, 20);
            this.label30.TabIndex = 138;
            this.label30.Text = "Voltage L1";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label16.Location = new System.Drawing.Point(197, 133);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(23, 16);
            this.label16.TabIndex = 137;
            this.label16.Text = "Hz";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Frequency
            // 
            this.label_Frequency.BackColor = System.Drawing.Color.Silver;
            this.label_Frequency.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_Frequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_Frequency.Location = new System.Drawing.Point(129, 124);
            this.label_Frequency.Name = "label_Frequency";
            this.label_Frequency.Size = new System.Drawing.Size(62, 29);
            this.label_Frequency.TabIndex = 136;
            this.label_Frequency.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label24.Location = new System.Drawing.Point(39, 129);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(84, 20);
            this.label24.TabIndex = 135;
            this.label24.Text = "Frequency";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_CosPhi
            // 
            this.label_CosPhi.BackColor = System.Drawing.Color.Silver;
            this.label_CosPhi.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_CosPhi.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_CosPhi.Location = new System.Drawing.Point(129, 93);
            this.label_CosPhi.Name = "label_CosPhi";
            this.label_CosPhi.Size = new System.Drawing.Size(62, 29);
            this.label_CosPhi.TabIndex = 134;
            this.label_CosPhi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label20.Location = new System.Drawing.Point(60, 98);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(63, 20);
            this.label20.TabIndex = 133;
            this.label20.Text = "Cos Phi";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label9.Location = new System.Drawing.Point(197, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 16);
            this.label9.TabIndex = 132;
            this.label9.Text = "kW";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Power_1s
            // 
            this.label_Power_1s.BackColor = System.Drawing.Color.Silver;
            this.label_Power_1s.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_Power_1s.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_Power_1s.Location = new System.Drawing.Point(129, 62);
            this.label_Power_1s.Name = "label_Power_1s";
            this.label_Power_1s.Size = new System.Drawing.Size(62, 29);
            this.label_Power_1s.TabIndex = 131;
            this.label_Power_1s.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label14.Location = new System.Drawing.Point(70, 67);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 20);
            this.label14.TabIndex = 130;
            this.label14.Text = "Power";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage_Temperatures
            // 
            this.tabPage_Temperatures.BackColor = System.Drawing.Color.SlateGray;
            this.tabPage_Temperatures.Controls.Add(this.label79);
            this.tabPage_Temperatures.Controls.Add(this.label_Temp_CoolWaterVCS);
            this.tabPage_Temperatures.Controls.Add(this.label81);
            this.tabPage_Temperatures.Controls.Add(this.label82);
            this.tabPage_Temperatures.Controls.Add(this.label_Temp_GeneratorBearing);
            this.tabPage_Temperatures.Controls.Add(this.label84);
            this.tabPage_Temperatures.Controls.Add(this.label85);
            this.tabPage_Temperatures.Controls.Add(this.label_Temp_HVTransformerL3);
            this.tabPage_Temperatures.Controls.Add(this.label87);
            this.tabPage_Temperatures.Controls.Add(this.label88);
            this.tabPage_Temperatures.Controls.Add(this.label_Temp_HVTransformerL2);
            this.tabPage_Temperatures.Controls.Add(this.label90);
            this.tabPage_Temperatures.Controls.Add(this.label91);
            this.tabPage_Temperatures.Controls.Add(this.label_Temp_HVTransformerL1);
            this.tabPage_Temperatures.Controls.Add(this.label93);
            this.tabPage_Temperatures.Controls.Add(this.label61);
            this.tabPage_Temperatures.Controls.Add(this.label_Temp_Spinner);
            this.tabPage_Temperatures.Controls.Add(this.label63);
            this.tabPage_Temperatures.Controls.Add(this.label64);
            this.tabPage_Temperatures.Controls.Add(this.label_Temp_BusBar);
            this.tabPage_Temperatures.Controls.Add(this.label66);
            this.tabPage_Temperatures.Controls.Add(this.label67);
            this.tabPage_Temperatures.Controls.Add(this.label_Temp_TopController);
            this.tabPage_Temperatures.Controls.Add(this.label69);
            this.tabPage_Temperatures.Controls.Add(this.label70);
            this.tabPage_Temperatures.Controls.Add(this.label_Temp_Nacelle);
            this.tabPage_Temperatures.Controls.Add(this.label72);
            this.tabPage_Temperatures.Controls.Add(this.label73);
            this.tabPage_Temperatures.Controls.Add(this.label_Temp_HubController);
            this.tabPage_Temperatures.Controls.Add(this.label75);
            this.tabPage_Temperatures.Controls.Add(this.label55);
            this.tabPage_Temperatures.Controls.Add(this.label_Temp_GearBearing);
            this.tabPage_Temperatures.Controls.Add(this.label57);
            this.tabPage_Temperatures.Controls.Add(this.label52);
            this.tabPage_Temperatures.Controls.Add(this.label_Temp_SlipringVCS);
            this.tabPage_Temperatures.Controls.Add(this.label54);
            this.tabPage_Temperatures.Controls.Add(this.label49);
            this.tabPage_Temperatures.Controls.Add(this.label_Temp_Generator);
            this.tabPage_Temperatures.Controls.Add(this.label51);
            this.tabPage_Temperatures.Controls.Add(this.label41);
            this.tabPage_Temperatures.Controls.Add(this.label_Temp_Gear);
            this.tabPage_Temperatures.Controls.Add(this.label47);
            this.tabPage_Temperatures.Controls.Add(this.label28);
            this.tabPage_Temperatures.Controls.Add(this.label_Temp_Environment);
            this.tabPage_Temperatures.Controls.Add(this.label38);
            this.tabPage_Temperatures.Controls.Add(this.label12);
            this.tabPage_Temperatures.Controls.Add(this.label_Temp_Hydraulic);
            this.tabPage_Temperatures.Controls.Add(this.label22);
            this.tabPage_Temperatures.Location = new System.Drawing.Point(4, 25);
            this.tabPage_Temperatures.Name = "tabPage_Temperatures";
            this.tabPage_Temperatures.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Temperatures.Size = new System.Drawing.Size(792, 347);
            this.tabPage_Temperatures.TabIndex = 2;
            this.tabPage_Temperatures.Text = "Temperatures";
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label79.Location = new System.Drawing.Point(230, 245);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(20, 16);
            this.label79.TabIndex = 183;
            this.label79.Text = "°C";
            this.label79.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Temp_CoolWaterVCS
            // 
            this.label_Temp_CoolWaterVCS.BackColor = System.Drawing.Color.Silver;
            this.label_Temp_CoolWaterVCS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_Temp_CoolWaterVCS.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_Temp_CoolWaterVCS.Location = new System.Drawing.Point(162, 236);
            this.label_Temp_CoolWaterVCS.Name = "label_Temp_CoolWaterVCS";
            this.label_Temp_CoolWaterVCS.Size = new System.Drawing.Size(62, 29);
            this.label_Temp_CoolWaterVCS.TabIndex = 182;
            this.label_Temp_CoolWaterVCS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label81
            // 
            this.label81.AutoSize = true;
            this.label81.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label81.Location = new System.Drawing.Point(31, 241);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(125, 20);
            this.label81.TabIndex = 181;
            this.label81.Text = "Cool Water VCS";
            this.label81.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label82.Location = new System.Drawing.Point(230, 121);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(20, 16);
            this.label82.TabIndex = 180;
            this.label82.Text = "°C";
            this.label82.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Temp_GeneratorBearing
            // 
            this.label_Temp_GeneratorBearing.BackColor = System.Drawing.Color.Silver;
            this.label_Temp_GeneratorBearing.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_Temp_GeneratorBearing.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_Temp_GeneratorBearing.Location = new System.Drawing.Point(162, 112);
            this.label_Temp_GeneratorBearing.Name = "label_Temp_GeneratorBearing";
            this.label_Temp_GeneratorBearing.Size = new System.Drawing.Size(62, 29);
            this.label_Temp_GeneratorBearing.TabIndex = 179;
            this.label_Temp_GeneratorBearing.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label84.Location = new System.Drawing.Point(17, 117);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(139, 20);
            this.label84.TabIndex = 178;
            this.label84.Text = "Generator bearing";
            this.label84.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label85.Location = new System.Drawing.Point(758, 153);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(20, 16);
            this.label85.TabIndex = 177;
            this.label85.Text = "°C";
            this.label85.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Temp_HVTransformerL3
            // 
            this.label_Temp_HVTransformerL3.BackColor = System.Drawing.Color.Silver;
            this.label_Temp_HVTransformerL3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_Temp_HVTransformerL3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_Temp_HVTransformerL3.Location = new System.Drawing.Point(690, 144);
            this.label_Temp_HVTransformerL3.Name = "label_Temp_HVTransformerL3";
            this.label_Temp_HVTransformerL3.Size = new System.Drawing.Size(62, 29);
            this.label_Temp_HVTransformerL3.TabIndex = 176;
            this.label_Temp_HVTransformerL3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label87.Location = new System.Drawing.Point(544, 149);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(140, 20);
            this.label87.TabIndex = 175;
            this.label87.Text = "HV transformer L3";
            this.label87.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label88
            // 
            this.label88.AutoSize = true;
            this.label88.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label88.Location = new System.Drawing.Point(758, 122);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(20, 16);
            this.label88.TabIndex = 174;
            this.label88.Text = "°C";
            this.label88.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Temp_HVTransformerL2
            // 
            this.label_Temp_HVTransformerL2.BackColor = System.Drawing.Color.Silver;
            this.label_Temp_HVTransformerL2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_Temp_HVTransformerL2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_Temp_HVTransformerL2.Location = new System.Drawing.Point(690, 113);
            this.label_Temp_HVTransformerL2.Name = "label_Temp_HVTransformerL2";
            this.label_Temp_HVTransformerL2.Size = new System.Drawing.Size(62, 29);
            this.label_Temp_HVTransformerL2.TabIndex = 173;
            this.label_Temp_HVTransformerL2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label90
            // 
            this.label90.AutoSize = true;
            this.label90.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label90.Location = new System.Drawing.Point(544, 118);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(140, 20);
            this.label90.TabIndex = 172;
            this.label90.Text = "HV transformer L2";
            this.label90.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label91
            // 
            this.label91.AutoSize = true;
            this.label91.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label91.Location = new System.Drawing.Point(758, 91);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(20, 16);
            this.label91.TabIndex = 171;
            this.label91.Text = "°C";
            this.label91.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Temp_HVTransformerL1
            // 
            this.label_Temp_HVTransformerL1.BackColor = System.Drawing.Color.Silver;
            this.label_Temp_HVTransformerL1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_Temp_HVTransformerL1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_Temp_HVTransformerL1.Location = new System.Drawing.Point(690, 82);
            this.label_Temp_HVTransformerL1.Name = "label_Temp_HVTransformerL1";
            this.label_Temp_HVTransformerL1.Size = new System.Drawing.Size(62, 29);
            this.label_Temp_HVTransformerL1.TabIndex = 170;
            this.label_Temp_HVTransformerL1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label93
            // 
            this.label93.AutoSize = true;
            this.label93.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label93.Location = new System.Drawing.Point(544, 87);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(140, 20);
            this.label93.TabIndex = 169;
            this.label93.Text = "HV transformer L1";
            this.label93.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label61.Location = new System.Drawing.Point(476, 152);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(20, 16);
            this.label61.TabIndex = 165;
            this.label61.Text = "°C";
            this.label61.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Temp_Spinner
            // 
            this.label_Temp_Spinner.BackColor = System.Drawing.Color.Silver;
            this.label_Temp_Spinner.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_Temp_Spinner.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_Temp_Spinner.Location = new System.Drawing.Point(408, 143);
            this.label_Temp_Spinner.Name = "label_Temp_Spinner";
            this.label_Temp_Spinner.Size = new System.Drawing.Size(62, 29);
            this.label_Temp_Spinner.TabIndex = 164;
            this.label_Temp_Spinner.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label63.Location = new System.Drawing.Point(338, 148);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(64, 20);
            this.label63.TabIndex = 163;
            this.label63.Text = "Spinner";
            this.label63.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label64.Location = new System.Drawing.Point(476, 245);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(20, 16);
            this.label64.TabIndex = 162;
            this.label64.Text = "°C";
            this.label64.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Temp_BusBar
            // 
            this.label_Temp_BusBar.BackColor = System.Drawing.Color.Silver;
            this.label_Temp_BusBar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_Temp_BusBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_Temp_BusBar.Location = new System.Drawing.Point(408, 236);
            this.label_Temp_BusBar.Name = "label_Temp_BusBar";
            this.label_Temp_BusBar.Size = new System.Drawing.Size(62, 29);
            this.label_Temp_BusBar.TabIndex = 161;
            this.label_Temp_BusBar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label66.Location = new System.Drawing.Point(338, 241);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(64, 20);
            this.label66.TabIndex = 160;
            this.label66.Text = "Bus bar";
            this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label67.Location = new System.Drawing.Point(476, 214);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(20, 16);
            this.label67.TabIndex = 159;
            this.label67.Text = "°C";
            this.label67.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Temp_TopController
            // 
            this.label_Temp_TopController.BackColor = System.Drawing.Color.Silver;
            this.label_Temp_TopController.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_Temp_TopController.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_Temp_TopController.Location = new System.Drawing.Point(408, 205);
            this.label_Temp_TopController.Name = "label_Temp_TopController";
            this.label_Temp_TopController.Size = new System.Drawing.Size(62, 29);
            this.label_Temp_TopController.TabIndex = 158;
            this.label_Temp_TopController.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label69.Location = new System.Drawing.Point(297, 210);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(105, 20);
            this.label69.TabIndex = 157;
            this.label69.Text = "Top controller";
            this.label69.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label70.Location = new System.Drawing.Point(476, 121);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(20, 16);
            this.label70.TabIndex = 156;
            this.label70.Text = "°C";
            this.label70.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Temp_Nacelle
            // 
            this.label_Temp_Nacelle.BackColor = System.Drawing.Color.Silver;
            this.label_Temp_Nacelle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_Temp_Nacelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_Temp_Nacelle.Location = new System.Drawing.Point(408, 112);
            this.label_Temp_Nacelle.Name = "label_Temp_Nacelle";
            this.label_Temp_Nacelle.Size = new System.Drawing.Size(62, 29);
            this.label_Temp_Nacelle.TabIndex = 155;
            this.label_Temp_Nacelle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label72.Location = new System.Drawing.Point(341, 117);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(61, 20);
            this.label72.TabIndex = 154;
            this.label72.Text = "Nacelle";
            this.label72.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label73.Location = new System.Drawing.Point(476, 183);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(20, 16);
            this.label73.TabIndex = 153;
            this.label73.Text = "°C";
            this.label73.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Temp_HubController
            // 
            this.label_Temp_HubController.BackColor = System.Drawing.Color.Silver;
            this.label_Temp_HubController.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_Temp_HubController.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_Temp_HubController.Location = new System.Drawing.Point(408, 174);
            this.label_Temp_HubController.Name = "label_Temp_HubController";
            this.label_Temp_HubController.Size = new System.Drawing.Size(62, 29);
            this.label_Temp_HubController.TabIndex = 152;
            this.label_Temp_HubController.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label75.Location = new System.Drawing.Point(294, 179);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(108, 20);
            this.label75.TabIndex = 151;
            this.label75.Text = "Hub controller";
            this.label75.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label55.Location = new System.Drawing.Point(230, 183);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(20, 16);
            this.label55.TabIndex = 150;
            this.label55.Text = "°C";
            this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Temp_GearBearing
            // 
            this.label_Temp_GearBearing.BackColor = System.Drawing.Color.Silver;
            this.label_Temp_GearBearing.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_Temp_GearBearing.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_Temp_GearBearing.Location = new System.Drawing.Point(162, 174);
            this.label_Temp_GearBearing.Name = "label_Temp_GearBearing";
            this.label_Temp_GearBearing.Size = new System.Drawing.Size(62, 29);
            this.label_Temp_GearBearing.TabIndex = 149;
            this.label_Temp_GearBearing.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label57.Location = new System.Drawing.Point(54, 179);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(102, 20);
            this.label57.TabIndex = 148;
            this.label57.Text = "Gear bearing";
            this.label57.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label52.Location = new System.Drawing.Point(758, 214);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(20, 16);
            this.label52.TabIndex = 147;
            this.label52.Text = "°C";
            this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Temp_SlipringVCS
            // 
            this.label_Temp_SlipringVCS.BackColor = System.Drawing.Color.Silver;
            this.label_Temp_SlipringVCS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_Temp_SlipringVCS.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_Temp_SlipringVCS.Location = new System.Drawing.Point(690, 205);
            this.label_Temp_SlipringVCS.Name = "label_Temp_SlipringVCS";
            this.label_Temp_SlipringVCS.Size = new System.Drawing.Size(62, 29);
            this.label_Temp_SlipringVCS.TabIndex = 146;
            this.label_Temp_SlipringVCS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label54.Location = new System.Drawing.Point(586, 210);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(98, 20);
            this.label54.TabIndex = 145;
            this.label54.Text = "Slipring VCS";
            this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label49.Location = new System.Drawing.Point(230, 90);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(20, 16);
            this.label49.TabIndex = 144;
            this.label49.Text = "°C";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Temp_Generator
            // 
            this.label_Temp_Generator.BackColor = System.Drawing.Color.Silver;
            this.label_Temp_Generator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_Temp_Generator.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_Temp_Generator.Location = new System.Drawing.Point(162, 81);
            this.label_Temp_Generator.Name = "label_Temp_Generator";
            this.label_Temp_Generator.Size = new System.Drawing.Size(62, 29);
            this.label_Temp_Generator.TabIndex = 143;
            this.label_Temp_Generator.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label51.Location = new System.Drawing.Point(74, 86);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(82, 20);
            this.label51.TabIndex = 142;
            this.label51.Text = "Generator";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label41.Location = new System.Drawing.Point(230, 152);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(20, 16);
            this.label41.TabIndex = 141;
            this.label41.Text = "°C";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Temp_Gear
            // 
            this.label_Temp_Gear.BackColor = System.Drawing.Color.Silver;
            this.label_Temp_Gear.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_Temp_Gear.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_Temp_Gear.Location = new System.Drawing.Point(162, 143);
            this.label_Temp_Gear.Name = "label_Temp_Gear";
            this.label_Temp_Gear.Size = new System.Drawing.Size(62, 29);
            this.label_Temp_Gear.TabIndex = 140;
            this.label_Temp_Gear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label47.Location = new System.Drawing.Point(111, 148);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(45, 20);
            this.label47.TabIndex = 139;
            this.label47.Text = "Gear";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label28.Location = new System.Drawing.Point(476, 90);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(20, 16);
            this.label28.TabIndex = 138;
            this.label28.Text = "°C";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Temp_Environment
            // 
            this.label_Temp_Environment.BackColor = System.Drawing.Color.Silver;
            this.label_Temp_Environment.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_Temp_Environment.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_Temp_Environment.Location = new System.Drawing.Point(408, 81);
            this.label_Temp_Environment.Name = "label_Temp_Environment";
            this.label_Temp_Environment.Size = new System.Drawing.Size(62, 29);
            this.label_Temp_Environment.TabIndex = 137;
            this.label_Temp_Environment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label38.Location = new System.Drawing.Point(304, 86);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(98, 20);
            this.label38.TabIndex = 136;
            this.label38.Text = "Environment";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label12.Location = new System.Drawing.Point(230, 214);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(20, 16);
            this.label12.TabIndex = 135;
            this.label12.Text = "°C";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Temp_Hydraulic
            // 
            this.label_Temp_Hydraulic.BackColor = System.Drawing.Color.Silver;
            this.label_Temp_Hydraulic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_Temp_Hydraulic.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_Temp_Hydraulic.Location = new System.Drawing.Point(162, 205);
            this.label_Temp_Hydraulic.Name = "label_Temp_Hydraulic";
            this.label_Temp_Hydraulic.Size = new System.Drawing.Size(62, 29);
            this.label_Temp_Hydraulic.TabIndex = 134;
            this.label_Temp_Hydraulic.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label22.Location = new System.Drawing.Point(82, 210);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(74, 20);
            this.label22.TabIndex = 133;
            this.label22.Text = "Hydraulic";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage_Control
            // 
            this.tabPage_Control.BackColor = System.Drawing.Color.SlateGray;
            this.tabPage_Control.Controls.Add(this.groupBox_Service_T01);
            this.tabPage_Control.Controls.Add(this.button_Ack_T01);
            this.tabPage_Control.Controls.Add(this.button_Start_T01);
            this.tabPage_Control.Controls.Add(this.button_Pause_T01);
            this.tabPage_Control.Location = new System.Drawing.Point(4, 25);
            this.tabPage_Control.Name = "tabPage_Control";
            this.tabPage_Control.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Control.Size = new System.Drawing.Size(792, 347);
            this.tabPage_Control.TabIndex = 3;
            this.tabPage_Control.Text = "Control";
            // 
            // groupBox_Service_T01
            // 
            this.groupBox_Service_T01.Controls.Add(this.textBox_ReactivePowerSetpoint);
            this.groupBox_Service_T01.Controls.Add(this.textBox_ActivePowerSetpoint);
            this.groupBox_Service_T01.Controls.Add(this.label21);
            this.groupBox_Service_T01.Controls.Add(this.label_ActivePowerSetpoint_1);
            this.groupBox_Service_T01.Controls.Add(this.label33);
            this.groupBox_Service_T01.Controls.Add(this.button_ReactivePowerSetpointSend);
            this.groupBox_Service_T01.Controls.Add(this.button_ActivePowerSetpointSend);
            this.groupBox_Service_T01.Controls.Add(this.label_ReactivePowerSetpoint_1);
            this.groupBox_Service_T01.Controls.Add(this.button_ParameterTool);
            this.groupBox_Service_T01.Controls.Add(this.label19);
            this.groupBox_Service_T01.Controls.Add(this.label35);
            this.groupBox_Service_T01.Location = new System.Drawing.Point(133, 122);
            this.groupBox_Service_T01.Name = "groupBox_Service_T01";
            this.groupBox_Service_T01.Size = new System.Drawing.Size(537, 197);
            this.groupBox_Service_T01.TabIndex = 200;
            this.groupBox_Service_T01.TabStop = false;
            this.groupBox_Service_T01.Text = "Service functions";
            // 
            // textBox_ReactivePowerSetpoint
            // 
            this.textBox_ReactivePowerSetpoint.Location = new System.Drawing.Point(280, 81);
            this.textBox_ReactivePowerSetpoint.Name = "textBox_ReactivePowerSetpoint";
            this.textBox_ReactivePowerSetpoint.Size = new System.Drawing.Size(57, 22);
            this.textBox_ReactivePowerSetpoint.TabIndex = 139;
            // 
            // textBox_ActivePowerSetpoint
            // 
            this.textBox_ActivePowerSetpoint.Location = new System.Drawing.Point(280, 51);
            this.textBox_ActivePowerSetpoint.Name = "textBox_ActivePowerSetpoint";
            this.textBox_ActivePowerSetpoint.Size = new System.Drawing.Size(57, 22);
            this.textBox_ActivePowerSetpoint.TabIndex = 135;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(72, 54);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(138, 16);
            this.label21.TabIndex = 136;
            this.label21.Text = "Active Power setpoint:";
            // 
            // label_ActivePowerSetpoint_1
            // 
            this.label_ActivePowerSetpoint_1.BackColor = System.Drawing.Color.Silver;
            this.label_ActivePowerSetpoint_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_ActivePowerSetpoint_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_ActivePowerSetpoint_1.Location = new System.Drawing.Point(217, 51);
            this.label_ActivePowerSetpoint_1.Name = "label_ActivePowerSetpoint_1";
            this.label_ActivePowerSetpoint_1.Size = new System.Drawing.Size(57, 22);
            this.label_ActivePowerSetpoint_1.TabIndex = 199;
            this.label_ActivePowerSetpoint_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(339, 84);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(35, 16);
            this.label33.TabIndex = 142;
            this.label33.Text = "kVar";
            // 
            // button_ReactivePowerSetpointSend
            // 
            this.button_ReactivePowerSetpointSend.Location = new System.Drawing.Point(377, 81);
            this.button_ReactivePowerSetpointSend.Name = "button_ReactivePowerSetpointSend";
            this.button_ReactivePowerSetpointSend.Size = new System.Drawing.Size(59, 23);
            this.button_ReactivePowerSetpointSend.TabIndex = 141;
            this.button_ReactivePowerSetpointSend.Text = "Send";
            this.button_ReactivePowerSetpointSend.UseVisualStyleBackColor = true;
            this.button_ReactivePowerSetpointSend.Click += new System.EventHandler(this.button_ReactivePowerSetpointSend_Click);
            // 
            // button_ActivePowerSetpointSend
            // 
            this.button_ActivePowerSetpointSend.Location = new System.Drawing.Point(377, 51);
            this.button_ActivePowerSetpointSend.Name = "button_ActivePowerSetpointSend";
            this.button_ActivePowerSetpointSend.Size = new System.Drawing.Size(59, 23);
            this.button_ActivePowerSetpointSend.TabIndex = 137;
            this.button_ActivePowerSetpointSend.Text = "Send";
            this.button_ActivePowerSetpointSend.UseVisualStyleBackColor = true;
            this.button_ActivePowerSetpointSend.Click += new System.EventHandler(this.button_ActivePowerSetpointSend_Click);
            // 
            // label_ReactivePowerSetpoint_1
            // 
            this.label_ReactivePowerSetpoint_1.BackColor = System.Drawing.Color.Silver;
            this.label_ReactivePowerSetpoint_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_ReactivePowerSetpoint_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_ReactivePowerSetpoint_1.Location = new System.Drawing.Point(217, 81);
            this.label_ReactivePowerSetpoint_1.Name = "label_ReactivePowerSetpoint_1";
            this.label_ReactivePowerSetpoint_1.Size = new System.Drawing.Size(57, 22);
            this.label_ReactivePowerSetpoint_1.TabIndex = 198;
            this.label_ReactivePowerSetpoint_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button_ParameterTool
            // 
            this.button_ParameterTool.Location = new System.Drawing.Point(217, 140);
            this.button_ParameterTool.Name = "button_ParameterTool";
            this.button_ParameterTool.Size = new System.Drawing.Size(125, 23);
            this.button_ParameterTool.TabIndex = 143;
            this.button_ParameterTool.Text = "Parameter Tool...";
            this.button_ParameterTool.UseVisualStyleBackColor = true;
            this.button_ParameterTool.Click += new System.EventHandler(this.button_ParameterTool_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(339, 54);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(27, 16);
            this.label19.TabIndex = 138;
            this.label19.Text = "kW";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(55, 84);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(155, 16);
            this.label35.TabIndex = 140;
            this.label35.Text = "Reactive Power setpoint:";
            // 
            // button_Ack_T01
            // 
            this.button_Ack_T01.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Ack_T01.Location = new System.Drawing.Point(489, 58);
            this.button_Ack_T01.Name = "button_Ack_T01";
            this.button_Ack_T01.Size = new System.Drawing.Size(125, 23);
            this.button_Ack_T01.TabIndex = 130;
            this.button_Ack_T01.Text = "Acknowledge";
            this.button_Ack_T01.UseVisualStyleBackColor = true;
            this.button_Ack_T01.Click += new System.EventHandler(this.button_Ack_T01_Click);
            // 
            // button_Start_T01
            // 
            this.button_Start_T01.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Start_T01.Location = new System.Drawing.Point(193, 58);
            this.button_Start_T01.Name = "button_Start_T01";
            this.button_Start_T01.Size = new System.Drawing.Size(125, 23);
            this.button_Start_T01.TabIndex = 131;
            this.button_Start_T01.Text = "Start";
            this.button_Start_T01.UseVisualStyleBackColor = true;
            this.button_Start_T01.Click += new System.EventHandler(this.button_Start_T01_Click);
            // 
            // button_Pause_T01
            // 
            this.button_Pause_T01.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Pause_T01.Location = new System.Drawing.Point(324, 58);
            this.button_Pause_T01.Name = "button_Pause_T01";
            this.button_Pause_T01.Size = new System.Drawing.Size(125, 23);
            this.button_Pause_T01.TabIndex = 132;
            this.button_Pause_T01.Text = "Pause";
            this.button_Pause_T01.UseVisualStyleBackColor = true;
            this.button_Pause_T01.Click += new System.EventHandler(this.button_Pause_T01_Click);
            // 
            // label_ParkActivePower
            // 
            this.label_ParkActivePower.BackColor = System.Drawing.Color.Silver;
            this.label_ParkActivePower.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_ParkActivePower.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_ParkActivePower.Location = new System.Drawing.Point(85, 29);
            this.label_ParkActivePower.Name = "label_ParkActivePower";
            this.label_ParkActivePower.Size = new System.Drawing.Size(63, 29);
            this.label_ParkActivePower.TabIndex = 148;
            this.label_ParkActivePower.Text = "2000";
            this.label_ParkActivePower.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_ParkWindSpeed
            // 
            this.label_ParkWindSpeed.BackColor = System.Drawing.Color.Silver;
            this.label_ParkWindSpeed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_ParkWindSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_ParkWindSpeed.Location = new System.Drawing.Point(196, 29);
            this.label_ParkWindSpeed.Name = "label_ParkWindSpeed";
            this.label_ParkWindSpeed.Size = new System.Drawing.Size(51, 29);
            this.label_ParkWindSpeed.TabIndex = 150;
            this.label_ParkWindSpeed.Text = "25,5";
            this.label_ParkWindSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.SteelBlue;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label29.ForeColor = System.Drawing.Color.White;
            this.label29.Location = new System.Drawing.Point(150, 37);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(27, 16);
            this.label29.TabIndex = 151;
            this.label29.Text = "kW";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.SteelBlue;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(249, 37);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(29, 16);
            this.label23.TabIndex = 153;
            this.label23.Text = "m/s";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.SteelBlue;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(771, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 16);
            this.label6.TabIndex = 161;
            this.label6.Text = "kWh";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_ParkProduction
            // 
            this.label_ParkProduction.BackColor = System.Drawing.Color.Silver;
            this.label_ParkProduction.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_ParkProduction.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_ParkProduction.Location = new System.Drawing.Point(627, 29);
            this.label_ParkProduction.Name = "label_ParkProduction";
            this.label_ParkProduction.Size = new System.Drawing.Size(138, 29);
            this.label_ParkProduction.TabIndex = 160;
            this.label_ParkProduction.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.SteelBlue;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label25.ForeColor = System.Drawing.Color.White;
            this.label25.Location = new System.Drawing.Point(573, 33);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(48, 20);
            this.label25.TabIndex = 159;
            this.label25.Text = "Total:";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer_AutoLogOff
            // 
            this.timer_AutoLogOff.Tick += new System.EventHandler(this.timer_AutoLogOff_Tick);
            // 
            // label_UserLevel
            // 
            this.label_UserLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_UserLevel.BackColor = System.Drawing.Color.Gold;
            this.label_UserLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_UserLevel.Location = new System.Drawing.Point(710, 0);
            this.label_UserLevel.Name = "label_UserLevel";
            this.label_UserLevel.Size = new System.Drawing.Size(114, 24);
            this.label_UserLevel.TabIndex = 162;
            this.label_UserLevel.Text = "ADMINISTRATOR";
            this.label_UserLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_UserLevel.Click += new System.EventHandler(this.label_UserLevel_Click);
            // 
            // button_AlarmAnnouncementEnable
            // 
            this.button_AlarmAnnouncementEnable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_AlarmAnnouncementEnable.Image = ((System.Drawing.Image)(resources.GetObject("button_AlarmAnnouncementEnable.Image")));
            this.button_AlarmAnnouncementEnable.ImageLocation = "";
            this.button_AlarmAnnouncementEnable.Location = new System.Drawing.Point(19, 30);
            this.button_AlarmAnnouncementEnable.Name = "button_AlarmAnnouncementEnable";
            this.button_AlarmAnnouncementEnable.Size = new System.Drawing.Size(28, 28);
            this.button_AlarmAnnouncementEnable.TabIndex = 187;
            this.button_AlarmAnnouncementEnable.TabStop = false;
            this.button_AlarmAnnouncementEnable.Click += new System.EventHandler(this.button_AlarmAnnouncementEnable_Click);
            // 
            // marketIfToolStripMenuItem
            // 
            this.marketIfToolStripMenuItem.Name = "marketIfToolStripMenuItem";
            this.marketIfToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.marketIfToolStripMenuItem.Text = "Market Interface";
            this.marketIfToolStripMenuItem.Click += new System.EventHandler(this.marketIfToolStripMenuItem_Click_1);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(824, 498);
            this.Controls.Add(this.button_AlarmAnnouncementEnable);
            this.Controls.Add(this.label_UserLevel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label_ParkProduction);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label_ParkWindSpeed);
            this.Controls.Add(this.label_ParkActivePower);
            this.Controls.Add(this.label_BannerBackground);
            this.Controls.Add(this.tabControl_Main);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(840, 500);
            this.Name = "Form_Main";
            this.Text = "Eleon SCADA";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Main_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl_Main.ResumeLayout(false);
            this.tabPage_T01.ResumeLayout(false);
            this.tabControl_Turbine_T01.ResumeLayout(false);
            this.tabPage_Overview.ResumeLayout(false);
            this.tabPage_Overview.PerformLayout();
            this.tabPage_Electrical.ResumeLayout(false);
            this.tabPage_Electrical.PerformLayout();
            this.tabPage_Temperatures.ResumeLayout(false);
            this.tabPage_Temperatures.PerformLayout();
            this.tabPage_Control.ResumeLayout(false);
            this.groupBox_Service_T01.ResumeLayout(false);
            this.groupBox_Service_T01.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.button_AlarmAnnouncementEnable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_BannerBackground;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Application;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_File_Close;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Settings;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Info;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_ParkConnect;
        private System.Windows.Forms.Timer timer_Update_fast;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel_DatabaseStatus;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel_TSOLink;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Control;
        private System.Windows.Forms.ToolStripMenuItem startParkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopParkToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel_PowerSetpoint;
        private System.Windows.Forms.ToolStripMenuItem TSOLinkToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel_SetpointMode;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Tools;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.Timer timer_Update_slow;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel_ParkConnection;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripMenuItem dataLogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statusCodesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataChartsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marketIfToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem productionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ParkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TSOInterfaceToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem alarmDispatchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem turbinesControlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem communicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vestasCOMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addInterfaceToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl_Main;
        private System.Windows.Forms.TabPage tabPage_T01;
        private System.Windows.Forms.ToolStripMenuItem TSOInterfaceToolStripMenuItem;
        private System.Windows.Forms.Label label_ParkActivePower;
        private System.Windows.Forms.Label label_ParkWindSpeed;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TabControl tabControl_Turbine_T01;
        private System.Windows.Forms.TabPage tabPage_Overview;
        private System.Windows.Forms.Label label_CommStatus_01;
        private System.Windows.Forms.Label label_RemoteControl;
        private System.Windows.Forms.Label label_ServiceState;
        private System.Windows.Forms.Label label_G_Connected;
        private System.Windows.Forms.Label label_TurbineAvailable;
        private System.Windows.Forms.Label label_YawStatus;
        private System.Windows.Forms.Label label_Error_Txt;
        private System.Windows.Forms.Label label_YawStateTxt;
        private System.Windows.Forms.Label label_PendOpStateTxt;
        private System.Windows.Forms.Label label_OpStateTxt;
        private System.Windows.Forms.Label label_StateTxt;
        private System.Windows.Forms.Label label_YawState;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label_PendOperationState;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label_OperationState;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label_PitchAngle_01;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label_ErrorCode_01;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_Power_01;
        private System.Windows.Forms.Label label_StateCode_01;
        private System.Windows.Forms.Label label_Power;
        private System.Windows.Forms.Label label_RPM_avg;
        private System.Windows.Forms.Label label_RPM_gen_01;
        private System.Windows.Forms.Label label_StateCode;
        private System.Windows.Forms.Label label_Wind_01;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage_Electrical;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_ReactivePowerSetpoint;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label_PowerSetpoint;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label_PowerControllerSetpoint;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.Label label_Production;
        private System.Windows.Forms.Label label83;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label_Current_L3;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label_Current_L2;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label_Current_L1;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label_Voltage_L3;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label_Voltage_L2;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label_Voltage_L1;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label_Frequency;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label_CosPhi;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label_Power_1s;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TabPage tabPage_Temperatures;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.Label label_Temp_CoolWaterVCS;
        private System.Windows.Forms.Label label81;
        private System.Windows.Forms.Label label82;
        private System.Windows.Forms.Label label_Temp_GeneratorBearing;
        private System.Windows.Forms.Label label84;
        private System.Windows.Forms.Label label85;
        private System.Windows.Forms.Label label_Temp_HVTransformerL3;
        private System.Windows.Forms.Label label87;
        private System.Windows.Forms.Label label88;
        private System.Windows.Forms.Label label_Temp_HVTransformerL2;
        private System.Windows.Forms.Label label90;
        private System.Windows.Forms.Label label91;
        private System.Windows.Forms.Label label_Temp_HVTransformerL1;
        private System.Windows.Forms.Label label93;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.Label label_Temp_Spinner;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Label label_Temp_BusBar;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.Label label_Temp_TopController;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Label label_Temp_Nacelle;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.Label label_Temp_HubController;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label_Temp_GearBearing;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label_Temp_SlipringVCS;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label_Temp_Generator;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label_Temp_Gear;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label_Temp_Environment;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label_Temp_Hydraulic;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TabPage tabPage_Control;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Button button_ReactivePowerSetpointSend;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox textBox_ReactivePowerSetpoint;
        private System.Windows.Forms.TextBox textBox_ActivePowerSetpoint;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button button_ActivePowerSetpointSend;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button button_Pause_T01;
        private System.Windows.Forms.Button button_Start_T01;
        private System.Windows.Forms.Button button_Ack_T01;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label_ParkProduction;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button button_ParameterTool;
        private System.Windows.Forms.Label label_ActivePowerSetpoint_1;
        private System.Windows.Forms.Label label_ReactivePowerSetpoint_1;
        private System.Windows.Forms.Timer timer_AutoLogOff;
        private System.Windows.Forms.Label label_UserLevel;
        private System.Windows.Forms.GroupBox groupBox_Service_T01;
        private System.Windows.Forms.ToolStripMenuItem licenseToolStripMenuItem;
        private System.Windows.Forms.PictureBox button_AlarmAnnouncementEnable;
        private System.Windows.Forms.ToolTip myToolTip;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel_Market;
        private System.Windows.Forms.ToolStripMenuItem marketIfToolStripMenuItem;
    }
}

