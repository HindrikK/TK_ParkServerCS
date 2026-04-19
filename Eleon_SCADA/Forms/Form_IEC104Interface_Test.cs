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
    public partial class Form_IEC104Interface_Test : Form
    {
        public Form_IEC104Interface_Test()
        {
            InitializeComponent();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Program.myIEC104_Interface.Simulation_Mode) RefreshSimulation_Data();
        }


        private void RefreshSimulation_Data()
        {
            try
            {
                label_ParkOperation_Sim.Text = Program.myIEC104_Interface.ParkStartStop_Ctrl_Sim.ToString();
                label_EmLimit80_Sim.Text = Program.myIEC104_Interface.EmLimit80_Ctrl_Sim.ToString();
                label_EmLimit60_Sim.Text = Program.myIEC104_Interface.EmLimit60_Ctrl_Sim.ToString();
                label_EmLimit40_Sim.Text = Program.myIEC104_Interface.EmLimit40_Ctrl_Sim.ToString();
                label_EmLimit20_Sim.Text = Program.myIEC104_Interface.EmLimit20_Ctrl_Sim.ToString();
                label_SecRegul_Sim.Text = Program.myIEC104_Interface.SecondaryRegulation_Sim.ToString();
                label_PowerSetpoint_Sim.Text = Program.myIEC104_Interface.ActivePowerSetpoint_Ctrl_Sim.ToString();

                // TEST
                label_IOA4000.Text = Program.myIEC104Server.myIECDatabase.C_DC_NA_data.Get(4000).ToString();
                label_IOA4001.Text = Program.myIEC104Server.myIECDatabase.C_DC_NA_data.Get(4001).ToString();
                label_IOA4002.Text = Program.myIEC104Server.myIECDatabase.C_DC_NA_data.Get(4002).ToString();
                Program.myIEC104Server.myIECDatabase.M_DP_NA_data.Set(3000, Convert.ToByte(label_IOA3000.Text));
                Program.myIEC104Server.myIECDatabase.M_DP_NA_data.Set(3001, Convert.ToByte(label_IOA3001.Text));
                Program.myIEC104Server.myIECDatabase.M_DP_NA_data.Set(3002, Convert.ToByte(label_IOA3002.Text));

                Program.myIEC104_Interface.ParkOperation_Mon_Sim = checkBox_ParkOperation_Mon_Sim.Checked;
                Program.myIEC104_Interface.ParkMVBreaker_Mon_Sim = checkBox_parkMVBreaker_Mon_Sim.Checked;
                Program.myIEC104_Interface.SecondaryRegulation_Mon_Sim = checkBox_secondaryRegulation_Mon_Sim.Checked;
                Program.myIEC104_Interface.EmLimit80_Mon_Sim = checkBox_EmLimit80_Mon_Sim.Checked;
                Program.myIEC104_Interface.EmLimit60_Mon_Sim = checkBox_EmLimit60_Mon_Sim.Checked;
                Program.myIEC104_Interface.EmLimit40_Mon_Sim = checkBox_EmLimit40_Mon_Sim.Checked;
                Program.myIEC104_Interface.EmLimit20_Mon_Sim = checkBox_EmLimit20_Mon_Sim.Checked;
                Program.myIEC104_Interface.WindSpeed_Mon_Sim = Convert.ToSingle(textBox_Windspeed_Mon_Sim.Text);
                Program.myIEC104_Interface.Voltage_Mon_Sim = Convert.ToSingle(textBox_Voltage_Mon_Sim.Text);
                Program.myIEC104_Interface.ActivePower_Mon_Sim = Convert.ToSingle(textBox_ActivePower_Mon_Sim.Text);
                Program.myIEC104_Interface.ReactivePower_Mon_Sim = Convert.ToSingle(textBox_ReactivePower_Mon_Sim.Text);
                Program.myIEC104_Interface.Current_Mon_Sim = Convert.ToSingle(textBox_Current_Mon_Sim.Text);
                Program.myIEC104_Interface.ActivePowerSetpoint_Mon_Sim = Convert.ToInt32(textBox_PowerSetpoint_Mon_Sim.Text);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error - RefreshSimulation_Data");
            }
        }

        private void checkBox_SimMode_CheckedChanged(object sender, EventArgs e)
        {
            Program.myIEC104_Interface.Simulation_Mode = checkBox_SimMode.Checked;
        }

        private void button_Logs_Click(object sender, EventArgs e)
        {
            ushort selectedChannel = Convert.ToUInt16(textBox_Channel.Text);
            Form_IEC104_Logs form_IEC104_Logs = new Form_IEC104_Logs(selectedChannel - 1);
            form_IEC104_Logs.Show(this);
        }
    }
}
