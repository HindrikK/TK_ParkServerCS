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
    public partial class Form_DatabaseSettings : Form
    {
        public Form_DatabaseSettings()
        {
            InitializeComponent();

            textBox_Path.Text = Eleon_SCADA.Settings.Database.Path;
            textBox_SampleTime.Text = Eleon_SCADA.Settings.Database.SampleTime.ToString();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            if (textBox_Path.Text != "" && textBox_SampleTime.Text != "")
            {
                Eleon_SCADA.Settings.Database.Path = textBox_Path.Text;
                Eleon_SCADA.Settings.Database.SampleTime = Convert.ToInt32(textBox_SampleTime.Text);
                Eleon_SCADA.Settings.Database.Save();
                Dispose();
            }
            else
            {
                MessageBox.Show(this, "Missing data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create an instance of the open file dialog box.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set filter options and filter index.
            openFileDialog1.Filter = "Access database (.mdb)|*.mdb|All Files|*.*";
            openFileDialog1.FilterIndex = 1;

            // Call the ShowDialog method to show the dialog box.
            DialogResult userClickedOK = openFileDialog1.ShowDialog();

            // Process input if the user clicked OK.
            if (userClickedOK == DialogResult.OK)
            {
                textBox_Path.Text = openFileDialog1.FileName;
            }
        }
    }
}
