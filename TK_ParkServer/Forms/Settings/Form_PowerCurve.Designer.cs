namespace TK_ParkServer.Forms.Settings
{
    partial class Form_PowerCurve
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button_Apply = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Windspeed_1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_Windspeed_2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_WindspeedStep = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridView_PowerCurve = new System.Windows.Forms.DataGridView();
            this.Wind = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Power = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_PowerCurve)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Apply
            // 
            this.button_Apply.Enabled = false;
            this.button_Apply.Location = new System.Drawing.Point(194, 488);
            this.button_Apply.Name = "button_Apply";
            this.button_Apply.Size = new System.Drawing.Size(75, 23);
            this.button_Apply.TabIndex = 5;
            this.button_Apply.Text = "Apply";
            this.button_Apply.UseVisualStyleBackColor = true;
            this.button_Apply.Click += new System.EventHandler(this.button_Apply_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Windspeed 1";
            // 
            // textBox_Windspeed_1
            // 
            this.textBox_Windspeed_1.Enabled = false;
            this.textBox_Windspeed_1.Location = new System.Drawing.Point(107, 23);
            this.textBox_Windspeed_1.Name = "textBox_Windspeed_1";
            this.textBox_Windspeed_1.Size = new System.Drawing.Size(42, 20);
            this.textBox_Windspeed_1.TabIndex = 7;
            this.textBox_Windspeed_1.Text = "2,5";
            this.textBox_Windspeed_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_Windspeed_1.Leave += new System.EventHandler(this.textBox_Windspeed_1_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(155, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "m/s";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(155, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "m/s";
            // 
            // textBox_Windspeed_2
            // 
            this.textBox_Windspeed_2.Enabled = false;
            this.textBox_Windspeed_2.Location = new System.Drawing.Point(107, 49);
            this.textBox_Windspeed_2.Name = "textBox_Windspeed_2";
            this.textBox_Windspeed_2.Size = new System.Drawing.Size(42, 20);
            this.textBox_Windspeed_2.TabIndex = 10;
            this.textBox_Windspeed_2.Text = "16,0";
            this.textBox_Windspeed_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_Windspeed_2.Leave += new System.EventHandler(this.textBox_Windspeed_2_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Windspeed 2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(155, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "m/s";
            // 
            // textBox_WindspeedStep
            // 
            this.textBox_WindspeedStep.Enabled = false;
            this.textBox_WindspeedStep.Location = new System.Drawing.Point(107, 75);
            this.textBox_WindspeedStep.Name = "textBox_WindspeedStep";
            this.textBox_WindspeedStep.Size = new System.Drawing.Size(42, 20);
            this.textBox_WindspeedStep.TabIndex = 13;
            this.textBox_WindspeedStep.Text = "0,1";
            this.textBox_WindspeedStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_WindspeedStep.Leave += new System.EventHandler(this.textBox_WindspeedStep_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Windspeed step";
            // 
            // dataGridView_PowerCurve
            // 
            this.dataGridView_PowerCurve.AllowUserToAddRows = false;
            this.dataGridView_PowerCurve.AllowUserToDeleteRows = false;
            this.dataGridView_PowerCurve.AllowUserToResizeColumns = false;
            this.dataGridView_PowerCurve.AllowUserToResizeRows = false;
            this.dataGridView_PowerCurve.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridView_PowerCurve.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_PowerCurve.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Wind,
            this.Power});
            this.dataGridView_PowerCurve.Location = new System.Drawing.Point(15, 150);
            this.dataGridView_PowerCurve.Name = "dataGridView_PowerCurve";
            this.dataGridView_PowerCurve.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView_PowerCurve.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView_PowerCurve.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView_PowerCurve.Size = new System.Drawing.Size(173, 361);
            this.dataGridView_PowerCurve.TabIndex = 15;
            // 
            // Wind
            // 
            this.Wind.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.Wind.DefaultCellStyle = dataGridViewCellStyle1;
            this.Wind.HeaderText = "Wind";
            this.Wind.Name = "Wind";
            this.Wind.ReadOnly = true;
            this.Wind.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Wind.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Wind.Width = 50;
            // 
            // Power
            // 
            this.Power.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.Power.DefaultCellStyle = dataGridViewCellStyle2;
            this.Power.HeaderText = "Power";
            this.Power.Name = "Power";
            this.Power.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Power.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Power.Width = 80;
            // 
            // Form_PowerCurve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 529);
            this.Controls.Add(this.dataGridView_PowerCurve);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_WindspeedStep);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_Windspeed_2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_Windspeed_1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_Apply);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_PowerCurve";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Power Curve";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_PowerCurve_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_PowerCurve)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Apply;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Windspeed_1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_Windspeed_2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_WindspeedStep;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataGridView_PowerCurve;
        private System.Windows.Forms.DataGridViewTextBoxColumn Wind;
        private System.Windows.Forms.DataGridViewTextBoxColumn Power;
    }
}