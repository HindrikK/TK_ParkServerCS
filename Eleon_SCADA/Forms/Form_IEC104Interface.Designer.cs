namespace Eleon_SCADA.Forms
{
    partial class Form_IEC104Interface
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
            this.listBox_Clients = new System.Windows.Forms.ListBox();
            this.label_Clients = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkBox_EmLimit20_Mon = new System.Windows.Forms.CheckBox();
            this.checkBox_EmLimit40_Mon = new System.Windows.Forms.CheckBox();
            this.checkBox_EmLimit60_Mon = new System.Windows.Forms.CheckBox();
            this.checkBox_EmLimit80_Mon = new System.Windows.Forms.CheckBox();
            this.checkBox_SecondaryRegulation_Mon = new System.Windows.Forms.CheckBox();
            this.checkBox_ParkMVBreaker_Mon = new System.Windows.Forms.CheckBox();
            this.checkBox_ParkOperation_Mon = new System.Windows.Forms.CheckBox();
            this.label78 = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.label80 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.label_PowerSetpoint_Mon = new System.Windows.Forms.Label();
            this.label68 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.label_Current_Mon = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label_ReactivePower_Mon = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label_ActivePower_Mon = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label_Voltage_Mon = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label_Windspeed_Mon = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label87 = new System.Windows.Forms.Label();
            this.label86 = new System.Windows.Forms.Label();
            this.label85 = new System.Windows.Forms.Label();
            this.label84 = new System.Windows.Forms.Label();
            this.label83 = new System.Windows.Forms.Label();
            this.label_PowerSetpoint = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label82 = new System.Windows.Forms.Label();
            this.label_ParkOperation = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label81 = new System.Windows.Forms.Label();
            this.label_SecRegul = new System.Windows.Forms.Label();
            this.label_EmLimit80 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_EmLimit60 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_EmLimit40 = new System.Windows.Forms.Label();
            this.label_EmLimit20 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button_ServiceFunctions = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox_Clients
            // 
            this.listBox_Clients.FormattingEnabled = true;
            this.listBox_Clients.Location = new System.Drawing.Point(331, 34);
            this.listBox_Clients.Name = "listBox_Clients";
            this.listBox_Clients.Size = new System.Drawing.Size(158, 134);
            this.listBox_Clients.TabIndex = 2;
            // 
            // label_Clients
            // 
            this.label_Clients.AutoSize = true;
            this.label_Clients.Location = new System.Drawing.Point(328, 18);
            this.label_Clients.Name = "label_Clients";
            this.label_Clients.Size = new System.Drawing.Size(121, 13);
            this.label_Clients.TabIndex = 3;
            this.label_Clients.Text = "Active clients/channels:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(286, 630);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Linked Data";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkBox_EmLimit20_Mon);
            this.groupBox4.Controls.Add(this.checkBox_EmLimit40_Mon);
            this.groupBox4.Controls.Add(this.checkBox_EmLimit60_Mon);
            this.groupBox4.Controls.Add(this.checkBox_EmLimit80_Mon);
            this.groupBox4.Controls.Add(this.checkBox_SecondaryRegulation_Mon);
            this.groupBox4.Controls.Add(this.checkBox_ParkMVBreaker_Mon);
            this.groupBox4.Controls.Add(this.checkBox_ParkOperation_Mon);
            this.groupBox4.Controls.Add(this.label78);
            this.groupBox4.Controls.Add(this.label79);
            this.groupBox4.Controls.Add(this.label80);
            this.groupBox4.Controls.Add(this.label44);
            this.groupBox4.Controls.Add(this.label69);
            this.groupBox4.Controls.Add(this.label43);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label66);
            this.groupBox4.Controls.Add(this.label_PowerSetpoint_Mon);
            this.groupBox4.Controls.Add(this.label68);
            this.groupBox4.Controls.Add(this.label65);
            this.groupBox4.Controls.Add(this.label63);
            this.groupBox4.Controls.Add(this.label64);
            this.groupBox4.Controls.Add(this.label62);
            this.groupBox4.Controls.Add(this.label61);
            this.groupBox4.Controls.Add(this.label_Current_Mon);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.label_ReactivePower_Mon);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.label_ActivePower_Mon);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.label_Voltage_Mon);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.label_Windspeed_Mon);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Location = new System.Drawing.Point(24, 248);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(237, 359);
            this.groupBox4.TabIndex = 170;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Monitoring Signals (OUT)";
            // 
            // checkBox_EmLimit20_Mon
            // 
            this.checkBox_EmLimit20_Mon.AutoSize = true;
            this.checkBox_EmLimit20_Mon.Enabled = false;
            this.checkBox_EmLimit20_Mon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_EmLimit20_Mon.Location = new System.Drawing.Point(114, 162);
            this.checkBox_EmLimit20_Mon.Name = "checkBox_EmLimit20_Mon";
            this.checkBox_EmLimit20_Mon.Size = new System.Drawing.Size(15, 14);
            this.checkBox_EmLimit20_Mon.TabIndex = 209;
            this.checkBox_EmLimit20_Mon.UseVisualStyleBackColor = true;
            // 
            // checkBox_EmLimit40_Mon
            // 
            this.checkBox_EmLimit40_Mon.AutoSize = true;
            this.checkBox_EmLimit40_Mon.Enabled = false;
            this.checkBox_EmLimit40_Mon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_EmLimit40_Mon.Location = new System.Drawing.Point(114, 141);
            this.checkBox_EmLimit40_Mon.Name = "checkBox_EmLimit40_Mon";
            this.checkBox_EmLimit40_Mon.Size = new System.Drawing.Size(15, 14);
            this.checkBox_EmLimit40_Mon.TabIndex = 208;
            this.checkBox_EmLimit40_Mon.UseVisualStyleBackColor = true;
            // 
            // checkBox_EmLimit60_Mon
            // 
            this.checkBox_EmLimit60_Mon.AutoSize = true;
            this.checkBox_EmLimit60_Mon.Enabled = false;
            this.checkBox_EmLimit60_Mon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_EmLimit60_Mon.Location = new System.Drawing.Point(114, 120);
            this.checkBox_EmLimit60_Mon.Name = "checkBox_EmLimit60_Mon";
            this.checkBox_EmLimit60_Mon.Size = new System.Drawing.Size(15, 14);
            this.checkBox_EmLimit60_Mon.TabIndex = 207;
            this.checkBox_EmLimit60_Mon.UseVisualStyleBackColor = true;
            // 
            // checkBox_EmLimit80_Mon
            // 
            this.checkBox_EmLimit80_Mon.AutoSize = true;
            this.checkBox_EmLimit80_Mon.Enabled = false;
            this.checkBox_EmLimit80_Mon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_EmLimit80_Mon.Location = new System.Drawing.Point(114, 99);
            this.checkBox_EmLimit80_Mon.Name = "checkBox_EmLimit80_Mon";
            this.checkBox_EmLimit80_Mon.Size = new System.Drawing.Size(15, 14);
            this.checkBox_EmLimit80_Mon.TabIndex = 206;
            this.checkBox_EmLimit80_Mon.UseVisualStyleBackColor = true;
            // 
            // checkBox_SecondaryRegulation_Mon
            // 
            this.checkBox_SecondaryRegulation_Mon.AutoSize = true;
            this.checkBox_SecondaryRegulation_Mon.Enabled = false;
            this.checkBox_SecondaryRegulation_Mon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_SecondaryRegulation_Mon.Location = new System.Drawing.Point(114, 78);
            this.checkBox_SecondaryRegulation_Mon.Name = "checkBox_SecondaryRegulation_Mon";
            this.checkBox_SecondaryRegulation_Mon.Size = new System.Drawing.Size(15, 14);
            this.checkBox_SecondaryRegulation_Mon.TabIndex = 205;
            this.checkBox_SecondaryRegulation_Mon.UseVisualStyleBackColor = true;
            // 
            // checkBox_ParkMVBreaker_Mon
            // 
            this.checkBox_ParkMVBreaker_Mon.AutoSize = true;
            this.checkBox_ParkMVBreaker_Mon.Enabled = false;
            this.checkBox_ParkMVBreaker_Mon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_ParkMVBreaker_Mon.Location = new System.Drawing.Point(114, 57);
            this.checkBox_ParkMVBreaker_Mon.Name = "checkBox_ParkMVBreaker_Mon";
            this.checkBox_ParkMVBreaker_Mon.Size = new System.Drawing.Size(15, 14);
            this.checkBox_ParkMVBreaker_Mon.TabIndex = 204;
            this.checkBox_ParkMVBreaker_Mon.UseVisualStyleBackColor = true;
            // 
            // checkBox_ParkOperation_Mon
            // 
            this.checkBox_ParkOperation_Mon.AutoSize = true;
            this.checkBox_ParkOperation_Mon.Enabled = false;
            this.checkBox_ParkOperation_Mon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_ParkOperation_Mon.Location = new System.Drawing.Point(114, 36);
            this.checkBox_ParkOperation_Mon.Name = "checkBox_ParkOperation_Mon";
            this.checkBox_ParkOperation_Mon.Size = new System.Drawing.Size(15, 14);
            this.checkBox_ParkOperation_Mon.TabIndex = 203;
            this.checkBox_ParkOperation_Mon.UseVisualStyleBackColor = true;
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.Location = new System.Drawing.Point(171, 162);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(52, 13);
            this.label78.TabIndex = 197;
            this.label78.Text = "IOA 2007";
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.Location = new System.Drawing.Point(171, 141);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(52, 13);
            this.label79.TabIndex = 196;
            this.label79.Text = "IOA 2006";
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.Location = new System.Drawing.Point(171, 120);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(52, 13);
            this.label80.TabIndex = 195;
            this.label80.Text = "IOA 2005";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(171, 99);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(52, 13);
            this.label44.TabIndex = 194;
            this.label44.Text = "IOA 2004";
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(171, 78);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(52, 13);
            this.label69.TabIndex = 193;
            this.label69.Text = "IOA 2003";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(171, 57);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(52, 13);
            this.label43.TabIndex = 192;
            this.label43.Text = "IOA 2002";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(171, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 191;
            this.label10.Text = "IOA 2001";
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(171, 288);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(52, 13);
            this.label66.TabIndex = 190;
            this.label66.Text = "IOA 1006";
            // 
            // label_PowerSetpoint_Mon
            // 
            this.label_PowerSetpoint_Mon.BackColor = System.Drawing.Color.Silver;
            this.label_PowerSetpoint_Mon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_PowerSetpoint_Mon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_PowerSetpoint_Mon.Location = new System.Drawing.Point(114, 284);
            this.label_PowerSetpoint_Mon.Name = "label_PowerSetpoint_Mon";
            this.label_PowerSetpoint_Mon.Size = new System.Drawing.Size(51, 21);
            this.label_PowerSetpoint_Mon.TabIndex = 189;
            this.label_PowerSetpoint_Mon.Text = "20";
            this.label_PowerSetpoint_Mon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(31, 288);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(77, 13);
            this.label68.TabIndex = 188;
            this.label68.Text = "Power setpoint";
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(171, 267);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(52, 13);
            this.label65.TabIndex = 187;
            this.label65.Text = "IOA 1005";
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(171, 246);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(52, 13);
            this.label63.TabIndex = 186;
            this.label63.Text = "IOA 1004";
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(171, 225);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(52, 13);
            this.label64.TabIndex = 185;
            this.label64.Text = "IOA 1003";
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(171, 204);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(52, 13);
            this.label62.TabIndex = 184;
            this.label62.Text = "IOA 1002";
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(171, 183);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(52, 13);
            this.label61.TabIndex = 6;
            this.label61.Text = "IOA 1001";
            // 
            // label_Current_Mon
            // 
            this.label_Current_Mon.BackColor = System.Drawing.Color.Silver;
            this.label_Current_Mon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_Current_Mon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_Current_Mon.Location = new System.Drawing.Point(114, 263);
            this.label_Current_Mon.Name = "label_Current_Mon";
            this.label_Current_Mon.Size = new System.Drawing.Size(51, 21);
            this.label_Current_Mon.TabIndex = 183;
            this.label_Current_Mon.Text = "100";
            this.label_Current_Mon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(67, 267);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(41, 13);
            this.label20.TabIndex = 182;
            this.label20.Text = "Current";
            // 
            // label_ReactivePower_Mon
            // 
            this.label_ReactivePower_Mon.BackColor = System.Drawing.Color.Silver;
            this.label_ReactivePower_Mon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_ReactivePower_Mon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_ReactivePower_Mon.Location = new System.Drawing.Point(114, 242);
            this.label_ReactivePower_Mon.Name = "label_ReactivePower_Mon";
            this.label_ReactivePower_Mon.Size = new System.Drawing.Size(51, 21);
            this.label_ReactivePower_Mon.TabIndex = 181;
            this.label_ReactivePower_Mon.Text = "0";
            this.label_ReactivePower_Mon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(26, 246);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(82, 13);
            this.label22.TabIndex = 180;
            this.label22.Text = "Reactive power";
            // 
            // label_ActivePower_Mon
            // 
            this.label_ActivePower_Mon.BackColor = System.Drawing.Color.Silver;
            this.label_ActivePower_Mon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_ActivePower_Mon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_ActivePower_Mon.Location = new System.Drawing.Point(114, 221);
            this.label_ActivePower_Mon.Name = "label_ActivePower_Mon";
            this.label_ActivePower_Mon.Size = new System.Drawing.Size(51, 21);
            this.label_ActivePower_Mon.TabIndex = 179;
            this.label_ActivePower_Mon.Text = "20";
            this.label_ActivePower_Mon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(39, 225);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(69, 13);
            this.label19.TabIndex = 178;
            this.label19.Text = "Active power";
            // 
            // label_Voltage_Mon
            // 
            this.label_Voltage_Mon.BackColor = System.Drawing.Color.Silver;
            this.label_Voltage_Mon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_Voltage_Mon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_Voltage_Mon.Location = new System.Drawing.Point(114, 200);
            this.label_Voltage_Mon.Name = "label_Voltage_Mon";
            this.label_Voltage_Mon.Size = new System.Drawing.Size(51, 21);
            this.label_Voltage_Mon.TabIndex = 177;
            this.label_Voltage_Mon.Text = "10500";
            this.label_Voltage_Mon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(65, 204);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(43, 13);
            this.label17.TabIndex = 176;
            this.label17.Text = "Voltage";
            // 
            // label_Windspeed_Mon
            // 
            this.label_Windspeed_Mon.BackColor = System.Drawing.Color.Silver;
            this.label_Windspeed_Mon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_Windspeed_Mon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_Windspeed_Mon.Location = new System.Drawing.Point(114, 179);
            this.label_Windspeed_Mon.Name = "label_Windspeed_Mon";
            this.label_Windspeed_Mon.Size = new System.Drawing.Size(51, 21);
            this.label_Windspeed_Mon.TabIndex = 170;
            this.label_Windspeed_Mon.Text = "125";
            this.label_Windspeed_Mon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(44, 183);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(64, 13);
            this.label16.TabIndex = 169;
            this.label16.Text = "Wind speed";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 170;
            this.label2.Text = "Em limit 60";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(51, 141);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 13);
            this.label14.TabIndex = 172;
            this.label14.Text = "Em limit 40";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(51, 99);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(57, 13);
            this.label15.TabIndex = 169;
            this.label15.Text = "Em limit 80";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(21, 78);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(87, 13);
            this.label13.TabIndex = 163;
            this.label13.Text = "Secondary regul.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 57);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 13);
            this.label11.TabIndex = 161;
            this.label11.Text = "Park MV breaker";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(51, 162);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(57, 13);
            this.label18.TabIndex = 174;
            this.label18.Text = "Em limit 20";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 157;
            this.label7.Text = "Park operation";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label87);
            this.groupBox3.Controls.Add(this.label86);
            this.groupBox3.Controls.Add(this.label85);
            this.groupBox3.Controls.Add(this.label84);
            this.groupBox3.Controls.Add(this.label83);
            this.groupBox3.Controls.Add(this.label_PowerSetpoint);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label82);
            this.groupBox3.Controls.Add(this.label_ParkOperation);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label81);
            this.groupBox3.Controls.Add(this.label_SecRegul);
            this.groupBox3.Controls.Add(this.label_EmLimit80);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label_EmLimit60);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label_EmLimit40);
            this.groupBox3.Controls.Add(this.label_EmLimit20);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(24, 40);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(237, 202);
            this.groupBox3.TabIndex = 169;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Control Signals (IN)";
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.Location = new System.Drawing.Point(171, 145);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(34, 13);
            this.label87.TabIndex = 204;
            this.label87.Text = "IOA 6";
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.Location = new System.Drawing.Point(171, 124);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(34, 13);
            this.label86.TabIndex = 203;
            this.label86.Text = "IOA 5";
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.Location = new System.Drawing.Point(171, 103);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(34, 13);
            this.label85.TabIndex = 202;
            this.label85.Text = "IOA 4";
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.Location = new System.Drawing.Point(171, 82);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(34, 13);
            this.label84.TabIndex = 201;
            this.label84.Text = "IOA 3";
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.Location = new System.Drawing.Point(171, 61);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(34, 13);
            this.label83.TabIndex = 200;
            this.label83.Text = "IOA 2";
            // 
            // label_PowerSetpoint
            // 
            this.label_PowerSetpoint.BackColor = System.Drawing.Color.Silver;
            this.label_PowerSetpoint.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_PowerSetpoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_PowerSetpoint.Location = new System.Drawing.Point(114, 162);
            this.label_PowerSetpoint.Name = "label_PowerSetpoint";
            this.label_PowerSetpoint.Size = new System.Drawing.Size(51, 21);
            this.label_PowerSetpoint.TabIndex = 166;
            this.label_PowerSetpoint.Text = "20";
            this.label_PowerSetpoint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 165;
            this.label5.Text = "Power setpoint";
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.Location = new System.Drawing.Point(171, 40);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(34, 13);
            this.label82.TabIndex = 199;
            this.label82.Text = "IOA 1";
            // 
            // label_ParkOperation
            // 
            this.label_ParkOperation.BackColor = System.Drawing.Color.Silver;
            this.label_ParkOperation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_ParkOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_ParkOperation.Location = new System.Drawing.Point(114, 120);
            this.label_ParkOperation.Name = "label_ParkOperation";
            this.label_ParkOperation.Size = new System.Drawing.Size(40, 21);
            this.label_ParkOperation.TabIndex = 156;
            this.label_ParkOperation.Text = "False";
            this.label_ParkOperation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Park start/stop";
            // 
            // label81
            // 
            this.label81.AutoSize = true;
            this.label81.Location = new System.Drawing.Point(171, 166);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(52, 13);
            this.label81.TabIndex = 198;
            this.label81.Text = "IOA 6201";
            // 
            // label_SecRegul
            // 
            this.label_SecRegul.BackColor = System.Drawing.Color.Silver;
            this.label_SecRegul.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_SecRegul.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_SecRegul.Location = new System.Drawing.Point(114, 141);
            this.label_SecRegul.Name = "label_SecRegul";
            this.label_SecRegul.Size = new System.Drawing.Size(40, 21);
            this.label_SecRegul.TabIndex = 168;
            this.label_SecRegul.Text = "False";
            this.label_SecRegul.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_EmLimit80
            // 
            this.label_EmLimit80.BackColor = System.Drawing.Color.Silver;
            this.label_EmLimit80.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_EmLimit80.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_EmLimit80.Location = new System.Drawing.Point(114, 36);
            this.label_EmLimit80.Name = "label_EmLimit80";
            this.label_EmLimit80.Size = new System.Drawing.Size(40, 21);
            this.label_EmLimit80.TabIndex = 158;
            this.label_EmLimit80.Text = "False";
            this.label_EmLimit80.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 145);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 13);
            this.label9.TabIndex = 167;
            this.label9.Text = "Secondary regul.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 159;
            this.label4.Text = "Em limit 60";
            // 
            // label_EmLimit60
            // 
            this.label_EmLimit60.BackColor = System.Drawing.Color.Silver;
            this.label_EmLimit60.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_EmLimit60.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_EmLimit60.Location = new System.Drawing.Point(114, 57);
            this.label_EmLimit60.Name = "label_EmLimit60";
            this.label_EmLimit60.Size = new System.Drawing.Size(40, 21);
            this.label_EmLimit60.TabIndex = 160;
            this.label_EmLimit60.Text = "False";
            this.label_EmLimit60.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(51, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 161;
            this.label6.Text = "Em limit 40";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 157;
            this.label3.Text = "Em limit 80";
            // 
            // label_EmLimit40
            // 
            this.label_EmLimit40.BackColor = System.Drawing.Color.Silver;
            this.label_EmLimit40.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_EmLimit40.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_EmLimit40.Location = new System.Drawing.Point(114, 78);
            this.label_EmLimit40.Name = "label_EmLimit40";
            this.label_EmLimit40.Size = new System.Drawing.Size(40, 21);
            this.label_EmLimit40.TabIndex = 162;
            this.label_EmLimit40.Text = "False";
            this.label_EmLimit40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_EmLimit20
            // 
            this.label_EmLimit20.BackColor = System.Drawing.Color.Silver;
            this.label_EmLimit20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_EmLimit20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label_EmLimit20.Location = new System.Drawing.Point(114, 99);
            this.label_EmLimit20.Name = "label_EmLimit20";
            this.label_EmLimit20.Size = new System.Drawing.Size(40, 21);
            this.label_EmLimit20.TabIndex = 164;
            this.label_EmLimit20.Text = "False";
            this.label_EmLimit20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(51, 103);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 163;
            this.label8.Text = "Em limit 20";
            // 
            // button_ServiceFunctions
            // 
            this.button_ServiceFunctions.Location = new System.Drawing.Point(331, 197);
            this.button_ServiceFunctions.Name = "button_ServiceFunctions";
            this.button_ServiceFunctions.Size = new System.Drawing.Size(158, 23);
            this.button_ServiceFunctions.TabIndex = 5;
            this.button_ServiceFunctions.Text = "Service functions...";
            this.button_ServiceFunctions.UseVisualStyleBackColor = true;
            this.button_ServiceFunctions.Click += new System.EventHandler(this.button_ServiceFunctions_Click);
            // 
            // Form_IEC104Interface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 654);
            this.Controls.Add(this.button_ServiceFunctions);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label_Clients);
            this.Controls.Add(this.listBox_Clients);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form_IEC104Interface";
            this.ShowIcon = false;
            this.Text = "IEC-104 Interface";
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_Clients;
        private System.Windows.Forms.Label label_Clients;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_EmLimit80;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_ParkOperation;
        private System.Windows.Forms.Label label_EmLimit20;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label_EmLimit40;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label_EmLimit60;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_PowerSetpoint;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_SecRegul;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label_Windspeed_Mon;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label_Voltage_Mon;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label_ActivePower_Mon;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label_Current_Mon;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label_ReactivePower_Mon;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.Label label_PowerSetpoint_Mon;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label87;
        private System.Windows.Forms.Label label86;
        private System.Windows.Forms.Label label85;
        private System.Windows.Forms.Label label84;
        private System.Windows.Forms.Label label83;
        private System.Windows.Forms.Label label82;
        private System.Windows.Forms.Label label81;
        private System.Windows.Forms.CheckBox checkBox_EmLimit20_Mon;
        private System.Windows.Forms.CheckBox checkBox_EmLimit40_Mon;
        private System.Windows.Forms.CheckBox checkBox_EmLimit60_Mon;
        private System.Windows.Forms.CheckBox checkBox_EmLimit80_Mon;
        private System.Windows.Forms.CheckBox checkBox_SecondaryRegulation_Mon;
        private System.Windows.Forms.CheckBox checkBox_ParkMVBreaker_Mon;
        private System.Windows.Forms.CheckBox checkBox_ParkOperation_Mon;
        private System.Windows.Forms.Button button_ServiceFunctions;

    }
}