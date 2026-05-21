using System;
using System.Windows.Forms;
using ModbusServerCS;

namespace Eleon_SCADA.Forms
{
    public partial class Form_ModbusStatus : Form
    {
        public Form_ModbusStatus()
        {
            InitializeComponent();
            RefreshConnections();
        }

        private void timer_Refresh_Tick(object sender, EventArgs e)
        {
            RefreshConnections();
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void RefreshConnections()
        {
            listView_Connections.BeginUpdate();
            listView_Connections.Items.Clear();

            try
            {
                if (Program.myModbusServer == null)
                {
                    label_Status.Text = "Market Interface server is not running.";
                    return;
                }

                var connections = Program.myModbusServer.GetActiveConnections();
                foreach (ModbusConnectionInfo connection in connections)
                {
                    var item = new ListViewItem(connection.ConnectedAt.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"));
                    item.SubItems.Add(connection.Transport);
                    item.SubItems.Add(connection.Address.ToString());
                    item.SubItems.Add(connection.Port.ToString());
                    item.SubItems.Add(connection.LastValidRequest.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"));
                    listView_Connections.Items.Add(item);
                }

                label_Status.Text = connections.Count.ToString() + " active connection(s)";
            }
            finally
            {
                listView_Connections.EndUpdate();
            }
        }
    }
}
