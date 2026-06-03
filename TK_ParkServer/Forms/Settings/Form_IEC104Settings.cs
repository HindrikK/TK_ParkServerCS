using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TK_ParkServer.Forms.Settings
{
    public partial class Form_IEC104Settings : Form
    {
        public Form_IEC104Settings()
        {
            InitializeComponent();

            textBox_MaxNoOfClients.Text = TK_ParkServer.Settings.TSOInterface.MaxNoOfClients.ToString();
            textBox_ServerIP.Text = TK_ParkServer.Settings.TSOInterface.ServerIP;
            textBox_Port.Text = TK_ParkServer.Settings.TSOInterface.Port.ToString();
            textBox_ASDU.Text = TK_ParkServer.Settings.TSOInterface.ASDU.ToString();
            textBox_ReconnectTime.Text = TK_ParkServer.Settings.TSOInterface.ReconnectTime.ToString();
            textBox_periodicPeriod.Text = TK_ParkServer.Settings.TSOInterface.periodicPeriod.ToString();
            checkBox_periodicTransmission.Checked = TK_ParkServer.Settings.TSOInterface.periodicTransmission;

            if (!checkBox_periodicTransmission.Checked)
            {
                textBox_periodicPeriod.Enabled = false;
            }
        }

        private void checkBox_periodicTransmission_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_periodicTransmission.Checked)
            {
                textBox_periodicPeriod.Enabled = true;
            }
            else
            {
                textBox_periodicPeriod.Enabled = false;
            }
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            TK_ParkServer.Settings.TSOInterface.MaxNoOfClients = Convert.ToInt16(textBox_MaxNoOfClients.Text);
            TK_ParkServer.Settings.TSOInterface.ServerIP = textBox_ServerIP.Text;
            TK_ParkServer.Settings.TSOInterface.Port = Convert.ToInt32(textBox_Port.Text);
            TK_ParkServer.Settings.TSOInterface.ASDU = Convert.ToInt32(textBox_ASDU.Text);
            TK_ParkServer.Settings.TSOInterface.ReconnectTime = Convert.ToInt16(textBox_ReconnectTime.Text);
            TK_ParkServer.Settings.TSOInterface.periodicPeriod = Convert.ToInt32(textBox_periodicPeriod.Text);
            TK_ParkServer.Settings.TSOInterface.periodicTransmission = checkBox_periodicTransmission.Checked;
            TK_ParkServer.Settings.TSOInterface.Save();
            Dispose();
        }
    }
}
