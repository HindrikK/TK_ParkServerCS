using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eleon_SCADA.Forms
{
    public partial class Form_DataCharts : Form
    {
        DateTime FromDate = DateTime.Parse("01.01.2014");
        DateTime ToDate = DateTime.Parse("01.01.2014");
        int Turbine_ID;
        string Data;

        public Form_DataCharts()
        {
            InitializeComponent();

            // set date values
            ToDate = DateTime.Parse(DateTime.Now.Year + "." + DateTime.Now.Month + "." + DateTime.Now.Day + " " 
                + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second);
            //FromDate = ToDate.AddDays(-7);
            FromDate = DateTime.Parse(DateTime.Now.Year + "." + DateTime.Now.Month + "." + DateTime.Now.Day).AddDays(-30);
            dateTimePicker_From.Value = FromDate;
            dateTimePicker_To.Value = ToDate;

            // fill comboBox_Turbine
            for (int i = 1; i <= Eleon_SCADA.Program.myPark.NumOfTurbinesInPark; i++)
            {
                comboBox_Turbine.Items.Add(Program.myPark.myTurbines[i].TurbineName);
            }
            comboBox_Turbine.SelectedIndex = 0;
            Turbine_ID = 1;

            // fill comboBox_Data
            comboBox_Data.Items.Add("Active Power");
            comboBox_Data.Items.Add("Windspeed");
            //comboBox_Data.Items.Add("Yaw position");

            comboBox_Data.SelectedIndex = 0;


            //Logging.TableAdapters.Data_1_TableAdapter.Fill_ByDate(2, FromDate, ToDate);
            //chart1.Series["Series1"].XValueMember = "Time";
            //chart1.Series["Series1"].YValueMembers = "ActivePower";
            //chart1.DataSource = Program.myDatabases.myDataSets[2].Tables["Data_1"];
            //chart1.DataBind();


            // add event handlers
            dateTimePicker_From.ValueChanged += new System.EventHandler(dateTimePicker_From_ValueChanged);
            dateTimePicker_To.ValueChanged += new System.EventHandler(dateTimePicker_To_ValueChanged);
            comboBox_Turbine.SelectedIndexChanged += new System.EventHandler(comboBox_Turbine_SelectedIndexChanged);
        }

        private void DrawChart()
        {
            if (Data == "Windspeed")
            {
                try { Logging.TableAdapters.Data_1_TableAdapter.Fill_ByDate(Turbine_ID, FromDate, ToDate); }
                catch (Exception ex) { MessageBox.Show(this, "Database exception\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                chart1.ChartAreas["ChartArea1"].AxisY.Maximum = double.NaN;

                chart1.Series["Series1"].XValueMember = "Time";
                chart1.Series["Series1"].YValueMembers = "WindSpeed";
                chart1.DataSource = Program.myDatabases.myDataSets[Turbine_ID].Tables["Data_1"];
                chart1.DataBind();
            }
            else if (Data == "Active Power")
            {
                try { Logging.TableAdapters.Data_1_TableAdapter.Fill_ByDate(Turbine_ID, FromDate, ToDate); }
                catch (Exception ex) { MessageBox.Show(this, "Database exception\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                chart1.ChartAreas["ChartArea1"].AxisY.Maximum = double.NaN;

                chart1.Series["Series1"].XValueMember = "Time";
                chart1.Series["Series1"].YValueMembers = "ActivePower";
                chart1.DataSource = Program.myDatabases.myDataSets[Turbine_ID].Tables["Data_1"];
                chart1.DataBind();
            }
            else if (Data == "Yaw position")
            {
                try { Logging.TableAdapters.Data_2_TableAdapter.Fill_ByDate(Turbine_ID, FromDate, ToDate); }
                catch (Exception ex) { MessageBox.Show(this, "Database exception\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                chart1.ChartAreas["ChartArea1"].AxisY.Maximum = 360;

                chart1.Series["Series1"].XValueMember = "Time";
                chart1.Series["Series1"].YValueMembers = "YawPosition";
                chart1.DataSource = Program.myDatabases.myDataSets[Turbine_ID].Tables["Data_2"];
                chart1.DataBind();
            }
            else
            {
                MessageBox.Show("Choose data", "Info");
            }
        }

        private void comboBox_Turbine_SelectedIndexChanged(object sender, EventArgs e)
        {
            Turbine_ID = comboBox_Turbine.SelectedIndex + 1;
        }

        private void dateTimePicker_From_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker_From.Value <= ToDate.AddMinutes(-30) && dateTimePicker_From.Value >= ToDate.AddDays(-31))
            {
                FromDate = dateTimePicker_From.Value;
            }
            else
            {
                //MessageBox.Show(this, "Illegal value\n\n\"From\" greater than \"To\" or\nmax(31 days)/min(30 min) timespan exceeded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //dateTimePicker_From.Value = FromDate;
                FromDate = dateTimePicker_From.Value;
                dateTimePicker_To.Value = FromDate.AddDays(31);
            }
        }

        private void dateTimePicker_To_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker_To.Value >= FromDate.AddMinutes(30) && dateTimePicker_To.Value <= FromDate.AddDays(31))
            {
                ToDate = dateTimePicker_To.Value;
            }
            else
            {
                MessageBox.Show(this, "Illegal value\n\"From\" greater than \"To\" or\nmax timespan(31 days) exceeded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePicker_To.Value = ToDate;
            }
        }

        private void button_Load_Click(object sender, EventArgs e)
        {
            DrawChart();
        }

        private void comboBox_Data_SelectedIndexChanged(object sender, EventArgs e)
        {
            Data = comboBox_Data.Text;
        }

        private void chart1_SelectionRangeChanged(object sender, System.Windows.Forms.DataVisualization.Charting.CursorEventArgs e)
        {
            ////label5.Text = Convert.ToString(chart1.ChartAreas["ChartArea1"].CursorX.SelectionStart);
            ////label6.Text = chart1.ChartAreas["ChartArea1"].CursorX.SelectionEnd.ToString();
            //System.Globalization.NumberFormatInfo numFormat = new System.Globalization.NumberFormatInfo();
            //numFormat.NumberDecimalSeparator = ".";
            //dateTimePicker_From.Value = Convert.ToDateTime(chart1.ChartAreas["ChartArea1"].CursorX.SelectionStart.ToString(numFormat));
            //dateTimePicker_To.Value = Convert.ToDateTime(chart1.ChartAreas["ChartArea1"].CursorX.SelectionEnd.ToString(numFormat));
        }
    }
}
