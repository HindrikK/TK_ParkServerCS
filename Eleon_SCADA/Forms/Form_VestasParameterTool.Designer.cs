namespace Eleon_SCADA.Forms
{
    partial class Form_VestasParameterTool
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_Value = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.button_Read = new System.Windows.Forms.Button();
            this.textBox_Text = new System.Windows.Forms.TextBox();
            this.textBox_Group2 = new System.Windows.Forms.TextBox();
            this.label53 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.textBox_Index2 = new System.Windows.Forms.TextBox();
            this.label59 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_Old = new System.Windows.Forms.TextBox();
            this.label60 = new System.Windows.Forms.Label();
            this.button_Change = new System.Windows.Forms.Button();
            this.textBox_New = new System.Windows.Forms.TextBox();
            this.textBox_Group1 = new System.Windows.Forms.TextBox();
            this.label62 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.textBox_Index1 = new System.Windows.Forms.TextBox();
            this.label68 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_Value);
            this.groupBox2.Controls.Add(this.label34);
            this.groupBox2.Controls.Add(this.button_Read);
            this.groupBox2.Controls.Add(this.textBox_Text);
            this.groupBox2.Controls.Add(this.textBox_Group2);
            this.groupBox2.Controls.Add(this.label53);
            this.groupBox2.Controls.Add(this.label58);
            this.groupBox2.Controls.Add(this.textBox_Index2);
            this.groupBox2.Controls.Add(this.label59);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(293, 169);
            this.groupBox2.TabIndex = 136;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Read Parameter";
            // 
            // textBox_Value
            // 
            this.textBox_Value.Location = new System.Drawing.Point(73, 93);
            this.textBox_Value.Name = "textBox_Value";
            this.textBox_Value.ReadOnly = true;
            this.textBox_Value.Size = new System.Drawing.Size(72, 20);
            this.textBox_Value.TabIndex = 13;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(36, 122);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(31, 13);
            this.label34.TabIndex = 16;
            this.label34.Text = "Text:";
            // 
            // button_Read
            // 
            this.button_Read.Location = new System.Drawing.Point(207, 17);
            this.button_Read.Name = "button_Read";
            this.button_Read.Size = new System.Drawing.Size(75, 23);
            this.button_Read.TabIndex = 8;
            this.button_Read.Text = "Read";
            this.button_Read.UseVisualStyleBackColor = true;
            this.button_Read.Click += new System.EventHandler(this.button_Read_Click);
            // 
            // textBox_Text
            // 
            this.textBox_Text.Location = new System.Drawing.Point(73, 119);
            this.textBox_Text.Name = "textBox_Text";
            this.textBox_Text.ReadOnly = true;
            this.textBox_Text.Size = new System.Drawing.Size(206, 20);
            this.textBox_Text.TabIndex = 15;
            // 
            // textBox_Group2
            // 
            this.textBox_Group2.Location = new System.Drawing.Point(73, 41);
            this.textBox_Group2.Name = "textBox_Group2";
            this.textBox_Group2.Size = new System.Drawing.Size(72, 20);
            this.textBox_Group2.TabIndex = 9;
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(30, 96);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(37, 13);
            this.label53.TabIndex = 14;
            this.label53.Text = "Value:";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(28, 44);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(39, 13);
            this.label58.TabIndex = 10;
            this.label58.Text = "Group:";
            // 
            // textBox_Index2
            // 
            this.textBox_Index2.Location = new System.Drawing.Point(73, 67);
            this.textBox_Index2.Name = "textBox_Index2";
            this.textBox_Index2.Size = new System.Drawing.Size(72, 20);
            this.textBox_Index2.TabIndex = 11;
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(31, 70);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(36, 13);
            this.label59.TabIndex = 12;
            this.label59.Text = "Index:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_Old);
            this.groupBox1.Controls.Add(this.label60);
            this.groupBox1.Controls.Add(this.button_Change);
            this.groupBox1.Controls.Add(this.textBox_New);
            this.groupBox1.Controls.Add(this.textBox_Group1);
            this.groupBox1.Controls.Add(this.label62);
            this.groupBox1.Controls.Add(this.label65);
            this.groupBox1.Controls.Add(this.textBox_Index1);
            this.groupBox1.Controls.Add(this.label68);
            this.groupBox1.Location = new System.Drawing.Point(311, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(293, 169);
            this.groupBox1.TabIndex = 135;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Change Parameter";
            // 
            // textBox_Old
            // 
            this.textBox_Old.Location = new System.Drawing.Point(81, 93);
            this.textBox_Old.Name = "textBox_Old";
            this.textBox_Old.Size = new System.Drawing.Size(72, 20);
            this.textBox_Old.TabIndex = 13;
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(43, 122);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(32, 13);
            this.label60.TabIndex = 16;
            this.label60.Text = "New:";
            // 
            // button_Change
            // 
            this.button_Change.Location = new System.Drawing.Point(208, 17);
            this.button_Change.Name = "button_Change";
            this.button_Change.Size = new System.Drawing.Size(75, 23);
            this.button_Change.TabIndex = 8;
            this.button_Change.Text = "Change";
            this.button_Change.UseVisualStyleBackColor = true;
            this.button_Change.Click += new System.EventHandler(this.button_Change_Click);
            // 
            // textBox_New
            // 
            this.textBox_New.Location = new System.Drawing.Point(81, 119);
            this.textBox_New.Name = "textBox_New";
            this.textBox_New.Size = new System.Drawing.Size(72, 20);
            this.textBox_New.TabIndex = 15;
            // 
            // textBox_Group1
            // 
            this.textBox_Group1.Location = new System.Drawing.Point(81, 41);
            this.textBox_Group1.Name = "textBox_Group1";
            this.textBox_Group1.Size = new System.Drawing.Size(72, 20);
            this.textBox_Group1.TabIndex = 9;
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(49, 96);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(26, 13);
            this.label62.TabIndex = 14;
            this.label62.Text = "Old:";
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(36, 44);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(39, 13);
            this.label65.TabIndex = 10;
            this.label65.Text = "Group:";
            // 
            // textBox_Index1
            // 
            this.textBox_Index1.Location = new System.Drawing.Point(81, 67);
            this.textBox_Index1.Name = "textBox_Index1";
            this.textBox_Index1.Size = new System.Drawing.Size(72, 20);
            this.textBox_Index1.TabIndex = 11;
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(39, 70);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(36, 13);
            this.label68.TabIndex = 12;
            this.label68.Text = "Index:";
            // 
            // Form_VestasParameterTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 193);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Form_VestasParameterTool";
            this.ShowIcon = false;
            this.Text = "Vestas Parameter Tool";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_Value;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Button button_Read;
        private System.Windows.Forms.TextBox textBox_Text;
        private System.Windows.Forms.TextBox textBox_Group2;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.TextBox textBox_Index2;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_Old;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.Button button_Change;
        private System.Windows.Forms.TextBox textBox_New;
        private System.Windows.Forms.TextBox textBox_Group1;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.TextBox textBox_Index1;
        private System.Windows.Forms.Label label68;
    }
}