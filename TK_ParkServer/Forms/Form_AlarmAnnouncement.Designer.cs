namespace TK_ParkServer.Forms
{
    partial class Form_AlarmAnnouncement
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_ClearOutbox = new System.Windows.Forms.Button();
            this.listBox_Outbox = new System.Windows.Forms.ListBox();
            this.button_RefreshScreen = new System.Windows.Forms.Button();
            this.listBox_Sent = new System.Windows.Forms.ListBox();
            this.button_ResendOutbox = new System.Windows.Forms.Button();
            this.button_ClearSent = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button_ExcludedCodes = new System.Windows.Forms.Button();
            this.button_Default = new System.Windows.Forms.Button();
            this.button_OK = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_Subject = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_From = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_Server = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBox_Recipients = new System.Windows.Forms.ListBox();
            this.button_AddUser = new System.Windows.Forms.Button();
            this.button_SendTest = new System.Windows.Forms.Button();
            this.button_DeactAct = new System.Windows.Forms.Button();
            this.button_RemoveUser = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_TriggerDelay = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label3.Location = new System.Drawing.Point(2, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 20);
            this.label3.TabIndex = 57;
            this.label3.Text = "Sent";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label2.Location = new System.Drawing.Point(2, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 56;
            this.label2.Text = "Outbox";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button_ClearOutbox
            // 
            this.button_ClearOutbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ClearOutbox.Location = new System.Drawing.Point(449, 60);
            this.button_ClearOutbox.Name = "button_ClearOutbox";
            this.button_ClearOutbox.Size = new System.Drawing.Size(91, 23);
            this.button_ClearOutbox.TabIndex = 60;
            this.button_ClearOutbox.Text = "Clear Outbox";
            this.button_ClearOutbox.UseVisualStyleBackColor = true;
            this.button_ClearOutbox.Click += new System.EventHandler(this.button_ClearOutbox_Click);
            // 
            // listBox_Outbox
            // 
            this.listBox_Outbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_Outbox.FormattingEnabled = true;
            this.listBox_Outbox.Location = new System.Drawing.Point(6, 31);
            this.listBox_Outbox.Name = "listBox_Outbox";
            this.listBox_Outbox.Size = new System.Drawing.Size(437, 95);
            this.listBox_Outbox.TabIndex = 61;
            // 
            // button_RefreshScreen
            // 
            this.button_RefreshScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_RefreshScreen.Location = new System.Drawing.Point(506, 5);
            this.button_RefreshScreen.Name = "button_RefreshScreen";
            this.button_RefreshScreen.Size = new System.Drawing.Size(60, 23);
            this.button_RefreshScreen.TabIndex = 62;
            this.button_RefreshScreen.Text = "Refresh";
            this.button_RefreshScreen.UseVisualStyleBackColor = true;
            this.button_RefreshScreen.Click += new System.EventHandler(this.button_RefreshScreen_Click);
            // 
            // listBox_Sent
            // 
            this.listBox_Sent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_Sent.FormattingEnabled = true;
            this.listBox_Sent.Location = new System.Drawing.Point(6, 171);
            this.listBox_Sent.Name = "listBox_Sent";
            this.listBox_Sent.Size = new System.Drawing.Size(437, 238);
            this.listBox_Sent.TabIndex = 63;
            // 
            // button_ResendOutbox
            // 
            this.button_ResendOutbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ResendOutbox.Location = new System.Drawing.Point(449, 31);
            this.button_ResendOutbox.Name = "button_ResendOutbox";
            this.button_ResendOutbox.Size = new System.Drawing.Size(91, 23);
            this.button_ResendOutbox.TabIndex = 64;
            this.button_ResendOutbox.Text = "Resend";
            this.button_ResendOutbox.UseVisualStyleBackColor = true;
            this.button_ResendOutbox.Click += new System.EventHandler(this.button_ResendOutbox_Click);
            // 
            // button_ClearSent
            // 
            this.button_ClearSent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ClearSent.Location = new System.Drawing.Point(449, 171);
            this.button_ClearSent.Name = "button_ClearSent";
            this.button_ClearSent.Size = new System.Drawing.Size(91, 23);
            this.button_ClearSent.TabIndex = 70;
            this.button_ClearSent.Text = "Clear Sent";
            this.button_ClearSent.UseVisualStyleBackColor = true;
            this.button_ClearSent.Click += new System.EventHandler(this.button_ClearSent_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(554, 462);
            this.tabControl1.TabIndex = 71;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.button_ExcludedCodes);
            this.tabPage2.Controls.Add(this.textBox_TriggerDelay);
            this.tabPage2.Controls.Add(this.button_Default);
            this.tabPage2.Controls.Add(this.button_OK);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(546, 436);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button_ExcludedCodes
            // 
            this.button_ExcludedCodes.Location = new System.Drawing.Point(28, 398);
            this.button_ExcludedCodes.Name = "button_ExcludedCodes";
            this.button_ExcludedCodes.Size = new System.Drawing.Size(106, 23);
            this.button_ExcludedCodes.TabIndex = 88;
            this.button_ExcludedCodes.Text = "Excluded codes...";
            this.button_ExcludedCodes.UseVisualStyleBackColor = true;
            this.button_ExcludedCodes.Click += new System.EventHandler(this.button_ExcludedCodes_Click);
            // 
            // button_Default
            // 
            this.button_Default.Location = new System.Drawing.Point(374, 398);
            this.button_Default.Name = "button_Default";
            this.button_Default.Size = new System.Drawing.Size(75, 23);
            this.button_Default.TabIndex = 87;
            this.button_Default.Text = "Default";
            this.button_Default.UseVisualStyleBackColor = true;
            this.button_Default.Click += new System.EventHandler(this.button_Default_Click);
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(455, 398);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 86;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_Subject);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBox_From);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBox_Port);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.textBox_Server);
            this.groupBox2.Location = new System.Drawing.Point(9, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(521, 151);
            this.groupBox2.TabIndex = 85;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mail settings";
            // 
            // textBox_Subject
            // 
            this.textBox_Subject.Location = new System.Drawing.Point(95, 83);
            this.textBox_Subject.Name = "textBox_Subject";
            this.textBox_Subject.Size = new System.Drawing.Size(296, 20);
            this.textBox_Subject.TabIndex = 82;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 76;
            this.label4.Text = "Server:";
            // 
            // textBox_From
            // 
            this.textBox_From.Location = new System.Drawing.Point(95, 109);
            this.textBox_From.Name = "textBox_From";
            this.textBox_From.Size = new System.Drawing.Size(296, 20);
            this.textBox_From.TabIndex = 83;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 77;
            this.label5.Text = "Port:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 78;
            this.label6.Text = "Email subject:";
            // 
            // textBox_Port
            // 
            this.textBox_Port.Location = new System.Drawing.Point(95, 57);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(64, 20);
            this.textBox_Port.TabIndex = 81;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(56, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 79;
            this.label7.Text = "From:";
            // 
            // textBox_Server
            // 
            this.textBox_Server.Location = new System.Drawing.Point(95, 31);
            this.textBox_Server.Name = "textBox_Server";
            this.textBox_Server.Size = new System.Drawing.Size(296, 20);
            this.textBox_Server.TabIndex = 80;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBox_Recipients);
            this.groupBox1.Controls.Add(this.button_AddUser);
            this.groupBox1.Controls.Add(this.button_SendTest);
            this.groupBox1.Controls.Add(this.button_DeactAct);
            this.groupBox1.Controls.Add(this.button_RemoveUser);
            this.groupBox1.Location = new System.Drawing.Point(9, 173);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(521, 144);
            this.groupBox1.TabIndex = 84;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Recipients";
            // 
            // listBox_Recipients
            // 
            this.listBox_Recipients.FormattingEnabled = true;
            this.listBox_Recipients.Location = new System.Drawing.Point(19, 24);
            this.listBox_Recipients.Name = "listBox_Recipients";
            this.listBox_Recipients.Size = new System.Drawing.Size(372, 108);
            this.listBox_Recipients.TabIndex = 71;
            // 
            // button_AddUser
            // 
            this.button_AddUser.Location = new System.Drawing.Point(407, 24);
            this.button_AddUser.Name = "button_AddUser";
            this.button_AddUser.Size = new System.Drawing.Size(91, 23);
            this.button_AddUser.TabIndex = 73;
            this.button_AddUser.Text = "Add...";
            this.button_AddUser.UseVisualStyleBackColor = true;
            this.button_AddUser.Click += new System.EventHandler(this.button_AddUser_Click);
            // 
            // button_SendTest
            // 
            this.button_SendTest.Location = new System.Drawing.Point(407, 111);
            this.button_SendTest.Name = "button_SendTest";
            this.button_SendTest.Size = new System.Drawing.Size(91, 23);
            this.button_SendTest.TabIndex = 70;
            this.button_SendTest.Text = "Send Test";
            this.button_SendTest.UseVisualStyleBackColor = true;
            this.button_SendTest.Click += new System.EventHandler(this.button_SendTest_Click);
            // 
            // button_DeactAct
            // 
            this.button_DeactAct.Location = new System.Drawing.Point(407, 82);
            this.button_DeactAct.Name = "button_DeactAct";
            this.button_DeactAct.Size = new System.Drawing.Size(91, 23);
            this.button_DeactAct.TabIndex = 74;
            this.button_DeactAct.Text = "Deact/Act";
            this.button_DeactAct.UseVisualStyleBackColor = true;
            this.button_DeactAct.Click += new System.EventHandler(this.button_DeactAct_Click);
            // 
            // button_RemoveUser
            // 
            this.button_RemoveUser.Location = new System.Drawing.Point(407, 53);
            this.button_RemoveUser.Name = "button_RemoveUser";
            this.button_RemoveUser.Size = new System.Drawing.Size(91, 23);
            this.button_RemoveUser.TabIndex = 75;
            this.button_RemoveUser.Text = "Remove";
            this.button_RemoveUser.UseVisualStyleBackColor = true;
            this.button_RemoveUser.Click += new System.EventHandler(this.button_RemoveUser_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listBox_Outbox);
            this.tabPage1.Controls.Add(this.button_ClearSent);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.button_ClearOutbox);
            this.tabPage1.Controls.Add(this.listBox_Sent);
            this.tabPage1.Controls.Add(this.button_ResendOutbox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(546, 436);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Status";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 350);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 84;
            this.label1.Text = "Delayed trigger:";
            // 
            // textBox_TriggerDelay
            // 
            this.textBox_TriggerDelay.Location = new System.Drawing.Point(113, 347);
            this.textBox_TriggerDelay.Name = "textBox_TriggerDelay";
            this.textBox_TriggerDelay.Size = new System.Drawing.Size(42, 20);
            this.textBox_TriggerDelay.TabIndex = 85;
            this.textBox_TriggerDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(158, 351);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(12, 13);
            this.label8.TabIndex = 89;
            this.label8.Text = "s";
            // 
            // Form_AlarmDispatch
            // 
            this.AcceptButton = this.button_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 486);
            this.Controls.Add(this.button_RefreshScreen);
            this.Controls.Add(this.tabControl1);
            this.MaximumSize = new System.Drawing.Size(800, 2000);
            this.MinimumSize = new System.Drawing.Size(590, 450);
            this.Name = "Form_AlarmDispatch";
            this.ShowIcon = false;
            this.Text = "Alarm dispatch";
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_ClearOutbox;
        private System.Windows.Forms.ListBox listBox_Outbox;
        private System.Windows.Forms.Button button_RefreshScreen;
        private System.Windows.Forms.ListBox listBox_Sent;
        private System.Windows.Forms.Button button_ResendOutbox;
        private System.Windows.Forms.Button button_ClearSent;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button_RemoveUser;
        private System.Windows.Forms.Button button_DeactAct;
        private System.Windows.Forms.Button button_SendTest;
        private System.Windows.Forms.Button button_AddUser;
        private System.Windows.Forms.ListBox listBox_Recipients;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_Subject;
        private System.Windows.Forms.TextBox textBox_From;
        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_Server;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_Default;
        private System.Windows.Forms.Button button_ExcludedCodes;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_TriggerDelay;
    }
}