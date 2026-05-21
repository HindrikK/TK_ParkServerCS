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
                EnsureSettingsFile();
                SettingsFile = System.Xml.Linq.XDocument.Load(FilePath);
                EnsureRoot();

                AlarmAnnouncement.Load();
                Application.Load();
                Database.Load();
                VestasDriver.Load();
                TSOInterface.Load();
                Park.Load();
                T01.Load();
                MarketInterface.Load();

                SaveFile();
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
                EnsureRoot();

                AlarmAnnouncement.Save();
                Application.Save();
                Database.Save();
                VestasDriver.Save();
                TSOInterface.Save();
                Park.Save();
                T01.Save();
                MarketInterface.Save();

                SaveFile();
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

        private static void EnsureSettingsFile()
        {
            string directory = System.IO.Path.GetDirectoryName(FilePath);
            if (!System.IO.Directory.Exists(directory))
            {
                System.IO.Directory.CreateDirectory(directory);
            }

            if (!System.IO.File.Exists(FilePath))
            {
                SettingsFile = new System.Xml.Linq.XDocument(new System.Xml.Linq.XElement("Settings"));
                SaveFile();
            }
        }

        private static void EnsureRoot()
        {
            if (SettingsFile == null)
            {
                SettingsFile = new System.Xml.Linq.XDocument(new System.Xml.Linq.XElement("Settings"));
            }
            else if (SettingsFile.Root == null)
            {
                SettingsFile.Add(new System.Xml.Linq.XElement("Settings"));
            }
            else if (SettingsFile.Root.Name != "Settings")
            {
                throw new Exception("Settings root element must be named \"Settings\"");
            }
        }

        public static System.Xml.Linq.XElement EnsureSection(string sectionName)
        {
            EnsureRoot();

            System.Xml.Linq.XElement section = SettingsFile.Root.Element(sectionName);
            if (section == null)
            {
                section = new System.Xml.Linq.XElement(sectionName);
                SettingsFile.Root.Add(section);
            }

            return section;
        }

        public static string GetValue(string sectionName, string settingName, string defaultValue)
        {
            System.Xml.Linq.XElement section = EnsureSection(sectionName);
            System.Xml.Linq.XElement element = section.Element(settingName);
            if (element == null)
            {
                element = new System.Xml.Linq.XElement(settingName, defaultValue);
                section.Add(element);
            }

            return element.Value;
        }

        public static int GetInt(string sectionName, string settingName, int defaultValue)
        {
            string value = GetValue(sectionName, settingName, defaultValue.ToString());
            int parsedValue;
            if (!int.TryParse(value, out parsedValue))
            {
                throw new Exception("Invalid integer value for " + sectionName + "/" + settingName + ": " + value);
            }

            return parsedValue;
        }

        public static ushort GetUInt16(string sectionName, string settingName, ushort defaultValue)
        {
            string value = GetValue(sectionName, settingName, defaultValue.ToString());
            ushort parsedValue;
            if (!ushort.TryParse(value, out parsedValue))
            {
                throw new Exception("Invalid UInt16 value for " + sectionName + "/" + settingName + ": " + value);
            }

            return parsedValue;
        }

        public static float GetFloat(string sectionName, string settingName, float defaultValue)
        {
            string value = GetValue(sectionName, settingName, defaultValue.ToString());
            float parsedValue;
            if (!float.TryParse(value, out parsedValue))
            {
                throw new Exception("Invalid float value for " + sectionName + "/" + settingName + ": " + value);
            }

            return parsedValue;
        }

        public static bool GetBool(string sectionName, string settingName, bool defaultValue)
        {
            string value = GetValue(sectionName, settingName, defaultValue.ToString());
            bool parsedValue;
            if (!bool.TryParse(value, out parsedValue))
            {
                throw new Exception("Invalid boolean value for " + sectionName + "/" + settingName + ": " + value);
            }

            return parsedValue;
        }

        public static void SetValue(string sectionName, string settingName, string value)
        {
            System.Xml.Linq.XElement section = EnsureSection(sectionName);
            System.Xml.Linq.XElement element = section.Element(settingName);
            if (element == null)
            {
                element = new System.Xml.Linq.XElement(settingName);
                section.Add(element);
            }

            element.Value = value;
        }

        public static void SaveFile()
        {
            string directory = System.IO.Path.GetDirectoryName(FilePath);
            if (!System.IO.Directory.Exists(directory))
            {
                System.IO.Directory.CreateDirectory(directory);
            }

            SettingsFile.Save(FilePath);
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
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(Convert.FromBase64String(excludedstatus)))
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
                TriggerDelay = Settings.GetInt("AlarmDispatch", "TriggerDelay", TriggerDelay);
                DefaultName = Settings.GetValue("AlarmDispatch", "DefaultName", DefaultName);
                DefaultAddress = Settings.GetValue("AlarmDispatch", "DefaultAddress", DefaultAddress);
                Subject = Settings.GetValue("AlarmDispatch", "Subject", Subject);
                Server = Settings.GetValue("AlarmDispatch", "Server", Server);
                Port = Settings.GetInt("AlarmDispatch", "Port", Port);
                Timeout = Settings.GetInt("AlarmDispatch", "Timeout", Timeout);
                FromAddress = Settings.GetValue("AlarmDispatch", "FromAddress", FromAddress);
                Recipients = DeserializeRecipients(Settings.GetValue("AlarmDispatch", "Recipients", SerializeRecipients(Recipients)));
                ExcludedStatus = DeserializeExcludedStatus(Settings.GetValue("AlarmDispatch", "ExcludedStatus", SerializeExcludedStatus(ExcludedStatus)));
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
                Settings.SetValue("AlarmDispatch", "TriggerDelay", TriggerDelay.ToString());
                Settings.SetValue("AlarmDispatch", "DefaultName", DefaultName);
                Settings.SetValue("AlarmDispatch", "DefaultAddress", DefaultAddress);
                Settings.SetValue("AlarmDispatch", "Subject", Subject);
                Settings.SetValue("AlarmDispatch", "Server", Server);
                Settings.SetValue("AlarmDispatch", "Port", Port.ToString());
                Settings.SetValue("AlarmDispatch", "Timeout", Timeout.ToString());
                Settings.SetValue("AlarmDispatch", "FromAddress", FromAddress);
                Settings.SetValue("AlarmDispatch", "Recipients", SerializeRecipients(Recipients));
                Settings.SetValue("AlarmDispatch", "ExcludedStatus", SerializeExcludedStatus(ExcludedStatus));

                Settings.SaveFile();
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
                AutoConnectPark = Settings.GetBool("Application", "AutoConnectPark", AutoConnectPark);
                AutoStartIEC104 = Settings.GetBool("Application", "AutoStartIEC104", AutoStartIEC104);
                AutoLogoutTime = Settings.GetInt("Application", "AutoLogoutTime", AutoLogoutTime);
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
                Settings.SetValue("Application", "AutoConnectPark", AutoConnectPark.ToString());
                Settings.SetValue("Application", "AutoStartIEC104", AutoStartIEC104.ToString());
                Settings.SetValue("Application", "AutoLogoutTime", AutoLogoutTime.ToString());

                Settings.SaveFile();
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
                Path = Settings.GetValue("Database", "Path", Path);
                SampleTime = Settings.GetInt("Database", "SampleTime", SampleTime);
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
                Settings.SetValue("Database", "Path", Path);
                Settings.SetValue("Database", "SampleTime", SampleTime.ToString());

                Settings.SaveFile();
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
                Baudrate = Settings.GetInt("VestasDriver", "Baudrate", Baudrate);
                PortName = Settings.GetValue("VestasDriver", "PortName", PortName);
                PollInterval1 = Settings.GetInt("VestasDriver", "PollInterval1", PollInterval1);
                PollInterval2 = Settings.GetInt("VestasDriver", "PollInterval2", PollInterval2);
                Parity = Settings.GetValue("VestasDriver", "Parity", Parity);
                CommTimeout = Settings.GetInt("VestasDriver", "CommTimeout", CommTimeout);
                CommStatusTimeout = Settings.GetInt("VestasDriver", "CommStatusTimeout", CommStatusTimeout);
                PowerSetpoint = Settings.GetUInt16("VestasDriver", "PowerSetpoint", PowerSetpoint);
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
                Settings.SetValue("VestasDriver", "Baudrate", Baudrate.ToString());
                Settings.SetValue("VestasDriver", "PortName", PortName);
                Settings.SetValue("VestasDriver", "PollInterval1", PollInterval1.ToString());
                Settings.SetValue("VestasDriver", "PollInterval2", PollInterval2.ToString());
                Settings.SetValue("VestasDriver", "Parity", Parity);
                Settings.SetValue("VestasDriver", "CommTimeout", CommTimeout.ToString());
                Settings.SetValue("VestasDriver", "CommStatusTimeout", CommStatusTimeout.ToString());
                Settings.SetValue("VestasDriver", "PowerSetpoint", PowerSetpoint.ToString());

                Settings.SaveFile();
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



    static class TSOInterface
    {
        public static int Port = 2404;
        public static bool periodicTransmission = false;
        public static int periodicPeriod = 5000;
        public static int MaxNoOfClients = 10;
        public static string ServerIP = "0.0.0.0";
        public static int ReconnectTime = 20;
        public static int ASDU = 3;

        /// <summary>
        /// Read settings from file
        /// </summary>
        public static void Load()
        {
            try
            {
                Port = Settings.GetInt("IEC104Server", "Port", Port);
                periodicTransmission = Settings.GetBool("IEC104Server", "periodicTransmission", periodicTransmission);
                periodicPeriod = Settings.GetInt("IEC104Server", "periodicPeriod", periodicPeriod);
                MaxNoOfClients = Settings.GetInt("IEC104Server", "MaxNoOfClients", MaxNoOfClients);
                ServerIP = Settings.GetValue("IEC104Server", "ServerIP", ServerIP);
                ReconnectTime = Settings.GetInt("IEC104Server", "ReconnectTime", ReconnectTime);
                ASDU = Settings.GetInt("IEC104Server", "ASDU", ASDU);
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
                Settings.SetValue("IEC104Server", "Port", Port.ToString());
                Settings.SetValue("IEC104Server", "periodicTransmission", periodicTransmission.ToString());
                Settings.SetValue("IEC104Server", "periodicPeriod", periodicPeriod.ToString());
                Settings.SetValue("IEC104Server", "MaxNoOfClients", MaxNoOfClients.ToString());
                Settings.SetValue("IEC104Server", "ServerIP", ServerIP);
                Settings.SetValue("IEC104Server", "ReconnectTime", ReconnectTime.ToString());
                Settings.SetValue("IEC104Server", "ASDU", ASDU.ToString());

                Settings.SaveFile();
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
        public static ushort TSO_ActivePowerSetpoint = 2000;
        public static ushort Market_ActivePowerSetpoint = 2000;

        /// <summary>
        /// Read settings from file
        /// </summary>
        public static void Load()
        {
            try
            {
                Local_ActivePowerSetpoint = Settings.GetUInt16("Park", "Local_ActivePowerSetpoint", Local_ActivePowerSetpoint);
                ParkMaxPower = Settings.GetUInt16("Park", "ParkMaxPower", ParkMaxPower);
                ParkMVBreaker_Status = Settings.GetBool("Park", "ParkMVBreaker_Status", ParkMVBreaker_Status);
                ActivePowerSetpoint_Mode = Settings.GetInt("Park", "ActivePowerSetpoint_Mode", ActivePowerSetpoint_Mode);
                TSO_ActivePowerSetpoint = Settings.GetUInt16("Park", "TSO_ActivePowerSetpoint", TSO_ActivePowerSetpoint);
                Market_ActivePowerSetpoint = Settings.GetUInt16("Park", "Market_ActivePowerSetpoint", Market_ActivePowerSetpoint);
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
                Settings.SetValue("Park", "Local_ActivePowerSetpoint", Local_ActivePowerSetpoint.ToString());
                Settings.SetValue("Park", "ParkMaxPower", ParkMaxPower.ToString());
                Settings.SetValue("Park", "ParkMVBreaker_Status", ParkMVBreaker_Status.ToString());
                Settings.SetValue("Park", "ActivePowerSetpoint_Mode", ActivePowerSetpoint_Mode.ToString());
                Settings.SetValue("Park", "TSO_ActivePowerSetpoint", TSO_ActivePowerSetpoint.ToString());
                Settings.SetValue("Park", "Market_ActivePowerSetpoint", Market_ActivePowerSetpoint.ToString());

                Settings.SaveFile();
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
                PrimRegulNorm = Settings.GetBool("T01", "PrimRegulNorm", PrimRegulNorm);
                PrimRegulEmAutoActivate = Settings.GetBool("T01", "PrimRegulEmAutoActivate", PrimRegulEmAutoActivate);
                SetpointSendRate = Settings.GetInt("T01", "SetpointSendRate", SetpointSendRate);

                // general parameters
                NominalPower = Settings.GetInt("T01", "NominalPower", NominalPower);
                PowerRamping = Settings.GetInt("T01", "PowerRamping", PowerRamping);
                NominalFrequency = Settings.GetFloat("T01", "NominalFrequency", NominalFrequency);

                // normal mode parameters
                PrimReservePercentNorm = Settings.GetFloat("T01", "PrimReservePercentNorm", PrimReservePercentNorm);
                DroopNorm = Settings.GetFloat("T01", "DroopNorm", DroopNorm);
                DeadbandNorm = Settings.GetFloat("T01", "DeadbandNorm", DeadbandNorm);

                // emergency mode parameters
                PrimReservePercentEm = Settings.GetFloat("T01", "PrimReservePercentEm", PrimReservePercentEm);
                DroopEm = Settings.GetFloat("T01", "DroopEm", DroopEm);
                DeadbandEm = Settings.GetFloat("T01", "DeadbandEm", DeadbandEm);
                MaxFreqChange = Settings.GetFloat("T01", "MaxFreqChange", MaxFreqChange);
                MaxFreqDeviation = Settings.GetFloat("T01", "MaxFreqDeviation", MaxFreqDeviation);
                PrimRegulEmResetDelay = Settings.GetInt("T01", "PrimRegulEmResetDelay", PrimRegulEmResetDelay);

                AutoResetError = DeserializeAutoResetError(Settings.GetValue("T01", "AutoResetError", SerializeAutoResetError(AutoResetError)));
                AutoErrorAckDelay = Settings.GetInt("T01", "AutoErrorAckDelay", AutoErrorAckDelay);
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
                Settings.SetValue("T01", "PrimRegulNorm", PrimRegulNorm.ToString());
                Settings.SetValue("T01", "PrimRegulEmAutoActivate", PrimRegulEmAutoActivate.ToString());
                Settings.SetValue("T01", "SetpointSendRate", SetpointSendRate.ToString());

                // general parameters
                Settings.SetValue("T01", "NominalPower", NominalPower.ToString());
                Settings.SetValue("T01", "PowerRamping", PowerRamping.ToString());
                Settings.SetValue("T01", "NominalFrequency", NominalFrequency.ToString());

                // normal mode parameters
                Settings.SetValue("T01", "PrimReservePercentNorm", PrimReservePercentNorm.ToString());
                Settings.SetValue("T01", "DroopNorm", DroopNorm.ToString());
                Settings.SetValue("T01", "DeadbandNorm", DeadbandNorm.ToString());

                // emergency mode parameters
                Settings.SetValue("T01", "PrimReservePercentEm", PrimReservePercentEm.ToString());
                Settings.SetValue("T01", "DroopEm", DroopEm.ToString());
                Settings.SetValue("T01", "DeadbandEm", DeadbandEm.ToString());
                Settings.SetValue("T01", "MaxFreqChange", MaxFreqChange.ToString());
                Settings.SetValue("T01", "MaxFreqDeviation", MaxFreqDeviation.ToString());
                Settings.SetValue("T01", "PrimRegulEmResetDelay", PrimRegulEmResetDelay.ToString());

                Settings.SetValue("T01", "AutoResetError", SerializeAutoResetError(AutoResetError));
                Settings.SetValue("T01", "AutoErrorAckDelay", AutoErrorAckDelay.ToString());

                Settings.SaveFile();
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
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(Convert.FromBase64String(autoResetError)))
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



    static class MarketInterface
    {
        public static bool MarketIfEnable = false;
        public static string IpAddress = "0.0.0.0";
        public static int UdpPort = 502;
        public static int TcpPort = 502;
        public static bool UdpEnable = true;
        public static bool TcpEnable = true;
        public static int MaxActiveConnections = 3;
        public static int ConnStaleTimeout = 60;
        public static int ResponseRateLimit = 100;
        public static int FallbackTimeout = 900;

        public static void Load()
        {
            try
            {
                MarketIfEnable = Settings.GetBool("MarketInterface", "MarketIfEnable", MarketIfEnable);
                IpAddress = Settings.GetValue("MarketInterface", "IpAddress", IpAddress);
                System.Net.IPAddress.Parse(IpAddress);
                UdpPort = Settings.GetInt("MarketInterface", "UdpPort", UdpPort);
                TcpPort = Settings.GetInt("MarketInterface", "TcpPort", TcpPort);
                UdpEnable = Settings.GetBool("MarketInterface", "UdpEnable", UdpEnable);
                TcpEnable = Settings.GetBool("MarketInterface", "TcpEnable", TcpEnable);
                MaxActiveConnections = Settings.GetInt("MarketInterface", "MaxActiveConnections", MaxActiveConnections);
                ConnStaleTimeout = Settings.GetInt("MarketInterface", "ConnStaleTimeout", ConnStaleTimeout);
                ResponseRateLimit = Settings.GetInt("MarketInterface", "ResponseRateLimit", ResponseRateLimit);
                FallbackTimeout = Settings.GetInt("MarketInterface", "FallbackTimeout", FallbackTimeout);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to load \"MarketInterface\" settings\n\n" + ex.Message);
            }
        }

        public static void Save()
        {
            try
            {
                Settings.SetValue("MarketInterface", "MarketIfEnable", MarketIfEnable.ToString());
                Settings.SetValue("MarketInterface", "IpAddress", IpAddress);
                Settings.SetValue("MarketInterface", "UdpPort", UdpPort.ToString());
                Settings.SetValue("MarketInterface", "TcpPort", TcpPort.ToString());
                Settings.SetValue("MarketInterface", "UdpEnable", UdpEnable.ToString());
                Settings.SetValue("MarketInterface", "TcpEnable", TcpEnable.ToString());
                Settings.SetValue("MarketInterface", "MaxActiveConnections", MaxActiveConnections.ToString());
                Settings.SetValue("MarketInterface", "ConnStaleTimeout", ConnStaleTimeout.ToString());
                Settings.SetValue("MarketInterface", "ResponseRateLimit", ResponseRateLimit.ToString());
                Settings.SetValue("MarketInterface", "FallbackTimeout", FallbackTimeout.ToString());

                Settings.SaveFile();
            }
            catch (Exception ex)
            {
                throw new Exception("Error saving \"MarketInterface\" settings\n\n" + ex.Message);
            }
        }
    }
}
