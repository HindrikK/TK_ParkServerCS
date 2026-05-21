namespace Eleon_SCADA.Forms
{
    partial class Form_MarketInterfaceSettings
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox_ServerSettings = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_IpAddress = new System.Windows.Forms.TextBox();
            this.label_IpAddress = new System.Windows.Forms.Label();
            this.textBox_UdpPort = new System.Windows.Forms.TextBox();
            this.label_UdpPort = new System.Windows.Forms.Label();
            this.textBox_TcpPort = new System.Windows.Forms.TextBox();
            this.label_TcpPort = new System.Windows.Forms.Label();
            this.checkBox_UdpEnable = new System.Windows.Forms.CheckBox();
            this.label_UdpEnable = new System.Windows.Forms.Label();
            this.checkBox_TcpEnable = new System.Windows.Forms.CheckBox();
            this.label_TcpEnable = new System.Windows.Forms.Label();
            this.textBox_MaxActiveConnections = new System.Windows.Forms.TextBox();
            this.label_MaxActiveConnections = new System.Windows.Forms.Label();
            this.textBox_ConnStaleTimeout = new System.Windows.Forms.TextBox();
            this.label_ConnStaleTimeout = new System.Windows.Forms.Label();
            this.textBox_ResponseRateLimit = new System.Windows.Forms.TextBox();
            this.label_ResponseRateLimit = new System.Windows.Forms.Label();
            this.checkBox_MarketIfEnable = new System.Windows.Forms.CheckBox();
            this.label_ModbusEnable = new System.Windows.Forms.Label();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.textBox_FallbackTimeout = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox_ServerSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_ServerSettings
            // 
            this.groupBox_ServerSettings.Controls.Add(this.label3);
            this.groupBox_ServerSettings.Controls.Add(this.label2);
            this.groupBox_ServerSettings.Controls.Add(this.textBox_IpAddress);
            this.groupBox_ServerSettings.Controls.Add(this.label_IpAddress);
            this.groupBox_ServerSettings.Controls.Add(this.textBox_UdpPort);
            this.groupBox_ServerSettings.Controls.Add(this.label_UdpPort);
            this.groupBox_ServerSettings.Controls.Add(this.textBox_TcpPort);
            this.groupBox_ServerSettings.Controls.Add(this.label_TcpPort);
            this.groupBox_ServerSettings.Controls.Add(this.checkBox_UdpEnable);
            this.groupBox_ServerSettings.Controls.Add(this.label_UdpEnable);
            this.groupBox_ServerSettings.Controls.Add(this.checkBox_TcpEnable);
            this.groupBox_ServerSettings.Controls.Add(this.label_TcpEnable);
            this.groupBox_ServerSettings.Controls.Add(this.textBox_MaxActiveConnections);
            this.groupBox_ServerSettings.Controls.Add(this.label_MaxActiveConnections);
            this.groupBox_ServerSettings.Controls.Add(this.textBox_ConnStaleTimeout);
            this.groupBox_ServerSettings.Controls.Add(this.label_ConnStaleTimeout);
            this.groupBox_ServerSettings.Controls.Add(this.textBox_ResponseRateLimit);
            this.groupBox_ServerSettings.Controls.Add(this.label_ResponseRateLimit);
            this.groupBox_ServerSettings.Location = new System.Drawing.Point(17, 112);
            this.groupBox_ServerSettings.Name = "groupBox_ServerSettings";
            this.groupBox_ServerSettings.Size = new System.Drawing.Size(331, 255);
            this.groupBox_ServerSettings.TabIndex = 0;
            this.groupBox_ServerSettings.TabStop = false;
            this.groupBox_ServerSettings.Text = "Modbus server";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(220, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "ms";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(202, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "s";
            // 
            // textBox_IpAddress
            // 
            this.textBox_IpAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_IpAddress.Location = new System.Drawing.Point(161, 31);
            this.textBox_IpAddress.Name = "textBox_IpAddress";
            this.textBox_IpAddress.Size = new System.Drawing.Size(94, 20);
            this.textBox_IpAddress.TabIndex = 3;
            this.toolTip1.SetToolTip(this.textBox_IpAddress, "IP address of the local interface to listen on. Use \"0.0.0.0\" for all interfaces." +
        "");
            // 
            // label_IpAddress
            // 
            this.label_IpAddress.AutoSize = true;
            this.label_IpAddress.Location = new System.Drawing.Point(65, 35);
            this.label_IpAddress.Name = "label_IpAddress";
            this.label_IpAddress.Size = new System.Drawing.Size(90, 13);
            this.label_IpAddress.TabIndex = 2;
            this.label_IpAddress.Text = "Local interface IP";
            // 
            // textBox_UdpPort
            // 
            this.textBox_UdpPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_UdpPort.Location = new System.Drawing.Point(161, 57);
            this.textBox_UdpPort.Name = "textBox_UdpPort";
            this.textBox_UdpPort.Size = new System.Drawing.Size(58, 20);
            this.textBox_UdpPort.TabIndex = 5;
            // 
            // label_UdpPort
            // 
            this.label_UdpPort.AutoSize = true;
            this.label_UdpPort.Location = new System.Drawing.Point(104, 61);
            this.label_UdpPort.Name = "label_UdpPort";
            this.label_UdpPort.Size = new System.Drawing.Size(51, 13);
            this.label_UdpPort.TabIndex = 4;
            this.label_UdpPort.Text = "UDP port";
            // 
            // textBox_TcpPort
            // 
            this.textBox_TcpPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_TcpPort.Location = new System.Drawing.Point(161, 83);
            this.textBox_TcpPort.Name = "textBox_TcpPort";
            this.textBox_TcpPort.Size = new System.Drawing.Size(58, 20);
            this.textBox_TcpPort.TabIndex = 7;
            // 
            // label_TcpPort
            // 
            this.label_TcpPort.AutoSize = true;
            this.label_TcpPort.Location = new System.Drawing.Point(106, 87);
            this.label_TcpPort.Name = "label_TcpPort";
            this.label_TcpPort.Size = new System.Drawing.Size(49, 13);
            this.label_TcpPort.TabIndex = 6;
            this.label_TcpPort.Text = "TCP port";
            // 
            // checkBox_UdpEnable
            // 
            this.checkBox_UdpEnable.AutoSize = true;
            this.checkBox_UdpEnable.Location = new System.Drawing.Point(161, 113);
            this.checkBox_UdpEnable.Name = "checkBox_UdpEnable";
            this.checkBox_UdpEnable.Size = new System.Drawing.Size(15, 14);
            this.checkBox_UdpEnable.TabIndex = 9;
            this.checkBox_UdpEnable.UseVisualStyleBackColor = true;
            // 
            // label_UdpEnable
            // 
            this.label_UdpEnable.AutoSize = true;
            this.label_UdpEnable.Location = new System.Drawing.Point(90, 114);
            this.label_UdpEnable.Name = "label_UdpEnable";
            this.label_UdpEnable.Size = new System.Drawing.Size(65, 13);
            this.label_UdpEnable.TabIndex = 8;
            this.label_UdpEnable.Text = "UDP enable";
            // 
            // checkBox_TcpEnable
            // 
            this.checkBox_TcpEnable.AutoSize = true;
            this.checkBox_TcpEnable.Location = new System.Drawing.Point(161, 139);
            this.checkBox_TcpEnable.Name = "checkBox_TcpEnable";
            this.checkBox_TcpEnable.Size = new System.Drawing.Size(15, 14);
            this.checkBox_TcpEnable.TabIndex = 11;
            this.checkBox_TcpEnable.UseVisualStyleBackColor = true;
            // 
            // label_TcpEnable
            // 
            this.label_TcpEnable.AutoSize = true;
            this.label_TcpEnable.Location = new System.Drawing.Point(92, 140);
            this.label_TcpEnable.Name = "label_TcpEnable";
            this.label_TcpEnable.Size = new System.Drawing.Size(63, 13);
            this.label_TcpEnable.TabIndex = 10;
            this.label_TcpEnable.Text = "TCP enable";
            // 
            // textBox_MaxActiveConnections
            // 
            this.textBox_MaxActiveConnections.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_MaxActiveConnections.Location = new System.Drawing.Point(161, 163);
            this.textBox_MaxActiveConnections.Name = "textBox_MaxActiveConnections";
            this.textBox_MaxActiveConnections.Size = new System.Drawing.Size(35, 20);
            this.textBox_MaxActiveConnections.TabIndex = 13;
            this.toolTip1.SetToolTip(this.textBox_MaxActiveConnections, "Maximum number of simultaneous clients.");
            // 
            // label_MaxActiveConnections
            // 
            this.label_MaxActiveConnections.AutoSize = true;
            this.label_MaxActiveConnections.Location = new System.Drawing.Point(35, 167);
            this.label_MaxActiveConnections.Name = "label_MaxActiveConnections";
            this.label_MaxActiveConnections.Size = new System.Drawing.Size(120, 13);
            this.label_MaxActiveConnections.TabIndex = 12;
            this.label_MaxActiveConnections.Text = "Max active connections";
            // 
            // textBox_ConnStaleTimeout
            // 
            this.textBox_ConnStaleTimeout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_ConnStaleTimeout.Location = new System.Drawing.Point(161, 189);
            this.textBox_ConnStaleTimeout.Name = "textBox_ConnStaleTimeout";
            this.textBox_ConnStaleTimeout.Size = new System.Drawing.Size(35, 20);
            this.textBox_ConnStaleTimeout.TabIndex = 15;
            this.toolTip1.SetToolTip(this.textBox_ConnStaleTimeout, "When no valid request received for this time then connection isconsidered stale a" +
        "nd will be closed.");
            // 
            // label_ConnStaleTimeout
            // 
            this.label_ConnStaleTimeout.AutoSize = true;
            this.label_ConnStaleTimeout.Location = new System.Drawing.Point(32, 193);
            this.label_ConnStaleTimeout.Name = "label_ConnStaleTimeout";
            this.label_ConnStaleTimeout.Size = new System.Drawing.Size(123, 13);
            this.label_ConnStaleTimeout.TabIndex = 14;
            this.label_ConnStaleTimeout.Text = "Connection stale timeout";
            // 
            // textBox_ResponseRateLimit
            // 
            this.textBox_ResponseRateLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_ResponseRateLimit.Location = new System.Drawing.Point(161, 215);
            this.textBox_ResponseRateLimit.Name = "textBox_ResponseRateLimit";
            this.textBox_ResponseRateLimit.Size = new System.Drawing.Size(53, 20);
            this.textBox_ResponseRateLimit.TabIndex = 17;
            this.toolTip1.SetToolTip(this.textBox_ResponseRateLimit, "Defines the minimum amount of time for replying to consequtive requests. Creates " +
        "rate limiter for incoming requests.");
            // 
            // label_ResponseRateLimit
            // 
            this.label_ResponseRateLimit.AutoSize = true;
            this.label_ResponseRateLimit.Location = new System.Drawing.Point(59, 219);
            this.label_ResponseRateLimit.Name = "label_ResponseRateLimit";
            this.label_ResponseRateLimit.Size = new System.Drawing.Size(96, 13);
            this.label_ResponseRateLimit.TabIndex = 16;
            this.label_ResponseRateLimit.Text = "Response rate limit";
            // 
            // checkBox_MarketIfEnable
            // 
            this.checkBox_MarketIfEnable.AutoSize = true;
            this.checkBox_MarketIfEnable.Location = new System.Drawing.Point(173, 44);
            this.checkBox_MarketIfEnable.Name = "checkBox_MarketIfEnable";
            this.checkBox_MarketIfEnable.Size = new System.Drawing.Size(15, 14);
            this.checkBox_MarketIfEnable.TabIndex = 1;
            this.checkBox_MarketIfEnable.UseVisualStyleBackColor = true;
            // 
            // label_ModbusEnable
            // 
            this.label_ModbusEnable.AutoSize = true;
            this.label_ModbusEnable.Location = new System.Drawing.Point(83, 44);
            this.label_ModbusEnable.Name = "label_ModbusEnable";
            this.label_ModbusEnable.Size = new System.Drawing.Size(84, 13);
            this.label_ModbusEnable.TabIndex = 0;
            this.label_ModbusEnable.Text = "Interface enable";
            // 
            // button_OK
            // 
            this.button_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_OK.Location = new System.Drawing.Point(200, 393);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 1;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Location = new System.Drawing.Point(281, 393);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 2;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // textBox_FallbackTimeout
            // 
            this.textBox_FallbackTimeout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_FallbackTimeout.Location = new System.Drawing.Point(173, 64);
            this.textBox_FallbackTimeout.Name = "textBox_FallbackTimeout";
            this.textBox_FallbackTimeout.Size = new System.Drawing.Size(35, 20);
            this.textBox_FallbackTimeout.TabIndex = 17;
            this.toolTip1.SetToolTip(this.textBox_FallbackTimeout, "When market control is lost then after this timeout all control commands revert t" +
        "o defined fallbacks.");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Interface down timeout";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(214, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "s";
            // 
            // Form_MarketInterfaceSettings
            // 
            this.AcceptButton = this.button_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(368, 428);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_FallbackTimeout);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox_MarketIfEnable);
            this.Controls.Add(this.label_ModbusEnable);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.groupBox_ServerSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_MarketInterfaceSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Market Interface";
            this.groupBox_ServerSettings.ResumeLayout(false);
            this.groupBox_ServerSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.GroupBox groupBox_ServerSettings;
        private System.Windows.Forms.CheckBox checkBox_MarketIfEnable;
        private System.Windows.Forms.Label label_ModbusEnable;
        private System.Windows.Forms.TextBox textBox_IpAddress;
        private System.Windows.Forms.Label label_IpAddress;
        private System.Windows.Forms.TextBox textBox_UdpPort;
        private System.Windows.Forms.Label label_UdpPort;
        private System.Windows.Forms.TextBox textBox_TcpPort;
        private System.Windows.Forms.Label label_TcpPort;
        private System.Windows.Forms.CheckBox checkBox_UdpEnable;
        private System.Windows.Forms.Label label_UdpEnable;
        private System.Windows.Forms.CheckBox checkBox_TcpEnable;
        private System.Windows.Forms.Label label_TcpEnable;
        private System.Windows.Forms.TextBox textBox_MaxActiveConnections;
        private System.Windows.Forms.Label label_MaxActiveConnections;
        private System.Windows.Forms.TextBox textBox_ConnStaleTimeout;
        private System.Windows.Forms.Label label_ConnStaleTimeout;
        private System.Windows.Forms.TextBox textBox_ResponseRateLimit;
        private System.Windows.Forms.Label label_ResponseRateLimit;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_FallbackTimeout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
