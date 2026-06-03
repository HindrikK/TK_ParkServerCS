namespace TK_ParkServer.Forms.Settings
{
    partial class Form_AlarmAnnouncementStatusCodes
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
            this.button_OK = new System.Windows.Forms.Button();
            this.listBox_ExcludedStatus = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_Add = new System.Windows.Forms.Button();
            this.button_Remove = new System.Windows.Forms.Button();
            this.button_ClearAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_OK
            // 
            this.button_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_OK.Location = new System.Drawing.Point(148, 255);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 0;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // listBox_ExcludedStatus
            // 
            this.listBox_ExcludedStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.listBox_ExcludedStatus.FormattingEnabled = true;
            this.listBox_ExcludedStatus.ItemHeight = 20;
            this.listBox_ExcludedStatus.Location = new System.Drawing.Point(29, 54);
            this.listBox_ExcludedStatus.Name = "listBox_ExcludedStatus";
            this.listBox_ExcludedStatus.ScrollAlwaysVisible = true;
            this.listBox_ExcludedStatus.Size = new System.Drawing.Size(106, 224);
            this.listBox_ExcludedStatus.Sorted = true;
            this.listBox_ExcludedStatus.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "This list defines status codes that are \"silent\"";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "and which do not trigger alarm message";
            // 
            // button_Add
            // 
            this.button_Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Add.Location = new System.Drawing.Point(148, 86);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(75, 23);
            this.button_Add.TabIndex = 4;
            this.button_Add.Text = "Add";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // button_Remove
            // 
            this.button_Remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Remove.Location = new System.Drawing.Point(148, 115);
            this.button_Remove.Name = "button_Remove";
            this.button_Remove.Size = new System.Drawing.Size(75, 23);
            this.button_Remove.TabIndex = 5;
            this.button_Remove.Text = "Remove";
            this.button_Remove.UseVisualStyleBackColor = true;
            this.button_Remove.Click += new System.EventHandler(this.button_Remove_Click);
            // 
            // button_ClearAll
            // 
            this.button_ClearAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ClearAll.Location = new System.Drawing.Point(148, 144);
            this.button_ClearAll.Name = "button_ClearAll";
            this.button_ClearAll.Size = new System.Drawing.Size(75, 23);
            this.button_ClearAll.TabIndex = 6;
            this.button_ClearAll.Text = "Clear all";
            this.button_ClearAll.UseVisualStyleBackColor = true;
            this.button_ClearAll.Click += new System.EventHandler(this.button_ClearAll_Click);
            // 
            // Form_AlarmAnnouncementStatusCodes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 303);
            this.Controls.Add(this.button_ClearAll);
            this.Controls.Add(this.button_Remove);
            this.Controls.Add(this.button_Add);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox_ExcludedStatus);
            this.Controls.Add(this.button_OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Form_AlarmAnnouncementStatusCodes";
            this.ShowIcon = false;
            this.Text = "List of excluded status codes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.ListBox listBox_ExcludedStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Button button_Remove;
        private System.Windows.Forms.Button button_ClearAll;
    }
}