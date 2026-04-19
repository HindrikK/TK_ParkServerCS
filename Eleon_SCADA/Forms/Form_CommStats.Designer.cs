namespace Eleon_SCADA.Forms
{
    partial class Form_CommStats
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button_ResetTurbines = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_Rx_01 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_Tx_01 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_Errors_01 = new System.Windows.Forms.TextBox();
            this.button_Log = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button_ResetTurbines
            // 
            this.button_ResetTurbines.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ResetTurbines.Location = new System.Drawing.Point(194, 66);
            this.button_ResetTurbines.Name = "button_ResetTurbines";
            this.button_ResetTurbines.Size = new System.Drawing.Size(75, 23);
            this.button_ResetTurbines.TabIndex = 49;
            this.button_ResetTurbines.Text = "Reset";
            this.button_ResetTurbines.UseVisualStyleBackColor = true;
            this.button_ResetTurbines.Click += new System.EventHandler(this.button_ResetTurbines_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label8.Location = new System.Drawing.Point(46, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 13);
            this.label8.TabIndex = 48;
            this.label8.Text = "Rx";
            // 
            // textBox_Rx_01
            // 
            this.textBox_Rx_01.Location = new System.Drawing.Point(74, 43);
            this.textBox_Rx_01.Name = "textBox_Rx_01";
            this.textBox_Rx_01.ReadOnly = true;
            this.textBox_Rx_01.Size = new System.Drawing.Size(61, 20);
            this.textBox_Rx_01.TabIndex = 43;
            this.textBox_Rx_01.TabStop = false;
            this.textBox_Rx_01.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label7.Location = new System.Drawing.Point(47, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 13);
            this.label7.TabIndex = 42;
            this.label7.Text = "Tx";
            // 
            // textBox_Tx_01
            // 
            this.textBox_Tx_01.Location = new System.Drawing.Point(74, 17);
            this.textBox_Tx_01.Name = "textBox_Tx_01";
            this.textBox_Tx_01.ReadOnly = true;
            this.textBox_Tx_01.Size = new System.Drawing.Size(61, 20);
            this.textBox_Tx_01.TabIndex = 37;
            this.textBox_Tx_01.TabStop = false;
            this.textBox_Tx_01.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label6.Location = new System.Drawing.Point(28, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "Errors";
            // 
            // textBox_Errors_01
            // 
            this.textBox_Errors_01.Location = new System.Drawing.Point(74, 69);
            this.textBox_Errors_01.Name = "textBox_Errors_01";
            this.textBox_Errors_01.ReadOnly = true;
            this.textBox_Errors_01.Size = new System.Drawing.Size(61, 20);
            this.textBox_Errors_01.TabIndex = 27;
            this.textBox_Errors_01.TabStop = false;
            this.textBox_Errors_01.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button_Log
            // 
            this.button_Log.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Log.Location = new System.Drawing.Point(194, 17);
            this.button_Log.Name = "button_Log";
            this.button_Log.Size = new System.Drawing.Size(75, 23);
            this.button_Log.TabIndex = 50;
            this.button_Log.Text = "Log...";
            this.button_Log.UseVisualStyleBackColor = true;
            this.button_Log.Click += new System.EventHandler(this.button_Log_Click);
            // 
            // Form_CommStats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 106);
            this.Controls.Add(this.button_Log);
            this.Controls.Add(this.button_ResetTurbines);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox_Rx_01);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_Tx_01);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_Errors_01);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Form_CommStats";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Communication Statistics";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button_ResetTurbines;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_Rx_01;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_Tx_01;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_Errors_01;
        private System.Windows.Forms.Button button_Log;
    }
}