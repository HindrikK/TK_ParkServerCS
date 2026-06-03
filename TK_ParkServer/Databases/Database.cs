using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace TK_ParkServer.Logging
{
    class Databases
    {
        public System.Threading.Thread myLogger;
        Park.WindPark _Park;
        int[] Status_Code_prev;

        public DataSet[] myDataSets;
        public OleDbConnection[] myAccessConnections;
        public bool DatabaseConnected = false;
        public bool LoggingActive = false;

        string strAccessConn;

        public Databases(Park.WindPark _park)
        {
            _Park = _park;
            Status_Code_prev = new int[_Park.NumOfTurbinesInPark + 1];
            for (int i = 1; i <= _Park.NumOfTurbinesInPark; i++)
            {
                Status_Code_prev[i] = _Park.myTurbines[i].StatusCode;
            }

            myAccessConnections = new OleDbConnection[TK_ParkServer.Program.myPark.NumOfTurbinesInPark + 1];

            try
            {
                Connect();
            }
            catch (Exception ex)
            {
                throw new Exception("Error opening database:\n" + ex.Message);
            }


            // creates datasets for all databases and creates additional tables in datasets
            myDataSets = new DataSet[TK_ParkServer.Program.myPark.NumOfTurbinesInPark + 1];
            myDataSets[0] = new DataSet("Park");
            myDataSets[0].Tables.Add("Production");
            for (int i = 1; i <= _Park.NumOfTurbinesInPark; i++)
            {
                myDataSets[i] = new DataSet(Program.myPark.myTurbines[i].TurbineName);
                myDataSets[i].Tables.Add("Production");
                //myDataSets[i].Tables["Production"].Columns.Add("ID");
                myDataSets[i].Tables["Production"].Columns.Add("Time");
                myDataSets[i].Tables["Production"].Columns.Add("Production");
            }



            //// add data tables to the dataset
            //for (int i = 0; i < _Park.NumOfTurbinesInPark; i++)
            //{
            //    myDataSet.Tables.Add(new DataTable(Program.myPark.myTurbines[i].TurbineName + "_Status"));
            //    myDataSet.Tables[Program.myPark.myTurbines[i].TurbineName + "_Status"].Clear();
            //}
        }

        /// <summary>
        /// Connect to databases
        /// </summary>
        public void Connect()
        {
            for (int i = 1; i <= _Park.NumOfTurbinesInPark; i++)
            {
                try
                {
                    strAccessConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
                    TK_ParkServer.Settings.Database.Path + _Park.myTurbines[i].TurbineName + ".mdb";

                    myAccessConnections[i] = new OleDbConnection(strAccessConn);
                    myAccessConnections[i].Open();
                    DatabaseConnected = true;
                }
                catch (Exception ex)
                {
                    DatabaseConnected = false;
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Starts time triggerred logging of data
        /// </summary>
        public void StartLogging()
        {
            if (DatabaseConnected)
            {
                // start new thread for logging values
                myLogger = new System.Threading.Thread(Logging);
                myLogger.IsBackground = true;
                myLogger.Start();
            }
            else
            {
                throw new Exception("Some database closed. Open all databases first");
            }
        }

        #region THREAD "Logging"
        private void Logging()
        {
            System.Timers.Timer myLogData1Timer = new System.Timers.Timer();
            myLogData1Timer.Elapsed += myLogData1Timer_Elapsed;
            myLogData1Timer.Interval = TK_ParkServer.Settings.Database.SampleTime;
            myLogData1Timer.Start();

            System.Timers.Timer myLogData2Timer = new System.Timers.Timer();
            myLogData2Timer.Elapsed += myLogData2Timer_Elapsed;
            myLogData2Timer.Interval = 900000;  // 15 min
            myLogData2Timer.Start();

            // Start timer for checking status values
            System.Timers.Timer myLogStatusTimer = new System.Timers.Timer();
            myLogStatusTimer.Elapsed += myLogStatusTimer_Elapsed;
            myLogStatusTimer.Interval = 500;
            myLogStatusTimer.Start();

            LoggingActive = true;
        }

        private void myLogData1Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (LoggingActive && Program.myVestasController.PortIsOpen)
            {
                try
                {
                    WriteData1();
                }
                catch (Exception ex)
                {
                    //LoggingActive = false;
                    Program.myAlarmDispatch.SendAnnouncement(TK_ParkServer.Settings.AlarmAnnouncement.DefaultAddress, "Program exception\n\nDatabase - myLogData1Timer_Elapsed\n\n" + ex.Message);
                    //System.Windows.Forms.MessageBox.Show("Logging disabled.\n" + ex.Message, "Error");
                }
            }
        }

        private void myLogData2Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (LoggingActive && Program.myVestasController.PortIsOpen)
            {
                try
                {
                    WriteData2();
                }
                catch (Exception ex)
                {
                    //LoggingActive = false;
                    Program.myAlarmDispatch.SendAnnouncement(TK_ParkServer.Settings.AlarmAnnouncement.DefaultAddress, "Program exception\n\nDatabase - myLogData2Timer_Elapsed\n\n" + ex.Message);
                    //System.Windows.Forms.MessageBox.Show("Logging disabled.\n" + ex.Message, "Error");
                }
            }
        }

        private void myLogStatusTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (LoggingActive && Program.myVestasController.PortIsOpen)
            {
                try
                {
                    for (int i = 1; i <= _Park.NumOfTurbinesInPark; i++)
                    {
                        if (_Park.myTurbines[i].StatusCode != Status_Code_prev[i])
                        {
                            try { WriteStatus(i, _Park.myTurbines[i].StatusCode); }
                            catch { }
                        }
                        Status_Code_prev[i] = _Park.myTurbines[i].StatusCode;
                    }
                }
                catch (Exception ex)
                {
                    Program.myAlarmDispatch.SendAnnouncement(TK_ParkServer.Settings.AlarmAnnouncement.DefaultAddress, "Program exception\n\nDatabase - myLogStatusTimer_Elapsed\n\n" + ex.Message);
                }
            }
        }
        #endregion THREAD "Logging"

        /// <summary>
        /// Writes new log data(data1) of all turbines
        /// </summary>
        public void WriteData1()
        {

            //// get the table "T01"
            //try
            //{
            //    string strAccessSelect = "SELECT * FROM T01";
            //    OleDbCommand myAccessCommand = new OleDbCommand(strAccessSelect, myAccessConn);
            //    OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

            //    myAccessConn.Open();
            //    myDataAdapter.Fill(myDataSet, "T01");

            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}

            for (int i = 1; i <= TK_ParkServer.Program.myPark.NumOfTurbinesInPark; i++)
            {
                TableAdapters.Data_1_TableAdapter.InsertRecord(i);
            }


            // A dataset can contain multiple tables, so let's get them all into an array:
            //DataTableCollection dta = myDataSet.Tables;
            //foreach (DataTable dt in dta)
            //{
                //MessageBox.Show("Found data table " + dt.TableName, "Output");
            //}

            // The next two lines show two different ways you can get the count of tables in a dataset:
            //MessageBox.Show(myDataSet.Tables.Count + " tables in data set", "Output");
            //MessageBox.Show(dta.Count + " tables in data set", "Output");
            // The next several lines show how to get information on a specific table by name from the dataset:
            //MessageBox.Show(myDataSet.Tables["T01"].Rows.Count + " rows in T01 table", "Output");
            // The column info is automatically fetched from the database, so we can read it here:
            //MessageBox.Show(myDataSet.Tables["T01"].Columns.Count + " columns in T01 table", "Output");
            //DataColumnCollection drc = myDataSet.Tables["T01"].Columns;
            //int i = 0;
            //foreach (DataColumn dc in drc)
            //{
                // Print the column subscript, then the column's name and its data type:
            //    MessageBox.Show("Column name[" + i++ + "] is " + dc.ColumnName + " of type " + dc.DataType, "Output");
            //}
            //DataRowCollection dra = myDataSet.Tables["T01"].Rows;
            //foreach (DataRow dr in dra)
            //{
                // Print the CategoryID as a subscript, then the CategoryName:
            //    MessageBox.Show("CategoryName[" + dr[0] + "] is " + dr[1], "Output");
            //}

        }

        /// <summary>
        /// Writes new log data(data2) of all turbines
        /// </summary>
        public void WriteData2()
        {
            for (int i = 1; i <= TK_ParkServer.Program.myPark.NumOfTurbinesInPark; i++)
            {
                TableAdapters.Data_2_TableAdapter.InsertRecord(i);
            }
        }

        /// <summary>
        /// Writes new status data for turbine
        /// </summary>
        /// <param name="_ID">Turbine ID</param>
        /// <param name="_Status">Status code to write</param>
        public void WriteStatus(int _ID, int _Status)
        {
            TableAdapters.Status_TableAdapter.InsertRecord(_ID, _Status);
        }
    }
}


