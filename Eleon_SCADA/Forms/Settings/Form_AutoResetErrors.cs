using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Eleon_SCADA.Forms.Settings
{
    public partial class Form_AutoResetErrors : Form
    {
        public Form_AutoResetErrors()
        {
            InitializeComponent();
            RefreshScreen();
        }

        private void RefreshScreen()
        {
            listBox.Items.Clear();

            for (int i = 0; i < Eleon_SCADA.Settings.T01.AutoResetError.Count(); i++)
            {
                uint statusCode = Eleon_SCADA.Settings.T01.AutoResetError[i];
                listBox.Items.Add(statusCode.ToString());
            }

            textBox_AutoErrorAckDelay.Text = Eleon_SCADA.Settings.T01.AutoErrorAckDelay.ToString();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            Eleon_SCADA.Settings.T01.AutoErrorAckDelay = Convert.ToInt32(textBox_AutoErrorAckDelay.Text);
            Eleon_SCADA.Settings.T01.Save();
            this.Dispose();
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            Forms.Settings.Dialog_AddAutoResetCode myDialog = new Dialog_AddAutoResetCode();
            myDialog.ShowDialog();
            RefreshScreen();
        }

        private void button_Remove_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                Eleon_SCADA.Settings.T01.RemoveAutoResetError(listBox.SelectedItem.ToString());
                RefreshScreen();
            }
            else MessageBox.Show(this, "No user selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button_ClearAll_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Are you sure you want to clear\nall error codes ?",
                    "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                Eleon_SCADA.Settings.T01.AutoResetError.Clear();
                Eleon_SCADA.Settings.T01.Save();
                RefreshScreen();
            }
        }
    }
}
