using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Eleon_SCADA.Forms
{
    public partial class Dialog_License : Form
    {
        public Dialog_License()
        {
            InitializeComponent();

            try
            {
                label_HardwareID.Text = Eleon_SCADA.Licensing.GetHardwareID();

                // if valid license exists
                if (Eleon_SCADA.Licensing.CheckLicense())
                {
                    label_Owner.Text = Eleon_SCADA.Licensing.LicenseOwner;
                    label_LicenseNumber.Text = Eleon_SCADA.Licensing.LicenseNumber;
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
