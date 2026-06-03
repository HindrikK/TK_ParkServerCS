using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_Gateway.Data
{
    class EnerconData
    {
        public int TurbineComTransmitted;
        public int TurbineComReceived;
        public int TurbineComErrors;
        public int PowerSetpoint;

        public int Turbine_ID;
        public int Status_1;
        public int Status_2;
        public float WindSpeed_avg;
        public float WindSpeed_peak;
        public int Power;
        public float RPM_avg;
        public float RPM_peak;

        public EnerconData(int _turbineID)
        {
            Turbine_ID = _turbineID;
        }
    }
}
