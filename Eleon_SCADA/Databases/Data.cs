using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_Gateway.Data
{
    class ParkData
    {
        public static EnerconData[] EnerconData;
        //public static System.Data.DataTable RealtimeValues;
        //public static System.Data.DataTable StatusLogData;

        public ParkData(int _num)
        {
            EnerconData = new EnerconData[_num];
        }
    }
}
