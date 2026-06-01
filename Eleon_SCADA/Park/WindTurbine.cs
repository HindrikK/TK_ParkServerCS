using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eleon_SCADA.Park
{
    class WindTurbine
    {
        public int Turbine_ID { get; protected set; }
        public string TurbineName { get; protected set; }                 // identification name for turbine in park
        public  string TurbineType { get; protected set; }                // turbine make and model(separated by space), example: "Vestas V80"

        // measurement values
        public float WindSpeed { get; protected set; }
        public float WindDirection { get; protected set; }
        public float NacellePosition { get; protected set; }
        public int ActivePower { get; protected set; }
        public int ReactivePower { get; protected set; }
        public int ActivePowerCapability { get; protected set; }          // potential active power based on current wind speed
        public int ReactivePowerCapability { get; protected set; }        // potential reactive power capability, based on current active power
        public int RotorRPM { get; protected set; }

        // statistics values
        public long TotalActiveProduction { get; protected set; }         // total produced kWh
        public long TotalHours { get; set; }                              // total hours in production

        // control values
        public int ActivePowerMax { get; protected set; }                 // maximum possible power
        public int ActivePowerSetpoint { get; set; }                      // manual power setpoint in the park controller
        public int ActivePowerSetpointRemote { get; protected set; }      // power setpoint received from remote interface
        public int ActivePowerRampUpLimit { get; protected set; }         // manual max active power increasing rate
        public int ActivePowerRampUpLimitRemote { get; protected set; }   // max active power increasind rate received from remote interface
        public int ActivePowerRampDown { get; protected set; }
        public int ActivePowerRampDownRemote { get; protected set; }

        // status values
        public ushort Status;       // status bitfield
        public int StatusCode { get; set; }
        public string StatusCode_Txt { get; set; }


        public WindTurbine(int turbineID, string turbineName, string turbineType)
        {
            Turbine_ID = turbineID;
            TurbineName = turbineName;
            TurbineType = turbineType;
        }

        public virtual void Start_Turbine()
        {
            throw new NotSupportedException("Start command is not implemented for this turbine type");
        }

        public virtual void Stop_Turbine()
        {
            throw new NotSupportedException("Stop command is not implemented for this turbine type");
        }

        public virtual void Set_PowerSetpoint(short setpoint)
        {
            throw new NotSupportedException("Power setpoint command is not implemented for this turbine type");
        }

        public virtual void Reset_Turbine()
        {
            throw new NotSupportedException("Reset command is not implemented for this turbine type");
        }


        // define status bit values
        public const ushort statusBit_Stopped = 1 << 0;
        public const ushort statusBit_GridConnected = 1 << 1;
        public const ushort statusBit_ServiceMode = 1 << 2;
        //public const ushort statusBit_Warning = 1 << 3;
        public const ushort statusBit_Error = 1 << 4;
        public const ushort statusBit_RemoteControl = 1 << 5;
        public const ushort statusBit_LowWind = 1 << 6;
    }
}
