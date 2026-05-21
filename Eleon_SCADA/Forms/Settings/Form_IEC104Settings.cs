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

            textBox_MaxNoOfClients.Text = Eleon_SCADA.Settings.TSOInterface.MaxNoOfClients.ToString();
            textBox_ServerIP.Text = Eleon_SCADA.Settings.TSOInterface.ServerIP;
            textBox_Port.Text = Eleon_SCADA.Settings.TSOInterface.Port.ToString();
            textBox_ASDU.Text = Eleon_SCADA.Settings.TSOInterface.ASDU.ToString();
            textBox_ReconnectTime.Text = Eleon_SCADA.Settings.TSOInterface.ReconnectTime.ToString();
            textBox_periodicPeriod.Text = Eleon_SCADA.Settings.TSOInterface.periodicPeriod.ToString();
            checkBox_periodicTransmission.Checked = Eleon_SCADA.Settings.TSOInterface.periodicTransmission;

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
            Eleon_SCADA.Settings.TSOInterface.MaxNoOfClients = Convert.ToInt16(textBox_MaxNoOfClients.Text);
            Eleon_SCADA.Settings.TSOInterface.ServerIP = textBox_ServerIP.Text;
            Eleon_SCADA.Settings.TSOInterface.Port = Convert.ToInt32(textBox_Port.Text);
            Eleon_SCADA.Settings.TSOInterface.ASDU = Convert.ToInt32(textBox_ASDU.Text);
            Eleon_SCADA.Settings.TSOInterface.ReconnectTime = Convert.ToInt16(textBox_ReconnectTime.Text);
            Eleon_SCADA.Settings.TSOInterface.periodicPeriod = Convert.ToInt32(textBox_periodicPeriod.Text);
            Eleon_SCADA.Settings.TSOInterface.periodicTransmission = checkBox_periodicTransmission.Checked;
            Eleon_SCADA.Settings.TSOInterface.Save();
            Dispose();
        }
    }
}
