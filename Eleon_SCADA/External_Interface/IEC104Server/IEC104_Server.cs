using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eleon_SCADA.IEC104Server
{
    class IEC104Server
    {
        System.Net.Sockets.TcpListener myTcpListener;
        System.Threading.Thread myTCPServerListenThread;
        //public byte[] dataReceived = new byte[64];
        public IEC104_ServerStatus ServerStatus;
        public int ReconnectTimer = 0;      // counts seconds to retry starting TCP listener
        public int NoOfClients;             // also means number of channels, one channel is created for each client
        public int MaxNoOfClients;          // limits the maximum allowed number of clients
        public IEC104Channel[] Channels;
        //public System.Threading.Thread[] clientThread;

        // database
        public IEC104_Database myIECDatabase = new IEC104_Database();


        public IEC104Server()
        {
            MaxNoOfClients = Settings.IEC104Server.MaxNoOfClients;
            Channels = new IEC104Channel[MaxNoOfClients];
        }


        /// <summary>
        /// Start IEC-104 server to listen on TCP port
        /// </summary>
        public void Start()
        {
            //System.Net.IPEndPoint localEndPoint = new System.Net.IPEndPoint(System.Net.IPAddress.Parse("127.0.0.1"), 13000);
            //myTcpListener = new System.Net.Sockets.TcpListener(System.Net.IPAddress.Parse("127.0.0.1"), 2404);

            if (!Eleon_SCADA.Licensing.CheckLicense())
            {
                throw new Exception("IEC-104 Server disabled - No license");
            }

            ReconnectTimer = 0;

            myTcpListener = new System.Net.Sockets.TcpListener(System.Net.IPAddress.Parse(
                Eleon_SCADA.Settings.IEC104Server.ServerIP), Eleon_SCADA.Settings.IEC104Server.Port);
            myTCPServerListenThread = new System.Threading.Thread(ListenForClients);
            myTCPServerListenThread.Name = "IEC104_Server_Listen";
            myTCPServerListenThread.IsBackground = true;
            myTCPServerListenThread.Start();
        }

        /// <summary>
        /// Stop IEC-104 server and close all existing clients/channels
        /// </summary>
        public void Stop()
        {
            for (int i = Channels.Count() - 1; i >= 0; i--)
            {
                if (Channels[i] != null)
                {
                    Channels[i].CloseChannel();
                }
            }
            ServerStatus = IEC104_ServerStatus.STOPPED;
            myTcpListener.Stop();
        }


        #region THREAD "ListenForClients"
        private void ListenForClients()
        {
            bool RunThread = true;
            int Step = 0;
            System.Net.Sockets.TcpClient myTCPClient;

            while (RunThread)
            {
                // open socket to start listening for new clients
                switch (Step)
                {
                    // open socket
                    case 0:

                        if (ReconnectTimer > 0)
                        {
                            System.Threading.Thread.Sleep(1000);
                            ReconnectTimer--;
                        }
                        else
                        {
                            try
                            {
                                ServerStatus = IEC104_ServerStatus.STARTING;
                                System.Threading.Thread.Sleep(2000);
                                myTcpListener.Start();
                                ServerStatus = IEC104_ServerStatus.RUNNING;
                                Step = 1;   // switch to next step
                            }
                            catch (Exception ex)
                            {
                                ServerStatus = IEC104_ServerStatus.ERROR_STARTING;
                                System.Threading.Thread.Sleep(2000);

                                ReconnectTimer = Settings.IEC104Server.ReconnectTime;    // retry to start TCP listener when error occured
                                ServerStatus = IEC104_ServerStatus.WAITING_RESTART;
                                //throw new Exception("Error starting IEC listener" + ex.Message);
                            }
                        }
                        break;

                    // start accepting new TCP clients
                    case 1:

                        // exit this thread when server stopped
                        if (ServerStatus == IEC104_ServerStatus.STOPPED)
                        {
                            RunThread = false;
                        }

                        try
                        {
                            if (NoOfClients < MaxNoOfClients)
                            {
                                myTCPClient = this.myTcpListener.AcceptTcpClient();
                            }
                            else
                            {
                                System.Threading.Thread.Sleep(2000);
                                continue;
                            }

                            // check for the first available free channel in array
                            int x = -1;
                            for (int i = 0; i < this.Channels.Count(); i++)
                            {
                                if (this.Channels[i] == null)
                                {
                                    x = i;
                                    break;
                                }
                            }
                            //if (x == -1) throw new Exception("Channel request refused. All channels (" + MaxNoOfClients + ") are already in use");

                            IEC104Channel myIEC104Channel = new IEC104Channel(this, myIECDatabase, myTCPClient, x);
                            Channels[x] = myIEC104Channel;

                            System.Threading.Thread myTcpClientThread = new System.Threading.Thread(myIEC104Channel.Work);
                            myTcpClientThread.IsBackground = true;
                            myTcpClientThread.Name = "IEC104_Channel_" + x.ToString();
                            //clientThread[x] = myTcpClientThread;      // sets new thread to the array of client threads
                            myTcpClientThread.Start();
                        }
                        catch (Exception ex)
                        {
                            //System.Windows.Forms.MessageBox.Show(ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                            RunThread = false;
                        }
                        break;


                    default:
                        break;      // break the loop and close this program if unknown Step value
                }
            }
        }
        #endregion THREAD "ListenForClients"

    }

    #region ENUMERATIONS

    /// <summary>
    /// IEC data point type identifier
    /// </summary>
    enum TypeID : byte
    {
        /// <summary>
        /// Single-point information
        /// </summary>
        M_SP_NA_1 = 1,
        /// <summary>
        /// Single-point information with time tag
        /// </summary>
        M_SP_TA_1 = 2,
        /// <summary>
        /// Double-point information
        /// </summary>
        M_DP_NA_1 = 3,
        /// <summary>
        /// Double-point information with time tag
        /// </summary>
        M_DP_TA_1 = 4,
        /// <summary>
        /// Step position information
        /// </summary>
        M_ST_NA_1 = 5,
        /// <summary>
        /// Step position information with time tag
        /// </summary>
        M_ST_TA_1 = 6,
        /// <summary>
        /// Bitstring of 32 bit
        /// </summary>
        M_BO_NA_1 = 7,
        /// <summary>
        /// Bitstring of 32 bit with time tag
        /// </summary>
        M_BO_TA_1 = 8,
        /// <summary>
        /// Measured value, normalised value
        /// </summary>
        M_ME_NA_1 = 9,
        /// <summary>
        /// Measured value, normalized value with time tag
        /// </summary>
        M_ME_TA_1 = 10,
        /// <summary>
        /// Measured value, scaled value
        /// </summary>
        M_ME_NB_1 = 11,
        /// Measured value, scaled value wit time tag
        /// </summary>
        M_ME_TB_1 = 12,
        /// <summary>
        /// Measured value, short floating point number
        /// </summary>
        M_ME_NC_1 = 13,
        /// <summary>
        /// Measured value, short floating point number with time tag
        /// </summary>
        M_ME_TC_1 = 14,

        /// <summary>
        /// Integrated totals (15)
        /// </summary>
        M_IT_NA_1 = 15,
        /// <summary>
        /// Integrated totals with time tag (16)
        /// </summary>
        M_IT_TA_1 = 16,
        /// <summary>
        /// Event of protection equipment with time tag (17)
        /// </summary>
        M_EP_TA_1 = 17,
        /// <summary>
        /// Packed start events of protection equipment with time tag (18)
        /// </summary>
        M_EP_TB_1 = 18,
        /// <summary>
        /// Packed output circuit information of protection equipment with time tag (19)
        /// </summary>
        M_EP_TC_1 = 19,
        /// <summary>
        /// Packed single point information with status change detection (20)
        /// </summary>
        M_PS_NA_1 = 20,
        /// <summary>
        /// Measured value, normalized value without quality descriptor (21)
        /// </summary>
        M_ME_ND_1 = 21,

        /// <summary>
        /// Single-point information with time tag CP56Time2a (30)
        /// </summary>
        M_SP_TB_1 = 30,
        /// <summary>
        /// Double-point information with time tag CP56Time2a (31)
        /// </summary>
        M_DP_TB_1 = 31,
        /// <summary>
        /// Step position information with time tag CP56Time2a (32)
        /// </summary>
        M_ST_TB_1 = 32,
        /// <summary>
        /// Bitstring of 32 bit with time tag CP56Time2a (33)
        /// </summary>
        M_BO_TB_1 = 33,
        /// <summary>
        /// Measured value, normalised value with time tag CP56Time2a (34)
        /// </summary>
        M_ME_TD_1 = 34,
        /// <summary>
        /// Measured value, scaled value with time tag CP56Time2a (35)
        /// </summary>
        M_ME_TE_1 = 35,
        /// <summary>
        /// Measured value, short floating point number with time tag CP56Time2a (36)
        /// </summary>
        M_ME_TF_1 = 36,
        /// <summary>
        /// Integrated totals with time tag CP56Time2a (37)
        /// </summary>
        M_IT_TB_1 = 37,
        /// <summary>
        /// Event of protection equipment with time tag CP56Time2a (38)
        /// </summary>
        M_EP_TD_1 = 38,
        /// <summary>
        /// Packed start events of protection equipment with time tag CP56Time2a (39)
        /// </summary>
        M_EP_TE_1 = 39,
        /// <summary>
        /// Packed output circuit information of protection equipment with time tag CP56Time2a (40)
        /// </summary>
        M_EP_TF_1 = 40,

        /// <summary>
        /// Single command (45)
        /// </summary>
        C_SC_NA_1 = 45,
        /// <summary>
        /// Double command (46)
        /// </summary>
        C_DC_NA_1 = 46,
        /// <summary>
        /// Regulating step command (47)
        /// </summary>
        C_RC_NA_1 = 47,
        /// <summary>
        /// Set-point Command, normalised value (48)
        /// </summary>
        C_SE_NA_1 = 48,
        /// <summary>
        /// Set-point Command, scaled value (49)
        /// </summary>
        C_SE_NB_1 = 49,
        /// <summary>
        /// Set-point Command, short floating point number (50)
        /// </summary>
        C_SE_NC_1 = 50,
        /// <summary>
        /// Bitstring 32 bit command (51)
        /// </summary>
        C_BO_NA_1 = 51,

        /// <summary>
        /// Single command with time tag CP56Time2a (58)
        /// </summary>
        C_SC_TA_1 = 58,
        /// <summary>
        /// Double command with time tag CP56Time2a (59)
        /// </summary>
        C_DC_TA_1 = 59,
        /// <summary>
        /// Regulating step command with time tag CP56Time2a (60)
        /// </summary>
        C_RC_TA_1 = 60,
        /// <summary>
        /// Measured value, normalised value command with time tag CP56Time2a (61)
        /// </summary>
        C_SE_TA_1 = 61,
        /// <summary>
        /// Measured value, scaled value command with time tag CP56Time2a (62)
        /// </summary>
        C_SE_TB_1 = 62,
        /// <summary>
        /// Measured value, short floating point number command with time tag CP56Time2a (63)
        /// </summary>
        C_SE_TC_1 = 63,
        /// <summary>
        /// Bitstring of 32 bit command with time tag CP56Time2a (64)
        /// </summary>
        C_BO_TA_1 = 64,

        /// <summary>
        /// End of Initialisation (70)
        /// </summary>
        M_EI_NA_1 = 70,

        /// <summary>
        /// Interrogation command (100)
        /// </summary>
        C_IC_NA_1 = 100,
        /// <summary>
        /// Counter interrogation command (101)
        /// </summary>
        C_CI_NA_1 = 101,
        /// <summary>
        /// Read Command (102)
        /// </summary>
        C_RD_NA_1 = 102,
        /// <summary>
        /// Clock synchronisation command (103)
        /// </summary>
        C_CS_NA_1 = 103,
        /// <summary>
        /// Test command (104)
        /// </summary>
        C_TS_NA_1 = 104,
        /// <summary>
        /// Reset process command (105)
        /// </summary>
        C_RP_NA_1 = 105,
        /// <summary>
        /// C_CD_NA_1 Delay acquisition command (106)
        /// </summary>
        C_CD_NA_1 = 106,
        /// <summary>
        /// Test command with time tag CP56Time2a (107)
        /// </summary>
        C_TS_TA_1 = 107,

        /// <summary>
        /// Parameter of measured values, normalized value (110)
        /// </summary>
        P_ME_NA_1 = 110,
        /// <summary>
        /// Parameter of measured values, scaled value (111)
        /// </summary>
        P_ME_NB_1 = 111,
        /// <summary>
        /// Parameter of measured values, short floating point number (112)
        /// </summary>
        P_ME_NC_1 = 112,
        /// <summary>
        /// Parameter activation (113)
        /// </summary>
        P_AC_NA_1 = 113,

        /// <summary>
        /// File ready (120)
        /// </summary>
        F_FR_NA_1 = 120,
        /// <summary>
        /// Section ready (121)
        /// </summary>
        F_SR_NA_1 = 121,
        /// <summary>
        /// Call directory, select file, call file, call section (122)
        /// </summary>
        F_SC_NA_1 = 122,
        /// <summary>
        /// Last section, last segment (123)
        /// </summary>
        F_LS_NA_1 = 123,
        /// <summary>
        /// ACK file, ACK section (124)
        /// </summary>
        F_FA_NA_1 = 124,
        /// <summary>
        /// Segment (125)
        /// </summary>
        F_SG_NA_1 = 125,
        /// <summary>
        /// Directory (126)
        /// </summary>
        F_DR_TA_1 = 126
        /// <summary>
        /// Query log - request archive file (127)
        /// </summary>
        //F_SC_NB_1 = 127
    }

    /// <summary>
    /// IEC Cause of transfer
    /// </summary>
    enum COTType : byte
    {
        /// <summary>
        /// Not used (0)
        /// </summary>
        eIEC870_COT_UNUSED = 0,
        /// <summary>
        /// Cyclic data (1)
        /// </summary>
        eIEC870_COT_CYCLIC = 1,
        /// <summary>
        /// Background request (2)
        /// </summary>
        eIEC870_COT_BACKGROUND = 2,
        /// <summary>
        /// Spontaneous data (3)
        /// </summary>
        eIEC870_COT_SPONTAN = 3,
        /// <summary>
        /// End of initialisation (4)
        /// </summary>
        eIEC870_COT_INIT = 4,
        /// <summary>
        /// Read-Request (5)
        /// </summary>
        eIEC870_COT_REQ = 5,
        /// <summary>
        /// Command activation (6)
        /// </summary>
        eIEC870_COT_ACT = 6,
        /// <summary>
        /// Acknowledgement of command activation (7)
        /// </summary>
        eIEC870_COT_ACT_CON = 7,
        /// <summary>
        /// Command abort (8)
        /// </summary>
        eIEC870_COT_DEACT = 8,
        /// <summary>
        /// Acknowledgement of command activation (9)
        /// </summary>
        eIEC870_COT_DEACT_CON = 9,
        /// <summary>
        /// Termination of command activation (10)
        /// </summary>
        eIEC870_COT_ACT_TERM = 10,
        /// <summary>
        /// Return because of remote command (11)
        /// </summary>
        eIEC870_COT_RETREM = 11,
        /// <summary>
        /// Return because of local command (12)
        /// </summary>
        eIEC870_COT_RETLOC = 12,
        /// <summary>
        /// File access (13)
        /// </summary>
        eIEC870_COT_FILE = 13,
        /// <summary>
        /// Reserved/not used (14)
        /// </summary>
        eIEC870_COT_14 = 14,
        /// <summary>
        /// Reserved/not used (15)
        /// </summary>
        eIEC870_COT_15 = 15,
        /// <summary>
        /// Reserved/not used (16)
        /// </summary>
        eIEC870_COT_16 = 16,
        /// <summary>
        /// Reserved/not used (17)
        /// </summary>
        eIEC870_COT_17 = 17,
        /// <summary>
        /// Reserved/not used (18)
        /// </summary>
        eIEC870_COT_18 = 18,
        /// <summary>
        /// Reserved/not used (19)
        /// </summary>
        eIEC870_COT_19 = 19,
        /// <summary>
        /// Station interrogation (general) (20)
        /// </summary>
        eIEC870_COT_INROGEN = 20,
        /// <summary>
        /// Station interrogation of group 1 (21)
        /// </summary>
        eIEC870_COT_INRO1 = 21,
        /// <summary>
        /// Station interrogation of group 2 (22)
        /// </summary>
        eIEC870_COT_INRO2 = 22,
        /// <summary>
        /// Station interrogation of group 3 (23)
        /// </summary>
        eIEC870_COT_INRO3 = 23,
        /// <summary>
        /// Station interrogation of group 4 (24)
        /// </summary>
        eIEC870_COT_INRO4 = 24,
        /// <summary>
        /// Station interrogation of group 5 (25)
        /// </summary>
        eIEC870_COT_INRO5 = 25,
        /// <summary>
        /// Station interrogation of group 6 (26)
        /// </summary>
        eIEC870_COT_INRO6 = 26,
        /// <summary>
        /// Station interrogation of group 7 (27)
        /// </summary>
        eIEC870_COT_INRO7 = 27,
        /// <summary>
        /// Station interrogation of group 8 (28)
        /// </summary>
        eIEC870_COT_INRO8 = 28,
        /// <summary>
        /// Station interrogation of group 9 (29)
        /// </summary>
        eIEC870_COT_INRO9 = 29,
        /// <summary>
        /// Station interrogation of group 10 (30)
        /// </summary>
        eIEC870_COT_INRO10 = 30,
        /// <summary>
        /// Station interrogation of group 11 (31)
        /// </summary>
        eIEC870_COT_INRO11 = 31,
        /// <summary>
        /// Station interrogation of group 12 (32)
        /// </summary>
        eIEC870_COT_INRO12 = 32,
        /// <summary>
        /// Station interrogation of group 13 (33)
        /// </summary>
        eIEC870_COT_INRO13 = 33,
        /// <summary>
        /// Station interrogation of group 14 (34)
        /// </summary>
        eIEC870_COT_INRO14 = 34,
        /// <summary>
        /// Station interrogation of group 15 (35)
        /// </summary>
        eIEC870_COT_INRO15 = 35,
        /// <summary>
        /// Station interrogation of group 16 (36)
        /// </summary>
        eIEC870_COT_INRO16 = 36,
        /// <summary>
        /// Counter request (general) (37)
        /// </summary>
        eIEC870_COT_REQCOGEN = 37,
        /// <summary>
        /// Counter request of group 1 (38)
        /// </summary>
        eIEC870_COT_REQCO1 = 38,
        /// <summary>
        /// Counter request of group 2 (39)
        /// </summary>
        eIEC870_COT_REQCO2 = 39,
        /// <summary>
        /// Counter request of group 3 (40)
        /// </summary>
        eIEC870_COT_REQCO3 = 40,
        /// <summary>
        /// Counter request of group 4 (41)
        /// </summary>
        eIEC870_COT_REQCO4 = 41,
        /// <summary>
        /// Reserved/not used (42)
        /// </summary>
        eIEC870_COT_42 = 42,
        /// <summary>
        /// Reserved/not used (43)
        /// </summary>
        eIEC870_COT_43 = 43,
        /// <summary>
        /// Unknown type (44)
        /// </summary>
        eIEC870_COT_UNKNOWN_TYPE = 44,
        /// <summary>
        /// Unknown transmission cause (45)
        /// </summary>
        eIEC870_COT_UNKNOWN_CAUSE = 45,
        /// <summary>
        /// Unknown collective ASDU (46)
        /// </summary>
        eIEC870_COT_UNKNOWN_ASDU_ADDRESS = 46,
        /// <summary>
        /// Unknown object address (47)
        /// </summary>
        eIEC870_COT_UNKNOWN_OBJECT_ADDRESS = 47,
        /// <summary>
        /// Reserved/not used (48)
        /// </summary>
        eIEC870_COT_48 = 48,
        /// <summary>
        /// Reserved/not used (49)
        /// </summary>
        eIEC870_COT_49 = 49,
        /// <summary>
        /// Reserved/not used (50)
        /// </summary>
        eIEC870_COT_50 = 50,
        /// <summary>
        /// Reserved/not used (51)
        /// </summary>
        eIEC870_COT_51 = 51,
        /// <summary>
        /// Reserved/not used (52)
        /// </summary>
        eIEC870_COT_52 = 52,
        /// <summary>
        /// Reserved/not used (53)
        /// </summary>
        eIEC870_COT_53 = 53,
        /// <summary>
        /// Reserved/not used (54)
        /// </summary>
        eIEC870_COT_54 = 54,
        /// <summary>
        /// Reserved/not used (55)
        /// </summary>
        eIEC870_COT_55 = 55,
        /// <summary>
        /// Reserved/not used (56)
        /// </summary>
        eIEC870_COT_56 = 56,
        /// <summary>
        /// Reserved/not used (57)
        /// </summary>
        eIEC870_COT_57 = 57,
        /// <summary>
        /// Reserved/not used (58)
        /// </summary>
        eIEC870_COT_58 = 58,
        /// <summary>
        /// Reserved/not used (59)
        /// </summary>
        eIEC870_COT_59 = 59,
        /// <summary>
        /// Reserved/not used (60)
        /// </summary>
        eIEC870_COT_60 = 60,
        /// <summary>
        /// Reserved/not used (61)
        /// </summary>
        eIEC870_COT_61 = 61,
        /// <summary>
        /// Reserved/not used (62)
        /// </summary>
        eIEC870_COT_62 = 62,
        /// <summary>
        /// Reserved/not used (63)
        /// </summary>
        eIEC870_COT_63 = 63
    }

    enum IEC104_ServerStatus : int
    {
        STOPPED = 0,
        STARTING = 1,
        ERROR_STARTING = 2,
        WAITING_RESTART = 3,
        RUNNING = 4
    }
    #endregion ENUMERATIONS
}
