namespace TK_ParkServer.Forms.Settings
{
    partial class Form_TurbineSettings
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
            this.tabControl_Main = new System.Windows.Forms.TabControl();
            this.tabPage_General = new System.Windows.Forms.TabPage();
            this.button_FrequencyControl = new System.Windows.Forms.Button();
            this.button_AutoReset = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_ReactivePowerRamping = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_ReactivePowerSetpoint = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_ApplyGeneral = new System.Windows.Forms.Button();
            this.textBox_NominalPower = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox_ActivePowerRamping = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.tabPage_Communication = new System.Windows.Forms.TabPage();
            this.comboBox_CommInterface = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_Turbines = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabControl_Main.SuspendLayout();
            this.tabPage_General.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage_Communication.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl_Main
            // 
            this.tabControl_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl_Main.Controls.Add(this.tabPage_General);
            this.tabControl_Main.Controls.Add(this.tabPage_Communication);
            this.tabControl_Main.Location = new System.Drawing.Point(12, 54);
            this.tabControl_Main.Name = "tabControl_Main";
            this.tabControl_Main.SelectedIndex = 0;
            this.tabControl_Main.Size = new System.Drawing.Size(594, 384);
            this.tabControl_Main.TabIndex = 7;
            // 
            // tabPage_General
            // 
            this.tabPage_General.Controls.Add(this.button_FrequencyControl);
            this.tabPage_General.Controls.Add(this.button_AutoReset);
            this.tabPage_General.Controls.Add(this.groupBox1);
            this.tabPage_General.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage_General.Location = new System.Drawing.Point(4, 22);
            this.tabPage_General.Name = "tabPage_General";
            this.tabPage_General.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_General.Size = new System.Drawing.Size(586, 358);
            this.tabPage_General.TabIndex = 0;
            this.tabPage_General.Text = "General";
            this.tabPage_General.UseVisualStyleBackColor = true;
            // 
            // button_FrequencyControl
            // 
            this.button_FrequencyControl.Location = new System.Drawing.Point(209, 305);
            this.button_FrequencyControl.Name = "button_FrequencyControl";
            this.button_FrequencyControl.Size = new System.Drawing.Size(114, 23);
            this.button_FrequencyControl.TabIndex = 51;
            this.button_FrequencyControl.Text = "Frequency control";
            this.button_FrequencyControl.UseVisualStyleBackColor = true;
            this.button_FrequencyControl.Click += new System.EventHandler(this.button_FrequencyControl_Click);
            // 
            // button_AutoReset
            // 
            this.button_AutoReset.Location = new System.Drawing.Point(43, 305);
            this.button_AutoReset.Name = "button_AutoReset";
            this.button_AutoReset.Size = new System.Drawing.Size(114, 23);
            this.button_AutoReset.TabIndex = 50;
            this.button_AutoReset.Text = "Autoreset Errors...";
            this.button_AutoReset.UseVisualStyleBackColor = true;
            this.button_AutoReset.Click += new System.EventHandler(this.button_AutoReset_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_ReactivePowerRamping);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBox_ReactivePowerSetpoint);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.button_ApplyGeneral);
            this.groupBox1.Controls.Add(this.textBox_NominalPower);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.textBox_ActivePowerRamping);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label27);
            this.groupBox1.Controls.Add(this.label46);
            this.groupBox1.Location = new System.Drawing.Point(43, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(466, 229);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Power";
            // 
            // textBox_ReactivePowerRamping
            // 
            this.textBox_ReactivePowerRamping.Enabled = false;
            this.textBox_ReactivePowerRamping.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_ReactivePowerRamping.Location = new System.Drawing.Point(211, 169);
            this.textBox_ReactivePowerRamping.Name = "textBox_ReactivePowerRamping";
            this.textBox_ReactivePowerRamping.ReadOnly = true;
            this.textBox_ReactivePowerRamping.Size = new System.Drawing.Size(69, 29);
            this.textBox_ReactivePowerRamping.TabIndex = 38;
            this.textBox_ReactivePowerRamping.TabStop = false;
            this.textBox_ReactivePowerRamping.Text = "100";
            this.textBox_ReactivePowerRamping.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_ReactivePowerRamping.Leave += new System.EventHandler(this.textBox_ReactivePowerRamping_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(26, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(179, 20);
            this.label6.TabIndex = 40;
            this.label6.Text = "Reactive power ramping";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(286, 180);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 39;
            this.label7.Text = "kVar/s";
            // 
            // textBox_ReactivePowerSetpoint
            // 
            this.textBox_ReactivePowerSetpoint.Enabled = false;
            this.textBox_ReactivePowerSetpoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_ReactivePowerSetpoint.Location = new System.Drawing.Point(211, 134);
            this.textBox_ReactivePowerSetpoint.Name = "textBox_ReactivePowerSetpoint";
            this.textBox_ReactivePowerSetpoint.ReadOnly = true;
            this.textBox_ReactivePowerSetpoint.Size = new System.Drawing.Size(69, 29);
            this.textBox_ReactivePowerSetpoint.TabIndex = 35;
            this.textBox_ReactivePowerSetpoint.TabStop = false;
            this.textBox_ReactivePowerSetpoint.Text = "0";
            this.textBox_ReactivePowerSetpoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 20);
            this.label4.TabIndex = 37;
            this.label4.Text = "Reactive power setpoint";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(286, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "kVar";
            // 
            // button_ApplyGeneral
            // 
            this.button_ApplyGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ApplyGeneral.Enabled = false;
            this.button_ApplyGeneral.Location = new System.Drawing.Point(385, 200);
            this.button_ApplyGeneral.Name = "button_ApplyGeneral";
            this.button_ApplyGeneral.Size = new System.Drawing.Size(75, 23);
            this.button_ApplyGeneral.TabIndex = 31;
            this.button_ApplyGeneral.Text = "Apply";
            this.button_ApplyGeneral.UseVisualStyleBackColor = true;
            this.button_ApplyGeneral.Click += new System.EventHandler(this.button_ApplyGeneral_Click);
            // 
            // textBox_NominalPower
            // 
            this.textBox_NominalPower.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_NominalPower.Location = new System.Drawing.Point(211, 29);
            this.textBox_NominalPower.Name = "textBox_NominalPower";
            this.textBox_NominalPower.Size = new System.Drawing.Size(69, 29);
            this.textBox_NominalPower.TabIndex = 25;
            this.textBox_NominalPower.TabStop = false;
            this.textBox_NominalPower.Text = "9999";
            this.textBox_NominalPower.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_NominalPower.Leave += new System.EventHandler(this.textBox_NominalPower_Leave);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(92, 33);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(113, 20);
            this.label16.TabIndex = 24;
            this.label16.Text = "Nominal power";
            // 
            // textBox_ActivePowerRamping
            // 
            this.textBox_ActivePowerRamping.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_ActivePowerRamping.Location = new System.Drawing.Point(211, 99);
            this.textBox_ActivePowerRamping.Name = "textBox_ActivePowerRamping";
            this.textBox_ActivePowerRamping.Size = new System.Drawing.Size(69, 29);
            this.textBox_ActivePowerRamping.TabIndex = 28;
            this.textBox_ActivePowerRamping.TabStop = false;
            this.textBox_ActivePowerRamping.Text = "999";
            this.textBox_ActivePowerRamping.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_ActivePowerRamping.Leave += new System.EventHandler(this.textBox_ActivePowerRamping_Leave);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(286, 40);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(24, 13);
            this.label15.TabIndex = 26;
            this.label15.Text = "kW";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(45, 103);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(160, 20);
            this.label27.TabIndex = 30;
            this.label27.Text = "Active power ramping";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(286, 110);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(34, 13);
            this.label46.TabIndex = 29;
            this.label46.Text = "kW/s";
            // 
            // tabPage_Communication
            // 
            this.tabPage_Communication.Controls.Add(this.comboBox_CommInterface);
            this.tabPage_Communication.Controls.Add(this.label1);
            this.tabPage_Communication.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Communication.Name = "tabPage_Communication";
            this.tabPage_Communication.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Communication.Size = new System.Drawing.Size(586, 358);
            this.tabPage_Communication.TabIndex = 3;
            this.tabPage_Communication.Text = "Communication";
            this.tabPage_Communication.UseVisualStyleBackColor = true;
            // 
            // comboBox_CommInterface
            // 
            this.comboBox_CommInterface.Enabled = false;
            this.comboBox_CommInterface.FormattingEnabled = true;
            this.comboBox_CommInterface.Location = new System.Drawing.Point(197, 84);
            this.comboBox_CommInterface.Name = "comboBox_CommInterface";
            this.comboBox_CommInterface.Size = new System.Drawing.Size(121, 21);
            this.comboBox_CommInterface.TabIndex = 1;
            this.comboBox_CommInterface.Text = "Vestas COM";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Communication Interface:";
            // 
            // comboBox_Turbines
            // 
            this.comboBox_Turbines.Enabled = false;
            this.comboBox_Turbines.FormattingEnabled = true;
            this.comboBox_Turbines.Location = new System.Drawing.Point(83, 14);
            this.comboBox_Turbines.Name = "comboBox_Turbines";
            this.comboBox_Turbines.Size = new System.Drawing.Size(121, 21);
            this.comboBox_Turbines.TabIndex = 49;
            this.comboBox_Turbines.Text = "T01 - Vestas V80";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 20);
            this.label8.TabIndex = 50;
            this.label8.Text = "Turbine";
            // 
            // Form_TurbineSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 452);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBox_Turbines);
            this.Controls.Add(this.tabControl_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_TurbineSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Turbine settings";
            this.tabControl_Main.ResumeLayout(false);
            this.tabPage_General.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage_Communication.ResumeLayout(false);
            this.tabPage_Communication.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl_Main;
        private System.Windows.Forms.TabPage tabPage_General;
        private System.Windows.Forms.ComboBox comboBox_Turbines;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_ApplyGeneral;
        private System.Windows.Forms.TextBox textBox_NominalPower;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBox_ActivePowerRamping;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.TabPage tabPage_Communication;
        private System.Windows.Forms.ComboBox comboBox_CommInterface;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_ReactivePowerRamping;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_ReactivePowerSetpoint;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_AutoReset;
        private System.Windows.Forms.Button button_FrequencyControl;
    }
}