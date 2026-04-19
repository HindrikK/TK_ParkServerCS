using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eleon_SCADA
{
    class InteropServices
    {
        System.IO.MemoryMappedFiles.MemoryMappedFile MemoryMap;
        System.IO.MemoryMappedFiles.MemoryMappedViewAccessor MemoryMapAccessor;

        private byte programHeartBeat;
        public byte ProgramHeartBeat
        {
            get
            {
                //MemoryMapAccessor.Read(1, out programHeartBeat);
                return programHeartBeat;
            }
            set
            {
                programHeartBeat = value;
                MemoryMapAccessor.Write(1, ref programHeartBeat);
            }
        }



        // constructor
        public InteropServices()
        {
            MemoryMap = System.IO.MemoryMappedFiles.MemoryMappedFile.CreateOrOpen("WindParkServer_Map", 1);
            MemoryMapAccessor = MemoryMap.CreateViewAccessor();
        }

        //destructor
        public void Dispose()
        {
            try
            {
                MemoryMapAccessor.Dispose();
                MemoryMap.Dispose();
            }
            catch { }
        }
    }
}
