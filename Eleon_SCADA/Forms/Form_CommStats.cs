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
    public partial class Form_CommStats : Form
    {
        public Form_CommStats()
        {
            InitializeComponent();
        }

        // refresh data values on form
        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox_Errors_01.Text = Program.myPark.myTurbines[1].TurbineComErrors.ToString();
            textBox_Tx_01.Text = Program.myPark.myTurbines[1].TurbineComTransmitted.ToString();
            textBox_Rx_01.Text = Program.myPark.myTurbines[1].TurbineComReceived.ToString();
        }

        // reset all counters
        private void button_ResetTurbines_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to\nreset all counter ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                for (uint i = 1; i <= Program.myPark.NumOfTurbinesInPark; i++)
                {
                    Program.myPark.ParkComErrors = 0;
                    Program.myPark.ParkComTransmitted = 0;
                    Program.myPark.ParkComReceived = 0;

                    Program.myPark.myTurbines[i].TurbineComErrors = 0;
                    Program.myPark.myTurbines[i].TurbineComTransmitted = 0;
                    Program.myPark.myTurbines[i].TurbineComReceived = 0;
                }
            }
        }

        private void button_Log_Click(object sender, EventArgs e)
        {
            Form_CommErrorLog form_CommErrorLog = new Form_CommErrorLog();
            form_CommErrorLog.Show();
        }
    }
}
