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
    public partial class Form_FrequencyController : Form
    {
        bool PrimRegulNorm;
        bool PrimRegulEm;
        bool PrimRegulEmAutoActivate;

        // general parameters
        int NominalPower;
        int PowerRamping;
        float NominalFrequency;
        int SetpointSendRate;

        // normal mode parameters
        float PrimReservePercentNorm;
        int PrimReservePowerNorm;
        float DroopNorm;                // statism
        float DeadbandNorm;             // tundetus

        // emergency mode parameters
        float PrimReservePercentEm;
        int PrimReservePowerEm;
        float DroopEm;                // statism
        float DeadbandEm;             // tundetus
        float MaxFreqChange;
        float MaxFreqDeviation;
        int PrimRegulEmResetDelay;


        //DEBUG
        float Frequency;
        float Windspeed;
        int ActivePower;
        int AvailablePower;
        int ActivePowerSetpoint;

        ChangeRate FrequencyRate = new ChangeRate(50);
        RateLimiter PowerSetpointRateLimiter;
        Timer ControlTimer = new Timer();
        Timer ResetTimer = new Timer();
        Timer SetpointTimer = new Timer();




        public Form_FrequencyController()
        {
            InitializeComponent();

            try
            {

                LoadParameters();
            }
            catch { MessageBox.Show("Error reading loading settings"); }

            ControlTimer.Interval = 100;
            ControlTimer.Tick += ControlTimer_Elapsed;
            ControlTimer.Start();

            ResetTimer.Tick += ResetTimer_Elapsed;
            SetpointTimer.Tick += SetpointTimer_Elapsed;

            PowerSetpointRateLimiter = new RateLimiter(2000, 100, 100, 100, 1000);
        }


        private void LoadParameters()
        {
            Eleon_SCADA.Settings.T01.Load();

            PrimRegulNorm = Eleon_SCADA.Settings.T01.PrimRegulNorm;
            PrimRegulEmAutoActivate = Eleon_SCADA.Settings.T01.PrimRegulEmAutoActivate;
            SetpointSendRate = Eleon_SCADA.Settings.T01.SetpointSendRate;
            SetpointTimer.Interval = SetpointSendRate * 1000;

            textBox_SetpointSendRate.Text = SetpointSendRate.ToString();

            // general parameters
            NominalPower = Eleon_SCADA.Settings.T01.NominalPower;
            PowerRamping = Eleon_SCADA.Settings.T01.PowerRamping;
            NominalFrequency = Eleon_SCADA.Settings.T01.NominalFrequency;

            textBox_NominalFrequency.Text = NominalFrequency.ToString();

            // normal mode parameters
            PrimReservePercentNorm = Eleon_SCADA.Settings.T01.PrimReservePercentNorm;
            PrimReservePowerNorm = (int)(NominalPower * PrimReservePercentNorm / 100);
            DroopNorm = Eleon_SCADA.Settings.T01.DroopNorm;
            DeadbandNorm = Eleon_SCADA.Settings.T01.DeadbandNorm;

            textBox_PrimReservePercentNorm.Text = PrimReservePercentNorm.ToString();
            label_PrimReservePowerNorm.Text = PrimReservePowerNorm.ToString();
            textBox_DroopNorm.Text = DroopNorm.ToString();
            textBox_DeadbandNorm.Text = DeadbandNorm.ToString();

            // emergency mode parameters
            PrimReservePercentEm = Eleon_SCADA.Settings.T01.PrimReservePercentEm;
            PrimReservePowerEm = (int)(NominalPower * PrimReservePercentEm / 100);
            DroopEm = Eleon_SCADA.Settings.T01.DroopEm;
            DeadbandEm = Eleon_SCADA.Settings.T01.DeadbandEm;
            MaxFreqChange = Eleon_SCADA.Settings.T01.MaxFreqChange;
            MaxFreqDeviation = Eleon_SCADA.Settings.T01.MaxFreqDeviation;
            PrimRegulEmResetDelay = Eleon_SCADA.Settings.T01.PrimRegulEmResetDelay;
            ResetTimer.Interval = PrimRegulEmResetDelay * 1000;

            textBox_PrimReservePercentEm.Text = PrimReservePercentEm.ToString();
            label_PrimReservePowerEm.Text = PrimReservePowerEm.ToString();
            textBox_DroopEm.Text = DroopEm.ToString();
            textBox_DeadbandEm.Text = DeadbandEm.ToString();
            textBox_MaxFreqChange.Text = MaxFreqChange.ToString();
            textBox_MaxFreqDeviation.Text = MaxFreqDeviation.ToString();
            textBox_PrimRegulEmResetDelay.Text = PrimRegulEmResetDelay.ToString();
        }


        private void SetParametersGeneral()
        {
            try
            {
                NominalFrequency = Convert.ToInt32(textBox_NominalFrequency.Text);
                SetpointSendRate = Convert.ToInt32(textBox_SetpointSendRate.Text);

                Eleon_SCADA.Settings.T01.NominalPower = NominalPower;
                Eleon_SCADA.Settings.T01.PowerRamping = PowerRamping;
                Eleon_SCADA.Settings.T01.NominalFrequency = NominalFrequency;
                Eleon_SCADA.Settings.T01.SetpointSendRate = SetpointSendRate;

                PowerSetpointRateLimiter.RateUp = PowerRamping;
                PowerSetpointRateLimiter.RateDown = PowerRamping;

                Eleon_SCADA.Settings.T01.Save();

                LoadParameters();
            }
            catch { MessageBox.Show("Invalid parameter value"); }
        }


        private void SetParametersNorm()
        {
            try
            {
                PrimReservePercentNorm = Convert.ToSingle(textBox_PrimReservePercentNorm.Text);
                PrimReservePowerNorm = (int)(NominalPower * PrimReservePercentNorm / 100);
                DroopNorm = Convert.ToSingle(textBox_DroopNorm.Text);
                DeadbandNorm = Convert.ToSingle(textBox_DeadbandNorm.Text);

                Eleon_SCADA.Settings.T01.PrimReservePercentNorm = PrimReservePercentNorm;
                Eleon_SCADA.Settings.T01.DroopNorm = DroopNorm;
                Eleon_SCADA.Settings.T01.DeadbandNorm = DeadbandNorm;

                Eleon_SCADA.Settings.T01.Save();

                LoadParameters();
            }
            catch { MessageBox.Show("Invalid parameter value"); }
        }


        private void SetParametersEm()
        {
            try
            {
                PrimReservePercentEm = Convert.ToSingle(textBox_PrimReservePercentEm.Text);
                PrimReservePowerEm = (int)(NominalPower * PrimReservePercentEm / 100);
                DroopEm = Convert.ToSingle(textBox_DroopEm.Text);
                DeadbandEm = Convert.ToSingle(textBox_DeadbandEm.Text);
                MaxFreqChange = Convert.ToSingle(textBox_MaxFreqChange.Text);
                MaxFreqDeviation = Convert.ToSingle(textBox_MaxFreqDeviation.Text);
                PrimRegulEmResetDelay = Convert.ToInt32(textBox_PrimRegulEmResetDelay.Text);

                Eleon_SCADA.Settings.T01.PrimReservePercentEm = PrimReservePercentEm;
                Eleon_SCADA.Settings.T01.DroopEm = DroopEm;
                Eleon_SCADA.Settings.T01.DeadbandEm = DeadbandEm;
                Eleon_SCADA.Settings.T01.MaxFreqChange = MaxFreqChange;
                Eleon_SCADA.Settings.T01.MaxFreqDeviation = MaxFreqDeviation;
                Eleon_SCADA.Settings.T01.PrimRegulEmResetDelay = PrimRegulEmResetDelay;

                Eleon_SCADA.Settings.T01.Save();

                LoadParameters();
            }
            catch { MessageBox.Show("Invalid parameter value"); }
        }



        // Regulator program
        private void ControlTimer_Elapsed(object sender, EventArgs e)
        {
            Update_Frequency();
            Update_AvailablePower();
            Update_WindSpeed();

            FrequencyRate.UpdateBuffer(Frequency);

            int deltaP;

            if (PrimRegulEm)
            {
                if (Frequency < NominalFrequency - DeadbandEm)
                {
                    deltaP = (int)(((NominalFrequency - Frequency - DeadbandEm) / (NominalFrequency * DroopEm / 100)) * NominalPower);
                }
                else if (Frequency > NominalFrequency + DeadbandEm)
                {
                    deltaP = (int)(((NominalFrequency - Frequency + DeadbandEm) / (NominalFrequency * DroopEm / 100)) * NominalPower);
                }
                else
                {
                    deltaP = 0;
                }

                if (AvailablePower > NominalPower) { AvailablePower = NominalPower; }
                ActivePowerSetpoint = AvailablePower - PrimReservePowerEm + deltaP;
                if (ActivePowerSetpoint < AvailablePower - (2 * PrimReservePowerEm)) ActivePowerSetpoint = AvailablePower - (2 * PrimReservePowerEm);
                else if (ActivePowerSetpoint < 0) ActivePowerSetpoint = 0;
                else if (ActivePowerSetpoint > AvailablePower) ActivePowerSetpoint = AvailablePower;
            }
            else if (PrimRegulNorm)
            {
                if (Frequency < NominalFrequency - DeadbandNorm)
                {
                    deltaP = (int)(((NominalFrequency - Frequency - DeadbandNorm) / (NominalFrequency * DroopNorm / 100)) * NominalPower);
                }
                else if (Frequency > NominalFrequency + DeadbandNorm)
                {
                    deltaP = (int)(((NominalFrequency - Frequency + DeadbandNorm) / (NominalFrequency * DroopNorm / 100)) * NominalPower);
                }
                else
                {
                    deltaP = 0;
                }

                if (AvailablePower > NominalPower) { AvailablePower = NominalPower; }
                ActivePowerSetpoint = AvailablePower - PrimReservePowerNorm + deltaP;
                if (ActivePowerSetpoint < AvailablePower - (2 * PrimReservePowerNorm)) ActivePowerSetpoint = AvailablePower - (2 * PrimReservePowerNorm);
                else if (ActivePowerSetpoint < 0) ActivePowerSetpoint = 0;
                else if (ActivePowerSetpoint > AvailablePower) ActivePowerSetpoint = AvailablePower;
            }
            else
            {
                ActivePowerSetpoint = NominalPower;
            }

            // emergency primary control auto activation
            if (PrimRegulEmAutoActivate)
            {
                // activation of emergency primary control
                if (!PrimRegulEm)
                {
                    if (Frequency < (NominalFrequency - MaxFreqDeviation) || Frequency > (NominalFrequency + MaxFreqDeviation))
                    {
                        PrimRegulEm = true;
                        checkBox_PrimRegulEm.Checked = true;
                        ResetTimer.Stop();
                        ResetTimer.Start();

                        // set power setpoint to the current active power value
                        //PowerSetpointRateLimiter.Reset(ActivePower);
                    }

                    float changerate = FrequencyRate.GetRate();
                    if (changerate < -MaxFreqChange || changerate > MaxFreqChange)
                    {
                        PrimRegulEm = true;
                        checkBox_PrimRegulEm.Checked = true;
                        ResetTimer.Stop();
                        ResetTimer.Start();

                        // set power setpoint to the current active power value
                        //PowerSetpointRateLimiter.Reset(ActivePower);
                    }
                }
                // check if still active and reset ResetTimer
                else
                {
                    if (Frequency < (NominalFrequency - MaxFreqDeviation) || Frequency > (NominalFrequency + MaxFreqDeviation))
                    {
                        ResetTimer.Stop();
                        ResetTimer.Start();
                    }

                    float changerate = FrequencyRate.GetRate();
                    if (changerate < -MaxFreqChange || changerate > MaxFreqChange)
                    {
                        ResetTimer.Stop();
                        ResetTimer.Start();
                    }
                }
            }

            // normal primary control activating and deactivating
            // when activating, set power setpoint to available power without ramping
            if (checkBox_PrimRegulNorm.Checked && !PrimRegulNorm)
            {
                PowerSetpointRateLimiter.Reset(AvailablePower);
                PrimRegulNorm = true;
            }
            else if (!checkBox_PrimRegulNorm.Checked)
            {
                PrimRegulNorm = false;
            }

            ActivePowerSetpoint = PowerSetpointRateLimiter.Update(ActivePowerSetpoint);
            RefreshScreen();
        }


        private void ResetTimer_Elapsed(object sender, EventArgs e)
        {
            ResetTimer.Stop();
            PrimRegulEm = false;
            checkBox_PrimRegulEm.Checked = false;
        }


        private void SetpointTimer_Elapsed(object sender, EventArgs e)
        {
            //SetpointTimer.Stop();

            if (Program.myPark.myTurbines[1].ActivePowerSetpoint != ActivePowerSetpoint && Program.myPark.myTurbines[1].G_Connected)     // if value changed and turbine connected
            {
                Program.myPark.myTurbines[1].Set_PowerSetpoint((short)ActivePowerSetpoint);
            }

            //SetpointTimer.Start();
        }


        private void RefreshScreen()
        {
            textBox_ActivePowerSetpoint.Text = ActivePowerSetpoint.ToString();
        }


        private void Update_Frequency()
        {
            // get frequency value from trackbar only if frequency simulation is selected
            if (checkBox_SimulateFrequency.Checked)
            {
                Frequency = (float)trackBar_Frequency.Value / 100;
            }
            else    // get frequency from real turbine
            {
                Frequency = Program.myPark.myTurbines[1].Frequency;

                if (Frequency * 100 < trackBar_Frequency.Minimum)
                {
                    trackBar_Frequency.Value = trackBar_Frequency.Minimum;
                }
                else if (Frequency * 100 > trackBar_Frequency.Maximum)
                {
                    trackBar_Frequency.Value = trackBar_Frequency.Maximum;
                }
                else
                {
                    trackBar_Frequency.Value = (int)(Frequency * 100);
                }
            }

            textBox_Frequency.Text = Frequency.ToString("F2");
        }


        private void Update_AvailablePower()
        {
            if (checkBox_SimulateAvailablePower.Checked)
            {
                AvailablePower = trackBar_AvailablePower.Value;
                if (AvailablePower > NominalPower)
                {
                    AvailablePower = NominalPower;
                    trackBar_AvailablePower.Value = AvailablePower;
                }
            }
            else
            {
                AvailablePower = Program.PowerCurve_V80.GetPower(Windspeed);
                trackBar_AvailablePower.Value = AvailablePower;
            }

            textBox_AvailablePower.Text = AvailablePower.ToString();
        }


        private void Update_WindSpeed()
        {
            if (checkBox_SimulateWindSpeed.Checked)
            {
                Windspeed = (float)trackBar_Windspeed.Value / 10;
            }
            else
            {
                Windspeed = Program.myPark.myTurbines[1].Windspeed;
                trackBar_Windspeed.Value = (int)(Windspeed * 10);
            }

            textBox_Windspeed.Text = Windspeed.ToString("F1");
        }


        private void textBox_SetpointSendRate_Leave(object sender, EventArgs e)
        {
            SetParametersGeneral();
        }

        private void textBox_PrimReservePercent_Leave(object sender, EventArgs e)
        {
            button_ApplyNorm.Enabled = true;
        }

        private void textBox_Droop_Leave(object sender, EventArgs e)
        {
            button_ApplyNorm.Enabled = true;
        }

        private void textBox_Deadband_Leave(object sender, EventArgs e)
        {
            button_ApplyNorm.Enabled = true;
        }

        //private void checkBox_PrimRegulNorm_CheckedChanged(object sender, EventArgs e)
        //{
        //    PrimRegulNorm = checkBox_PrimRegulNorm.Checked;
        //}

        private void checkBox_PrimRegulEm_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox_AutoActivateEm_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox_NominalFrequency_Leave(object sender, EventArgs e)
        {

        }

        private void textBox_PrimReservePercentNorm_Leave(object sender, EventArgs e)
        {

        }

        private void textBox_DroopNorm_Leave(object sender, EventArgs e)
        {

        }

        private void textBox_DeadbandNorm_Leave(object sender, EventArgs e)
        {

        }

        private void textBox_PrimReservePercentEm_Leave(object sender, EventArgs e)
        {

        }

        private void textBox_DroopEm_Leave(object sender, EventArgs e)
        {

        }

        private void textBox_DeadbandEm_Leave(object sender, EventArgs e)
        {

        }

        private void textBox_MaxFreqChange_Leave(object sender, EventArgs e)
        {

        }

        private void textBox_MaxFreqDeviation_Leave(object sender, EventArgs e)
        {

        }

        private void textBox_PrimRegulEmResetDelay_Leave(object sender, EventArgs e)
        {

        }

        private void button_PowerCurve_Click(object sender, EventArgs e)
        {

        }

        private void button_ApplyNorm_Click(object sender, EventArgs e)
        {

        }

        private void button_ApplyEm_Click(object sender, EventArgs e)
        {

        }

        private void checkBox_EnableFrequencyControl_CheckedChanged(object sender, EventArgs e)
        {

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
