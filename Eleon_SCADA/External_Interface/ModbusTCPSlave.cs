//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using Modbus.Device;
//using Modbus.Data;
//using Modbus.Utility;

//namespace Park_Server.External_Interface
//{
//    class ModbusTCPSlave
//    {
//        public static System.Net.Sockets.TcpListener slaveTcpListener;
//        public static ModbusSlave myModSlave;
//        public static Thread ModbusSlaveThread;             // this thread runs modbus TCP slave
//        public static Thread InternalInterfaceThread;       // this thread manages internal data transmission/conversion between park/turbine and modbus


//        //public static void StartExternalInterface()
//        //{
//        //    if (Properties.ModbusSettings.AllowMasterAnyIP)
//        //    {
//        //        slaveTcpListener = new System.Net.Sockets.TcpListener(System.Net.IPAddress.Any, Properties.ModbusSettings.Port);
//        //    }
//        //    else
//        //    {
//        //        slaveTcpListener = new System.Net.Sockets.TcpListener(Properties.ModbusSettings.MasterIPaddress, Properties.ModbusSettings.Port);
//        //    }

//        //    slaveTcpListener.Start();
//        //    myModSlave = ModbusTcpSlave.CreateTcp(Properties.ModbusSettings.slaveID, slaveTcpListener);
//        //    myModSlave.DataStore = DataStoreFactory.CreateDefaultDataStore(1000, 1000, 1000, 1000);

//        //    ModbusSlaveThread = new Thread(myModSlave.Listen);
//        //    ModbusSlaveThread.IsBackground = true;
//        //    ModbusSlaveThread.Start();

//        //    InternalInterfaceThread = new Thread(InternalInterface);
//        //    InternalInterfaceThread.IsBackground = true;
//        //    InternalInterfaceThread.Start();
//        //}

//        public static void StopExternalInterface()
//        {
//            myModSlave.Dispose();
//            slaveTcpListener.Stop();
//            ModbusSlaveThread.Join(100);
//            InternalInterfaceThread.Join(100);
//        }

//        public static void InternalInterface()
//        {
//            for (int i = 1; i <= Program.myPark.NumOfTurbinesInPark; i++)
//            {
//                int x = i * 100;

//                myModSlave.DataStore.InputRegisters[x] = Convert.ToByte(Program.myPark.myTurbines[i].Status >> 8);
//                myModSlave.DataStore.InputRegisters[x + 1] = Convert.ToByte(Program.myPark.myTurbines[i].Status & 0xFF);
//                myModSlave.DataStore.InputRegisters[x + 2] = Convert.ToByte(Program.myPark.myTurbines[i].ActivePower);
//                myModSlave.DataStore.InputRegisters[x + 3] = Convert.ToByte(Program.myPark.myTurbines[i].WindSpeed_avg);
//                myModSlave.DataStore.InputRegisters[x + 4] = Convert.ToByte(Program.myPark.myTurbines[i].RPM_avg);
//                //ParkGateway.myModSlave.DataStore.InputRegisters[x + 5] = Convert.ToByte(ParkGateway.myPark.Turbines[i].Yaw);
//                //ParkGateway.myModSlave.DataStore.InputRegisters[x + 6] = Convert.ToByte(ParkGateway.myPark.Turbines[i].Production);
//                //ParkGateway.myModSlave.DataStore.InputRegisters[x + 7] = Convert.ToByte(ParkGateway.myPark.Turbines[i].Hours);
//            }
//        }
//    }
//}
