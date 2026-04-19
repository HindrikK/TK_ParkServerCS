using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eleon_SCADA.Park
{
    class VestasTurbine
    {
        // communication statistics
        public bool CommunicationStatus;
        public UInt16 TurbineComTransmitted;
        public UInt16 TurbineComReceived;
        public UInt16 TurbineComErrors;

        public int Turbine_ID;
        public string TurbineName;      // identification name for turbine in park
        public string TurbineType;      // turbine make and model(separated by space), example: "Vestas V80"


        // Turbine overview
        public int Active_Power;
        public int Gen_RPM;
        public float Rotor_RPM;
        public float Windspeed;
        public float Pitch_Angle;
        public int State;
        public string State_Txt = "NA";
        public int Error_Code;
        public string Error_Txt = "NA";

        // 1 sec. Wind data
        public float Windspeed_1s;
        public float Wind_Direction;
        public float RelativeWind_Direction;
        public float Nacelle_Direction;

        // 1 Sec. Electrical data
        public int Active_Power_1s;
        public float CosPhi;
        public float Frequency;
        public float Voltage_L1;
        public float Voltage_L2;
        public float Voltage_L3;
        public float Current_L1;
        public float Current_L2;
        public float Current_L3;

        // turbine status values (State1)
        public int OperationState;                  // 0=emergency; 1=stop; 2=pause; 3=run
        public string OperationState_Txt = "NA";
        public int PendOperationState;              // 0=emergency; 1=stop; 2=pause; 3=run
        public string PendOperationState_Txt = "NA";
        public bool ServiceState;                   // FALSE=normal; TRUE=service
        public bool YawCW;                          // yawing CW
        public bool YawCCW;                         // yawing CCW
        public bool CommandAccepted;                // command accepted - TRUE=accepted; FALSE=not accepted
        
        // turbine status values (State2)
        public bool RemoteControl;                  // remote control possible - TRUE=possible; FALSE=not possible
        public int YawState;                        // 0=not active; 1=manual yaw; 2=outyawing; 3=auto yaw
        public string YawState_Txt = "NA";
        public bool TurbineAvailable;               // TRUE=available; FALSE=not available
        public bool VDF_Triggered;
        public bool LocalModeRequest;               // local mode request, when key turned
        public bool G1_Connected;
        public bool G2_Connected;
        public bool G_Connected;                    // general Generator connection status; TRUE if G1 or G2 connected

        // Temperatures
        public int Temp_Hydraulic;
        public int Temp_Environment;
        public int Temp_Gear;
        public int Temp_Generator;
        public int Temp_SlipringVCS;
        public int Temp_GearBearing;
        public int Temp_HubController;
        public int Temp_Nacelle;
        public int Temp_TopController;
        public int Temp_BusBar;
        public int Temp_Spinner;
        public int Temp_HVTransformerL1;
        public int Temp_HVTransformerL2;
        public int Temp_HVTransformerL3;
        public int Temp_GeneratorBearing;
        public int Temp_CoolWaterVCS;

        // Power setpoint
        public int ActivePowerSetpoint;
        public int ReactivePowerSetpoint;
        public int NominalPower;
        public int ActivePowerRegulatorSetpoint;

        //
        public uint Hours;
        public int Production;
        public int Reactive_Power;


        public VestasTurbine(int turbineID, string turbineName, string turbineType)
        {
            Turbine_ID = turbineID;
            TurbineName = turbineName;
            TurbineType = turbineType;
        }

        public void Set_PowerSetpoint(short setpoint)
        {
            Program.myVestasController.Set_ActivePowerSetpoint(Turbine_ID, setpoint);
        }

        public void Start_Turbine()
        {
            Program.myVestasController.Start_Turbine(Turbine_ID);
        }

        public void Stop_Turbine()
        {
            Program.myVestasController.Pause_Turbine(Turbine_ID);
        }

        public void Reset_Turbine()
        {
            Program.myVestasController.Ack_Errors(Turbine_ID);
        }
    }
}
