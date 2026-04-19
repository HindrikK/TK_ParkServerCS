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
    public partial class Form_Preferences : Form
    {
        public Form_Preferences()
        {
            InitializeComponent();

            try
            {
                checkBox_AutoConnectPark.Checked = Eleon_SCADA.Settings.Application.AutoConnectPark;
                checkBox_AutoStartIEC104.Checked = Eleon_SCADA.Settings.Application.AutoStartIEC104;
                textBox_UserAutoLogOut.Text = Eleon_SCADA.Settings.Application.AutoLogoutTime.ToString();
            }
            catch { }
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            try
            {
                Eleon_SCADA.Settings.Application.AutoConnectPark = checkBox_AutoConnectPark.Checked;
                Eleon_SCADA.Settings.Application.AutoStartIEC104 = checkBox_AutoStartIEC104.Checked;
                Eleon_SCADA.Settings.Application.AutoLogoutTime = Convert.ToInt32(textBox_UserAutoLogOut.Text);

                Eleon_SCADA.Settings.Application.Save();
            }
            catch { }

            Dispose();
        }
    }
}
