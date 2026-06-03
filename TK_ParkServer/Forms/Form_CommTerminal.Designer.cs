namespace TK_ParkServer.Forms
{
    partial class Form_CommTerminal
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
            this.label4 = new System.Windows.Forms.Label();
            this.listBox_Sent = new System.Windows.Forms.ListBox();
            this.button_Clear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Pause = new System.Windows.Forms.Button();
            this.listBox_Received = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Sent data";
            // 
            // listBox_Sent
            // 
            this.listBox_Sent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_Sent.FormattingEnabled = true;
            this.listBox_Sent.HorizontalScrollbar = true;
            this.listBox_Sent.Location = new System.Drawing.Point(12, 41);
            this.listBox_Sent.Name = "listBox_Sent";
            this.listBox_Sent.Size = new System.Drawing.Size(915, 342);
            this.listBox_Sent.TabIndex = 24;
            // 
            // button_Clear
            // 
            this.button_Clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Clear.Location = new System.Drawing.Point(852, 12);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(75, 23);
            this.button_Clear.TabIndex = 23;
            this.button_Clear.Text = "Clear";
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 397);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Received data";
            // 
            // button_Pause
            // 
            this.button_Pause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Pause.Location = new System.Drawing.Point(771, 12);
            this.button_Pause.Name = "button_Pause";
            this.button_Pause.Size = new System.Drawing.Size(75, 23);
            this.button_Pause.TabIndex = 21;
            this.button_Pause.Text = "Start";
            this.button_Pause.UseVisualStyleBackColor = true;
            this.button_Pause.Click += new System.EventHandler(this.button_Pause_Click);
            // 
            // listBox_Received
            // 
            this.listBox_Received.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_Received.FormattingEnabled = true;
            this.listBox_Received.HorizontalScrollbar = true;
            this.listBox_Received.Location = new System.Drawing.Point(12, 416);
            this.listBox_Received.Name = "listBox_Received";
            this.listBox_Received.Size = new System.Drawing.Size(915, 342);
            this.listBox_Received.TabIndex = 20;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form_CommTerminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 761);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listBox_Sent);
            this.Controls.Add(this.button_Clear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Pause);
            this.Controls.Add(this.listBox_Received);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Form_CommTerminal";
            this.ShowIcon = false;
            this.Text = "Communication Terminal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_CommTerminal_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBox_Sent;
        private System.Windows.Forms.Button button_Clear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Pause;
        private System.Windows.Forms.ListBox listBox_Received;
        private System.Windows.Forms.Timer timer1;
    }
}