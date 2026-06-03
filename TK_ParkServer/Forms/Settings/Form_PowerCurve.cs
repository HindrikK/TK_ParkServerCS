using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TK_ParkServer.Forms.Settings
{
    public partial class Form_PowerCurve : Form
    {
        PowerCurve _powerCurve;
        PowerCurve tempPowerCurve = new PowerCurve();

        public Form_PowerCurve(PowerCurve powerCurve)
        {
            InitializeComponent();

            _powerCurve = powerCurve;
            _powerCurve.Copy(tempPowerCurve);
            FillDataGridView();

            this.dataGridView_PowerCurve.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_PowerCurve_CellValueChanged);
        }


        private void FillDataGridView()
        {
            dataGridView_PowerCurve.Rows.Clear();

            textBox_Windspeed_1.Text = tempPowerCurve.Windspeed_1.ToString("F1");
            textBox_Windspeed_2.Text = tempPowerCurve.Windspeed_2.ToString("F1");
            textBox_WindspeedStep.Text = tempPowerCurve.WindspeedStep.ToString("F1");

            float Wind;
            for (int i = 0; i < tempPowerCurve.NumOfValues; i++)
            {
                Wind = tempPowerCurve.Windspeed_1 + tempPowerCurve.WindspeedStep * i;
                dataGridView_PowerCurve.Rows.Add(Wind.ToString("F1"), tempPowerCurve.Power[i]);
            }
        }

        private void ChangePowerCurveWind()
        {
            tempPowerCurve.Windspeed_1 = Convert.ToSingle(textBox_Windspeed_1.Text);
            tempPowerCurve.Windspeed_2 = Convert.ToSingle(textBox_Windspeed_2.Text);
            tempPowerCurve.WindspeedStep = Convert.ToSingle(textBox_WindspeedStep.Text);
        }

        private void ChangePowerCurvePower()
        {
            for (int i = 0; i < tempPowerCurve.NumOfValues; i++)
            {
                tempPowerCurve.Power[i] = Convert.ToInt32(dataGridView_PowerCurve.Rows[i].Cells[1].Value);
            }
        }

        private void dataGridView_PowerCurve_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            button_Apply.Enabled = true;
        }

        private void button_Apply_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult answer = MessageBox.Show(this, "Are you sure you want to save the changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (answer == System.Windows.Forms.DialogResult.Yes)
            {
                ChangePowerCurveWind();
                ChangePowerCurvePower();
                tempPowerCurve.Copy(_powerCurve);
                _powerCurve.Save();
                _powerCurve.Copy(tempPowerCurve);
                FillDataGridView();
                button_Apply.Enabled = false;
            }
        }

        private void Form_PowerCurve_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (button_Apply.Enabled)
            {
                System.Windows.Forms.DialogResult answer = MessageBox.Show(this, "Do you want to save the changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (answer == System.Windows.Forms.DialogResult.Yes)
                {
                    tempPowerCurve.Copy(_powerCurve);
                    _powerCurve.Save();
                }
            }
        }

        private void textBox_Windspeed_1_Leave(object sender, EventArgs e)
        {
            try
            {
                tempPowerCurve.Windspeed_1 = Convert.ToSingle(textBox_Windspeed_1.Text);
                FillDataGridView();
            }
            catch
            {
                MessageBox.Show("Invalid value");
            }

            button_Apply.Enabled = true;
        }

        private void textBox_Windspeed_2_Leave(object sender, EventArgs e)
        {
            try
            {
                tempPowerCurve.Windspeed_2 = Convert.ToSingle(textBox_Windspeed_2.Text);
                FillDataGridView();
            }
            catch
            {
                MessageBox.Show("Invalid value");
            }

            button_Apply.Enabled = true;
        }

        private void textBox_WindspeedStep_Leave(object sender, EventArgs e)
        {
            try
            {
                tempPowerCurve.WindspeedStep = Convert.ToSingle(textBox_WindspeedStep.Text);
                FillDataGridView();
            }
            catch
            {
                MessageBox.Show("Invalid value");
            }

            button_Apply.Enabled = true;
        }
    }
}