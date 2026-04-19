using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eleon_SCADA.Forms
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
            Eleon_SCADA.Settings.AlarmAnnouncement.TriggerDelay = Convert.ToInt32(textBox_TriggerDelay.Text);
            Eleon_SCADA.Settings.AlarmAnnouncement.FromAddress = textBox_From.Text;
            Eleon_SCADA.Settings.AlarmAnnouncement.Port = Convert.ToInt32(textBox_Port.Text);
            Eleon_SCADA.Settings.AlarmAnnouncement.Server = textBox_Server.Text;
            Eleon_SCADA.Settings.AlarmAnnouncement.Subject = textBox_Subject.Text;
            Eleon_SCADA.Settings.AlarmAnnouncement.Save();
        }

        private void RefreshScreen()
        {
            textBox_TriggerDelay.Text = Eleon_SCADA.Settings.AlarmAnnouncement.TriggerDelay.ToString();
            textBox_From.Text = Eleon_SCADA.Settings.AlarmAnnouncement.FromAddress;
            textBox_Port.Text = Eleon_SCADA.Settings.AlarmAnnouncement.Port.ToString();
            textBox_Server.Text = Eleon_SCADA.Settings.AlarmAnnouncement.Server;
            textBox_Subject.Text = Eleon_SCADA.Settings.AlarmAnnouncement.Subject;

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

            for (int i = 0; i < Eleon_SCADA.Settings.AlarmAnnouncement.Recipients.Count(); i++)
            {
                if (Eleon_SCADA.Settings.AlarmAnnouncement.Recipients[i] != null)
                {
                    string recipient;
                    string active;
                    if (Eleon_SCADA.Settings.AlarmAnnouncement.Recipients[i].Active) active = "Active";
                    else active = "Not active";
                    recipient = Eleon_SCADA.Settings.AlarmAnnouncement.Recipients[i].Name + " (" + Eleon_SCADA.Settings.AlarmAnnouncement.Recipients[i].Address + ") status: " + active;

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
                try { Program.myAlarmDispatch.SendTestAlarm(Eleon_SCADA.Settings.AlarmAnnouncement.GetAddress(name)); }
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
                Eleon_SCADA.Settings.AlarmAnnouncement.RemoveRecipient(name);
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
                Eleon_SCADA.Settings.AlarmAnnouncement.ToggleActive(name);
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
                Eleon_SCADA.Settings.AlarmAnnouncement.Reset();
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
