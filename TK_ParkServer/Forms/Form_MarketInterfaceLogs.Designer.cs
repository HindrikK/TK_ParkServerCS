namespace TK_ParkServer.Forms
{
    partial class Form_MarketInterfaceLogs
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
            this.listBox_Logs = new System.Windows.Forms.ListBox();
            this.button_Close = new System.Windows.Forms.Button();
            this.label_Status = new System.Windows.Forms.Label();
            this.timer_Refresh = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // listBox_Logs
            // 
            this.listBox_Logs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_Logs.FormattingEnabled = true;
            this.listBox_Logs.HorizontalScrollbar = true;
            this.listBox_Logs.Location = new System.Drawing.Point(12, 12);
            this.listBox_Logs.Name = "listBox_Logs";
            this.listBox_Logs.Size = new System.Drawing.Size(760, 394);
            this.listBox_Logs.TabIndex = 0;
            // 
            // button_Close
            // 
            this.button_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Close.Location = new System.Drawing.Point(697, 421);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 23);
            this.button_Close.TabIndex = 2;
            this.button_Close.Text = "Close";
            this.button_Close.UseVisualStyleBackColor = true;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // label_Status
            // 
            this.label_Status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_Status.AutoSize = true;
            this.label_Status.Location = new System.Drawing.Point(12, 426);
            this.label_Status.Name = "label_Status";
            this.label_Status.Size = new System.Drawing.Size(37, 13);
            this.label_Status.TabIndex = 3;
            this.label_Status.Text = "Status";
            // 
            // timer_Refresh
            // 
            this.timer_Refresh.Enabled = true;
            this.timer_Refresh.Interval = 1000;
            this.timer_Refresh.Tick += new System.EventHandler(this.timer_Refresh_Tick);
            // 
            // Form_MarketInterfaceLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 456);
            this.Controls.Add(this.label_Status);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.listBox_Logs);
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "Form_MarketInterfaceLogs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Market Interface Logs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ListBox listBox_Logs;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.Label label_Status;
        private System.Windows.Forms.Timer timer_Refresh;
    }
}
