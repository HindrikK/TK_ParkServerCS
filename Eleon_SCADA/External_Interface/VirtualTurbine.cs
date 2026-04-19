using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eleon_SCADA.IEC104_Interface
{
    class VirtualTurbine
    {
        Park.WindPark WindPark;     // reference to the real wind park
        Park.VestasTurbine[] Turbines;    // reference to the wind turbines


        // measurement values
        public float WindSpeed { get; private set; }                    // the same value as in park
        public int WindDirection { get; private set; }                  // the average wind speed from all turbines
        public int NacellePosition { get; private set; }                // the average nacelle position from all turbines
        public int ActivePower { get; private set; }                    // the sum of active power from all turbines
        public int ReactivePower { get; private set; }                  // the sum of reactive power from all turbines
        public int ActivePowerCapability { get; private set; }          // potential active power based on current wind speed
        public int ReactivePowerCapability { get; private set; }        // potential reactive power capability, based on current active power
        public int RotorRPM { get; private set; }                       // this is the average RPM of all turbines

        // park statistics values
        public long TotalActiveProduction { get; private set; }         // total produced kWh; sum of all turbines
        public long TotalHours { get; private set; }                    // total hours in production

        // park control values
        public int ActivePowerMax { get; private set; }                 // maximum possible power for this park
        public int ActivePowerSetpoint { get; private set; }            // manual power setpoint in the park controller
        public int ActivePowerSetpointRemote { get; private set; }      // power setpoint received from remote interface
        public int ActivePowerRampUpLimit { get; private set; }         // manual max active power increasing rate
        public int ActivePowerRampUpLimitRemote { get; private set; }   // max active power increasind rate received from remote interface
        public int ActivePowerRampDown { get; private set; }
        public int ActivePowerRampDownRemote { get; private set; }

        // park status values
        public bool GridConnected { get; private set; }                 // TRUE when at least one turbine is connected
        public bool StoppedRemotely { get; private set; }               // TRUE when stop command is received from remote interface
        public bool StoppedLocally { get; private set; }                // TRUE when all turbines are stopped locally or in the park controller
        public bool ServiceMode { get; private set; }                   // TRUE when all turbines are in Service mode or service mode is set in park controller
        public bool ErrorSopped { get; private set; }                   // TRUE when all turbines are stopped by error
        public bool GridError { get; private set; }                     // TRUE when all turbines have stopped by grid error
        public bool WaitingWind { get; private set; }                   // TRUE when all turbines are waiting for wind
        public bool Freewheeling { get; private set; }                  // TRUE when all turbines are freewheeling (most likely when starting the park)
        public bool ActivePowerControlMode { get; private set; }        // indicates if "ActivePowerLimit" or "ActivePowerLimitRemote" is used for park control
        public bool ReactivePowerControlMode { get; private set; }
        public bool ActivePowerRampingMode { get; private set; }        // indicates if remote active power ramping values are used for park control



        public VirtualTurbine(Park.WindPark _windPark, Park.VestasTurbine[] _turbines)
        {
            WindPark = _windPark;
            Turbines = _turbines;
        }


        // do something
    }
}
