namespace Eleon_SCADA.Forms.Settings
{
    partial class Form_TurbineCommunication
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
            this.button_CommStats = new System.Windows.Forms.Button();
            this.comboBox_Parity = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox_PollInterval2 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_Timeout = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_PollInterval1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_Baudrate = new System.Windows.Forms.TextBox();
            this.comboBox_PortName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Apply = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_CommStatusTimeout = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_CommStats
            // 
            this.button_CommStats.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_CommStats.Location = new System.Drawing.Point(12, 269);
            this.button_CommStats.Name = "button_CommStats";
            this.button_CommStats.Size = new System.Drawing.Size(103, 22);
            this.button_CommStats.TabIndex = 13;
            this.button_CommStats.Text = "Comm. Stats";
            this.button_CommStats.UseVisualStyleBackColor = true;
            this.button_CommStats.Click += new System.EventHandler(this.button_CommErrors_Click);
            // 
            // comboBox_Parity
            // 
            this.comboBox_Parity.FormattingEnabled = true;
            this.comboBox_Parity.Location = new System.Drawing.Point(150, 118);
            this.comboBox_Parity.Name = "comboBox_Parity";
            this.comboBox_Parity.Size = new System.Drawing.Size(61, 21);
            this.comboBox_Parity.TabIndex = 16;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(108, 121);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(36, 13);
            this.label20.TabIndex = 15;
            this.label20.Text = "Parity:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(217, 174);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(20, 13);
            this.label18.TabIndex = 13;
            this.label18.Text = "ms";
            // 
            // textBox_PollInterval2
            // 
            this.textBox_PollInterval2.Location = new System.Drawing.Point(150, 171);
            this.textBox_PollInterval2.Name = "textBox_PollInterval2";
            this.textBox_PollInterval2.Size = new System.Drawing.Size(61, 20);
            this.textBox_PollInterval2.TabIndex = 11;
            this.textBox_PollInterval2.Text = "1000";
            this.textBox_PollInterval2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(36, 174);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(108, 13);
            this.label19.TabIndex = 12;
            this.label19.Text = "Polling interval (slow):";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(217, 200);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "ms";
            // 
            // textBox_Timeout
            // 
            this.textBox_Timeout.Location = new System.Drawing.Point(150, 197);
            this.textBox_Timeout.Name = "textBox_Timeout";
            this.textBox_Timeout.Size = new System.Drawing.Size(61, 20);
            this.textBox_Timeout.TabIndex = 8;
            this.textBox_Timeout.Text = "200";
            this.textBox_Timeout.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(45, 200);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Response Timeout:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(217, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "ms";
            // 
            // textBox_PollInterval1
            // 
            this.textBox_PollInterval1.Location = new System.Drawing.Point(150, 145);
            this.textBox_PollInterval1.Name = "textBox_PollInterval1";
            this.textBox_PollInterval1.Size = new System.Drawing.Size(61, 20);
            this.textBox_PollInterval1.TabIndex = 5;
            this.textBox_PollInterval1.Text = "500";
            this.textBox_PollInterval1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(40, 148);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Polling interval (fast):";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(217, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "kbit/s";
            // 
            // textBox_Baudrate
            // 
            this.textBox_Baudrate.Location = new System.Drawing.Point(150, 92);
            this.textBox_Baudrate.Name = "textBox_Baudrate";
            this.textBox_Baudrate.Size = new System.Drawing.Size(61, 20);
            this.textBox_Baudrate.TabIndex = 3;
            this.textBox_Baudrate.Text = "1600";
            this.textBox_Baudrate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // comboBox_PortName
            // 
            this.comboBox_PortName.FormattingEnabled = true;
            this.comboBox_PortName.Location = new System.Drawing.Point(150, 65);
            this.comboBox_PortName.Name = "comboBox_PortName";
            this.comboBox_PortName.Size = new System.Drawing.Size(61, 21);
            this.comboBox_PortName.TabIndex = 2;
            this.comboBox_PortName.Text = "COMx";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Baudrate:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Port:";
            // 
            // button_Apply
            // 
            this.button_Apply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Apply.Location = new System.Drawing.Point(259, 268);
            this.button_Apply.Name = "button_Apply";
            this.button_Apply.Size = new System.Drawing.Size(75, 23);
            this.button_Apply.TabIndex = 19;
            this.button_Apply.Text = "Apply";
            this.button_Apply.UseVisualStyleBackColor = true;
            this.button_Apply.Click += new System.EventHandler(this.button_Apply_Click);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(150, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(168, 20);
            this.textBox1.TabIndex = 20;
            this.textBox1.Text = "Vestas COM";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Interface name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(217, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "ms";
            // 
            // textBox_CommStatusTimeout
            // 
            this.textBox_CommStatusTimeout.Location = new System.Drawing.Point(150, 223);
            this.textBox_CommStatusTimeout.Name = "textBox_CommStatusTimeout";
            this.textBox_CommStatusTimeout.Size = new System.Drawing.Size(61, 20);
            this.textBox_CommStatusTimeout.TabIndex = 22;
            this.textBox_CommStatusTimeout.Text = "3500";
            this.textBox_CommStatusTimeout.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "No Comm Timeout:";
            // 
            // Form_TurbineCommunication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 303);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_CommStatusTimeout);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button_Apply);
            this.Controls.Add(this.comboBox_Parity);
            this.Controls.Add(this.button_CommStats);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.comboBox_PortName);
            this.Controls.Add(this.textBox_PollInterval2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox_Baudrate);
            this.Controls.Add(this.textBox_Timeout);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_PollInterval1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_TurbineCommunication";
            this.Text = "Communication";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_CommStats;
        private System.Windows.Forms.ComboBox comboBox_Parity;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBox_PollInterval2;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_Timeout;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_PollInterval1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_Baudrate;
        private System.Windows.Forms.ComboBox comboBox_PortName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Apply;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_CommStatusTimeout;
        private System.Windows.Forms.Label label5;
    }
}