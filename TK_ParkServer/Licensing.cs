using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TK_ParkServer
{
    static class Licensing
    {
        public static string LicenseOwner;
        public static string LicenseNumber;
        private static string License;


        /// <summary>
        /// Loads license data from license file
        /// </summary>
        public static void LoadLicenseData()
        {
            LoadLicenseData("");
        }

        /// <summary>
        /// Loads license data from license file
        /// </summary>
        /// <param name="path">License file path</param>
        public static void LoadLicenseData(string path)
        {
            if (System.IO.File.Exists(path + "License.dat"))
            {
                // read from file
                try
                {
                    string[] lines = System.IO.File.ReadAllLines(path + "License.dat");

                    LicenseOwner = lines[0];
                    LicenseNumber = lines[1];
                    License = lines[2];

                }
                catch (Exception ex)
                {
                    throw new Exception("Error loading license data\n" + ex.Message);
                }
            }
            else
            {
                throw new Exception("License file not found");
            }
        }


        public static string GetHardwareID()
        {
            string hardwareID;

            hardwareID = GetCpuID();

            return hardwareID;
        }


        public static string GetCpuID()
        {
            string cpuID = string.Empty;

            System.Management.ManagementClass managClass = new System.Management.ManagementClass("win32_processor");
            System.Management.ManagementObjectCollection managCollec = managClass.GetInstances();

            foreach (System.Management.ManagementObject managObj in managCollec)
            {
                cpuID = managObj.Properties["processorID"].Value.ToString();
                break;
            }

            return cpuID;
        }


        public static string GetHashString(string Input)
        {
            string salt = "1x5gü";

            System.Security.Cryptography.SHA256Managed mySHA256 = new System.Security.Cryptography.SHA256Managed();
            byte[] stringBytes;
            byte[] hashBytes;
            string hashString;

            stringBytes = System.Text.Encoding.Unicode.GetBytes(Input + salt);
            hashBytes = mySHA256.ComputeHash(stringBytes);
            hashString = Convert.ToBase64String(hashBytes);

            return hashString;
        }

        /// <summary>
        /// Check for correct license data
        /// </summary>
        /// <returns>Returns TRUE if license is valid</returns>
        public static bool CheckLicense()
        {
            try
            {
                LoadLicenseData();
            }
            catch
            {
                //throw new Exception("Not able to load license file");
                return false;
            }

            if (License == GetHashString(GetHardwareID() + LicenseOwner + LicenseNumber))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
