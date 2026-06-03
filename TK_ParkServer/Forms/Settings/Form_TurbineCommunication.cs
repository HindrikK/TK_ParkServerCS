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
    public partial class Form_TurbineCommunication : Form
    {
        public Form_TurbineCommunication()
        {
            InitializeComponent();

            comboBox_PortName.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            comboBox_PortName.Text = TK_ParkServer.Settings.VestasDriver.PortName;
            textBox_Baudrate.Text = TK_ParkServer.Settings.VestasDriver.Baudrate.ToString();
            textBox_PollInterval1.Text = TK_ParkServer.Settings.VestasDriver.PollInterval1.ToString();
            textBox_PollInterval2.Text = TK_ParkServer.Settings.VestasDriver.PollInterval2.ToString();
            textBox_Timeout.Text = TK_ParkServer.Settings.VestasDriver.CommTimeout.ToString();
            textBox_CommStatusTimeout.Text = TK_ParkServer.Settings.VestasDriver.CommStatusTimeout.ToString();

            // fill combobox_Parity
            comboBox_Parity.Items.Add(System.IO.Ports.Parity.Even.ToString());
            comboBox_Parity.Items.Add(System.IO.Ports.Parity.Mark.ToString());
            comboBox_Parity.Items.Add(System.IO.Ports.Parity.None.ToString());
            comboBox_Parity.Items.Add(System.IO.Ports.Parity.Odd.ToString());
            comboBox_Parity.Items.Add(System.IO.Ports.Parity.Space.ToString());

            comboBox_Parity.Text = TK_ParkServer.Settings.VestasDriver.Parity.ToString();
        }


        private void button_Apply_Click(object sender, EventArgs e)
        {
            try
            {
                TK_ParkServer.Settings.VestasDriver.PortName = comboBox_PortName.Text;
                TK_ParkServer.Settings.VestasDriver.Baudrate = Convert.ToInt32(textBox_Baudrate.Text);
                TK_ParkServer.Settings.VestasDriver.PollInterval1 = Convert.ToUInt16(textBox_PollInterval1.Text);
                TK_ParkServer.Settings.VestasDriver.PollInterval2 = Convert.ToUInt16(textBox_PollInterval2.Text);
                TK_ParkServer.Settings.VestasDriver.CommTimeout = Convert.ToUInt16(textBox_Timeout.Text);
                TK_ParkServer.Settings.VestasDriver.CommStatusTimeout = Convert.ToUInt16(textBox_CommStatusTimeout.Text);
                TK_ParkServer.Settings.VestasDriver.Parity = comboBox_Parity.Text;

                TK_ParkServer.Settings.VestasDriver.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wrong value detected\n\nDetails:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Program.myVestasController.PortIsOpen)
            {
                MessageBox.Show(this, "Connection needs to be restarted for\nsome changes to take effect", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Dispose();
        }

        private void button_CommErrors_Click(object sender, EventArgs e)
        {
            Form_CommStats form_CommStats = new Form_CommStats();
            form_CommStats.Show();
        }
    }
}
