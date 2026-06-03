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
    public partial class Form_Preferences : Form
    {
        public Form_Preferences()
        {
            InitializeComponent();

            try
            {
                checkBox_AutoConnectPark.Checked = TK_ParkServer.Settings.Application.AutoConnectPark;
                checkBox_AutoStartIEC104.Checked = TK_ParkServer.Settings.Application.AutoStartIEC104;
                textBox_UserAutoLogOut.Text = TK_ParkServer.Settings.Application.AutoLogoutTime.ToString();
            }
            catch { }
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            try
            {
                TK_ParkServer.Settings.Application.AutoConnectPark = checkBox_AutoConnectPark.Checked;
                TK_ParkServer.Settings.Application.AutoStartIEC104 = checkBox_AutoStartIEC104.Checked;
                TK_ParkServer.Settings.Application.AutoLogoutTime = Convert.ToInt32(textBox_UserAutoLogOut.Text);

                TK_ParkServer.Settings.Application.Save();
            }
            catch { }

            Dispose();
        }
    }
}
