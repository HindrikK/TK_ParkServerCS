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
    public partial class Dialog_AddExcludedStatus : Form
    {
        public Dialog_AddExcludedStatus()
        {
            InitializeComponent();
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            if (textBox_Status.Text != "")
            {
                try
                {
                    TK_ParkServer.Settings.AlarmAnnouncement.AddExcludedStatus(textBox_Status.Text);
                    MessageBox.Show(this, "Status code \"" + textBox_Status.Text + "\" added", "Added", MessageBoxButtons.OK, MessageBoxIcon.None);
                    Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(this, "Missing information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
