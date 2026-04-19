using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eleon_SCADA.Forms.Settings
{
    public partial class Form_IEC104Settings : Form
    {
        public Form_IEC104Settings()
        {
            InitializeComponent();

            textBox_MaxNoOfClients.Text = Eleon_SCADA.Settings.IEC104Server.MaxNoOfClients.ToString();
            textBox_ServerIP.Text = Eleon_SCADA.Settings.IEC104Server.ServerIP;
            textBox_Port.Text = Eleon_SCADA.Settings.IEC104Server.Port.ToString();
            textBox_ASDU.Text = Eleon_SCADA.Settings.IEC104Server.ASDU.ToString();
            textBox_ReconnectTime.Text = Eleon_SCADA.Settings.IEC104Server.ReconnectTime.ToString();
            textBox_periodicPeriod.Text = Eleon_SCADA.Settings.IEC104Server.periodicPeriod.ToString();
            checkBox_periodicTransmission.Checked = Eleon_SCADA.Settings.IEC104Server.periodicTransmission;

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
            Eleon_SCADA.Settings.IEC104Server.MaxNoOfClients = Convert.ToInt16(textBox_MaxNoOfClients.Text);
            Eleon_SCADA.Settings.IEC104Server.ServerIP = textBox_ServerIP.Text;
            Eleon_SCADA.Settings.IEC104Server.Port = Convert.ToInt32(textBox_Port.Text);
            Eleon_SCADA.Settings.IEC104Server.ASDU = Convert.ToInt32(textBox_ASDU.Text);
            Eleon_SCADA.Settings.IEC104Server.ReconnectTime = Convert.ToInt16(textBox_ReconnectTime.Text);
            Eleon_SCADA.Settings.IEC104Server.periodicPeriod = Convert.ToInt32(textBox_periodicPeriod.Text);
            Eleon_SCADA.Settings.IEC104Server.periodicTransmission = checkBox_periodicTransmission.Checked;
            Eleon_SCADA.Settings.IEC104Server.Save();
            Dispose();
        }
    }
}
