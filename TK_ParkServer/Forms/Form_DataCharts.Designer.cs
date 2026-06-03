namespace TK_ParkServer.Forms
{
    partial class Form_DataCharts
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button_Load = new System.Windows.Forms.Button();
            this.comboBox_Turbine = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker_From = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker_To = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_Data = new System.Windows.Forms.ComboBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Load
            // 
            this.button_Load.Location = new System.Drawing.Point(459, 39);
            this.button_Load.Name = "button_Load";
            this.button_Load.Size = new System.Drawing.Size(75, 23);
            this.button_Load.TabIndex = 5;
            this.button_Load.Text = "Load";
            this.button_Load.UseVisualStyleBackColor = true;
            this.button_Load.Click += new System.EventHandler(this.button_Load_Click);
            // 
            // comboBox_Turbine
            // 
            this.comboBox_Turbine.FormattingEnabled = true;
            this.comboBox_Turbine.Location = new System.Drawing.Point(314, 14);
            this.comboBox_Turbine.Name = "comboBox_Turbine";
            this.comboBox_Turbine.Size = new System.Drawing.Size(62, 21);
            this.comboBox_Turbine.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(262, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Turbine:";
            // 
            // dateTimePicker_From
            // 
            this.dateTimePicker_From.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            this.dateTimePicker_From.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_From.Location = new System.Drawing.Point(66, 12);
            this.dateTimePicker_From.MinDate = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker_From.Name = "dateTimePicker_From";
            this.dateTimePicker_From.Size = new System.Drawing.Size(150, 20);
            this.dateTimePicker_From.TabIndex = 1;
            this.dateTimePicker_From.Value = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "From:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "To:";
            // 
            // dateTimePicker_To
            // 
            this.dateTimePicker_To.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            this.dateTimePicker_To.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_To.Location = new System.Drawing.Point(66, 38);
            this.dateTimePicker_To.MinDate = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker_To.Name = "dateTimePicker_To";
            this.dateTimePicker_To.Size = new System.Drawing.Size(150, 20);
            this.dateTimePicker_To.TabIndex = 3;
            this.dateTimePicker_To.Value = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(275, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Data:";
            // 
            // comboBox_Data
            // 
            this.comboBox_Data.FormattingEnabled = true;
            this.comboBox_Data.Location = new System.Drawing.Point(314, 41);
            this.comboBox_Data.Name = "comboBox_Data";
            this.comboBox_Data.Size = new System.Drawing.Size(108, 21);
            this.comboBox_Data.TabIndex = 4;
            this.comboBox_Data.SelectedIndexChanged += new System.EventHandler(this.comboBox_Data_SelectedIndexChanged);
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea2.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Minutes;
            chartArea2.AxisX.IsLabelAutoFit = false;
            chartArea2.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont)));
            chartArea2.AxisX.LabelStyle.Angle = -90;
            chartArea2.AxisX.LabelStyle.Format = "dd.MM   HH:mm";
            chartArea2.CursorX.AutoScroll = false;
            chartArea2.CursorX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Minutes;
            chartArea2.CursorX.IsUserEnabled = true;
            chartArea2.CursorX.IsUserSelectionEnabled = true;
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Location = new System.Drawing.Point(12, 99);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.CustomProperties = "EmptyPointValue=Zero";
            series2.Name = "Series1";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series2.YValuesPerPoint = 2;
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(760, 451);
            this.chart1.TabIndex = 8;
            this.chart1.Text = "chart1";
            this.chart1.SelectionRangeChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.CursorEventArgs>(this.chart1_SelectionRangeChanged);
            // 
            // Form_DataCharts
            // 
            this.AcceptButton = this.button_Load;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox_Data);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker_To);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker_From);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_Turbine);
            this.Controls.Add(this.button_Load);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "Form_DataCharts";
            this.ShowIcon = false;
            this.Text = "Data charts";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Load;
        private System.Windows.Forms.ComboBox comboBox_Turbine;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_From;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker_To;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_Data;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}