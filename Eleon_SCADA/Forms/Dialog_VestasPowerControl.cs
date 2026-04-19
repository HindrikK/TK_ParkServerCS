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
    public partial class Dialog_VestasPowerControl : Form
    {
        public Dialog_VestasPowerControl()
        {
            InitializeComponent();
            textBox_Power.Text = Eleon_SCADA.Settings.VestasDriver.PowerSetpoint.ToString();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show(this, "Are you sure you want to send the values ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (answer == DialogResult.Yes)
            {
                UInt16 _power;

                try
                {
                    _power = Convert.ToUInt16(textBox_Power.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    //Program.myEnerconPark.SetPower(_power, _angle, _ramp);
                    Eleon_SCADA.Settings.VestasDriver.PowerSetpoint = _power;
                    Eleon_SCADA.Settings.VestasDriver.Save();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show(this, "New values set", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
        }
    }
}
