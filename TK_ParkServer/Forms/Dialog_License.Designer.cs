namespace TK_ParkServer.Forms
{
    partial class Dialog_License
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_NoLicense = new System.Windows.Forms.Label();
            this.label_HardwareID = new System.Windows.Forms.Label();
            this.label_Owner = new System.Windows.Forms.Label();
            this.label_LicenseNumber = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox_LicenseInfo = new System.Windows.Forms.GroupBox();
            this.groupBox_LicenseInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hardware ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "License owner:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "License number:";
            // 
            // label_NoLicense
            // 
            this.label_NoLicense.AutoSize = true;
            this.label_NoLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_NoLicense.Location = new System.Drawing.Point(149, 26);
            this.label_NoLicense.Name = "label_NoLicense";
            this.label_NoLicense.Size = new System.Drawing.Size(98, 20);
            this.label_NoLicense.TabIndex = 26;
            this.label_NoLicense.Text = "No License";
            // 
            // label_HardwareID
            // 
            this.label_HardwareID.AutoSize = true;
            this.label_HardwareID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_HardwareID.Location = new System.Drawing.Point(147, 119);
            this.label_HardwareID.Name = "label_HardwareID";
            this.label_HardwareID.Size = new System.Drawing.Size(87, 15);
            this.label_HardwareID.TabIndex = 27;
            this.label_HardwareID.Text = "1234567890";
            // 
            // label_Owner
            // 
            this.label_Owner.AutoSize = true;
            this.label_Owner.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Owner.Location = new System.Drawing.Point(108, 29);
            this.label_Owner.Name = "label_Owner";
            this.label_Owner.Size = new System.Drawing.Size(90, 15);
            this.label_Owner.TabIndex = 28;
            this.label_Owner.Text = "Owner Name";
            // 
            // label_LicenseNumber
            // 
            this.label_LicenseNumber.AutoSize = true;
            this.label_LicenseNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_LicenseNumber.Location = new System.Drawing.Point(107, 55);
            this.label_LicenseNumber.Name = "label_LicenseNumber";
            this.label_LicenseNumber.Size = new System.Drawing.Size(87, 15);
            this.label_LicenseNumber.TabIndex = 29;
            this.label_LicenseNumber.Text = "1234567890";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(113, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 16);
            this.label4.TabIndex = 31;
            this.label4.Text = "Contact Troonik OÜ";
            // 
            // groupBox_LicenseInfo
            // 
            this.groupBox_LicenseInfo.Controls.Add(this.label_Owner);
            this.groupBox_LicenseInfo.Controls.Add(this.label3);
            this.groupBox_LicenseInfo.Controls.Add(this.label2);
            this.groupBox_LicenseInfo.Controls.Add(this.label_LicenseNumber);
            this.groupBox_LicenseInfo.Location = new System.Drawing.Point(40, 14);
            this.groupBox_LicenseInfo.Name = "groupBox_LicenseInfo";
            this.groupBox_LicenseInfo.Size = new System.Drawing.Size(302, 93);
            this.groupBox_LicenseInfo.TabIndex = 32;
            this.groupBox_LicenseInfo.TabStop = false;
            // 
            // Dialog_License
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 142);
            this.Controls.Add(this.groupBox_LicenseInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_HardwareID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_NoLicense);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Dialog_License";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "License";
            this.groupBox_LicenseInfo.ResumeLayout(false);
            this.groupBox_LicenseInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_NoLicense;
        private System.Windows.Forms.Label label_HardwareID;
        private System.Windows.Forms.Label label_Owner;
        private System.Windows.Forms.Label label_LicenseNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox_LicenseInfo;
    }
}