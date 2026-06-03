using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using TK_ParkServer.Park;

namespace TK_ParkServer.Forms
{
    public partial class Form_Developer : Form
    {
        //Park_Server.Logging.Databases myDataLogs;

        bool updateLog1 = true;

        public Form_Developer()
        {
            InitializeComponent();
        }

        public void Test()
        {
            //myDataLogs = new Park_Server.Logging.Databases(Park_Server.Program.myPark);



            //// Set Access connection and select strings.
            //string strAccessConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\\..\\..\\Files\\Database1.MDB";

            //// Create the dataset and add the Categories table to it:
            //DataSet myDataSet = new DataSet();
            //OleDbConnection myAccessConn = null;
            //try
            //{
            //    myAccessConn = new OleDbConnection(strAccessConn);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error: Failed to create a database connection.\n" + ex.Message, "Error");
            //    return;
            //}

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
            //    MessageBox.Show("Error: Failed to retrieve the required data from the DataBase.\n" + ex.Message, "Error");
            //    return;
            //}

            //try
            //{
            //    DateTime time = DateTime.Now;
            //    double WindSpeed = 12.5;
            //    string strAccessInsert = "INSERT INTO T01 ([Time], [WindSpeed], [WindDirection], [ActivePower]) VALUES ('"+time+"','"+WindSpeed+"', 252, 257)";
            //    OleDbCommand myAccessCommand = new OleDbCommand(strAccessInsert, myAccessConn);
            //    myAccessCommand.ExecuteNonQuery();
            //    MessageBox.Show("Items added", "OK");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error: Failed to add data to the DataBase.\n" + ex.Message, "Error");
            //    return;
            //}
            //finally
            //{
            //    myAccessConn.Close();
            //}

            //// A dataset can contain multiple tables, so let's get them all into an array:
            //DataTableCollection dta = myDataSet.Tables;
            //foreach (DataTable dt in dta)
            //{
            //    MessageBox.Show("Found data table " + dt.TableName, "Output");
            //}

            //// The next two lines show two different ways you can get the count of tables in a dataset:
            //MessageBox.Show(myDataSet.Tables.Count + " tables in data set", "Output");
            //MessageBox.Show(dta.Count + " tables in data set", "Output");
            //// The next several lines show how to get information on a specific table by name from the dataset:
            //MessageBox.Show(myDataSet.Tables["T01"].Rows.Count + " rows in T01 table", "Output");
            //// The column info is automatically fetched from the database, so we can read it here:
            //MessageBox.Show(myDataSet.Tables["T01"].Columns.Count + " columns in T01 table", "Output");
            //DataColumnCollection drc = myDataSet.Tables["T01"].Columns;
            //int i = 0;
            //foreach (DataColumn dc in drc)
            //{
            //    // Print the column subscript, then the column's name and its data type:
            //    MessageBox.Show("Column name[" + i++ + "] is " + dc.ColumnName + " of type " + dc.DataType, "Output");
            //}
            //DataRowCollection dra = myDataSet.Tables["T01"].Rows;
            //foreach (DataRow dr in dra)
            //{
            //    // Print the CategoryID as a subscript, then the CategoryName:
            //    MessageBox.Show("CategoryName[" + dr[0] + "] is " + dr[1], "Output");
            //}

        }

        
        private void button5_Click(object sender, EventArgs e)
        {
            char Command;
            int Power;

            try
            {
                Command = textBox_Command.Text[0];
                Power = Convert.ToInt16(textBox_PowerSetpoint.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid input data - " + ex.Message, "Exception");
                return;
            }

            try
            {
                Program.myVestasController.TestCommand_1(1, Command, Power);
                MessageBox.Show("Setpoint sent", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            // clear setpoint textbox after procedure
            textBox_PowerSetpoint.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ushort numOfLogsToGet = 0;

            try
            {
                numOfLogsToGet = Convert.ToUInt16(textBox1.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Invalid input data", "Error");
            }

            try
            {
                List<Park.Log_Record> Alarm_Log = Program.myVestasController.Get_AlarmLog(1);
                textBox2.Text = Alarm_Log.Count().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }


        // refresh on-screen values
        private void timer1_Tick(object sender, EventArgs e)
        {
            label_LocalModeRequest_0.Text = ((VestasTurbine)Program.myPark.myTurbines[1]).LocalModeRequest.ToString();
        }
    }
}
