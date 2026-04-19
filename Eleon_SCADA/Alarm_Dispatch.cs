using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Eleon_SCADA
{
    class Alarm_Dispatch
    {
        const int OUTBOX_SIZE = 50;
        const int SENT_BOX_SIZE = 50;

        public System.Threading.Thread myCheckStatusThread;
        Park.WindPark _Park;
        int[] Error_Code_prev;
        int[] State_prev;
        public List<System.Net.Mail.MailMessage> Outbox = new List<System.Net.Mail.MailMessage>();      // stores all outgoing messages
        //public List<System.Net.Mail.MailMessage> UnSent = new List<System.Net.Mail.MailMessage>();    // stores all unsent messages
        public List<System.Net.Mail.MailMessage> Sent = new List<System.Net.Mail.MailMessage>();        // stores all sent messages
        System.Timers.Timer TriggerDelay_Timer;
        bool TriggerDelayTimer_Flag;
        public bool IsActive;     // indicates if alarm dispatch is active



        public Alarm_Dispatch(Park.WindPark _park)
        {
            _Park = _park;
            Error_Code_prev = new int[_Park.NumOfTurbinesInPark + 1];
            State_prev = new int[_Park.NumOfTurbinesInPark + 1];
            for (int i = 1; i <= _Park.NumOfTurbinesInPark; i++)
            {
                Error_Code_prev[i] = _Park.myTurbines[i].Error_Code;
                State_prev[i] = _Park.myTurbines[i].State;
            }

            TriggerDelay_Timer = new System.Timers.Timer();
            TriggerDelay_Timer.AutoReset = false;
            TriggerDelay_Timer.Elapsed += TriggerDelay_Timer_Elapsed;

            // start new thread for alarm dispatch
            myCheckStatusThread = new System.Threading.Thread(Main_Loop);
            myCheckStatusThread.IsBackground = true;
            myCheckStatusThread.Start();
        }

        private void TriggerDelay_Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            TriggerDelayTimer_Flag = true;
        }

        public void Start()
        {
            IsActive = true;
        }

        public void Stop()
        {
            TriggerDelay_Timer.Stop();
            IsActive = false;
        }


        private void Main_Loop()
        {
            while (true)
            {
                if (IsActive)
                {
                    try
                    {
                        for (int i = 1; i <= _Park.NumOfTurbinesInPark; i++)
                        {
                            if (_Park.myTurbines[i].Error_Code != Error_Code_prev[i])     // new alarm detected
                            {
                                TriggerDelay_Timer.Interval = Eleon_SCADA.Settings.AlarmAnnouncement.TriggerDelay * 1000;   // update timer interval value
                                //TriggerDelay_Timer.Start();     // restart timer
                                TriggerDelay_Timer.Enabled = true;     // start timer
                            }
                            else if (_Park.myTurbines[i].State != State_prev[i] && _Park.myTurbines[i].State == 3)    // check for "Countdown for autostart" state
                            {
                                TriggerDelay_Timer.Interval = Eleon_SCADA.Settings.AlarmAnnouncement.TriggerDelay * 1000;   // update timer interval value
                                //TriggerDelay_Timer.Start();     // restart timer
                                TriggerDelay_Timer.Enabled = true;     // start timer
                            }

                            if (TriggerDelayTimer_Flag)     // same alarm has been active long enough to trigger alarm message
                            {
                                TriggerDelayTimer_Flag = false;
                                if (!Eleon_SCADA.Settings.AlarmAnnouncement.ExcludedStatus.Exists(x => x == _Park.myTurbines[i].Error_Code))
                                {
                                    try
                                    {
                                        string message = "Turbine " + i + " : " + _Park.myTurbines[i].Error_Code + " - " + 
                                            Program.myPark.myTurbines[i].Error_Txt;
                                        SendToAll(message);
                                    }
                                    catch { }
                                }
                                else if (_Park.myTurbines[i].State == 3)
                                {
                                    try
                                    {
                                        string message = "Turbine " + i + " : Countdown for autostart - ";
                                        SendToAll(message);
                                    }
                                    catch { }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message + "\n( Alarm_Dispatch - Main_Loop )", "Exception", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    }
                }
                else
                {
                    TriggerDelay_Timer.Enabled = false;     // stop timer
                }

                for (int i = 1; i <= _Park.NumOfTurbinesInPark; i++)
                {
                    Error_Code_prev[i] = _Park.myTurbines[i].Error_Code;
                    State_prev[i] = _Park.myTurbines[i].State;
                }

                Thread.Sleep(1000);     // check for alarms only every 1s
            }
        }




        // Send message to all active recipients
        public void SendToAll(string Message)
        {
            lock (this)
            {
                if (!IsActive) return;
                
                if (Eleon_SCADA.Settings.AlarmAnnouncement.Recipients.Count() > 0)
                {
                    for (int i = 0; i < Eleon_SCADA.Settings.AlarmAnnouncement.Recipients.Count(); i++)
                    {
                        if (Eleon_SCADA.Settings.AlarmAnnouncement.Recipients[i].Active)
                        {
                            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
                            message.To.Add(Eleon_SCADA.Settings.AlarmAnnouncement.Recipients[i].Address);
                            message.Subject = Eleon_SCADA.Settings.AlarmAnnouncement.Subject;
                            message.From = new System.Net.Mail.MailAddress(Eleon_SCADA.Settings.AlarmAnnouncement.FromAddress);
                            message.Body = Message;

                            AddToOutbox(message);

                            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient(Eleon_SCADA.Settings.AlarmAnnouncement.Server, Eleon_SCADA.Settings.AlarmAnnouncement.Port);
                            smtp.Timeout = Eleon_SCADA.Settings.AlarmAnnouncement.Timeout;

                            try
                            {
                                smtp.Send(message);
                                AddToSent(message);
                                Outbox.Remove(message);
                            }
                            catch
                            {
                            }
                        }
                    }

                    if (Outbox.Count() > 0) throw new Exception("Problems occured while sending messages");
                }
                else throw new Exception("Recipients list is empty");
            }
        }
        /*
        public void SendAlarm(int _ID, int _Status)
        {
           if (!IsActive) return;
          
           if (Park_Server.Settings.AlarmDispatch.Recipients.Count() > 0)
            {
                for (int i = 0; i < Park_Server.Settings.AlarmDispatch.Recipients.Count(); i++)
                {
                    if (Park_Server.Settings.AlarmDispatch.Recipients[i].Active)
                    {
                        System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
                        message.To.Add(Park_Server.Settings.AlarmDispatch.Recipients[i].Address);
                        message.Subject = Park_Server.Settings.AlarmDispatch.Subject;
                        message.From = new System.Net.Mail.MailAddress(Park_Server.Settings.AlarmDispatch.FromAddress);
                        message.Body = "Turbine " + _ID + " status: " + (_Status >> 8) + ":" + (_Status & 0xFF);

                        AddToOutbox(message);

                        System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient(Park_Server.Settings.AlarmDispatch.Server, Park_Server.Settings.AlarmDispatch.Port);
                        smtp.Timeout = Park_Server.Settings.AlarmDispatch.Timeout;

                        try
                        {
                            smtp.Send(message);
                            AddToSent(message);
                            Outbox.Remove(message);
                        }
                        catch
                        {
                        }
                    }
                }

                if (Outbox.Count() > 0) throw new Exception("Problems occured while sending messages");
            }
            else throw new Exception("Recipients list is empty");
        }*/

        public void ResendOutbox()
        {
            if (!IsActive) return;
            
            int noOfMessages = Outbox.Count();
            for (int i = 0; i < noOfMessages; i++)
            {
                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient(Eleon_SCADA.Settings.AlarmAnnouncement.Server, Eleon_SCADA.Settings.AlarmAnnouncement.Port);
                smtp.Timeout = Eleon_SCADA.Settings.AlarmAnnouncement.Timeout;

                try
                {
                    smtp.Send(Outbox[i]);
                    AddToSent(Outbox[i]);
                    Outbox.Remove(Outbox[i]);
                }
                catch
                {
                }
            }

            if (Outbox.Count() > 0) throw new Exception("Problems occured while sending messages");
        }

        public void ClearOutbox()
        {
            Outbox.Clear();
        }

        public void ClearSent()
        {
            Sent.Clear();
        }

        public void SendTestAlarm(string _address)
        {
            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
            message.To.Add(_address);
            message.Subject = "Test Message";
            message.From = new System.Net.Mail.MailAddress(Eleon_SCADA.Settings.AlarmAnnouncement.FromAddress);
            message.Body = "Test message from park server";
            AddToOutbox(message);
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient(Eleon_SCADA.Settings.AlarmAnnouncement.Server, Eleon_SCADA.Settings.AlarmAnnouncement.Port);
            smtp.Timeout = Eleon_SCADA.Settings.AlarmAnnouncement.Timeout;
            try
            {
                smtp.Send(message);
                AddToSent(message);
                Outbox.Remove(message);
            }
            catch (Exception ex) { throw ex; }
        }

        public void SendAnnouncement(string _text)
        {
            if (!IsActive) return;
            
            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
            message.To.Add(Eleon_SCADA.Settings.AlarmAnnouncement.DefaultAddress);
            message.Subject = "Park Announcement";
            message.From = new System.Net.Mail.MailAddress(Eleon_SCADA.Settings.AlarmAnnouncement.FromAddress);
            message.Body = _text;
            AddToOutbox(message);
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient(Eleon_SCADA.Settings.AlarmAnnouncement.Server, Eleon_SCADA.Settings.AlarmAnnouncement.Port);
            smtp.Timeout = Eleon_SCADA.Settings.AlarmAnnouncement.Timeout;
            try
            {
                smtp.Send(message);
                AddToSent(message);
                Outbox.Remove(message);
            }
            catch (Exception ex) { throw ex; }
        }

        public void SendAnnouncement(string _address, string _text)
        {
            if (!IsActive) return;
            
            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
            message.To.Add(_address);
            message.Subject = "Park Announcement";
            message.From = new System.Net.Mail.MailAddress(Eleon_SCADA.Settings.AlarmAnnouncement.FromAddress);
            message.Body = _text;
            AddToOutbox(message);
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient(Eleon_SCADA.Settings.AlarmAnnouncement.Server, Eleon_SCADA.Settings.AlarmAnnouncement.Port);
            smtp.Timeout = Eleon_SCADA.Settings.AlarmAnnouncement.Timeout;
            try
            {
                smtp.Send(message);
                AddToSent(message);
                Outbox.Remove(message);
            }
            catch (Exception ex) { throw ex; }
        }



        private void AddToOutbox(System.Net.Mail.MailMessage message)
        {
            // If box becomes full, just clear it
            if (Outbox.Count() > OUTBOX_SIZE)
            {
                Outbox.Clear();
            }
            Outbox.Add(message);
        }


        private void AddToSent(System.Net.Mail.MailMessage message)
        {
            // If box becomes full, just clear the last one
            if (Sent.Count() > SENT_BOX_SIZE)
            {
                Sent.Clear();
            }
            Sent.Add(message);
        }



        [Serializable]
        public class MailRecipient
        {
            public string Name;         // name for the user
            public string Address;      // mail address
            public bool Active;         // shows if this recipient is active

            public MailRecipient(string _name, string _address)
            {
                Name = _name;
                Address = _address;
                Active = true;
            }

            public bool Equals(MailRecipient other)
            {
                if (other == null) return false;
                return (this.Name.Equals(other.Name));
            }
        }
    }
}