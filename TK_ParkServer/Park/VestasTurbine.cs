using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK_ParkServer.Park
{
    class VestasTurbine : WindTurbine
    {
        private VestasRCS vestasController;
        private int state;
        private int operationState;
        private bool serviceState;
        private bool remoteControl;
        private bool gConnected;
        private bool communicationStatus;

        public int State
        {
            get { return state; }
            set {
                state = value;
                switch (value)
                {
                    case 4:
                    case 5:
                        Status |= statusBit_Error;
                        break;
                    case 6:
                        Status |= statusBit_LowWind;
                        break;
                    default:
                        Status &= unchecked((ushort)~statusBit_Error);
                        Status &= unchecked((ushort)~statusBit_LowWind);
                        break;
                }
            }
        }
        public string State_Txt;

        // communication statistics
        public bool CommunicationStatus
        {
            get { return communicationStatus; }
            set {
                communicationStatus = value;
                if (value)
                {
                    Status |= statusBit_Online; // set online bit
                }
                else
                {
                    Status &= unchecked((ushort)~statusBit_Online); // clear online bit
                }
            }
        }
        public UInt16 TurbineComTransmitted;
        public UInt16 TurbineComReceived;
        public UInt16 TurbineComErrors;

        // Turbine overview
        public int Active_Power
        {
            get { return ActivePower; }
            set { ActivePower = value; }
        }
        public int Gen_RPM;
        public float Rotor_RPM;
        public float Wind_Speed
        {
            get { return WindSpeed; }
            set { WindSpeed = value; }
        }
        public float Pitch_Angle;

        // 1 sec. Wind data
        public float Windspeed_1s
        {
            get { return WindSpeed; }
            set { WindSpeed = value; }
        }
        public float Wind_Direction;
        public float RelativeWind_Direction;
        public float Nacelle_Direction
        {
            get { return NacellePosition; }
            set { NacellePosition = value; }
        }

        // 1 Sec. Electrical data
        public int Active_Power_1s
        {
            get { return ActivePower; }
            set { ActivePower = value; }
        }
        public float CosPhi;
        public float Frequency;
        public float Voltage_L1;
        public float Voltage_L2;
        public float Voltage_L3;
        public float Current_L1;
        public float Current_L2;
        public float Current_L3;

        // turbine status values (State1)
        public int OperationState                   // 0=emergency; 1=stop; 2=pause; 3=run
        {
            get { return operationState; }
            set {
                operationState = value;
                if (value == 3)
                {
                    Status &= unchecked((ushort)~statusBit_Stopped); // clear stopped bit
                }
                else
                {
                    Status |= statusBit_Stopped; // set stopped bit
                }
            }
        }
        public string OperationState_Txt = "NA";
        public int PendOperationState;              // 0=emergency; 1=stop; 2=pause; 3=run
        public string PendOperationState_Txt = "NA";
        public bool ServiceState {                   // FALSE=normal; TRUE=service
            get { return serviceState; }
            set {
                serviceState = value;
                if (value)
                {
                    Status |= statusBit_ServiceMode;
                }
                else
                {
                    Status &= unchecked((ushort)~statusBit_ServiceMode);
                }
            }
        }
        public bool YawCW;                          // yawing CW
        public bool YawCCW;                         // yawing CCW
        public bool CommandAccepted;                // command accepted - TRUE=accepted; FALSE=not accepted
        
        // turbine status values (State2)
        public bool RemoteControl {                  // remote control possible - TRUE=possible; FALSE=not possible
            get { return remoteControl; }
            set {
                remoteControl = value;
                if (value)
                {
                    Status |= statusBit_RemoteControl;
                }
                else
                {
                    Status &= unchecked((ushort)~statusBit_RemoteControl);
                }
            }
        }
        public int YawState;                        // 0=not active; 1=manual yaw; 2=outyawing; 3=auto yaw
        public string YawState_Txt = "NA";
        public bool TurbineAvailable;               // TRUE=available; FALSE=not available
        public bool VDF_Triggered;
        public bool LocalModeRequest;               // local mode request, when key turned
        public bool G1_Connected;
        public bool G2_Connected;
        public bool G_Connected {                    // general Generator connection status; TRUE if G1 or G2 connected
            get { return gConnected; }
            set {
                gConnected = value;
                if (value)
                {
                    Status |= statusBit_GridConnected;
                }
                else
                {
                    Status &= unchecked((ushort)~statusBit_GridConnected);
                }
            }
        }

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
        public int ReactivePowerSetpoint;
        public int NominalPower;
        public int ActivePowerRegulatorSetpoint;

        //
        public long Hours
        {
            get { return TotalHours;  }
            set { TotalHours = value; }
        }
        public long Production
        {
            get { return TotalActiveProduction; }
            set { TotalActiveProduction = value; }
        }
        public int Reactive_Power
        {
            get { return ReactivePower; }
            set { ReactivePower = value; }
        }


        public VestasTurbine(int turbineID, string turbineName, string turbineType)
            : base(turbineID, turbineName, turbineType)
        {
            State_Txt = "NA";
            StatusCode_Txt = "NA";
        }

        public void SetVestasController(VestasRCS controller)
        {
            this.vestasController = controller;
        }

        public override void Set_PowerSetpoint(short setpoint)
        {
            if (this.vestasController == null) throw new InvalidOperationException("Vestas controller is not assigned");
            this.vestasController.Set_ActivePowerSetpoint(Turbine_ID, setpoint);
        }

        public override void Start_Turbine()
        {
            if (this.vestasController == null) throw new InvalidOperationException("Vestas controller is not assigned");
            this.vestasController.Start_Turbine(Turbine_ID);
        }

        public override void Stop_Turbine()
        {
            if (this.vestasController == null) throw new InvalidOperationException("Vestas controller is not assigned");
            this.vestasController.Pause_Turbine(Turbine_ID);
        }

        public override void Reset_Turbine()
        {
            if (this.vestasController == null) throw new InvalidOperationException("Vestas controller is not assigned");
            this.vestasController.Ack_Errors(Turbine_ID);
        }
    }
}
