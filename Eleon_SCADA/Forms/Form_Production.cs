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
    public partial class Form_Production : Form
    {
        BindingSource myBindingSource;
        DateTime FromDate = DateTime.Parse("01.01.2014");
        DateTime ToDate = DateTime.Parse("01.01.2014");
        int Selection;
        string Period;


        public Form_Production()
        {
            InitializeComponent();

            // fill comboBox_Turbine
            comboBox_Selection.Items.Add("Park");
            for (int i = 1; i <= Eleon_SCADA.Program.myPark.NumOfTurbinesInPark; i++)
            {
                comboBox_Selection.Items.Add(Program.myPark.myTurbines[i].TurbineName);
            }
            comboBox_Selection.SelectedIndex = 1;
            Selection = 1;

            // fill comboBox_Period
            comboBox_Period.Items.Add("Day");
            comboBox_Period.Items.Add("Month");
            //comboBox_Period.Items.Add("Year");
            comboBox_Period.SelectedIndex = 1;
            Period = "Month";

            comboBox_Period_SelectedIndexChanged(this, EventArgs.Empty);

            // set date values for "Month" period view
            FromDate = DateTime.Parse(DateTime.Now.Year + ".01.01");
            ToDate = DateTime.Parse(DateTime.Now.Year + "." + DateTime.Now.Month + ".01");
            dateTimePicker_From.Value = FromDate;
            dateTimePicker_To.Value = ToDate;

            // prepare datagridView
            //Park_Server.Logging.TableAdapters.Data_2_TableAdapter.GetProduction_ByMonth(Selection, FromDate, ToDate);
            dataGridView1.AutoGenerateColumns = false;
            myBindingSource = new BindingSource();
            dataGridView1.Columns["Date"].DataPropertyName = "Time";
            dataGridView1.Columns["Production"].DataPropertyName = "Production";
            myBindingSource.DataSource = Program.myDatabases.myDataSets[Selection];
            dataGridView1.DataMember = "Production";
            dataGridView1.DataSource = myBindingSource;

            // add event handlers
            dateTimePicker_From.ValueChanged += new System.EventHandler(dateTimePicker_From_ValueChanged);
            dateTimePicker_To.ValueChanged += new System.EventHandler(dateTimePicker_To_ValueChanged);
            comboBox_Selection.SelectedIndexChanged += new System.EventHandler(comboBox_Selection_SelectedIndexChanged);
            comboBox_Period.SelectedIndexChanged += new System.EventHandler(comboBox_Period_SelectedIndexChanged);
        }

        private void RefreshData()
        {
            if (comboBox_Period.Text == "Day")
            {
                try
                {
                    Eleon_SCADA.Logging.TableAdapters.Data_2_TableAdapter.GetProduction_ByDay(Selection, FromDate, ToDate);
                    myBindingSource.DataSource = Program.myDatabases.myDataSets[Selection];
                }
                catch (Exception ex) { MessageBox.Show(this, "Database exception\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else if (Period == "Month")
            {
                try
                {
                    Eleon_SCADA.Logging.TableAdapters.Data_2_TableAdapter.GetProduction_ByMonth(Selection, FromDate, ToDate);
                    myBindingSource.DataSource = Program.myDatabases.myDataSets[Selection];
                }
                catch (Exception ex) { MessageBox.Show(this, "Database exception\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else if (Period == "Year")
            {
            }
            else
            {
                MessageBox.Show("Choose period", "Info");
            }
        }

        private void dateTimePicker_From_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker_From.Value <= ToDate)
            {
                FromDate = dateTimePicker_From.Value;
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
            }
            else
            {
                MessageBox.Show(this, "Illegal value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePicker_To.Value = ToDate;
            }
        }

        private void comboBox_Selection_SelectedIndexChanged(object sender, EventArgs e)
        {
            Selection = comboBox_Selection.SelectedIndex;
        }

        private void comboBox_Period_SelectedIndexChanged(object sender, EventArgs e)
        {
            Period = comboBox_Period.Text;

            if (Period == "Day")
            {
                dateTimePicker_From.Format = DateTimePickerFormat.Long;
                dateTimePicker_From.ShowUpDown = false;
                dateTimePicker_To.Format = DateTimePickerFormat.Long;
                dateTimePicker_To.ShowUpDown = false;

                dataGridView1.Columns["Date"].HeaderText = "Day";
                dataGridView1.Columns["Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            else if (Period == "Month")
            {
                dateTimePicker_From.CustomFormat = "MMM.yyyy";
                dateTimePicker_From.Format = DateTimePickerFormat.Custom;
                dateTimePicker_From.ShowUpDown = true;
                dateTimePicker_To.CustomFormat = "MMM.yyyy";
                dateTimePicker_To.Format = DateTimePickerFormat.Custom;
                dateTimePicker_To.ShowUpDown = true;

                dataGridView1.Columns["Date"].HeaderText = "Month";
                dataGridView1.Columns["Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            //else if (Period == "Year")
            //{
            //    dateTimePicker_From.CustomFormat = "yyyy";
            //    dateTimePicker_From.Format = DateTimePickerFormat.Custom;
            //    dateTimePicker_From.ShowUpDown = true;
            //    dateTimePicker_To.CustomFormat = "yyyy";
            //    dateTimePicker_To.Format = DateTimePickerFormat.Custom;
            //    dateTimePicker_To.ShowUpDown = true;

            //    dataGridView1.Columns["Date"].HeaderText = "Year";
            //    dataGridView1.Columns["Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //}
            else
            {
                MessageBox.Show("Choose period", "Info");
            }
        }

        private void button_Load_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
