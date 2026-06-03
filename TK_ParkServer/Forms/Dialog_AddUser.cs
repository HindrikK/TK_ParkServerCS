using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TK_ParkServer.Forms
{
    public partial class Dialog_AddUser : Form
    {
        public Dialog_AddUser()
        {
            InitializeComponent();
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            if (textBox_Name.Text != "" && textBox_Address.Text != "")
            {
                try
                {
                    TK_ParkServer.Settings.AlarmAnnouncement.AddRecipient(textBox_Name.Text, textBox_Address.Text);
                    MessageBox.Show(this, "user " + textBox_Name.Text + " added", "Added", MessageBoxButtons.OK, MessageBoxIcon.None);
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