namespace TK_ParkServer.Logging.TableAdapters
{
    static class Status_TableAdapter
    {
        public static void Fill(int _ID)
        {
            if (Program.myDatabases.myDataSets[_ID].Tables["Status"] != null)
            {
                Program.myDatabases.myDataSets[_ID].Tables["Status"].Clear();
            }

            // get the table "Status" of specific turbine database
            try
            {
                string strAccessSelect = "SELECT * FROM Status"
                    + " ORDER BY Status.Time DESC";
                OleDbCommand myAccessCommand = new OleDbCommand(strAccessSelect, Program.myDatabases.myAccessConnections[_ID]);
                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

                //Program.myDatabases.myAccessConnections[_ID].Open();
                myDataAdapter.Fill(Program.myDatabases.myDataSets[_ID], "Status");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Fill_ByDate(int _ID, DateTime _FromDate, DateTime _ToDate)
        {
            if (Program.myDatabases.myDataSets[_ID].Tables["Status"] != null)
            {
                Program.myDatabases.myDataSets[_ID].Tables["Status"].Clear();
            }

            // get the table "Status" of specific turbine database
            try
            {
                string strAccessSelect = "SELECT * FROM Status WHERE Status.Time BETWEEN "
                    + _FromDate.ToOADate() + " AND " + (_ToDate.AddDays(1)).ToOADate()
                    + " ORDER BY Status.Time DESC";
                OleDbCommand myAccessCommand = new OleDbCommand(strAccessSelect, Program.myDatabases.myAccessConnections[_ID]);
                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

                //Program.myDatabases.myAccessConnections[_ID].Open();
                myDataAdapter.Fill(Program.myDatabases.myDataSets[_ID], "Status");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void InsertRecord(int _ID, int _Status)
        {
            DateTime time = DateTime.Now;

            try
            {
                string Status = _Status.ToString();

                string strAccessInsert = "INSERT INTO " + "Status" +
                    " ([Time], [Status]) VALUES ('" + time +
                    "','" + Status + "')";

                OleDbCommand myAccessCommand = new OleDbCommand(strAccessInsert, Program.myDatabases.myAccessConnections[_ID]);

                myAccessCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Error writing Status data of turbine T" + (_ID + 1).ToString("D2") + " to database:\n" + ex.Message);
            }
        }
    }

    static class Data_1_TableAdapter
    {
        public static void Fill(int _ID)
        {
            if (Program.myDatabases.myDataSets[_ID].Tables["Data_1"] != null)
            {
                Program.myDatabases.myDataSets[_ID].Tables["Data_1"].Clear();
            }

            try
            {
                string strAccessSelect = "SELECT * FROM Data_1";
                OleDbCommand myAccessCommand = new OleDbCommand(strAccessSelect, Program.myDatabases.myAccessConnections[_ID]);
                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

                //Program.myDatabases.myAccessConnections[_ID].Open();
                myDataAdapter.Fill(Program.myDatabases.myDataSets[_ID], "Data_1");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Fill_ByDate(int _ID, DateTime _FromDate, DateTime _ToDate)
        {
            if (Program.myDatabases.myDataSets[_ID].Tables["Data_1"] != null)
            {
                Program.myDatabases.myDataSets[_ID].Tables["Data_1"].Clear();
            }

            try
            {
                System.Globalization.NumberFormatInfo numFormat = new System.Globalization.NumberFormatInfo();
                numFormat.NumberDecimalSeparator = ".";
                string strAccessSelect = "SELECT * FROM Data_1 WHERE Time BETWEEN "
                    + _FromDate.ToOADate().ToString(numFormat) + " AND " + _ToDate.ToOADate().ToString(numFormat);
                OleDbCommand myAccessCommand = new OleDbCommand(strAccessSelect, Program.myDatabases.myAccessConnections[_ID]);
                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

                //Program.myDatabases.myAccessConnections[_ID].Open();
                myDataAdapter.Fill(Program.myDatabases.myDataSets[_ID], "Data_1");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void InsertRecord(int _ID)
        {
            string strAccessInsert;
            OleDbCommand myAccessCommand = new OleDbCommand();
            DateTime time = DateTime.Now;

            try
                {
                    myAccessCommand.Connection = Program.myDatabases.myAccessConnections[_ID];

                    strAccessInsert = "INSERT INTO " + "Data_1" +
                        " ([Time], [WindSpeed], [ActivePower]) VALUES ('" + time +
                        "','" + Program.myPark.myTurbines[_ID].WindSpeed +
                        "', '" + Program.myPark.myTurbines[_ID].ActivePower + "')";
                    myAccessCommand.CommandText = strAccessInsert;
                    myAccessCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error writing to database:\n" + ex.Message);
                }
        }
    }

    static class Data_2_TableAdapter
    {
        public static void Fill(int _ID)
        {
            if (Program.myDatabases.myDataSets[_ID].Tables["Data_2"] != null)
            {
                Program.myDatabases.myDataSets[_ID].Tables["Data_2"].Clear();
            }

            try
            {
                string strAccessSelect = "SELECT * FROM Data_2";
                OleDbCommand myAccessCommand = new OleDbCommand(strAccessSelect, Program.myDatabases.myAccessConnections[_ID]);
                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

                myDataAdapter.Fill(Program.myDatabases.myDataSets[_ID], "Data_2");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Fill_ByDate(int _ID, DateTime _FromDate, DateTime _ToDate)
        {
            if (Program.myDatabases.myDataSets[_ID].Tables["Data_2"] != null)
            {
                Program.myDatabases.myDataSets[_ID].Tables["Data_2"].Clear();
            }

            try
            {
                System.Globalization.NumberFormatInfo numFormat = new System.Globalization.NumberFormatInfo();
                numFormat.NumberDecimalSeparator = ".";
                string strAccessSelect = "SELECT * FROM Data_2 WHERE Time BETWEEN "
                    + _FromDate.ToOADate().ToString(numFormat) + " AND " + _ToDate.ToOADate().ToString(numFormat);
                OleDbCommand myAccessCommand = new OleDbCommand(strAccessSelect, Program.myDatabases.myAccessConnections[_ID]);
                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

                myDataAdapter.Fill(Program.myDatabases.myDataSets[_ID], "Data_2");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void GetProduction_ByDay(int _ID, DateTime _FromDate, DateTime _ToDate)
        {
            if (Program.myDatabases.myDataSets[_ID].Tables["Production"] != null)
            {
                Program.myDatabases.myDataSets[_ID].Tables["Production"].Clear();
            }

            DateTime datum = _FromDate;
            int month = _FromDate.Month;
            int day = _FromDate.Day;
            int dayCount = (_ToDate.Subtract(_FromDate)).Days + 1;
            int production;

            string strAccessSelect;
            OleDbCommand myAccessCommand;
            OleDbDataAdapter myDataAdapter;

            try
            {
                int y = 1;

                // get production data from database
                for (int i = 0; i < dayCount; i++)
                {
                    //System.Globalization.NumberFormatInfo numFormat = new System.Globalization.NumberFormatInfo();
                    //numFormat.NumberDecimalSeparator = ".";
                    //string strAccessSelect = "SELECT ID, Time, MONTH(Time) as DateMonth, Production FROM Data_2 WHERE Time BETWEEN "
                    //    + from.ToOADate().ToString(numFormat) + " AND " + to.ToOADate().ToString(numFormat);
                    strAccessSelect = "SELECT TOP 1 Time, Production FROM (SELECT ID, Time, Production FROM Data_2 WHERE DAY(Time) = " + datum.Day + " AND MONTH(Time) = "
                        + datum.Month + " AND YEAR(Time) = " + datum.Year + " ORDER BY Time ASC)";
                    myAccessCommand = new OleDbCommand(strAccessSelect, Program.myDatabases.myAccessConnections[_ID]);
                    myDataAdapter = new OleDbDataAdapter(myAccessCommand);
                    int x = myDataAdapter.Fill(Program.myDatabases.myDataSets[_ID], "Production_1");
                    if (x < 1)  // if nothing returned (no record with this date)
                    {
                        if ((i + 1) == dayCount)  // if already looked throught all the days
                        {
                            break;
                        }
                        else  // if not yet looked through all the days
                        {
                            y++;  // increase the number of missing days in a row
                        }
                    }
                    else
                    {
                        y = 1;  // reset to 1 when received something
                    }
                    datum = datum.AddDays(1);
                }
                datum = datum.AddDays(-y);
                strAccessSelect = "SELECT TOP 1 Time, Production FROM (SELECT ID, Time, Production FROM Data_2 WHERE DAY(Time) = " + datum.Day + " AND MONTH(Time) = "
                        + datum.Month + " AND YEAR(Time) = " + datum.Year + " ORDER BY Time DESC)";
                myAccessCommand = new OleDbCommand(strAccessSelect, Program.myDatabases.myAccessConnections[_ID]);
                myDataAdapter = new OleDbDataAdapter(myAccessCommand);
                myDataAdapter.Fill(Program.myDatabases.myDataSets[_ID], "Production_1");
            }
            catch (Exception ex)
            {
                throw ex;
            }


            // Fill final production data table for day view
            int j = 0;
            DateTime datum1 = new DateTime(_FromDate.Year, _FromDate.Month, _FromDate.Day);

            for (int i = 0; i < dayCount; i++)
            {
                try
                {
                    datum = (DateTime)Program.myDatabases.myDataSets[_ID].Tables["Production_1"].Rows[j]["Time"];
                    DateTime datum4 = new DateTime(datum.Year, datum.Month, datum.Day);  // make new datetime value where time part is 00:00:00
                    datum = datum4;  // now time part is 00:00:00
                }
                catch
                {
                    string date1 = datum1.Day + "." + datum1.Month + "." + datum1.Year;
                    Program.myDatabases.myDataSets[_ID].Tables["Production"].Rows.Add(date1, "No data");
                    datum1 = datum1.AddDays(1);
                    continue;
                }

                try
                {
                    while (true)
                    {
                        if (datum == datum1)  // check if data exists for this day
                        {
                            DateTime datum3 = ((DateTime)(Program.myDatabases.myDataSets[_ID].Tables["Production_1"].Rows[j + 1]["Time"])).AddDays(-1);
                            DateTime datum2 = new DateTime(datum3.Year, datum3.Month, datum3.Day);  // make new datetime value where time part is 00:00:00

                            if (datum2 <= datum1)  // check if it is the next day in the next record
                            {
                                production = ((int)Program.myDatabases.myDataSets[_ID].Tables["Production_1"].Rows[j + 1]["Production"]) -
                                ((int)Program.myDatabases.myDataSets[_ID].Tables["Production_1"].Rows[j]["Production"]);
                                string date1 = datum1.Day + "." + datum1.Month + "." + datum1.Year;
                                if (production < 0)
                                {
                                    Program.myDatabases.myDataSets[_ID].Tables["Production"].Rows.Add(date1, "Invalid data");
                                }
                                else
                                {
                                    Program.myDatabases.myDataSets[_ID].Tables["Production"].Rows.Add(date1, production);
                                }
                                datum1 = datum1.AddDays(1);
                                j++;
                                break;
                            }
                            else
                            {
                                string date1 = datum1.Day + "." + datum1.Month + "." + datum1.Year;
                                Program.myDatabases.myDataSets[_ID].Tables["Production"].Rows.Add(date1, "No data");
                                datum1 = datum1.AddDays(1);
                                i++;
                            }
                        }
                        else if (datum < datum1)
                        {
                            string date1 = datum1.Day + "." + datum1.Month + "." + datum1.Year;
                            Program.myDatabases.myDataSets[_ID].Tables["Production"].Rows.Add(date1, "No data");
                            datum1 = datum1.AddDays(1);
                            j++;
                            break;
                        }
                        else
                        {
                            string date1 = datum1.Day + "." + datum1.Month + "." + datum1.Year;
                            Program.myDatabases.myDataSets[_ID].Tables["Production"].Rows.Add(date1, "No data");
                            datum1 = datum1.AddDays(1);
                            i++;
                        }
                    }
                }
                catch
                {
                    string date1 = datum1.Day + "." + datum1.Month + "." + datum1.Year;
                    Program.myDatabases.myDataSets[_ID].Tables["Production"].Rows.Add(date1, "No data");
                    datum1 = datum1.AddDays(1);
                    j++;
                }
            }

            Program.myDatabases.myDataSets[_ID].Tables["Production_1"].Clear();

        }

        public static void GetProduction_ByMonth(int _ID, DateTime _FromDate, DateTime _ToDate)
        {
            if (Program.myDatabases.myDataSets[_ID].Tables["Production"] != null)
            {
                Program.myDatabases.myDataSets[_ID].Tables["Production"].Clear();
            }

            DateTime datum = new DateTime(_FromDate.Year, _FromDate.Month, 1);
            int month = _FromDate.Month;
            int production;
            int monthCount;

            // get the monthCount
            if (_FromDate.Year == _ToDate.Year)
            {
                monthCount = (_ToDate.Month - datum.Month) + 1;
            }
            else
            {
                int y = (_ToDate.Year - _FromDate.Year) - 1;
                monthCount = ((13 - _FromDate.Month) + _ToDate.Month) + y * 12;
            }

            string strAccessSelect;
            OleDbCommand myAccessCommand;
            OleDbDataAdapter myDataAdapter;

            try
            {
                int y = 1;

                // get production data from database
                for (int i = 0; i < monthCount; i++)
                {
                    System.Globalization.NumberFormatInfo numFormat = new System.Globalization.NumberFormatInfo();
                    strAccessSelect = "SELECT TOP 1 Time, Production FROM (SELECT ID, Time, Production FROM Data_2 WHERE MONTH(Time) = "
                        + datum.Month + " AND YEAR(Time) = " + datum.Year + " ORDER BY Time ASC)";
                    myAccessCommand = new OleDbCommand(strAccessSelect, Program.myDatabases.myAccessConnections[_ID]);
                    myDataAdapter = new OleDbDataAdapter(myAccessCommand);
                    int x = myDataAdapter.Fill(Program.myDatabases.myDataSets[_ID], "Production_1");
                    if (x < 1)  // if nothing returned (no record with this date)
                    {
                        if ((i + 1) == monthCount)  // if already looked throught all the months
                        { 
                            break;
                        }
                        else  // if not yet looked through all the months
                        {
                            y++;  // increase the number of missing months in a row
                        }
                    }
                    else
                    {
                        y = 1;  // reset to 1 when received something
                    }
                    datum = datum.AddMonths(1);
                }
                datum = datum.AddMonths(-y);
                strAccessSelect = "SELECT TOP 1 Time, Production FROM (SELECT ID, Time, Production FROM Data_2 WHERE MONTH(Time) = "
                        + datum.Month + " ORDER BY Time DESC)";
                myAccessCommand = new OleDbCommand(strAccessSelect, Program.myDatabases.myAccessConnections[_ID]);
                myDataAdapter = new OleDbDataAdapter(myAccessCommand);
                myDataAdapter.Fill(Program.myDatabases.myDataSets[_ID], "Production_1");
            }
            catch (Exception ex)
            {
                throw ex;
            }


            // Fill final production data table for month view
            int j = 0;
            DateTime datum1 = new DateTime(_FromDate.Year, _FromDate.Month, 1);
            for (int i = 0; i < monthCount; i++)
            {
                try
                {
                    datum = (DateTime)Program.myDatabases.myDataSets[_ID].Tables["Production_1"].Rows[j]["Time"];
                    DateTime datum4 = new DateTime(datum.Year, datum.Month, 1);  // make new datetime value where day is 1 and time part is 00:00:00
                    datum = datum4;  // now day is 1 and time part is 00:00:00
                }
                catch
                {
                    string date1 = datum1.Month + "." + datum1.Year;
                    Program.myDatabases.myDataSets[_ID].Tables["Production"].Rows.Add(date1, "No data");
                    datum1 = datum1.AddMonths(1);
                    continue;
                }

                try
                {
                    while (true)
                    {
                        if (datum == datum1)  // check if data exists for this month
                        {
                            DateTime datum3 = ((DateTime)(Program.myDatabases.myDataSets[_ID].Tables["Production_1"].Rows[j + 1]["Time"])).AddMonths(-1);
                            DateTime datum2 = new DateTime(datum3.Year, datum3.Month, 1);  // make new datetime value where day is 1 and time part is 00:00:00

                            if (datum2 <= datum1)  // check if it is the next month in the next record
                            {
                                production = ((int)Program.myDatabases.myDataSets[_ID].Tables["Production_1"].Rows[j + 1]["Production"]) -
                                ((int)Program.myDatabases.myDataSets[_ID].Tables["Production_1"].Rows[j]["Production"]);
                                string date1 = datum1.Month + "." + datum1.Year;
                                if (production < 0)
                                {
                                    Program.myDatabases.myDataSets[_ID].Tables["Production"].Rows.Add(date1, "Invalid data");
                                }
                                else
                                {
                                    Program.myDatabases.myDataSets[_ID].Tables["Production"].Rows.Add(date1, production);
                                }
                                datum1 = datum1.AddMonths(1);
                                j++;
                                break;
                            }
                            else
                            {
                                string date1 = datum1.Month + "." + datum1.Year;
                                Program.myDatabases.myDataSets[_ID].Tables["Production"].Rows.Add(date1, "No data");
                                datum1 = datum1.AddMonths(1);
                                i++;
                            }
                        }
                        else if (datum < datum1)
                        {
                            string date1 = datum1.Month + "." + datum1.Year;
                            Program.myDatabases.myDataSets[_ID].Tables["Production"].Rows.Add(date1, "No data");
                            datum1 = datum1.AddMonths(1);
                            j++;
                            break;
                        }
                        else
                        {
                            string date1 = datum1.Month + "." + datum1.Year;
                            Program.myDatabases.myDataSets[_ID].Tables["Production"].Rows.Add(date1, "No data");
                            datum1 = datum1.AddMonths(1);
                            i++;
                        }
                    }
                }
                catch
                {
                    string date1 = datum1.Month + "." + datum1.Year;
                    Program.myDatabases.myDataSets[_ID].Tables["Production"].Rows.Add(date1, "No data");
                    datum1 = datum1.AddMonths(1);
                    j++;
                }
            }

            Program.myDatabases.myDataSets[_ID].Tables["Production_1"].Clear();

        }

        public static void InsertRecord(int _ID)
        {
            string strAccessInsert;
            OleDbCommand myAccessCommand = new OleDbCommand();
            DateTime time = DateTime.Now;

            try
            {
                myAccessCommand.Connection = Program.myDatabases.myAccessConnections[_ID];

                strAccessInsert = "INSERT INTO " + "Data_2" +
                    " ([Time], [YawPosition], [Hours], [Production]) VALUES ('" + time +
                    "', '" + Program.myPark.myTurbines[_ID].NacellePosition +
                    "', '" + Program.myPark.myTurbines[_ID].TotalHours +
                    "', '" + Program.myPark.myTurbines[_ID].TotalActiveProduction + "')";
                myAccessCommand.CommandText = strAccessInsert;
                myAccessCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error writing to database:\n" + ex.Message);
            }
        }
    }

    static class Park_TableAdapter
    {
        public static void GetProduction_ByMonth(DateTime _FromDate, DateTime _ToDate)
        {
            //DataTable productionTable = new DataTable();
            //productionTable.Columns.Add("ID");
            //productionTable.Columns.Add("Month");
            //productionTable.Columns.Add("Production");
            //try
            //{
                
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }
    }
}