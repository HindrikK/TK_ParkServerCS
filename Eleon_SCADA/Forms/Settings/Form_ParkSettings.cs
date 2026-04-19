using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Net;


namespace Eleon_SCADA.Forms
{
    public partial class Form_ParkSettings : Form
    {
        public Form_ParkSettings()
        {
            InitializeComponent();

            textBox_LocalPowerSetpoint.Text = Program.myPark.Local_ActivePowerSetpoint.ToString();
            textBox_ParkMaxPower.Text = Program.myPark.ActivePowerMax.ToString();
            comboBox_PowerControlMode.SelectedIndex = Program.myPark.ActivePowerSetpoint_Mode;
            textBox_RemoteSetpoint.Text = Program.myPark.Remote_ActivePowerSetpoint.ToString();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            ushort LocalActivePowerSetpoint;
            ushort RemoteActivePowerSetpoint;
            ushort ActivePowerMax;
            int SetPoint_Mode;

            try
            {
                LocalActivePowerSetpoint = Convert.ToUInt16(textBox_LocalPowerSetpoint.Text);
                RemoteActivePowerSetpoint = Convert.ToUInt16(textBox_RemoteSetpoint.Text);
                ActivePowerMax = Convert.ToUInt16(textBox_ParkMaxPower.Text);
                SetPoint_Mode = comboBox_PowerControlMode.SelectedIndex;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Invalid input value", "Error");
                return;
            }

            try
            {
                Program.myPark.Local_ActivePowerSetpoint = Convert.ToUInt16(textBox_LocalPowerSetpoint.Text);
                Program.myPark.Remote_ActivePowerSetpoint = Convert.ToUInt16(textBox_RemoteSetpoint.Text);
                Program.myPark.ActivePowerMax = Convert.ToUInt16(textBox_ParkMaxPower.Text);
                Program.myPark.ActivePowerSetpoint_Mode = comboBox_PowerControlMode.SelectedIndex;

                
                if (LocalActivePowerSetpoint > Program.myPark.ActivePowerMax) { Program.myPark.Local_ActivePowerSetpoint = ActivePowerMax; }
                else { Program.myPark.Local_ActivePowerSetpoint = LocalActivePowerSetpoint; }
                Program.myPark.ActivePowerSetpoint_Mode = SetPoint_Mode;
            }
            catch (Exception ex)
            {
                DialogResult answer = MessageBox.Show("Not able to set some values\n Do you want to save the settings anyway?\n\nDetails:\n" +
                    ex.Message, "Problem", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (answer != DialogResult.Yes) { return; }
            }


            try
            {
                Eleon_SCADA.Settings.Park.Local_ActivePowerSetpoint = LocalActivePowerSetpoint;
                Eleon_SCADA.Settings.Park.Remote_ActivePowerSetpoint = RemoteActivePowerSetpoint;
                Eleon_SCADA.Settings.Park.ParkMaxPower = ActivePowerMax;
                Eleon_SCADA.Settings.Park.ActivePowerSetpoint_Mode = SetPoint_Mode;
                Eleon_SCADA.Settings.Park.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving the settings\n\nDetails:\n" + ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }


            /*
            if (SetPoint_Mode == 1)
            {
                try
                {
                    Program.myPark.myTurbines[1].Set_PowerSetpoint(ActivePowerSetpoint);
                    MessageBox.Show("Power setpoint successfully sent", "Success");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Power setpoint command failed - " + ex.Message, "Error");
                }
            }
            */

            this.Dispose();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
