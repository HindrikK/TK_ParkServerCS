using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TK_ParkServer.Forms
{
    public partial class Dialog_License : Form
    {
        public Dialog_License()
        {
            InitializeComponent();

            try
            {
                label_HardwareID.Text = TK_ParkServer.Licensing.GetHardwareID();

                // if valid license exists
                if (TK_ParkServer.Licensing.CheckLicense())
                {
                    label_Owner.Text = TK_ParkServer.Licensing.LicenseOwner;
                    label_LicenseNumber.Text = TK_ParkServer.Licensing.LicenseNumber;
                    groupBox_LicenseInfo.Visible = true;
                }
                else
                {
                    groupBox_LicenseInfo.Visible = false;
                }
            }
            catch(Exception ex)
            {
                groupBox_LicenseInfo.Visible = false;
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
