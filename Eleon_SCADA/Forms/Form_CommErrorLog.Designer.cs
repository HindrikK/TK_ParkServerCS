namespace Eleon_SCADA.Forms
{
    partial class Form_CommErrorLog
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
            this.button_Clear = new System.Windows.Forms.Button();
            this.button_Pause = new System.Windows.Forms.Button();
            this.listBox_Errors = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button_Terminal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_Clear
            // 
            this.button_Clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Clear.Location = new System.Drawing.Point(569, 8);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(75, 23);
            this.button_Clear.TabIndex = 9;
            this.button_Clear.Text = "Clear";
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // button_Pause
            // 
            this.button_Pause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Pause.Location = new System.Drawing.Point(488, 8);
            this.button_Pause.Name = "button_Pause";
            this.button_Pause.Size = new System.Drawing.Size(75, 23);
            this.button_Pause.TabIndex = 7;
            this.button_Pause.Text = "Pause";
            this.button_Pause.UseVisualStyleBackColor = true;
            this.button_Pause.Click += new System.EventHandler(this.button_Pause_Click);
            // 
            // listBox_Errors
            // 
            this.listBox_Errors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_Errors.FormattingEnabled = true;
            this.listBox_Errors.Location = new System.Drawing.Point(12, 37);
            this.listBox_Errors.Name = "listBox_Errors";
            this.listBox_Errors.Size = new System.Drawing.Size(632, 277);
            this.listBox_Errors.TabIndex = 6;
            this.listBox_Errors.UseTabStops = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button_Terminal
            // 
            this.button_Terminal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Terminal.Location = new System.Drawing.Point(12, 8);
            this.button_Terminal.Name = "button_Terminal";
            this.button_Terminal.Size = new System.Drawing.Size(76, 23);
            this.button_Terminal.TabIndex = 10;
            this.button_Terminal.Text = "Terminal...";
            this.button_Terminal.UseVisualStyleBackColor = true;
            this.button_Terminal.Click += new System.EventHandler(this.button_Terminal_Click);
            // 
            // Form_CommErrorLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 325);
            this.Controls.Add(this.button_Terminal);
            this.Controls.Add(this.button_Clear);
            this.Controls.Add(this.button_Pause);
            this.Controls.Add(this.listBox_Errors);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_CommErrorLog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Communication errors";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Clear;
        private System.Windows.Forms.Button button_Pause;
        private System.Windows.Forms.ListBox listBox_Errors;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button_Terminal;
    }
}