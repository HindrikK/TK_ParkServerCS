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
    public partial class Form_CommTerminal : Form
    {
        //CONSTRUCTOR
        public Form_CommTerminal()
        {
            InitializeComponent();
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            if (Program.myVestasController.TerminalLogging)
            {
                // refresh listbox
                listBox_Received.Items.Clear();
                listBox_Sent.Items.Clear();

                try
                {
                    for (int i = 0; i < Program.myVestasController.TerminalSentLog.Count(); i++)
                    {
                        if (Program.myVestasController.TerminalSentLog[i] != null)
                        {
                            listBox_Sent.Items.Add(Program.myVestasController.TerminalSentLog[i]);
                        }
                    }
                    for (int i = 0; i < Program.myVestasController.TerminalReceivedLog.Count(); i++)
                    {
                        if (Program.myVestasController.TerminalReceivedLog[i] != null)
                        {
                            listBox_Received.Items.Add(Program.myVestasController.TerminalReceivedLog[i]);
                        }
                    }
                }
                catch { }
            }
        }

        private void button_Pause_Click(object sender, EventArgs e)
        {
            if (Program.myVestasController.TerminalLogging)
            {
                timer1.Enabled = false;
                Program.myVestasController.TerminalLogging = false;
                button_Pause.Text = "Start";
            }
            else
            {
                timer1.Enabled = true;
                Program.myVestasController.TerminalLogging = true;
                button_Pause.Text = "Pause";
            }
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            Program.myVestasController.TerminalReceivedLog.Clear();
            Program.myVestasController.TerminalSentLog.Clear();
            Refresh();
        }

        private void Form_CommTerminal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.myVestasController.TerminalLogging = false;
        }
    }
}
