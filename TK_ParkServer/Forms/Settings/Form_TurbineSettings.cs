using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TK_ParkServer.Forms.Settings
{
    public partial class Form_TurbineSettings : Form
    {
        bool PrimRegulNorm;
        bool PrimRegulEm;
        bool PrimRegulEmAutoActivate;

        // general parameters
        int NominalPower;
        int PowerRamping;
        //float NominalFrequency;



        public Form_TurbineSettings()
        {
            InitializeComponent();

            try
            {

                LoadParameters();
            }
            catch { MessageBox.Show("Error reading loading settings"); }


            // USER LEVEL ADJUSTMENTS
            if (Users.User_Level >= Users.UserLevel.USER_LEVEL_DEVELOPER)
            {
                button_AutoReset.Visible = true;
                button_FrequencyControl.Visible = true;
            }
            else if (Users.User_Level >= Users.UserLevel.USER_LEVEL_ADMIN)
            {
                button_AutoReset.Visible = true;
                button_FrequencyControl.Visible = false;
            }
            else
            {
                button_AutoReset.Visible = false;
                button_FrequencyControl.Visible = false;
            }
        }


        private void LoadParameters()
        {
            TK_ParkServer.Settings.T01.Load();

            // general parameters
            NominalPower = TK_ParkServer.Settings.T01.NominalPower;
            PowerRamping = TK_ParkServer.Settings.T01.PowerRamping;

            textBox_NominalPower.Text = NominalPower.ToString();
            textBox_ActivePowerRamping.Text = PowerRamping.ToString();
        }


        private void SetParametersGeneral()
        {
            try
            {
                NominalPower = Convert.ToInt32(textBox_NominalPower.Text);
                PowerRamping = Convert.ToInt32(textBox_ActivePowerRamping.Text);

                TK_ParkServer.Settings.T01.NominalPower = NominalPower;
                TK_ParkServer.Settings.T01.PowerRamping = PowerRamping;

                TK_ParkServer.Settings.T01.Save();

                LoadParameters();
            }
            catch { MessageBox.Show("Invalid parameter value"); }
        }


        private void textBox_NominalPower_Leave(object sender, EventArgs e)
        {
            button_ApplyGeneral.Enabled = true;
        }

        private void textBox_ActivePowerRamping_Leave(object sender, EventArgs e)
        {
            button_ApplyGeneral.Enabled = true;
        }

        private void textBox_ReactivePowerRamping_Leave(object sender, EventArgs e)
        {
            // not used at the moment
        }

        private void button_ApplyGeneral_Click(object sender, EventArgs e)
        {
            button_ApplyGeneral.Enabled = false;

            SetParametersGeneral();
        }

        private void button_AutoReset_Click(object sender, EventArgs e)
        {
            Form_AutoResetErrors myForm = new Form_AutoResetErrors();
            myForm.ShowDialog(this);
        }

        private void button_FrequencyControl_Click(object sender, EventArgs e)
        {
            Form_FrequencyController myForm = new Form_FrequencyController();
            myForm.Show();
        }
    }


    public class ChangeRate
    {
        float[] buffer = new float[10];

        public ChangeRate(float value)
        {
            for (int i = 0; i < 10; i++)
            {
                buffer[i] = value;
            }
        }

        public void UpdateBuffer(float value)
        {
            //shift buffer
            for (int i = 9; i > 0; i--)
            {
                buffer[i] = buffer[i - 1];
            }
            buffer[0] = value;
        }

        public float GetRate()
        {
            //double sum = 0;
            //for (int i = 0; i < 10; i++)
            //{
            //    sum += buffer[i];
            //}
            //return (float)(sum / 10);
            return buffer[9] - buffer[0];
        }
    }


    public class RateLimiter
    {
        //Inputs
        uint TimeDelta = 100;	// Fixed time step/delay - used when "TimeMode" = FALSE.
        public int RateUp;	    // Maximum rate of increasing signal per defined time base.
        public int RateDown;	// Maximum rate of decreasing signal per defined time base.
        uint TimeBase = 1000;	// Base time for "RateUp" and "RateDown" rate values.
        int Output;			    // Current output value (scaled x100)
        int max_newOut;


        public RateLimiter(int value, int rateup, int ratedown, uint time_delta, uint timebase)
        {
            RateUp = rateup;
            RateDown = ratedown;
            TimeDelta = time_delta;
            TimeBase = timebase;
            Reset(value);
        }

        public void Reset(int value)
        {
            Output = value * 100;
        }

        public int Update(int Input)
        {
            int _Input = Input * 100;

            if (_Input > Output)
            {
                max_newOut = Output + (int)((Int64)RateUp * 100 * TimeDelta / (Int64)TimeBase);
                if (_Input > max_newOut)
                {
                    Output = max_newOut;
                }
                else
                {
                    Output = _Input;
                }
            }
            else if (_Input < Output)
            {
                max_newOut = Output - (int)((Int64)RateDown * 100 * TimeDelta / (Int64)TimeBase);
                if (_Input < max_newOut)
                {
                    Output = max_newOut;
                }
                else
                {
                    Output = _Input;
                }
            }

            return Output / 100;
        }
    }

}