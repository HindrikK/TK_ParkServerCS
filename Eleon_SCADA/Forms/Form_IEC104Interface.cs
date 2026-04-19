using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eleon_SCADA.Forms
{
    public partial class Form_IEC104Interface : Form
    {
        public Form_IEC104Interface()
        {
            InitializeComponent();

            if (Users.User_Level > Users.UserLevel.USER_LEVEL_SERVICE)
            {
                button_ServiceFunctions.Visible = false;
            }
            else
            {
                button_ServiceFunctions.Visible = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RefreshClientsList();
            RefreshLinked_Data();


            // USER LEVEL ADJUSTMENTS
            if (Users.User_Level >= Users.UserLevel.USER_LEVEL_SERVICE && !button_ServiceFunctions.Visible)
            {
                button_ServiceFunctions.Visible = true;
            }
            else if (Users.User_Level < Users.UserLevel.USER_LEVEL_SERVICE && button_ServiceFunctions.Visible)
            {
                button_ServiceFunctions.Visible = false;
            }
        }

        private void RefreshClientsList()
        {
            listBox_Clients.Items.Clear();

            for (int i = 0; i < Program.myIEC104Server.Channels.Count(); i++)
            {
                if (Program.myIEC104Server.Channels[i] != null)
                {
                    string client = (i + 1) + " - " + Program.myIEC104Server.Channels[i].channelSrcAdr;
                    listBox_Clients.Items.Add(client);
                }
            }
            label_Clients.Text = "Clients:  " + Program.myIEC104Server.NoOfClients + "/" + Program.myIEC104Server.MaxNoOfClients;
        }

        private void RefreshLinked_Data()
        {
            label_ParkOperation.Text = Program.myIEC104_Interface.ParkStartStop_Ctrl.ToString();
            label_EmLimit80.Text = Program.myIEC104_Interface.EmLimit80_Ctrl.ToString();
            label_EmLimit60.Text = Program.myIEC104_Interface.EmLimit60_Ctrl.ToString();
            label_EmLimit40.Text = Program.myIEC104_Interface.EmLimit40_Ctrl.ToString();
            label_EmLimit20.Text = Program.myIEC104_Interface.EmLimit20_Ctrl.ToString();
            label_SecRegul.Text = Program.myIEC104_Interface.SecondaryRegulation_Ctrl.ToString();
            label_PowerSetpoint.Text = Program.myIEC104_Interface.ActivePowerSetpoint_Ctrl.ToString();


            checkBox_ParkOperation_Mon.Checked = Program.myIEC104_Interface.ParkOperation_Mon;
            checkBox_ParkMVBreaker_Mon.Checked = Program.myIEC104_Interface.ParkMVBreaker_Mon;
            checkBox_SecondaryRegulation_Mon.Checked = Program.myIEC104_Interface.SecondaryRegulation_Mon;
            checkBox_EmLimit80_Mon.Checked = Program.myIEC104_Interface.EmLimit80_Mon;
            checkBox_EmLimit60_Mon.Checked = Program.myIEC104_Interface.EmLimit60_Mon;
            checkBox_EmLimit40_Mon.Checked = Program.myIEC104_Interface.EmLimit40_Mon;
            checkBox_EmLimit20_Mon.Checked = Program.myIEC104_Interface.EmLimit20_Mon;
            label_Windspeed_Mon.Text = Program.myIEC104_Interface.WindSpeed_Mon.ToString();
            label_Voltage_Mon.Text = Program.myIEC104_Interface.Voltage_Mon.ToString();
            label_ActivePower_Mon.Text = Program.myIEC104_Interface.ActivePower_Mon.ToString();
            label_ReactivePower_Mon.Text = Program.myIEC104_Interface.ReactivePower_Mon.ToString();
            label_Current_Mon.Text = Program.myIEC104_Interface.Current_Mon.ToString();
            label_PowerSetpoint_Mon.Text = Program.myIEC104_Interface.ActivePowerSetpoint_Mon.ToString();
        }

        private void button_ServiceFunctions_Click(object sender, EventArgs e)
        {
            Form_IEC104Interface_Test myForm = new Form_IEC104Interface_Test();
            myForm.Show(this);
        }
    }
}
