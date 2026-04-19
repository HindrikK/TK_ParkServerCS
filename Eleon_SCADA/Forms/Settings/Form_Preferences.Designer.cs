namespace Eleon_SCADA.Forms.Settings
{
    partial class Form_Preferences
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
            this.checkBox_AutoConnectPark = new System.Windows.Forms.CheckBox();
            this.checkBox_AutoStartIEC104 = new System.Windows.Forms.CheckBox();
            this.button_OK = new System.Windows.Forms.Button();
            this.textBox_UserAutoLogOut = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkBox_AutoConnectPark
            // 
            this.checkBox_AutoConnectPark.AutoSize = true;
            this.checkBox_AutoConnectPark.Location = new System.Drawing.Point(127, 34);
            this.checkBox_AutoConnectPark.Name = "checkBox_AutoConnectPark";
            this.checkBox_AutoConnectPark.Size = new System.Drawing.Size(114, 17);
            this.checkBox_AutoConnectPark.TabIndex = 2;
            this.checkBox_AutoConnectPark.Text = "Auto connect park";
            this.checkBox_AutoConnectPark.UseVisualStyleBackColor = true;
            // 
            // checkBox_AutoStartIEC104
            // 
            this.checkBox_AutoStartIEC104.AutoSize = true;
            this.checkBox_AutoStartIEC104.Location = new System.Drawing.Point(127, 57);
            this.checkBox_AutoStartIEC104.Name = "checkBox_AutoStartIEC104";
            this.checkBox_AutoStartIEC104.Size = new System.Drawing.Size(144, 17);
            this.checkBox_AutoStartIEC104.TabIndex = 3;
            this.checkBox_AutoStartIEC104.Text = "Auto start IEC-104 server";
            this.checkBox_AutoStartIEC104.UseVisualStyleBackColor = true;
            // 
            // button_OK
            // 
            this.button_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_OK.Location = new System.Drawing.Point(243, 128);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 4;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // textBox_UserAutoLogOut
            // 
            this.textBox_UserAutoLogOut.Location = new System.Drawing.Point(127, 85);
            this.textBox_UserAutoLogOut.Name = "textBox_UserAutoLogOut";
            this.textBox_UserAutoLogOut.Size = new System.Drawing.Size(55, 20);
            this.textBox_UserAutoLogOut.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "User auto logout:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "s";
            // 
            // Form_Preferences
            // 
            this.AcceptButton = this.button_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 163);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_UserAutoLogOut);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.checkBox_AutoStartIEC104);
            this.Controls.Add(this.checkBox_AutoConnectPark);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_Preferences";
            this.ShowInTaskbar = false;
            this.Text = "Preferences";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_AutoConnectPark;
        private System.Windows.Forms.CheckBox checkBox_AutoStartIEC104;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.TextBox textBox_UserAutoLogOut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}