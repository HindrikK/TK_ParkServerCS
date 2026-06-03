using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TK_ParkServer.Forms
{
    public partial class Form_AlarmAnnouncement : Form
    {
        public Form_AlarmAnnouncement()
        {
            InitializeComponent();
            RefreshScreen();
        }

        private void SetSettings()
        {
            TK_ParkServer.Settings.AlarmAnnouncement.TriggerDelay = Convert.ToInt32(textBox_TriggerDelay.Text);
            TK_ParkServer.Settings.AlarmAnnouncement.FromAddress = textBox_From.Text;
            TK_ParkServer.Settings.AlarmAnnouncement.Port = Convert.ToInt32(textBox_Port.Text);
            TK_ParkServer.Settings.AlarmAnnouncement.Server = textBox_Server.Text;
            TK_ParkServer.Settings.AlarmAnnouncement.Subject = textBox_Subject.Text;
            TK_ParkServer.Settings.AlarmAnnouncement.Save();
        }

        private void RefreshScreen()
        {
            textBox_TriggerDelay.Text = TK_ParkServer.Settings.AlarmAnnouncement.TriggerDelay.ToString();
            textBox_From.Text = TK_ParkServer.Settings.AlarmAnnouncement.FromAddress;
            textBox_Port.Text = TK_ParkServer.Settings.AlarmAnnouncement.Port.ToString();
            textBox_Server.Text = TK_ParkServer.Settings.AlarmAnnouncement.Server;
            textBox_Subject.Text = TK_ParkServer.Settings.AlarmAnnouncement.Subject;

            listBox_Outbox.Items.Clear();

            for (int i = 0; i < Program.myAlarmDispatch.Outbox.Count(); i++)
            {
                if (Program.myAlarmDispatch.Outbox[i] != null)
                {
                    string message;
                    message = i + " - " + Program.myAlarmDispatch.Outbox[i].To + " - "
                        + Program.myAlarmDispatch.Outbox[i].Body;

                    listBox_Outbox.Items.Add(message);
                }
            }

            listBox_Sent.Items.Clear();

            for (int i = 0; i < Program.myAlarmDispatch.Sent.Count(); i++)
            {
                if (Program.myAlarmDispatch.Sent[i] != null)
                {
                    string messageDate = Program.myAlarmDispatch.Sent[i].Headers["Date"];
                    string message;
                    message = i + " - " + messageDate + "  " + Program.myAlarmDispatch.Sent[i].To + " - "
                        + Program.myAlarmDispatch.Sent[i].Body;

                    listBox_Sent.Items.Add(message);
                }
            }

            listBox_Recipients.Items.Clear();

            for (int i = 0; i < TK_ParkServer.Settings.AlarmAnnouncement.Recipients.Count(); i++)
            {
                if (TK_ParkServer.Settings.AlarmAnnouncement.Recipients[i] != null)
                {
                    string recipient;
                    string active;
                    if (TK_ParkServer.Settings.AlarmAnnouncement.Recipients[i].Active) active = "Active";
                    else active = "Not active";
                    recipient = TK_ParkServer.Settings.AlarmAnnouncement.Recipients[i].Name + " (" + TK_ParkServer.Settings.AlarmAnnouncement.Recipients[i].Address + ") status: " + active;

                    listBox_Recipients.Items.Add(recipient);
                }
            }
        }

        private void button_RefreshScreen_Click(object sender, EventArgs e)
        {
            RefreshScreen();
        }

        private void button_ClearOutbox_Click(object sender, EventArgs e)
        {
            Program.myAlarmDispatch.ClearOutbox();
            RefreshScreen();
        }

        private void button_ResendOutbox_Click(object sender, EventArgs e)
        {
            try { Program.myAlarmDispatch.ResendOutbox(); }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            RefreshScreen();
        }

        private void button_AddUser_Click(object sender, EventArgs e)
        {
            Dialog_AddUser myAddUser_Dialog = new Dialog_AddUser();
            myAddUser_Dialog.ShowDialog();
            RefreshScreen();
        }

        private void button_ClearSent_Click(object sender, EventArgs e)
        {
            Program.myAlarmDispatch.ClearSent();
            RefreshScreen();
        }

        private void button_SendTest_Click(object sender, EventArgs e)
        {
            if (listBox_Recipients.SelectedItem != null)
            {
                string item = listBox_Recipients.SelectedItem.ToString();
                string name = item.Substring(0, item.LastIndexOf("(") - 1);
                try { Program.myAlarmDispatch.SendTestAlarm(TK_ParkServer.Settings.AlarmAnnouncement.GetAddress(name)); }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Sending failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    RefreshScreen();
                    return;
                }
                MessageBox.Show(this, "Test message sent to " + name, "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
                RefreshScreen();
            }
            else MessageBox.Show(this, "No user selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button_RemoveUser_Click(object sender, EventArgs e)
        {
            if (listBox_Recipients.SelectedItem != null)
            {
                string item = listBox_Recipients.SelectedItem.ToString();
                string name = item.Substring(0, item.LastIndexOf("(") - 1);
                TK_ParkServer.Settings.AlarmAnnouncement.RemoveRecipient(name);
                RefreshScreen();
            }
            else MessageBox.Show(this, "No user selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button_DeactAct_Click(object sender, EventArgs e)
        {
            if (listBox_Recipients.SelectedItem != null)
            {
                string item = listBox_Recipients.SelectedItem.ToString();
                string name = item.Substring(0, item.LastIndexOf("(") - 1);
                TK_ParkServer.Settings.AlarmAnnouncement.ToggleActive(name);
                RefreshScreen();
            }
            else MessageBox.Show(this, "No user selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            SetSettings();
            Dispose();
        }

        private void button_Default_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Do you really want to restore the default settings?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                TK_ParkServer.Settings.AlarmAnnouncement.Reset();
                RefreshScreen();
            }
        }

        private void button_ExcludedCodes_Click(object sender, EventArgs e)
        {
            Forms.Settings.Form_AlarmAnnouncementStatusCodes myExcludedCodesForm = new Settings.Form_AlarmAnnouncementStatusCodes();
            myExcludedCodesForm.ShowDialog();
        }
    }
}
