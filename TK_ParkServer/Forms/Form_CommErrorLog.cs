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
    public partial class Form_CommErrorLog : Form
    {
        bool refreshErrors = true;

        public Form_CommErrorLog()
        {
            InitializeComponent();
        }

        private void button_Pause_Click(object sender, EventArgs e)
        {
            if (refreshErrors)
            {
                refreshErrors = false;
                button_Pause.Text = "Start";
            }
            else
            {
                refreshErrors = true;
                button_Pause.Text = "Pause";
            }
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            Program.myVestasController.ErrorLog.Clear();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (refreshErrors)
            {
                // refresh listbox
                listBox_Errors.Items.Clear();

                for (int i = 0; i < Program.myVestasController.ErrorLog.Count(); i++)
                {
                    if (Program.myVestasController.ErrorLog[i] != null)
                    {
                        listBox_Errors.Items.Add(Program.myVestasController.ErrorLog[i]);
                    }
                }
            }
        }

        private void button_Terminal_Click(object sender, EventArgs e)
        {
            Form_CommTerminal form_CommTerminal = new Form_CommTerminal();
            form_CommTerminal.Show();
        }
    }
}
