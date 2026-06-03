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
    public partial class Form_AlarmAnnouncementStatusCodes : Form
    {
        public Form_AlarmAnnouncementStatusCodes()
        {
            InitializeComponent();
            RefreshScreen();
        }

        private void RefreshScreen()
        {
            /*try { Park_Server.Settings.AlarmDispatch.GetExcludedStatus(); }
            catch (Exception ex)
            { 
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
            //Park_Server.Settings.AlarmDispatch.Load();

            listBox_ExcludedStatus.Items.Clear();

            for (int i = 0; i < TK_ParkServer.Settings.AlarmAnnouncement.ExcludedStatus.Count(); i++)
            {
                uint statusCode = TK_ParkServer.Settings.AlarmAnnouncement.ExcludedStatus[i];
                //string status = (statusCode >> 8).ToString() + ":" + (statusCode & 0xFF).ToString();
                //listBox_ExcludedStatus.Items.Add(status);
                listBox_ExcludedStatus.Items.Add(statusCode.ToString());
            }
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            Forms.Settings.Dialog_AddExcludedStatus myDialog = new Dialog_AddExcludedStatus();
            myDialog.ShowDialog();
            RefreshScreen();
        }

        private void button_Remove_Click(object sender, EventArgs e)
        {
            if (listBox_ExcludedStatus.SelectedItem != null)
            {
                TK_ParkServer.Settings.AlarmAnnouncement.RemoveExcludedStatus(listBox_ExcludedStatus.SelectedItem.ToString());
                RefreshScreen();
            }
            else MessageBox.Show(this, "No user selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button_ClearAll_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Are you sure you want to clear\nall status codes ?",
                    "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                TK_ParkServer.Settings.AlarmAnnouncement.ExcludedStatus.Clear();
                //Park_Server.Settings.AlarmDispatch.SetExcludedStatus();
                TK_ParkServer.Settings.AlarmAnnouncement.Save();
                RefreshScreen();
            }
        }
    }
}
