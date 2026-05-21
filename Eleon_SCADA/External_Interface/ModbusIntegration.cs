using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using ModbusServerCS;

namespace Eleon_SCADA
{
    static class ModbusRegisters
    {
        public static ushort ParkStatus = 0;
        public static ushort Turbine1Status = 0;
        public static int TotalEnergy = 0;
    }

    class ModbusIntegration
    {
        private readonly CancellationTokenSource stopCts = new CancellationTokenSource();
        private readonly ModbusServer server;
        private Task serverTask;

        public ModbusIntegration()
        {
            var database = new ModbusDatabase();
            CreateRegisterMap(database);

            server = new ModbusServer(database, CreateOptions());
            server.ConnectionOpened += server_ConnectionOpened;
            server.ConnectionClosed += server_ConnectionClosed;
            server.ConnectionRefused += server_ConnectionRefused;
        }

        public IReadOnlyList<ModbusConnectionInfo> GetActiveConnections()
        {
            return server.GetActiveConnections();
        }

        public void Start()
        {
            if (!Licensing.CheckLicense())
            {
                throw new Exception("Market Interface server disabled - No license");
            }

            if (serverTask != null)
            {
                return;
            }

            MarketInterfaceLog.Add("Market Interface server started.");

            serverTask = Task.Run(async () =>
            {
                try
                {
                    await server.StartAsync(stopCts.Token);
                }
                catch (OperationCanceledException)
                {
                }
                catch (Exception ex)
                {
                    MarketInterfaceLog.Add("Market Interface server stopped unexpectedly: " + ex.Message);
                    Debug.WriteLine("Modbus server stopped: " + ex.Message);
                }
            });
        }

        public void Stop()
        {
            stopCts.Cancel();

            try
            {
                server.StopAsync().Wait(1000);
            }
            catch
            {
            }

            try
            {
                if (serverTask != null)
                {
                    serverTask.Wait(1000);
                }
            }
            catch
            {
            }

            MarketInterfaceLog.Add("Market Interface server stopped.");
        }

        private void CreateRegisterMap(ModbusDatabase database)
        {
            ModbusApi.CreateHoldingRegister(database, 100, ReadMarketActivePowerSetpointMw, WriteMarketActivePowerSetpointMw);
            ModbusApi.CreateHoldingRegister(database, 101, ReadMarketActivePowerSetpointPct, WriteMarketActivePowerSetpointPct);

            ModbusApi.CreateInputRegister(database, 500, () => ModbusRegisters.ParkStatus);
            ModbusApi.CreateInputRegister(database, 501, () => ToInt16Register((int)Math.Round(Program.myPark.ActivePower / 100.0)));
            ModbusApi.CreateInputRegister(database, 502, () => ToUInt16Register(Program.myPark.WindSpeed * 10));

            ModbusApi.CreateInputRegister(database, 1000, () => ModbusRegisters.Turbine1Status);
            ModbusApi.CreateInputRegister(database, 1001, () => ToInt16Register(GetTurbine1ActivePower()));
            ModbusApi.CreateInputRegister(database, 1002, () => ToUInt16Register(GetTurbine1WindSpeed() * 10));
        }

        private ModbusServerOptions CreateOptions()
        {
            return new ModbusServerOptions
            {
                IpAddress = IPAddress.Parse(Settings.MarketInterface.IpAddress),
                UdpPort = Settings.MarketInterface.UdpPort,
                TcpPort = Settings.MarketInterface.TcpPort,
                UdpEnable = Settings.MarketInterface.UdpEnable,
                TcpEnable = Settings.MarketInterface.TcpEnable,
                MaxActiveConnections = Settings.MarketInterface.MaxActiveConnections,
                ConnStaleTimeout = TimeSpan.FromSeconds(Settings.MarketInterface.ConnStaleTimeout),
                ResponseRateLimit = TimeSpan.FromMilliseconds(Settings.MarketInterface.ResponseRateLimit)
            };
        }

