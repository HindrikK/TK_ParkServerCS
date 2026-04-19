namespace Eleon_SCADA.Forms.Settings
{
    partial class Form_IEC104Settings
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_MaxNoOfClients = new System.Windows.Forms.TextBox();
            this.textBox_ServerIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_OK = new System.Windows.Forms.Button();
            this.checkBox_periodicTransmission = new System.Windows.Forms.CheckBox();
            this.textBox_periodicPeriod = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_ASDU = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_ReconnectTime = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Max number of clients:";
            // 
            // textBox_MaxNoOfClients
            // 
            this.textBox_MaxNoOfClients.Location = new System.Drawing.Point(150, 31);
            this.textBox_MaxNoOfClients.Name = "textBox_MaxNoOfClients";
            this.textBox_MaxNoOfClients.Size = new System.Drawing.Size(35, 20);
            this.textBox_MaxNoOfClients.TabIndex = 1;
            this.textBox_MaxNoOfClients.Text = "10";
            this.textBox_MaxNoOfClients.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_ServerIP
            // 
            this.textBox_ServerIP.Location = new System.Drawing.Point(150, 57);
            this.textBox_ServerIP.Name = "textBox_ServerIP";
            this.textBox_ServerIP.Size = new System.Drawing.Size(91, 20);
            this.textBox_ServerIP.TabIndex = 3;
            this.textBox_ServerIP.Text = "127.0.0.1";
            this.textBox_ServerIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Server listener IP:";
            // 
            // textBox_Port
            // 
            this.textBox_Port.Location = new System.Drawing.Point(150, 83);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(55, 20);
            this.textBox_Port.TabIndex = 5;
            this.textBox_Port.Text = "2404";
            this.textBox_Port.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Server port:";
            // 
            // button_OK
            // 
            this.button_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_OK.Location = new System.Drawing.Point(251, 258);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 6;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // checkBox_periodicTransmission
            // 
            this.checkBox_periodicTransmission.AutoSize = true;
            this.checkBox_periodicTransmission.Location = new System.Drawing.Point(150, 210);
            this.checkBox_periodicTransmission.Name = "checkBox_periodicTransmission";
            this.checkBox_periodicTransmission.Size = new System.Drawing.Size(123, 17);
            this.checkBox_periodicTransmission.TabIndex = 7;
            this.checkBox_periodicTransmission.Text = "periodic transmission";
            this.checkBox_periodicTransmission.UseVisualStyleBackColor = true;
            this.checkBox_periodicTransmission.CheckedChanged += new System.EventHandler(this.checkBox_periodicTransmission_CheckedChanged);
            // 
            // textBox_periodicPeriod
            // 
            this.textBox_periodicPeriod.Location = new System.Drawing.Point(150, 184);
            this.textBox_periodicPeriod.Name = "textBox_periodicPeriod";
            this.textBox_periodicPeriod.Size = new System.Drawing.Size(55, 20);
            this.textBox_periodicPeriod.TabIndex = 9;
            this.textBox_periodicPeriod.Text = "5000";
            this.textBox_periodicPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Transmission period:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(206, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "ms";
            // 
            // textBox_ASDU
            // 
            this.textBox_ASDU.Location = new System.Drawing.Point(150, 109);
            this.textBox_ASDU.Name = "textBox_ASDU";
            this.textBox_ASDU.Size = new System.Drawing.Size(55, 20);
            this.textBox_ASDU.TabIndex = 12;
            this.textBox_ASDU.Text = "3";
            this.textBox_ASDU.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(64, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "ASDU address:";
            // 
            // textBox_ReconnectTime
            // 
            this.textBox_ReconnectTime.Location = new System.Drawing.Point(150, 135);
            this.textBox_ReconnectTime.Name = "textBox_ReconnectTime";
            this.textBox_ReconnectTime.Size = new System.Drawing.Size(35, 20);
            this.textBox_ReconnectTime.TabIndex = 14;
            this.textBox_ReconnectTime.Text = "20";
            this.textBox_ReconnectTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(53, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Retry connection:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(188, 139);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(12, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "s";
            // 
            // Form_IEC104Settings
            // 
            this.AcceptButton = this.button_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 293);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox_ReconnectTime);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_ASDU);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_periodicPeriod);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBox_periodicTransmission);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.textBox_Port);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_ServerIP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_MaxNoOfClients);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Form_IEC104Settings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "IEC-104 Server settings";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_MaxNoOfClients;
        private System.Windows.Forms.TextBox textBox_ServerIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.CheckBox checkBox_periodicTransmission;
        private System.Windows.Forms.TextBox textBox_periodicPeriod;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_ASDU;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_ReconnectTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}