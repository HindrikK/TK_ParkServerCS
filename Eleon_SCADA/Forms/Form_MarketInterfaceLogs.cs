using System;
using System.Windows.Forms;

namespace Eleon_SCADA.Forms
{
    public partial class Form_MarketInterfaceLogs : Form
    {
        public Form_MarketInterfaceLogs()
        {
            InitializeComponent();
            RefreshLog();
        }

        private void timer_Refresh_Tick(object sender, EventArgs e)
        {
            RefreshLog();
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void RefreshLog()
        {
            int topIndex = listBox_Logs.TopIndex;

            listBox_Logs.BeginUpdate();
            listBox_Logs.Items.Clear();

            foreach (string logEntry in MarketInterfaceLog.GetDisplayEntries())
            {
                listBox_Logs.Items.Add(logEntry);
            }

            if (listBox_Logs.Items.Count > 0)
            {
                if (topIndex < listBox_Logs.Items.Count)
                {
                    listBox_Logs.TopIndex = topIndex;
                }
                else
                {
                    listBox_Logs.TopIndex = listBox_Logs.Items.Count - 1;
                }
            }

            label_Status.Text = listBox_Logs.Items.Count.ToString() + " log entry(s)";
            listBox_Logs.EndUpdate();
        }
    }
}
