using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eleon_SCADA.Settings
{
    static class Settings
    {
        public static System.Xml.Linq.XDocument SettingsFile;
        public static string FilePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Eleon_SCADA\\Settings.xml");

        // Load settings file
        public static void Load()
        {
            try
            {
                //Settings.FilePath = "Settings.xml";
                SettingsFile = System.Xml.Linq.XDocument.Load(FilePath);

                AlarmAnnouncement.Load();
                Application.Load();
                Database.Load();
                VestasDriver.Load();
                IEC104Server.Load();
                Park.Load();
                T01.Load();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to load settings.\n\n" + ex.Message);
            }
        }

        // Save all settings to file
        public static void Save()
        {
            try
            {
                AlarmAnnouncement.Save();
                Application.Save();
                Database.Save();
                VestasDriver.Save();
                IEC104Server.Save();
                Park.Save();
                T01.Save();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to save settings.\n\n" + ex.Message);
            }
        }

        public static void Reset()
        {
            /*
            AlarmDispatch.Reset();
            Database.Reset();
            EnerconMaster.Reset();
            Park.Reset();
            */
        }
    }



    static class AlarmAnnouncement
    {
        public static int TriggerDelay = 60;
        public static string DefaultName = "Hindrik";
        public static string DefaultAddress = "hindrik@eleon.ee";
        public static List<Alarm_Dispatch.MailRecipient> Recipients = new List<Alarm_Dispatch.MailRecipient>();
        public static string Subject = "Park Server Alarm Dispatch";
        public static string Server = "mail.neti.ee";
        public static int Port = 25;
        public static int Timeout = 5000;
        public static string FromAddress = "hindrik@eleon.ee";
        public static List<UInt16> ExcludedStatus = new List<UInt16>();


        public static void AddRecipient(string _name, string _address)
        {
            if (Recipients.Exists(x => x.Name.Equals(_name))) throw new Exception("User name already exists");
            Recipients.Add(new Alarm_Dispatch.MailRecipient(_name, _address));
        }

        public static void RemoveRecipient(string _name)
        {
            Recipients.Remove(Recipients.Find(x => x.Name.Equals(_name)));
        }

        public static void Activate(string _name)
        {
            Recipients[Recipients.FindIndex(x => x.Name.Equals(_name))].Active = true;
        }

        public static void Deactivate(string _name)
        {
            Recipients[Recipients.FindIndex(x => x.Name.Equals(_name))].Active = false;
        }

        public static void ToggleActive(string _name)
        {
            int i = Recipients.FindIndex(x => x.Name.Equals(_name));
            if (Recipients[i].Active) Recipients[i].Active = false;
            else Recipients[i].Active = true;
        }

        public static string GetAddress(string _name)
        {
            return Recipients[Recipients.FindIndex(x => x.Name.Equals(_name))].Address;
        }


        #region Recipients List methods
        /// <summary>
        /// Write the current Recipients value to settings file
        /// </summary>
        private static string SerializeRecipients(List<Alarm_Dispatch.MailRecipient> recipients)
        {
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader(ms))
                {
                    System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf =
                        new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    bf.Serialize(ms, recipients);
                    ms.Position = 0;
                    byte[] buffer = new byte[(int)ms.Length];
                    ms.Read(buffer, 0, buffer.Length);
                    return Convert.ToBase64String(buffer);
                }
            }
        }

        /// <summary>
        /// Read Recipients_ value from settings file to Recipients variable
        /// </summary>
        private static List<Alarm_Dispatch.MailRecipient> DeserializeRecipients(string recipients)
        {
            string Recipients_ = (string)Settings.SettingsFile.Element("Settings").Element("AlarmDispatch").Element("Recipients");
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(Convert.FromBase64String(recipients)))
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf =
                    new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                try
                {
                    return (List<Alarm_Dispatch.MailRecipient>)bf.Deserialize(ms);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Error reading \"Recipients\" settings:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //DialogResult myAnswer = MessageBox.Show("Do you want to restore the Recipients to default value ?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    //if (myAnswer == DialogResult.OK)
                    //{
                    Recipients.Clear();
                    AddRecipient(DefaultName, DefaultAddress);
                    //Save();
                    //}
                    throw new Exception("Error deserializing \"Recipients\"\n" + ex.Message);
                }
            }
        }
        #endregion


        #region ExcludedStatus List methods
        public static void AddExcludedStatus(string _status)
        {
            /*
            string[] string1 = _status.Split(':');
            uint status1 = Convert.ToUInt16(string1[0]);
            uint status2 = Convert.ToUInt16(string1[1]);
            */

            //UInt16 status = (UInt16)((status1 << 8) + status2);
            UInt16 status = Convert.ToUInt16(_status);
            if (ExcludedStatus.Exists(x => x.Equals(status))) throw new Exception("Status code already exists");
            ExcludedStatus.Add(status);
        }

        public static void RemoveExcludedStatus(string _status)
        {
            string[] string1 = _status.Split(':');
            uint status1 = Convert.ToUInt32(string1[0]);
            uint status2 = Convert.ToUInt32(string1[1]);
            UInt16 status = (UInt16)((status1 << 8) + status2);
            ExcludedStatus.Remove(ExcludedStatus.Find(x => x.Equals(status)));
        }

        /// <summary>
        /// Read ExcludedStatus value from settings file
        /// </summary>
        private static List<UInt16> DeserializeExcludedStatus(string excludedstatus)
        {
            string ExcludedStatus_ = (string)Settings.SettingsFile.Element("Settings").Element("AlarmDispatch").Element("ExcludedStatus");
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(Convert.FromBase64String(ExcludedStatus_)))
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf =
                    new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                try
                {
                    return ExcludedStatus = (List<UInt16>)bf.Deserialize(ms);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Error reading \"Recipients\" settings:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //DialogResult myAnswer = MessageBox.Show("Do you want to restore the Recipients to default value ?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    //if (myAnswer == DialogResult.OK)
                    //{
                    ExcludedStatus.Clear();
                    //SetExcludedStatus();
                    //Save();
                    //}
                    throw new Exception("Error reading settings");
                }
            }
        }

        /// <summary>
        /// Write the current ExcludedStatus value to settings file
        /// </summary>
        private static string SerializeExcludedStatus(List<UInt16> excludedstatus)
        {
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader(ms))
                {
                    System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf =
                        new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    bf.Serialize(ms, ExcludedStatus);
                    ms.Position = 0;
                    byte[] buffer = new byte[(int)ms.Length];
                    ms.Read(buffer, 0, buffer.Length);
                    return Convert.ToBase64String(buffer);
                }
            }
        }
        #endregion

        /// <summary>
        /// Read settings from file
        /// </summary>
        public static void Load()
        {
            try
            {
                TriggerDelay = (int)Settings.SettingsFile.Element("Settings").Element("AlarmDispatch").Element("TriggerDelay");
                DefaultName = (string)Settings.SettingsFile.Element("Settings").Element("AlarmDispatch").Element("DefaultName");
                DefaultAddress = (string)Settings.SettingsFile.Element("Settings").Element("AlarmDispatch").Element("DefaultAddress");
                Subject = (string)Settings.SettingsFile.Element("Settings").Element("AlarmDispatch").Element("Subject");
                Server = (string)Settings.SettingsFile.Element("Settings").Element("AlarmDispatch").Element("Server");
                Port = (int)Settings.SettingsFile.Element("Settings").Element("AlarmDispatch").Element("Port");
                Timeout = (int)Settings.SettingsFile.Element("Settings").Element("AlarmDispatch").Element("Timeout");
                FromAddress = (string)Settings.SettingsFile.Element("Settings").Element("AlarmDispatch").Element("FromAddress");
                Recipients = DeserializeRecipients((string)Settings.SettingsFile.Element("Settings").Element("AlarmDispatch").Element("Recipients"));
                ExcludedStatus = DeserializeExcludedStatus((string)Settings.SettingsFile.Element("Settings").Element("AlarmDispatch").Element("ExcludedStatus"));
            }
            catch (Exception ex)
            {
                throw new Exception("Error loading \"Alarm announcement\" settings\n\n" + ex.Message);
            }
        }

        /// <summary>
        /// Write settings to file
        /// </summary>
        public static void Save()
        {
            try
            {
                Settings.SettingsFile.Element("Settings").Element("AlarmDispatch").Element("TriggerDelay").Value = TriggerDelay.ToString();
                Settings.SettingsFile.Element("Settings").Element("AlarmDispatch").Element("DefaultName").Value = DefaultName;
                Settings.SettingsFile.Element("Settings").Element("AlarmDispatch").Element("DefaultAddress").Value = DefaultAddress;
                Settings.SettingsFile.Element("Settings").Element("AlarmDispatch").Element("Subject").Value = Subject;
                Settings.SettingsFile.Element("Settings").Element("AlarmDispatch").Element("Server").Value = Server;
                Settings.SettingsFile.Element("Settings").Element("AlarmDispatch").Element("Port").Value = Port.ToString();
                Settings.SettingsFile.Element("Settings").Element("AlarmDispatch").Element("Timeout").Value = Timeout.ToString();
                Settings.SettingsFile.Element("Settings").Element("AlarmDispatch").Element("FromAddress").Value = FromAddress;
                Settings.SettingsFile.Element("Settings").Element("AlarmDispatch").Element("Recipients").Value = SerializeRecipients(Recipients);
                Settings.SettingsFile.Element("Settings").Element("AlarmDispatch").Element("ExcludedStatus").Value = SerializeExcludedStatus(ExcludedStatus);

                Settings.SettingsFile.Save(Settings.FilePath);
            }
            catch (Exception ex)
            {
                throw new Exception("Error saving \"Alarm announcement\" settings\n\n" + ex.Message);
            }
        }

        /// <summary>
        /// Reset settings to default values
        /// </summary>
        public static void Reset()
        {
        }
    }



    static class Application
    {
        public static bool AutoConnectPark = true;
        public static bool AutoStartIEC104 = true;
        public static int AutoLogoutTime = 600;

        /// <summary>
        /// Read settings from file
        /// </summary>
        public static void Load()
        {
            try
            {
                AutoConnectPark = Convert.ToBoolean(Settings.SettingsFile.Element("Settings").Element("Application").Element("AutoConnectPark").Value);
                AutoStartIEC104 = Convert.ToBoolean(Settings.SettingsFile.Element("Settings").Element("Application").Element("AutoStartIEC104").Value);
                AutoLogoutTime = Convert.ToInt32(Settings.SettingsFile.Element("Settings").Element("Application").Element("AutoLogoutTime").Value);
            }
            catch (Exception ex)
            {
                throw new Exception("Error loading \"Application\" settings\n\n" + ex.Message);
            }
        }

        /// <summary>
        /// Write settings to file
        /// </summary>
        public static void Save()
        {
            try
            {
                Settings.SettingsFile.Element("Settings").Element("Application").Element("AutoConnectPark").Value = AutoConnectPark.ToString();
                Settings.SettingsFile.Element("Settings").Element("Application").Element("AutoStartIEC104").Value = AutoStartIEC104.ToString();
                Settings.SettingsFile.Element("Settings").Element("Application").Element("AutoLogoutTime").Value = AutoLogoutTime.ToString();

                Settings.SettingsFile.Save(Settings.FilePath);
            }
            catch (Exception ex)
            {
                throw new Exception("Error saving \"Application\" settings\n\n" + ex.Message);
            }
        }

        /// <summary>
        /// Reset settings to default values
        /// </summary>
        public static void Reset()
        {
        }
    }



    static class Database
    {
        public static string Path = "Database\\";
        public static int SampleTime = 60000;

        /// <summary>
        /// Read settings from file
        /// </summary>
        public static void Load()
        {
            try
            {
                Path = (string)Settings.SettingsFile.Element("Settings").Element("Database").Element("Path");
                SampleTime = (int)Settings.SettingsFile.Element("Settings").Element("Database").Element("SampleTime");
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to load \"Database\" settings\n\n" + ex.Message);
            }
        }

        /// <summary>
        /// Write settings to file
        /// </summary>
        public static void Save()
        {
            try
            {
                Settings.SettingsFile.Element("Settings").Element("Database").Element("Path").Value = Path;
                Settings.SettingsFile.Element("Settings").Element("Database").Element("SampleTime").Value = SampleTime.ToString();

                Settings.SettingsFile.Save(Settings.FilePath);
            }
            catch (Exception ex)
            {
                throw new Exception("Error saving \"Database\" settings\n" + ex.Message);
            }
        }

        /// <summary>
        /// Reset settings to default values
        /// </summary>
        public static void Reset()
        {
        }
    }



    static class VestasDriver
    {
        public static int Baudrate = 9600;
        public static string PortName = "COM1";
        public static int PollInterval1 = 500;
        public static int PollInterval2 = 1000;
        public static string Parity = "None";
        public static int CommTimeout = 200;
        public static int CommStatusTimeout = 3500;
        public static ushort PowerSetpoint = 2000;

        /// <summary>
        /// Read settings from file
        /// </summary>
        public static void Load()
        {
            try
            {
                Baudrate = (int)Settings.SettingsFile.Element("Settings").Element("VestasDriver").Element("Baudrate");
                PortName = (string)Settings.SettingsFile.Element("Settings").Element("VestasDriver").Element("PortName");
                PollInterval1 = (int)Settings.SettingsFile.Element("Settings").Element("VestasDriver").Element("PollInterval1");
                PollInterval2 = (int)Settings.SettingsFile.Element("Settings").Element("VestasDriver").Element("PollInterval2");
                Parity = (string)Settings.SettingsFile.Element("Settings").Element("VestasDriver").Element("Parity");
                CommTimeout = (int)Settings.SettingsFile.Element("Settings").Element("VestasDriver").Element("CommTimeout");
                CommStatusTimeout = (int)Settings.SettingsFile.Element("Settings").Element("VestasDriver").Element("CommStatusTimeout");
                PowerSetpoint = Convert.ToUInt16(Settings.SettingsFile.Element("Settings").Element("VestasDriver").Element("PowerSetpoint").Value);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to load \"Vestas Driver\" settings\n\n" + ex.Message);
            }
        }

        /// <summary>
        /// Write settings to file
        /// </summary>
        public static void Save()
        {
            try
            {
                Settings.SettingsFile.Element("Settings").Element("VestasDriver").Element("Baudrate").Value = Baudrate.ToString();
                Settings.SettingsFile.Element("Settings").Element("VestasDriver").Element("PortName").Value = PortName.ToString();
                Settings.SettingsFile.Element("Settings").Element("VestasDriver").Element("PollInterval1").Value = PollInterval1.ToString();
                Settings.SettingsFile.Element("Settings").Element("VestasDriver").Element("PollInterval2").Value = PollInterval2.ToString();
                Settings.SettingsFile.Element("Settings").Element("VestasDriver").Element("Parity").Value = Parity.ToString();
                Settings.SettingsFile.Element("Settings").Element("VestasDriver").Element("CommTimeout").Value = CommTimeout.ToString();
                Settings.SettingsFile.Element("Settings").Element("VestasDriver").Element("CommStatusTimeout").Value = CommStatusTimeout.ToString();
                Settings.SettingsFile.Element("Settings").Element("VestasDriver").Element("PowerSetpoint").Value = PowerSetpoint.ToString();

                Settings.SettingsFile.Save(Settings.FilePath);
            }
            catch (Exception ex)
            {
                throw new Exception("Error saving \"Application\" settings\n\n" + ex.Message);
            }
        }

        /// <summary>
        /// Reset settings to default values
        /// </summary>
        public static void Reset()
        {
        }
    }



    static class IEC104Server
    {
        public static int Port = 2404;
        public static bool periodicTransmission = false;
        public static int periodicPeriod = 5000;
        public static int MaxNoOfClients = 10;
        public static string ServerIP = "127.0.0.1";
        public static int ReconnectTime = 20;
        public static int ASDU = 3;

        /// <summary>
        /// Read settings from file
        /// </summary>
        public static void Load()
        {
            try
            {
                Port = (int)Settings.SettingsFile.Element("Settings").Element("IEC104Server").Element("Port");
                periodicTransmission = Convert.ToBoolean(Settings.SettingsFile.Element("Settings").Element("IEC104Server").Element("periodicTransmission").Value);
                periodicPeriod = (int)Settings.SettingsFile.Element("Settings").Element("IEC104Server").Element("periodicPeriod");
                MaxNoOfClients = (int)Settings.SettingsFile.Element("Settings").Element("IEC104Server").Element("MaxNoOfClients");
                ServerIP = (string)Settings.SettingsFile.Element("Settings").Element("IEC104Server").Element("ServerIP");
                ReconnectTime = (int)Settings.SettingsFile.Element("Settings").Element("IEC104Server").Element("ReconnectTime");
                ASDU = (int)Settings.SettingsFile.Element("Settings").Element("IEC104Server").Element("ASDU");
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to load \"IEC104 server\" settings\n\n" + ex.Message);
            }
        }

        /// <summary>
        /// Write settings to file
        /// </summary>
        public static void Save()
        {
            try
            {
                Settings.SettingsFile.Element("Settings").Element("IEC104Server").Element("Port").Value = Port.ToString();
                Settings.SettingsFile.Element("Settings").Element("IEC104Server").Element("periodicTransmission").Value = periodicTransmission.ToString();
                Settings.SettingsFile.Element("Settings").Element("IEC104Server").Element("periodicPeriod").Value = periodicPeriod.ToString();
                Settings.SettingsFile.Element("Settings").Element("IEC104Server").Element("MaxNoOfClients").Value = MaxNoOfClients.ToString();
                Settings.SettingsFile.Element("Settings").Element("IEC104Server").Element("ServerIP").Value = ServerIP.ToString();
                Settings.SettingsFile.Element("Settings").Element("IEC104Server").Element("ReconnectTime").Value = ReconnectTime.ToString();
                Settings.SettingsFile.Element("Settings").Element("IEC104Server").Element("ASDU").Value = ASDU.ToString();

                Settings.SettingsFile.Save(Settings.FilePath);
            }
            catch (Exception ex)
            {
                throw new Exception("Error saving \"IEC104 server\" settings\n" + ex.Message);
            }
        }

        /// <summary>
        /// Reset settings to default values
        /// </summary>
        public static void Reset()
        {
        }
    }



    static class Park
    {
        public static ushort Local_ActivePowerSetpoint = 2000;
        public static ushort ParkMaxPower = 2000;
        public static bool ParkMVBreaker_Status = true;
        public static int ActivePowerSetpoint_Mode = 0;
        public static ushort Remote_ActivePowerSetpoint = 2000;

        /// <summary>
        /// Read settings from file
        /// </summary>
        public static void Load()
        {
            try
            {
                Local_ActivePowerSetpoint = Convert.ToUInt16(Settings.SettingsFile.Element("Settings").Element("Park").Element("Local_ActivePowerSetpoint").Value);
                ParkMaxPower = Convert.ToUInt16(Settings.SettingsFile.Element("Settings").Element("Park").Element("ParkMaxPower").Value);
                ParkMVBreaker_Status = Convert.ToBoolean(Settings.SettingsFile.Element("Settings").Element("Park").Element("ParkMVBreaker_Status").Value);
                ActivePowerSetpoint_Mode = (int)Settings.SettingsFile.Element("Settings").Element("Park").Element("ActivePowerSetpoint_Mode");
                Remote_ActivePowerSetpoint = Convert.ToUInt16(Settings.SettingsFile.Element("Settings").Element("Park").Element("Remote_ActivePowerSetpoint").Value);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to load \"Park\" settings\n\n" + ex.Message);
            }
        }

        /// <summary>
        /// Write settings to file
        /// </summary>
        public static void Save()
        {
            try
            {
                Settings.SettingsFile.Element("Settings").Element("Park").Element("Local_ActivePowerSetpoint").Value = Local_ActivePowerSetpoint.ToString();
                Settings.SettingsFile.Element("Settings").Element("Park").Element("ParkMaxPower").Value = ParkMaxPower.ToString();
                Settings.SettingsFile.Element("Settings").Element("Park").Element("ParkMVBreaker_Status").Value = ParkMVBreaker_Status.ToString();
                Settings.SettingsFile.Element("Settings").Element("Park").Element("ActivePowerSetpoint_Mode").Value = ActivePowerSetpoint_Mode.ToString();
                Settings.SettingsFile.Element("Settings").Element("Park").Element("Remote_ActivePowerSetpoint").Value = Remote_ActivePowerSetpoint.ToString();

                Settings.SettingsFile.Save(Settings.FilePath);
            }
            catch (Exception ex)
            {
                throw new Exception("Error saving \"Park\" settings\n\n" + ex.Message);
            }
        }

        /// <summary>
        /// Reset settings to default values
        /// </summary>
        public static void Reset()
        {
        }
    }



    static class T01
    {
        public static bool PrimRegulNorm = false;
        public static bool PrimRegulEmAutoActivate = true;

        // general parameters
        public static int NominalPower = 2000;
        public static int PowerRamping = 100;
        public static float NominalFrequency = 50;

        // normal mode parameters
        public static float PrimReservePercentNorm = 5;
        public static float DroopNorm = 2;                      // statism
        public static float DeadbandNorm = (float)0.01;         // tundetus

        // emergency mode parameters
        public static float PrimReservePercentEm = (float)12.5;
        public static float DroopEm = 2;                        // statism
        public static float DeadbandEm = (float)0.1;            // tundetus
        public static float MaxFreqChange = (float)0.5;
        public static float MaxFreqDeviation = (float)0.5;
        public static int PrimRegulEmResetDelay = 600;
        public static int SetpointSendRate = 2;

        public static List<UInt16> AutoResetError = new List<UInt16>();
        public static int AutoErrorAckDelay = 20;



        /// <summary>
        /// Read settings from file
        /// </summary>
        public static void Load()
        {
            try
            {
                PrimRegulNorm = Convert.ToBoolean(Settings.SettingsFile.Element("Settings").Element("T01").Element("PrimRegulNorm").Value);
                PrimRegulEmAutoActivate = Convert.ToBoolean(Settings.SettingsFile.Element("Settings").Element("T01").Element("PrimRegulEmAutoActivate").Value);
                SetpointSendRate = (int)Settings.SettingsFile.Element("Settings").Element("T01").Element("SetpointSendRate");

                // general parameters
                NominalPower = (int)Settings.SettingsFile.Element("Settings").Element("T01").Element("NominalPower");
                PowerRamping = (int)Settings.SettingsFile.Element("Settings").Element("T01").Element("PowerRamping");
                NominalFrequency = Convert.ToSingle(Settings.SettingsFile.Element("Settings").Element("T01").Element("NominalFrequency").Value);

                // normal mode parameters
                PrimReservePercentNorm = Convert.ToSingle(Settings.SettingsFile.Element("Settings").Element("T01").Element("PrimReservePercentNorm").Value);
                DroopNorm = Convert.ToSingle(Settings.SettingsFile.Element("Settings").Element("T01").Element("DroopNorm").Value);
                DeadbandNorm = Convert.ToSingle(Settings.SettingsFile.Element("Settings").Element("T01").Element("DeadbandNorm").Value);

                // emergency mode parameters
                PrimReservePercentEm = Convert.ToSingle(Settings.SettingsFile.Element("Settings").Element("T01").Element("PrimReservePercentEm").Value);
                DroopEm = Convert.ToSingle(Settings.SettingsFile.Element("Settings").Element("T01").Element("DroopEm").Value);
                DeadbandEm = Convert.ToSingle(Settings.SettingsFile.Element("Settings").Element("T01").Element("DeadbandEm").Value);
                MaxFreqChange = Convert.ToSingle(Settings.SettingsFile.Element("Settings").Element("T01").Element("MaxFreqChange").Value);
                MaxFreqDeviation = Convert.ToSingle(Settings.SettingsFile.Element("Settings").Element("T01").Element("MaxFreqDeviation").Value);
                PrimRegulEmResetDelay = (int)Settings.SettingsFile.Element("Settings").Element("T01").Element("PrimRegulEmResetDelay");

                AutoResetError = DeserializeAutoResetError(Settings.SettingsFile.Element("Settings").Element("T01").Element("AutoResetError").Value);
                AutoErrorAckDelay = (int)Settings.SettingsFile.Element("Settings").Element("T01").Element("AutoErrorAckDelay");
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to load \"Park\" settings\n\n" + ex.Message);
            }
        }

        /// <summary>
        /// Write settings to file
        /// </summary>
        public static void Save()
        {
            try
            {
                Settings.SettingsFile.Element("Settings").Element("T01").Element("PrimRegulNorm").Value = PrimRegulNorm.ToString();
                Settings.SettingsFile.Element("Settings").Element("T01").Element("PrimRegulEmAutoActivate").Value = PrimRegulEmAutoActivate.ToString();
                Settings.SettingsFile.Element("Settings").Element("T01").Element("SetpointSendRate").Value = SetpointSendRate.ToString();

                // general parameters
                Settings.SettingsFile.Element("Settings").Element("T01").Element("NominalPower").Value = NominalPower.ToString();
                Settings.SettingsFile.Element("Settings").Element("T01").Element("PowerRamping").Value = PowerRamping.ToString();
                Settings.SettingsFile.Element("Settings").Element("T01").Element("NominalFrequency").Value = NominalFrequency.ToString();

                // normal mode parameters
                Settings.SettingsFile.Element("Settings").Element("T01").Element("PrimReservePercentNorm").Value = PrimReservePercentNorm.ToString();
                Settings.SettingsFile.Element("Settings").Element("T01").Element("DroopNorm").Value = DroopNorm.ToString();
                Settings.SettingsFile.Element("Settings").Element("T01").Element("DeadbandNorm").Value = DeadbandNorm.ToString();

                // emergency mode parameters
                Settings.SettingsFile.Element("Settings").Element("T01").Element("PrimReservePercentEm").Value = PrimReservePercentEm.ToString();
                Settings.SettingsFile.Element("Settings").Element("T01").Element("DroopEm").Value = DroopEm.ToString();
                Settings.SettingsFile.Element("Settings").Element("T01").Element("DeadbandEm").Value = DeadbandEm.ToString();
                Settings.SettingsFile.Element("Settings").Element("T01").Element("MaxFreqChange").Value = MaxFreqChange.ToString();
                Settings.SettingsFile.Element("Settings").Element("T01").Element("MaxFreqDeviation").Value = MaxFreqDeviation.ToString();
                Settings.SettingsFile.Element("Settings").Element("T01").Element("PrimRegulEmResetDelay").Value = PrimRegulEmResetDelay.ToString();

                Settings.SettingsFile.Element("Settings").Element("T01").Element("AutoResetError").Value = SerializeAutoResetError(AutoResetError);
                Settings.SettingsFile.Element("Settings").Element("T01").Element("AutoErrorAckDelay").Value = AutoErrorAckDelay.ToString();

                Settings.SettingsFile.Save(Settings.FilePath);
            }
            catch (Exception ex)
            {
                throw new Exception("Error saving \"Park\" settings\n\n" + ex.Message);
            }
        }

        /// <summary>
        /// Reset settings to default values
        /// </summary>
        public static void Reset()
        {
        }


        #region AddAutoResetError List methods
        public static void AddAutoResetError(string _code)
        {
            UInt16 code = Convert.ToUInt16(_code);
            if (AutoResetError.Exists(x => x.Equals(code))) throw new Exception("Error code already exists");
            AutoResetError.Add(code);
        }

        public static void RemoveAutoResetError(string _code)
        {
            string[] string1 = _code.Split(':');
            uint status1 = Convert.ToUInt32(string1[0]);
            uint status2 = Convert.ToUInt32(string1[1]);
            UInt16 status = (UInt16)((status1 << 8) + status2);
            AutoResetError.Remove(AutoResetError.Find(x => x.Equals(status)));
        }

        /// <summary>
        /// Read AutoResetError value from settings file
        /// </summary>
        private static List<UInt16> DeserializeAutoResetError(string autoResetError)
        {
            string AutoResetError_ = (string)Settings.SettingsFile.Element("Settings").Element("T01").Element("AutoResetError");
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(Convert.FromBase64String(AutoResetError_)))
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf =
                    new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                try
                {
                    return AutoResetError = (List<UInt16>)bf.Deserialize(ms);
                }
                catch (Exception ex)
                {
                    AutoResetError.Clear();
                    throw new Exception("Error reading settings");
                }
            }
        }

        /// <summary>
        /// Write the current AutoResetError value to settings file
        /// </summary>
        private static string SerializeAutoResetError(List<UInt16> autoResetError)
        {
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader(ms))
                {
                    System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf =
                        new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    bf.Serialize(ms, autoResetError);
                    ms.Position = 0;
                    byte[] buffer = new byte[(int)ms.Length];
                    ms.Read(buffer, 0, buffer.Length);
                    return Convert.ToBase64String(buffer);
                }
            }
        }
        #endregion
    }
}
