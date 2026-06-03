using System;
using System.Net;
using System.Windows.Forms;

namespace TK_ParkServer.Forms
{
    public partial class Form_MarketInterface : Form
    {
        public Form_MarketInterface()
        {
            InitializeComponent();

            button_Status.Enabled = Program.myModbusServer != null;
        }

        private void button_OK_Click(object sender, EventArgs e)
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
    }
}
