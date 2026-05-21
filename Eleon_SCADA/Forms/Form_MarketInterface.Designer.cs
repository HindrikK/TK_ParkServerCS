namespace Eleon_SCADA.Forms
{
    partial class Form_MarketInterface
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
            this.button_OK = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button_Status = new System.Windows.Forms.Button();
            this.button_Logs = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_OK
            // 
            this.button_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_OK.Location = new System.Drawing.Point(115, 152);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 1;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // button_Status
            // 
            this.button_Status.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button_Status.Location = new System.Drawing.Point(63, 37);
            this.button_Status.Name = "button_Status";
            this.button_Status.Size = new System.Drawing.Size(75, 23);
            this.button_Status.TabIndex = 3;
            this.button_Status.Text = "Clients";
            this.button_Status.UseVisualStyleBackColor = true;
            this.button_Status.Click += new System.EventHandler(this.button_Status_Click);
            // 
            // button_Logs
            // 
            this.button_Logs.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button_Logs.Location = new System.Drawing.Point(63, 77);
            this.button_Logs.Name = "button_Logs";
            this.button_Logs.Size = new System.Drawing.Size(75, 23);
            this.button_Logs.TabIndex = 21;
            this.button_Logs.Text = "Logs";
            this.button_Logs.UseVisualStyleBackColor = true;
            this.button_Logs.Click += new System.EventHandler(this.button_Logs_Click);
            // 
            // Form_MarketInterface
            // 
            this.AcceptButton = this.button_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(202, 187);
            this.Controls.Add(this.button_Logs);
            this.Controls.Add(this.button_Status);
            this.Controls.Add(this.button_OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_MarketInterface";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Market Interface";
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button_Status;
        private System.Windows.Forms.Button button_Logs;
    }
}
