using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TK_ParkServer.Forms.Settings
{
    public partial class Dialog_AddAutoResetCode : Form
    {
        public Dialog_AddAutoResetCode()
        {
            InitializeComponent();
        }


        private void button_Add_Click(object sender, EventArgs e)
        {
            if (textBox_Status.Text != "")
            {
                try
                {
                    TK_ParkServer.Settings.T01.AddAutoResetError(textBox_Status.Text);
                    MessageBox.Show(this, "Error code \"" + textBox_Status.Text + "\" added", "Added", MessageBoxButtons.OK, MessageBoxIcon.None);
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
