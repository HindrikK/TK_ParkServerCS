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
    public partial class Form_IEC104_Logs : Form
    {
        bool updateLog = true;
        int Channel_ID;

        public Form_IEC104_Logs(int channel_ID)
        {
            InitializeComponent();

            Channel_ID = channel_ID;

            this.Text += " - channel: " + (channel_ID + 1).ToString();
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            if (updateLog)
            {
                // refresh listbox
                listBox_Received.Items.Clear();
                listBox_Sent.Items.Clear();

                try
                {
                    for (int i = 0; i < Program.myIEC104Server.Channels[Channel_ID].IEC104_Received_Data.Count(); i++)
                    {
                        if (Program.myIEC104Server.Channels[Channel_ID].IEC104_Received_Data[i] != null)
                        {
                            listBox_Received.Items.Add(Program.myIEC104Server.Channels[Channel_ID].IEC104_Received_Data[i]);
                        }
                    }
                    for (int i = 0; i < Program.myIEC104Server.Channels[Channel_ID].IEC104_Sent_Data.Count(); i++)
                    {
                        if (Program.myIEC104Server.Channels[Channel_ID].IEC104_Sent_Data[i] != null)
                        {
                            listBox_Sent.Items.Add(Program.myIEC104Server.Channels[Channel_ID].IEC104_Sent_Data[i]);
                        }
                    }
                }
                catch { }
            }
        }

        private void button_Pause_Click(object sender, EventArgs e)
        {
            if (updateLog)
            {
                updateLog = false;
                button_Pause.Text = "Start";
            }
            else
            {
                updateLog = true;
                button_Pause.Text = "Pause";
            }
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            Program.myIEC104Server.Channels[Channel_ID].IEC104_Received_Data.Clear();
            Program.myIEC104Server.Channels[Channel_ID].IEC104_Sent_Data.Clear();
        }
    }
}