        private static ushort ToInt16Register(int value)
        {
            if (value > short.MaxValue)
            {
                value = short.MaxValue;
            }
            else if (value < short.MinValue)
            {
                value = short.MinValue;
            }

            return unchecked((ushort)(short)value);
        }

        private static ushort ToUInt16Register(float value)
        {
            if (value < ushort.MinValue)
            {
                value = ushort.MinValue;
            }
            else if (value > ushort.MaxValue)
            {
                value = ushort.MaxValue;
            }

            return (ushort)Math.Round(value);
        }

        private static ushort ReadMarketActivePowerSetpointMw()
        {
            return ToUInt16Register(ClampMarketActivePowerSetpoint(Program.myPark.Market_ActivePowerSetpoint) / 100.0f);
        }

        private static void WriteMarketActivePowerSetpointMw(ushort value)
        {
            int setpoint = ClampMarketActivePowerSetpoint(value * 100);
            Program.myPark.Market_ActivePowerSetpoint = setpoint;
            MarketInterfaceLog.Add("Market active power setpoint changed from Modbus register 100: " + (setpoint / 1000.0).ToString("F1") + " MW.");
        }

        private static ushort ReadMarketActivePowerSetpointPct()
        {
            int maxPower = GetMarketActivePowerMax();
            if (maxPower <= 0)
            {
                return 0;
            }

            return ToUInt16Register((float)ClampMarketActivePowerSetpoint(Program.myPark.Market_ActivePowerSetpoint) * 1000 / maxPower);
        }

        private static void WriteMarketActivePowerSetpointPct(ushort value)
        {
            if (value > 1000)
            {
                value = 1000;
            }

            int setpoint = ClampMarketActivePowerSetpoint((int)Math.Round((double)value * GetMarketActivePowerMax() / 1000));
            Program.myPark.Market_ActivePowerSetpoint = setpoint;
            MarketInterfaceLog.Add("Market active power setpoint changed from Modbus register 101: " + (value / 10.0).ToString("F1") + " % (" + (setpoint / 1000.0).ToString("F1") + " MW).");
        }

        private void server_ConnectionOpened(object sender, ModbusConnectionEventArgs e)
        {
            MarketInterfaceLog.Add("Modbus client connected: " + e.Key + " " + e.Reason);
        }

        private void server_ConnectionClosed(object sender, ModbusConnectionEventArgs e)
        {
            MarketInterfaceLog.Add("Modbus client disconnected: " + e.Key + " " + e.Reason);
        }

        private void server_ConnectionRefused(object sender, ModbusConnectionRefusedEventArgs e)
        {
            MarketInterfaceLog.Add("Modbus client refused: " + e.Key + " " + e.Reason);
        }

        private static int ClampMarketActivePowerSetpoint(int value)
        {
            if (value < 0)
            {
                return 0;
            }

            int maxPower = GetMarketActivePowerMax();
            if (value > maxPower)
            {
                return maxPower;
            }

            return value;
        }

        private static int GetMarketActivePowerMax()
        {
            if (Program.myPark != null && Program.myPark.ActivePowerMax > 0)
            {
                return Program.myPark.ActivePowerMax;
            }

            return Settings.Park.ParkMaxPower;
        }

        private static int GetTurbine1ActivePower()
        {
            if (Program.myPark == null ||
                Program.myPark.myTurbines == null ||
                Program.myPark.myTurbines.Length <= 1 ||
                Program.myPark.myTurbines[1] == null)
            {
                return 0;
            }

            return Program.myPark.myTurbines[1].Active_Power;
        }

        private static float GetTurbine1WindSpeed()
        {
            if (Program.myPark == null ||
                Program.myPark.myTurbines == null ||
                Program.myPark.myTurbines.Length <= 1 ||
                Program.myPark.myTurbines[1] == null)
            {
                return 0;
            }

            return Program.myPark.myTurbines[1].Windspeed;
        }
    }
}
