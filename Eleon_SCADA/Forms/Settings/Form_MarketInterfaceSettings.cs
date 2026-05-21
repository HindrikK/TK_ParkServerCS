using System;
using System.Net;
using System.Windows.Forms;

namespace Eleon_SCADA.Forms
{
    public partial class Form_MarketInterfaceSettings : Form
    {
        public Form_MarketInterfaceSettings()
        {
            InitializeComponent();

            checkBox_MarketIfEnable.Checked = global::Eleon_SCADA.Settings.MarketInterface.MarketIfEnable;
            textBox_IpAddress.Text = global::Eleon_SCADA.Settings.MarketInterface.IpAddress;
            textBox_UdpPort.Text = global::Eleon_SCADA.Settings.MarketInterface.UdpPort.ToString();
            textBox_TcpPort.Text = global::Eleon_SCADA.Settings.MarketInterface.TcpPort.ToString();
            checkBox_UdpEnable.Checked = global::Eleon_SCADA.Settings.MarketInterface.UdpEnable;
            checkBox_TcpEnable.Checked = global::Eleon_SCADA.Settings.MarketInterface.TcpEnable;
            textBox_MaxActiveConnections.Text = global::Eleon_SCADA.Settings.MarketInterface.MaxActiveConnections.ToString();
            textBox_ConnStaleTimeout.Text = global::Eleon_SCADA.Settings.MarketInterface.ConnStaleTimeout.ToString();
            textBox_ResponseRateLimit.Text = global::Eleon_SCADA.Settings.MarketInterface.ResponseRateLimit.ToString();
            textBox_FallbackTimeout.Text = global::Eleon_SCADA.Settings.MarketInterface.FallbackTimeout.ToString();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            try
            {
                global::Eleon_SCADA.Settings.MarketInterface.MarketIfEnable = checkBox_MarketIfEnable.Checked;
                global::Eleon_SCADA.Settings.MarketInterface.IpAddress = IPAddress.Parse(textBox_IpAddress.Text).ToString();
                global::Eleon_SCADA.Settings.MarketInterface.UdpPort = Convert.ToInt32(textBox_UdpPort.Text);
                global::Eleon_SCADA.Settings.MarketInterface.TcpPort = Convert.ToInt32(textBox_TcpPort.Text);
                global::Eleon_SCADA.Settings.MarketInterface.UdpEnable = checkBox_UdpEnable.Checked;
                global::Eleon_SCADA.Settings.MarketInterface.TcpEnable = checkBox_TcpEnable.Checked;
                global::Eleon_SCADA.Settings.MarketInterface.MaxActiveConnections = Convert.ToInt32(textBox_MaxActiveConnections.Text);
                global::Eleon_SCADA.Settings.MarketInterface.ConnStaleTimeout = Convert.ToInt32(textBox_ConnStaleTimeout.Text);
                global::Eleon_SCADA.Settings.MarketInterface.ResponseRateLimit = Convert.ToInt32(textBox_ResponseRateLimit.Text);
                global::Eleon_SCADA.Settings.MarketInterface.FallbackTimeout = Convert.ToInt32(textBox_FallbackTimeout.Text);

                global::Eleon_SCADA.Settings.MarketInterface.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wrong value detected\n\nDetails:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                ApplyServerState();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error starting Market Interface server\n\nDetails:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Dispose();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void button_Status_Click(object sender, EventArgs e)
        {
            Form_ModbusStatus form_ModbusStatus = new Form_ModbusStatus();
            form_ModbusStatus.Show(this);
        }

        private void button_Logs_Click(object sender, EventArgs e)
        {
            Form_MarketInterfaceLogs form_MarketInterfaceLogs = new Form_MarketInterfaceLogs();
            form_MarketInterfaceLogs.Show();
        }

        private void ApplyServerState()
        {
            if (Program.myModbusServer != null)
            {
                Program.myModbusServer.Stop();
                Program.myModbusServer = null;
            }

            if (global::Eleon_SCADA.Settings.MarketInterface.MarketIfEnable)
            {
                try
                {
                    Program.myModbusServer = new ModbusIntegration();
                    Program.myModbusServer.Start();
                    MarketInterfaceLog.Add("Market Interface manually enabled.");
                }
                catch
                {
                    Program.myModbusServer = null;
                    throw;
                }
            }
            else if (Program.myPark != null)
            {
                Program.myPark.Market_ActivePowerSetpoint = Program.myPark.ActivePowerMax;
                MarketInterfaceLog.Add("Market Interface manually disabled.");
            }
        }
    }
}
