using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TK_ParkServer.Forms
{
    public partial class Form_ErrorLogs : Form
    {
        BindingSource myBindingSource;
        DateTime FromDate = DateTime.Parse("01.01.2015");
        DateTime ToDate = DateTime.Parse("01.01.2015");
        int Turbine_ID;


        public Form_ErrorLogs()
        {
            InitializeComponent();

            // set date values
            FromDate = DateTime.Parse(DateTime.Now.Year + "." + DateTime.Now.Month + "." + 1);
            ToDate = DateTime.Parse(DateTime.Now.Year + "." + DateTime.Now.Month + "." + DateTime.Now.Day);
            dateTimePicker_From.Value = FromDate;
            dateTimePicker_To.Value = ToDate;

            // fill comboBox_Turbine
            for (int i = 1; i <= TK_ParkServer.Program.myPark.NumOfTurbinesInPark; i++)
            {
                comboBox_Turbine.Items.Add(Program.myPark.myTurbines[i].TurbineName);
            }
            comboBox_Turbine.SelectedIndex = 0;
            Turbine_ID = 1;

            // fill table first time
            TK_ParkServer.Logging.TableAdapters.Status_TableAdapter.Fill_ByDate(Turbine_ID, FromDate, ToDate);
            dataGridView1.AutoGenerateColumns = false;
            myBindingSource = new BindingSource();
            dataGridView1.Columns["Date"].DataPropertyName = "Time";
            dataGridView1.Columns["Time"].DataPropertyName = "Time";
            dataGridView1.Columns["Status"].DataPropertyName = "Status";
            myBindingSource.DataSource = Program.myDatabases.myDataSets[Turbine_ID];
            dataGridView1.DataMember = "Status";
            dataGridView1.DataSource = myBindingSource;


            // add event handlers
            dateTimePicker_From.ValueChanged += new System.EventHandler(dateTimePicker_From_ValueChanged);
            dateTimePicker_To.ValueChanged += new System.EventHandler(dateTimePicker_To_ValueChanged);
            comboBox_Turbine.SelectedIndexChanged += new System.EventHandler(comboBox_Turbine_SelectedIndexChanged);
        }

        private void RefreshData()
        {
            try
            {
                TK_ParkServer.Logging.TableAdapters.Status_TableAdapter.Fill_ByDate(Turbine_ID, FromDate, ToDate);
                myBindingSource.DataSource = Program.myDatabases.myDataSets[Turbine_ID];
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Database exception\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox_Turbine_SelectedIndexChanged(object sender, EventArgs e)
        {
            Turbine_ID = comboBox_Turbine.SelectedIndex + 1;
            RefreshData();
        }

        private void dateTimePicker_From_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker_From.Value <= ToDate)
            {
                FromDate = dateTimePicker_From.Value;
                RefreshData();
            }
            else
	        {
                MessageBox.Show(this, "Illegal value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePicker_From.Value = FromDate;
	        }
        }

        private void dateTimePicker_To_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker_To.Value >= FromDate)
            {
                ToDate = dateTimePicker_To.Value;
                RefreshData();
            }
            else
            {
                MessageBox.Show(this, "Illegal value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePicker_To.Value = ToDate;
            }
        }
    }
}
