using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK_ParkServer.IEC104Server
{
    class IEC104_Database
    {
        //public object[] All_ObjectGroups;

        // monitoring points
        public M_SP_NA M_SP_NA_data;
        public M_ME_NC M_ME_NC_data;
        // control points
        public C_SC_NA C_SC_NA_data;
        //public C_SE_NA C_SE_NA_data;
        public C_SE_NA C_SE_NA_data;

        // TEST
        public M_DP_NA M_DP_NA_data;
        public C_DC_NA C_DC_NA_data;





        // CONSTRUCTOR - create/initialize database
        public IEC104_Database()
        {
            // create and initialize all database objects
            M_SP_NA_data = new M_SP_NA(2001, 7);
            M_ME_NC_data = new M_ME_NC(1001, 6);
            C_SC_NA_data = new C_SC_NA(1, 6);
            //C_SE_NA_data = new C_SE_NA(6201, 1);
            C_SE_NA_data = new C_SE_NA(6201, 1);

            // TEST
            M_DP_NA_data = new M_DP_NA(3000, 3);
            C_DC_NA_data = new C_DC_NA(4000, 3);

            /*
            // create database objects container
            All_ObjectGroups = new object[4];
            // fill database objects container
            All_ObjectGroups[0] = M_SP_NA_data;
            All_ObjectGroups[1] = M_ME_NB_data;
            All_ObjectGroups[2] = C_SC_NA_data;
            All_ObjectGroups[3] = C_SE_NA_data;
            */
        }


        /// <summary>
        /// Returns value from specific IOA in all database
        /// </summary>
        /// <param name="_IOA">Information Object Address</param>
        public object Get(int _IOA)
        {
            lock (this)
            {
                try { return (bool)M_SP_NA_data.Get(_IOA); }
                catch { }

                try { return (float)M_ME_NC_data.Get(_IOA); }
                catch { }

                try { return (bool)C_SC_NA_data.Get(_IOA); }
                catch { }

                try { return (float)C_SE_NA_data.Get(_IOA); }
                catch { }

                throw new Exception("IOA unknown");
            }
        }

        /// <summary>
        /// Returns object type for specific IOA in all database
        /// </summary>
        /// <param name="_IOA">Information Object Address</param>
        public int GetType(int _IOA)
        {
            lock (this)
            {
                try
                {
                    M_SP_NA_data.Get(_IOA);
                    return M_SP_NA_data.GetType();
                }
                catch { }
                try
                {
                    M_DP_NA_data.Get(_IOA);
                    return M_DP_NA_data.GetType();
                }
                catch { }
                try
                {
                    M_ME_NC_data.Get(_IOA);
                    return M_ME_NC_data.GetType();
                }
                catch { }
                try
                {
                    C_SC_NA_data.Get(_IOA);
                    return C_SC_NA_data.GetType();
                }
                catch { }
                try
                {
                    C_DC_NA_data.Get(_IOA);
                    return C_DC_NA_data.GetType();
                }
                catch { }
                try
                {
                    C_SE_NA_data.Get(_IOA);
                    return C_SE_NA_data.GetType();
                }
                catch { }

                throw new Exception("IOA unknown");
            }
        }


        /// <summary>
        /// Sets value in specific IOA in all database
        /// </summary>
        /// <param name="_IOA">Information Object Address</param>
        public void Set(int _IOA, object _Value)
        {
            lock (this)
            {
                try
                {
                    M_SP_NA_data.Set(_IOA, (bool)_Value);
                    return;
                }
                catch (Exception ex){ }

                try
                {
                    M_ME_NC_data.Set(_IOA, Convert.ToSingle(_Value));
                    return;
                }
                catch { }

                try
                {
                    C_SC_NA_data.Set(_IOA, (bool)_Value);
                    return;
                }
                catch { }

                try
                {
                    C_SE_NA_data.Set(_IOA, Convert.ToInt16(_Value));
                    return;
                }
                catch { }


                throw new Exception("IOA unknown");
            }
        }
    }


    #region OBJECT_TYPES

    // Single-point information
    // One bit size; value 1 or 0
    class M_SP_NA
    {
        const int Type = (int)TypeID.M_SP_NA_1;
        List<int> IOA = new List<int>();
        List<bool> Value = new List<bool>();

        public delegate void MyEventHandler(object source, IEC104_Database_EventArgs e);
        /// <summary>
        /// Event is raised every time a value is updated
        /// </summary>
        public event MyEventHandler ValueUpdated;
        /// <summary>
        /// Event is raised only when value has changed
        /// </summary>
        public event MyEventHandler ValueChanged;

        public M_SP_NA()
        {
        }

        /// <summary>
        /// Creates specific "Single-point information" object list
        /// </summary>
        /// <param name="firstIOA">First IOA address in array</param>
        /// <param name="count">Number of elements in array</param>
        public M_SP_NA(int firstIOA, int count)
        {
            for (int i = 0; i < count; i++)
            {
                IOA.Add(firstIOA + i);
                Value.Add(false);
            }
        }

        /// <summary>
        /// Add number of "Single-point information" objects to list
        /// </summary>
        /// <param name="firstIOA">First IOA address to add</param>
        /// <param name="count">Number of objects to add</param>
        public void Add(int firstIOA, int count)
        {
            lock (this)
            {
                for (int i = 0; i < count; i++)
                {
                    IOA.Add(firstIOA + i);
                    Value.Add(false);
                }
            }
        }

        /// <summary>
        /// Returns value from specific IOA
        /// </summary>
        /// <param name="_IOA">Information Object Address</param>
        public bool Get(int _IOA)
        {
            lock (this)
            {
                int index = IOA.BinarySearch(_IOA);
                if (index > -1)
                {
                    return Value[index];
                }
                else
                {
                    throw new Exception("IOA unknown");
                }
            }
        }

        /// <summary>
        /// Returns value from list based on index
        /// </summary>
        /// <param name="index">Index of requested information object value in list</param>
        public bool GetValue(int index)
        {
            lock (this)
            {
                if (index > -1 && index < IOA.Count())
                {
                    return Value[index];
                }
                else
                {
                    throw new Exception("Index out of range");
                }
            }
        }

        /// <summary>
        /// Returns IOA from list based on index
        /// </summary>
        /// <param name="index">Index of requested IOA in list</param>
        public int GetIOA(int index)
        {
            lock (this)
            {
                if (index > -1 && index < IOA.Count())
                {
                    return IOA[index];
                }
                else
                {
                    throw new Exception("Index out of range");
                }
            }
        }

        /// <summary>
        /// Returns the IEC-104 type ID for this object group
        /// </summary>
        public int GetType()
        {
            return Type;
        }

        /// <summary>
        /// Set value on specific IOA
        /// </summary>
        /// <param name="_IOA">IOA of object to set new value</param>
        /// <param name="_Value">Value to set</param>
        public void Set(int _IOA, bool _Value)
        {
            lock (this)
            {
                int index = IOA.BinarySearch(_IOA);
                if (index > -1)
                {
                    // Trigger the event if value has changed and a handler is present
                    if (Value[index] != _Value && ValueChanged != null)
                    {
                        ValueChanged(this, new IEC104_Database_EventArgs(_IOA, (bool)_Value));
                    }

                    Value[index] = _Value;

                    // Trigger the event every time a value is updated and a handler is present
                    if (ValueUpdated != null)
                    {
                        ValueUpdated(this, new IEC104_Database_EventArgs(_IOA, (bool)_Value));
                    }
                }
                else
                {
                    throw new Exception("IOA unknown");
                }
            }
        }

        /// <summary>
        /// Returns number of information objects in list
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            lock (this)
            {
                return IOA.Count();
            }
        }
    }

    // Single-point information with time tag
    class M_SP_TA
    {
        const int Type = (int)TypeID.M_SP_TA_1;
        List<int> IOA = new List<int>();
        List<bool> Value = new List<bool>();
        List<CP56Time2a> TimeTag = new List<CP56Time2a>();
        public delegate void MyEventHandler(object source, IEC104_Database_EventArgs e);
        /// <summary>
        /// Event is raised every time a value is updated
        /// </summary>
        public event MyEventHandler ValueUpdated;
        /// <summary>
        /// Event is raised only when value has changed
        /// </summary>
        public event MyEventHandler ValueChanged;

        public M_SP_TA()
        {
        }

        /// <summary>
        /// Creates specific "Single-point information" object list
        /// </summary>
        /// <param name="firstIOA">First IOA address in array</param>
        /// <param name="count">Number of elements in array</param>
        public M_SP_TA(int firstIOA, int count)
        {
            for (int i = 0; i < count; i++)
            {
                IOA.Add(firstIOA + i);
                Value.Add(false);
                TimeTag.Add(new CP56Time2a());
            }
        }

        /// <summary>
        /// Add number of "Single-point information" objects to list
        /// </summary>
        /// <param name="firstIOA">First IOA address to add</param>
        /// <param name="count">Number of objects to add</param>
        public void Add(int firstIOA, int count)
        {
            lock (this)
            {
                for (int i = 0; i < count; i++)
                {
                    IOA.Add(firstIOA + i);
                    Value.Add(false);
                }
            }
        }

        /// <summary>
        /// Returns value from specific IOA
        /// </summary>
        /// <param name="_IOA">Information Object Address</param>
        public bool Get(int _IOA)
        {
            lock (this)
            {
                int index = IOA.BinarySearch(_IOA);
                if (index > -1)
                {
                    return Value[index];
                }
                else
                {
                    throw new Exception("IOA unknown");
                }
            }
        }

        /// <summary>
        /// Returns value from list based on index
        /// </summary>
        /// <param name="index">Index of requested information object value in list</param>
        public bool GetValue(int index)
        {
            lock (this)
            {
                if (index > -1 && index < IOA.Count())
                {
                    return Value[index];
                }
                else
                {
                    throw new Exception("Index out of range");
                }
            }
        }

        /// <summary>
        /// Returns IOA from list based on index
        /// </summary>
        /// <param name="index">Index of requested IOA in list</param>
        public int GetIOA(int index)
        {
            lock (this)
            {
                if (index > -1 && index < IOA.Count())
                {
                    return IOA[index];
                }
                else
                {
                    throw new Exception("Index out of range");
                }
            }
        }

        /// <summary>
        /// Returns the IEC-104 type ID for this object group
        /// </summary>
        public int GetType()
        {
            return Type;
        }

        /// <summary>
        /// Set value on specific IOA
        /// </summary>
        /// <param name="_IOA">IOA of object to set new value</param>
        /// <param name="_Value">Value to set</param>
        public void Set(int _IOA, bool _Value)
        {
            lock (this)
            {
                int index = IOA.BinarySearch(_IOA);
                if (index > -1)
                {
                    // Trigger the event if value has changed and a handler is present
                    if (Value[index] != _Value && ValueChanged != null)
                    {
                        ValueChanged(this, new IEC104_Database_EventArgs(_IOA, (bool)_Value));
                    }

                    Value[index] = _Value;

                    // Trigger the event every time a value is updated and a handler is present
                    if (ValueUpdated != null)
                    {
                        ValueUpdated(this, new IEC104_Database_EventArgs(_IOA, (bool)_Value));
                    }
                }
                else
                {
                    throw new Exception("IOA unknown");
                }
            }
        }

        /// <summary>
        /// Returns number of information objects in list
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            lock (this)
            {
                return IOA.Count();
            }
        }
    }

    // Double-point information
    // Two bit size; value 0-3
    class M_DP_NA
    {
        const int Type = (int)TypeID.M_DP_NA_1;
        List<int> IOA = new List<int>();
        List<byte> Value = new List<byte>();

        public delegate void MyEventHandler(object source, IEC104_Database_EventArgs e);
        /// <summary>
        /// Event is raised every time a value is updated
        /// </summary>
        public event MyEventHandler ValueUpdated;
        /// <summary>
        /// Event is raised only when value has changed
        /// </summary>
        public event MyEventHandler ValueChanged;

        public M_DP_NA()
        {
        }

        /// <summary>
        /// Creates specific object list
        /// </summary>
        /// <param name="firstIOA">First IOA address in array</param>
        /// <param name="count">Number of elements in array</param>
        public M_DP_NA(int firstIOA, int count)
        {
            for (int i = 0; i < count; i++)
            {
                IOA.Add(firstIOA + i);
                Value.Add(0);
            }
        }

        /// <summary>
        /// Add number of objects to list
        /// </summary>
        /// <param name="firstIOA">First IOA address to add</param>
        /// <param name="count">Number of objects to add</param>
        public void Add(int firstIOA, int count)
        {
            lock (this)
            {
                for (int i = 0; i < count; i++)
                {
                    IOA.Add(firstIOA + i);
                    Value.Add(0);
                }
            }
        }

        /// <summary>
        /// Returns value from specific IOA
        /// </summary>
        /// <param name="_IOA">Information Object Address</param>
        public byte Get(int _IOA)
        {
            lock (this)
            {
                int index = IOA.BinarySearch(_IOA);
                if (index > -1)
                {
                    return Value[index];
                }
                else
                {
                    throw new Exception("IOA unknown");
                }
            }
        }

        /// <summary>
        /// Returns value from list based on index
        /// </summary>
        /// <param name="index">Index of requested information object value in list</param>
        public byte GetValue(int index)
        {
            lock (this)
            {
                if (index > -1 && index < IOA.Count())
                {
                    return Value[index];
                }
                else
                {
                    throw new Exception("Index out of range");
                }
            }
        }

        /// <summary>
        /// Returns IOA from list based on index
        /// </summary>
        /// <param name="index">Index of requested IOA in list</param>
        public int GetIOA(int index)
        {
            lock (this)
            {
                if (index > -1 && index < IOA.Count())
                {
                    return IOA[index];
                }
                else
                {
                    throw new Exception("Index out of range");
                }
            }
        }

        /// <summary>
        /// Returns the IEC-104 type ID for this object group
        /// </summary>
        public int GetType()
        {
            return Type;
        }

        /// <summary>
        /// Set value on specific IOA
        /// </summary>
        /// <param name="_IOA">IOA of object to set new value</param>
        /// <param name="_Value">Value to set</param>
        public void Set(int _IOA, byte _Value)
        {
            lock (this)
            {
                int index = IOA.BinarySearch(_IOA);
                if (index > -1)
                {
                    _Value = (byte)(_Value & 0x03);    // use only 2 least significant bits
                    
                    // Trigger the event if value has changed and a handler is present
                    if (Value[index] != _Value && ValueChanged != null)
                    {
                        ValueChanged(this, new IEC104_Database_EventArgs(_IOA, (byte)_Value));
                    }

                    Value[index] = _Value;

                    // Trigger the event every time a value is updated and a handler is present
                    if (ValueUpdated != null)
                    {
                        ValueUpdated(this, new IEC104_Database_EventArgs(_IOA, (byte)_Value));
                    }
                }
                else
                {
                    throw new Exception("IOA unknown");
                }
            }
        }

        /// <summary>
        /// Returns number of information objects in list
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            lock (this)
            {
                return IOA.Count();
            }
        }
    }

    // Measured value, normalised value
    class M_ME_NA
    {
        const int Type = (int)TypeID.M_ME_NA_1;
        List<int> IOA = new List<int>();
        List<Int16> Value = new List<Int16>();
        public delegate void MyEventHandler(object source, IEC104_Database_EventArgs e);
        /// <summary>
        /// Event is raised every time a value is updated
        /// </summary>
        public event MyEventHandler ValueUpdated;
        /// <summary>
        /// Event is raised only when value has changed
        /// </summary>
        public event MyEventHandler ValueChanged;

        public M_ME_NA()
        {
        }

        /// <summary>
        /// Creates specific "Measured value, normalised value" object list
        /// </summary>
        /// <param name="firstIOA">First IOA address in array</param>
        /// <param name="count">Number of elements in array</param>
        public M_ME_NA(int firstIOA, int count)
        {
            for (int i = 0; i < count; i++)
            {
                IOA.Add(firstIOA + i);
                Value.Add(0);
            }
        }

        /// <summary>
        /// Add number of "Measured value, normalised value" objects to list
        /// </summary>
        /// <param name="firstIOA">First IOA address to add</param>
        /// <param name="count">Number of objects to add</param>
        public void Add(int firstIOA, int count)
        {
            lock (this)
            {
                for (int i = 0; i < count; i++)
                {
                    IOA.Add(firstIOA + i);
                    Value.Add(0);
                }
            }
        }

        /// <summary>
        /// Returns value from specific IOA
        /// </summary>
        /// <param name="_IOA">Information Object Address</param>
        public Int16 Get(int _IOA)
        {
            lock (this)
            {
                int index = IOA.BinarySearch(_IOA);
                if (index > -1)
                {
                    return Value[index];
                }
                else
                {
                    throw new Exception("IOA unknown");
                }
            }
        }

        /// <summary>
        /// Returns value from list based on index
        /// </summary>
        /// <param name="index">Index of requested information object value in list</param>
        public Int16 GetValue(int index)
        {
            lock (this)
            {
                if (index > -1 && index < IOA.Count())
                {
                    return Value[index];
                }
                else
                {
                    throw new Exception("Index out of range");
                }
            }
        }

        /// <summary>
        /// Returns IOA from list based on index
        /// </summary>
        /// <param name="index">Index of requested IOA in list</param>
        public int GetIOA(int index)
        {
            lock (this)
            {
                if (index > -1 && index < IOA.Count())
                {
                    return IOA[index];
                }
                else
                {
                    throw new Exception("Index out of range");
                }
            }
        }

        /// <summary>
        /// Returns the IEC-104 type ID for this object group
        /// </summary>
        public int GetType()
        {
            return Type;
        }

        /// <summary>
        /// Set value on specific IOA
        /// </summary>
        /// <param name="_IOA">IOA of object to set new value</param>
        /// <param name="_Value">Value to set</param>
        public void Set(int _IOA, Int16 _Value)
        {
            lock (this)
            {
                int index = IOA.BinarySearch(_IOA);
                if (index > -1)
                {
                    // Trigger the event if value has changed and a handler is present
                    if (Value[index] != _Value && ValueChanged != null)
                    {
                        ValueChanged(this, new IEC104_Database_EventArgs(_IOA, (short)_Value));
                    }

                    Value[index] = _Value;

                    // Trigger the event every time a value is updated and a handler is present
                    if (ValueUpdated != null)
                    {
                        ValueUpdated(this, new IEC104_Database_EventArgs(_IOA, (short)_Value));
                    }
                }
                else
                {
                    throw new Exception("IOA unknown");
                }
            }
        }

        /// <summary>
        /// Returns number of information objects in list
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            lock (this)
            {
                return IOA.Count();
            }
        }
    }

    // Measured value, scaled value
    class M_ME_NB
    {
        const int Type = (int)TypeID.M_ME_NB_1;
        List<int> IOA = new List<int>();
        List<Int16> Value = new List<Int16>();
        public delegate void MyEventHandler(object source, IEC104_Database_EventArgs e);
        /// <summary>
        /// Event is raised every time a value is updated
        /// </summary>
        public event MyEventHandler ValueUpdated;
        /// <summary>
        /// Event is raised only when value has changed
        /// </summary>
        public event MyEventHandler ValueChanged;

        public M_ME_NB()
        {
        }

        /// <summary>
        /// Creates specific "Measured value, scaled value" object list
        /// </summary>
        /// <param name="firstIOA">First IOA address in array</param>
        /// <param name="count">Number of elements in array</param>
        public M_ME_NB(int firstIOA, int count)
        {
            for (int i = 0; i < count; i++)
            {
                IOA.Add(firstIOA + i);
                Value.Add(0);
            }
        }

        /// <summary>
        /// Add number of "Measured value, scaled value" objects to list
        /// </summary>
        /// <param name="firstIOA">First IOA address to add</param>
        /// <param name="count">Number of objects to add</param>
        public void Add(int firstIOA, int count)
        {
            lock (this)
            {
                for (int i = 0; i < count; i++)
                {
                    IOA.Add(firstIOA + i);
                    Value.Add(0);
                }
            }
        }

        /// <summary>
        /// Returns value from specific IOA
        /// </summary>
        /// <param name="_IOA">Information Object Address</param>
        public Int16 Get(int _IOA)
        {
            lock (this)
            {
                int index = IOA.BinarySearch(_IOA);
                if (index > -1)
                {
                    return Value[index];
                }
                else
                {
                    throw new Exception("IOA unknown");
                }
            }
        }

        /// <summary>
        /// Returns value from list based on index
        /// </summary>
        /// <param name="index">Index of requested information object value in list</param>
        public Int16 GetValue(int index)
        {
            lock (this)
            {
                if (index > -1 && index < IOA.Count())
                {
                    return Value[index];
                }
                else
                {
                    throw new Exception("Index out of range");
                }
            }
        }

        /// <summary>
        /// Returns IOA from list based on index
        /// </summary>
        /// <param name="index">Index of requested IOA in list</param>
        public int GetIOA(int index)
        {
            lock (this)
            {
                if (index > -1 && index < IOA.Count())
                {
                    return IOA[index];
                }
                else
                {
                    throw new Exception("Index out of range");
                }
            }
        }

        /// <summary>
        /// Returns the IEC-104 type ID for this object group
        /// </summary>
        public int GetType()
        {
            return Type;
        }

        /// <summary>
        /// Set value on specific IOA
        /// </summary>
        /// <param name="_IOA">IOA of object to set new value</param>
        /// <param name="_Value">Value to set</param>
        public void Set(int _IOA, Int16 _Value)
        {
            lock (this)
            {
                int index = IOA.BinarySearch(_IOA);
                if (index > -1)
                {
                    // Trigger the event if value has changed and a handler is present
                    if (Value[index] != _Value && ValueChanged != null)
                    {
                        ValueChanged(this, new IEC104_Database_EventArgs(_IOA, (short)_Value));
                    }

                    Value[index] = _Value;

                    // Trigger the event every time a value is updated and a handler is present
                    if (ValueUpdated != null)
                    {
                        ValueUpdated(this, new IEC104_Database_EventArgs(_IOA, (short)_Value));
                    }
                }
                else
                {
                    throw new Exception("IOA unknown");
                }
            }
        }

        /// <summary>
        /// Returns number of information objects in list
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            lock (this)
            {
                return IOA.Count();
            }
        }
    }

    // Measured value, short floating point number
    class M_ME_NC
    {
        const int Type = (int)TypeID.M_ME_NC_1;
        List<int> IOA = new List<int>();
        List<float> Value = new List<float>();
        public delegate void MyEventHandler(object source, IEC104_Database_EventArgs e);
        /// <summary>
        /// Event is raised every time a value is updated
        /// </summary>
        public event MyEventHandler ValueUpdated;
        /// <summary>
        /// Event is raised only when value has changed
        /// </summary>
        public event MyEventHandler ValueChanged;

        public M_ME_NC()
        {
        }

        /// <summary>
        /// Creates specific "Measured value, scaled value" object list
        /// </summary>
        /// <param name="firstIOA">First IOA address in array</param>
        /// <param name="count">Number of elements in array</param>
        public M_ME_NC(int firstIOA, int count)
        {
            for (int i = 0; i < count; i++)
            {
                IOA.Add(firstIOA + i);
                Value.Add(0);
            }
        }

        /// <summary>
        /// Add number of "Measured value, scaled value" objects to list
        /// </summary>
        /// <param name="firstIOA">First IOA address to add</param>
        /// <param name="count">Number of objects to add</param>
        public void Add(int firstIOA, int count)
        {
            lock (this)
            {
                for (int i = 0; i < count; i++)
                {
                    IOA.Add(firstIOA + i);
                    Value.Add(0);
                }
            }
        }

        /// <summary>
        /// Returns value from specific IOA
        /// </summary>
        /// <param name="_IOA">Information Object Address</param>
        public float Get(int _IOA)
        {
            lock (this)
            {
                int index = IOA.BinarySearch(_IOA);
                if (index > -1)
                {
                    return Value[index];
                }
                else
                {
                    throw new Exception("IOA unknown");
                }
            }
        }

        /// <summary>
        /// Returns value from list based on index
        /// </summary>
        /// <param name="index">Index of requested information object value in list</param>
        public float GetValue(int index)
        {
            lock (this)
            {
                if (index > -1 && index < IOA.Count())
                {
                    return Value[index];
                }
                else
                {
                    throw new Exception("Index out of range");
                }
            }
        }

        /// <summary>
        /// Returns IOA from list based on index
        /// </summary>
        /// <param name="index">Index of requested IOA in list</param>
        public int GetIOA(int index)
        {
            lock (this)
            {
                if (index > -1 && index < IOA.Count())
                {
                    return IOA[index];
                }
                else
                {
                    throw new Exception("Index out of range");
                }
            }
        }

        /// <summary>
        /// Returns the IEC-104 type ID for this object group
        /// </summary>
        public int GetType()
        {
            return Type;
        }

        /// <summary>
        /// Set value on specific IOA
        /// </summary>
        /// <param name="_IOA">IOA of object to set new value</param>
        /// <param name="_Value">Value to set</param>
        public void Set(int _IOA, float _Value)
        {
            lock (this)
            {
                int index = IOA.BinarySearch(_IOA);
                if (index > -1)
                {
                    // Trigger the event if value has changed and a handler is present
                    if (Value[index] != _Value && ValueChanged != null)
                    {
                        ValueChanged(this, new IEC104_Database_EventArgs(_IOA, (float)_Value));
                    }

                    Value[index] = _Value;

                    // Trigger the event every time a value is updated and a handler is present
                    if (ValueUpdated != null)
                    {
                        ValueUpdated(this, new IEC104_Database_EventArgs(_IOA, (float)_Value));
                    }
                }
                else
                {
                    throw new Exception("IOA unknown");
                }
            }
        }

        /// <summary>
        /// Returns number of information objects in list
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            lock (this)
            {
                return IOA.Count();
            }
        }
    }

    // Single-point control objects
    class C_SC_NA
    {
        const int Type = (int)TypeID.C_SC_NA_1;
        List<int> IOA = new List<int>();
        List<bool> Value = new List<bool>();
        public delegate void MyEventHandler(object source, IEC104_Database_EventArgs e);
        /// <summary>
        /// Event is raised every time a value is updated
        /// </summary>
        public event MyEventHandler ValueUpdated;
        /// <summary>
        /// Event is raised only when value has changed
        /// </summary>
        public event MyEventHandler ValueChanged;


        public C_SC_NA()
        {
        }

        /// <summary>
        /// Creates specific "Single-point control" object list
        /// </summary>
        /// <param name="firstIOA">First IOA address in array</param>
        /// <param name="count">Number of elements in array</param>
        public C_SC_NA(int firstIOA, int count)
        {
            for (int i = 0; i < count; i++)
            {
                IOA.Add(firstIOA + i);
                Value.Add(false);
            }
        }

        /// <summary>
        /// Add number of "Single-point control" objects to list
        /// </summary>
        /// <param name="firstIOA">First IOA address to add</param>
        /// <param name="count">Number of objects to add</param>
        public void Add(int firstIOA, int count)
        {
            lock (this)
            {
                for (int i = 0; i < count; i++)
                {
                    IOA.Add(firstIOA + i);
                    Value.Add(false);
                }
            }
        }

        /// <summary>
        /// Returns value from specific IOA
        /// </summary>
        /// <param name="_IOA">Information Object Address</param>
        public bool Get(int _IOA)
        {
            lock (this)
            {
                int index = IOA.BinarySearch(_IOA);
                if (index > -1)
                {
                    return Value[index];
                }
                else
                {
                    throw new Exception("IOA unknown");
                }
            }
        }

        /// <summary>
        /// Returns value from list based on index
        /// </summary>
        /// <param name="index">Index of requested information object value in list</param>
        public bool GetValue(int index)
        {
            lock (this)
            {
                if (index > -1 && index < IOA.Count())
                {
                    return Value[index];
                }
                else
                {
                    throw new Exception("Index out of range");
                }
            }
        }

        /// <summary>
        /// Returns IOA from list based on index
        /// </summary>
        /// <param name="index">Index of requested IOA in list</param>
        public int GetIOA(int index)
        {
            lock (this)
            {
                if (index > -1 && index < IOA.Count())
                {
                    return IOA[index];
                }
                else
                {
                    throw new Exception("Index out of range");
                }
            }
        }

        /// <summary>
        /// Returns the IEC-104 type ID for this object group
        /// </summary>
        public int GetType()
        {
            return Type;
        }

        /// <summary>
        /// Set value on specific IOA
        /// </summary>
        /// <param name="_IOA">IOA of object to set new value</param>
        /// <param name="_Value">Value to set</param>
        public void Set(int _IOA, bool _Value)
        {
            lock (this)
            {
                int index = IOA.BinarySearch(_IOA);
                if (index > -1)
                {
                    // Trigger the event if value has changed and a handler is present
                    if (Value[index] != _Value && ValueChanged != null)
                    {
                        ValueChanged(this, new IEC104_Database_EventArgs(_IOA, (bool)_Value));
                    }

                    Value[index] = _Value;

                    // Trigger the event every time a value is updated and a handler is present
                    if (ValueUpdated != null)
                    {
                        ValueUpdated(this, new IEC104_Database_EventArgs(_IOA, (bool)_Value));
                    }
                }
                else
                {
                    throw new Exception("IOA unknown");
                }
            }
        }

        /// <summary>
        /// Returns number of information objects in list
        /// </summary>
        /// <returns></returns>
        public int Count()
        {

            lock (this)
            {
                return IOA.Count();
            }
        }
    }

    // Double-point control objects
    class C_DC_NA
    {
        const int Type = (int)TypeID.C_DC_NA_1;
        List<int> IOA = new List<int>();
        List<byte> Value = new List<byte>();
        public delegate void MyEventHandler(object source, IEC104_Database_EventArgs e);
        /// <summary>
        /// Event is raised every time a value is updated
        /// </summary>
        public event MyEventHandler ValueUpdated;
        /// <summary>
        /// Event is raised only when value has changed
        /// </summary>
        public event MyEventHandler ValueChanged;


        public C_DC_NA()
        {
        }

        /// <summary>
        /// Creates specific object list
        /// </summary>
        /// <param name="firstIOA">First IOA address in array</param>
        /// <param name="count">Number of elements in array</param>
        public C_DC_NA(int firstIOA, int count)
        {
            for (int i = 0; i < count; i++)
            {
                IOA.Add(firstIOA + i);
                Value.Add(0);
            }
        }

        /// <summary>
        /// Add number of objects to list
        /// </summary>
        /// <param name="firstIOA">First IOA address to add</param>
        /// <param name="count">Number of objects to add</param>
        public void Add(int firstIOA, int count)
        {
            lock (this)
            {
                for (int i = 0; i < count; i++)
                {
                    IOA.Add(firstIOA + i);
                    Value.Add(0);
                }
            }
        }

        /// <summary>
        /// Returns value from specific IOA
        /// </summary>
        /// <param name="_IOA">Information Object Address</param>
        public byte Get(int _IOA)
        {
            lock (this)
            {
                int index = IOA.BinarySearch(_IOA);
                if (index > -1)
                {
                    return Value[index];
                }
                else
                {
                    throw new Exception("IOA unknown");
                }
            }
        }

        /// <summary>
        /// Returns value from list based on index
        /// </summary>
        /// <param name="index">Index of requested information object value in list</param>
        public byte GetValue(int index)
        {
            lock (this)
            {
                if (index > -1 && index < IOA.Count())
                {
                    return Value[index];
                }
                else
                {
                    throw new Exception("Index out of range");
                }
            }
        }

        /// <summary>
        /// Returns IOA from list based on index
        /// </summary>
        /// <param name="index">Index of requested IOA in list</param>
        public int GetIOA(int index)
        {
            lock (this)
            {
                if (index > -1 && index < IOA.Count())
                {
                    return IOA[index];
                }
                else
                {
                    throw new Exception("Index out of range");
                }
            }
        }

        /// <summary>
        /// Returns the IEC-104 type ID for this object group
        /// </summary>
        public int GetType()
        {
            return Type;
        }

        /// <summary>
        /// Set value on specific IOA
        /// </summary>
        /// <param name="_IOA">IOA of object to set new value</param>
        /// <param name="_Value">Value to set</param>
        public void Set(int _IOA, byte _Value)
        {
            lock (this)
            {
                int index = IOA.BinarySearch(_IOA);
                if (index > -1)
                {
                    _Value = (byte)(_Value & 0x03);    // use only 2 least significant bits
                    
                    // Trigger the event if value has changed and a handler is present
                    if (Value[index] != _Value && ValueChanged != null)
                    {
                        ValueChanged(this, new IEC104_Database_EventArgs(_IOA, (byte)_Value));
                    }

                    Value[index] = _Value;

                    // Trigger the event every time a value is updated and a handler is present
                    if (ValueUpdated != null)
                    {
                        ValueUpdated(this, new IEC104_Database_EventArgs(_IOA, (byte)_Value));
                    }
                }
                else
                {
                    throw new Exception("IOA unknown");
                }
            }
        }

        /// <summary>
        /// Returns number of information objects in list
        /// </summary>
        /// <returns></returns>
        public int Count()
        {

            lock (this)
            {
                return IOA.Count();
            }
        }
    }

    // Set-point control objects, normalised value
    class C_SE_NA
    {
        const int Type = (int)TypeID.C_SE_NA_1;
        List<int> IOA = new List<int>();
        List<Int16> Value = new List<Int16>();
        public delegate void MyEventHandler(object source, IEC104_Database_EventArgs e);
        /// <summary>
        /// Event is raised every time a value is updated
        /// </summary>
        public event MyEventHandler ValueUpdated;
        /// <summary>
        /// Event is raised only when value has changed
        /// </summary>
        public event MyEventHandler ValueChanged;

        public C_SE_NA()
        {
        }

        /// <summary>
        /// Creates specific object list
        /// </summary>
        /// <param name="firstIOA">First IOA address in array</param>
        /// <param name="count">Number of elements in array</param>
        public C_SE_NA(int firstIOA, int count)
        {
            for (int i = 0; i < count; i++)
            {
                IOA.Add(firstIOA + i);
                Value.Add(0);
            }
        }

        /// <summary>
        /// Add number of objects to list
        /// </summary>
        /// <param name="firstIOA">First IOA address to add</param>
        /// <param name="count">Number of objects to add</param>
        public void Add(int firstIOA, int count)
        {
            lock (this)
            {
                for (int i = 0; i < count; i++)
                {
                    IOA.Add(firstIOA + i);
                    Value.Add(0);
                }
            }
        }

        /// <summary>
        /// Returns value from specific IOA
        /// </summary>
        /// <param name="_IOA">Information Object Address</param>
        public Int16 Get(int _IOA)
        {
            lock (this)
            {
                int index = IOA.BinarySearch(_IOA);
                if (index > -1)
                {
                    return Value[index];
                }
                else
                {
                    throw new Exception("IOA unknown");
                }
            }
        }

        /// <summary>
        /// Returns value from list based on index
        /// </summary>
        /// <param name="index">Index of requested information object value in list</param>
        public Int16 GetValue(int index)
        {
            lock (this)
            {
                if (index > -1 && index < IOA.Count())
                {
                    return Value[index];
                }
                else
                {
                    throw new Exception("Index out of range");
                }
            }
        }

        /// <summary>
        /// Returns IOA from list based on index
        /// </summary>
        /// <param name="index">Index of requested IOA in list</param>
        public int GetIOA(int index)
        {
            lock (this)
            {
                if (index > -1 && index < IOA.Count())
                {
                    return IOA[index];
                }
                else
                {
                    throw new Exception("Index out of range");
                }
            }
        }

        /// <summary>
        /// Returns the IEC-104 type ID for this object group
        /// </summary>
        public int GetType()
        {
            return Type;
        }

        /// <summary>
        /// Set value on specific IOA
        /// </summary>
        /// <param name="_IOA">IOA of object to set new value</param>
        /// <param name="_Value">Value to set</param>
        public void Set(int _IOA, Int16 _Value)
        {
            lock (this)
            {
                int index = IOA.BinarySearch(_IOA);
                if (index > -1)
                {
                    // Trigger the event if value has changed and a handler is present
                    if (Value[index] != _Value && ValueChanged != null)
                    {
                        ValueChanged(this, new IEC104_Database_EventArgs(_IOA, (short)_Value));
                    }

                    Value[index] = _Value;

                    // Trigger the event every time a value is updated and a handler is present
                    if (ValueUpdated != null)
                    {
                        ValueUpdated(this, new IEC104_Database_EventArgs(_IOA, (short)_Value));
                    }
                }
                else
                {
                    throw new Exception("IOA unknown");
                }
            }
        }

        /// <summary>
        /// Returns number of information objects in list
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            lock (this)
            {
                return IOA.Count();
            }
        }
    }

    // Set-point control objects, scaled value
    class C_SE_NB
    {
        const int Type = (int)TypeID.C_SE_NB_1;
        List<int> IOA = new List<int>();
        List<Int16> Value = new List<Int16>();
        public delegate void MyEventHandler(object source, IEC104_Database_EventArgs e);
        /// <summary>
        /// Event is raised every time a value is updated
        /// </summary>
        public event MyEventHandler ValueUpdated;
        /// <summary>
        /// Event is raised only when value has changed
        /// </summary>
        public event MyEventHandler ValueChanged;

        public C_SE_NB()
        {
        }

        /// <summary>
        /// Creates specific object list
        /// </summary>
        /// <param name="firstIOA">First IOA address in array</param>
        /// <param name="count">Number of elements in array</param>
        public C_SE_NB(int firstIOA, int count)
        {
            for (int i = 0; i < count; i++)
            {
                IOA.Add(firstIOA + i);
                Value.Add(0);
            }
        }

        /// <summary>
        /// Add number of objects to list
        /// </summary>
        /// <param name="firstIOA">First IOA address to add</param>
        /// <param name="count">Number of objects to add</param>
        public void Add(int firstIOA, int count)
        {
            lock (this)
            {
                for (int i = 0; i < count; i++)
                {
                    IOA.Add(firstIOA + i);
                    Value.Add(0);
                }
            }
        }

        /// <summary>
        /// Returns value from specific IOA
        /// </summary>
        /// <param name="_IOA">Information Object Address</param>
        public Int16 Get(int _IOA)
        {
            lock (this)
            {
                int index = IOA.BinarySearch(_IOA);
                if (index > -1)
                {
                    return Value[index];
                }
                else
                {
                    throw new Exception("IOA unknown");
                }
            }
        }

        /// <summary>
        /// Returns value from list based on index
        /// </summary>
        /// <param name="index">Index of requested information object value in list</param>
        public Int16 GetValue(int index)
        {
            lock (this)
            {
                if (index > -1 && index < IOA.Count())
                {
                    return Value[index];
                }
                else
                {
                    throw new Exception("Index out of range");
                }
            }
        }

        /// <summary>
        /// Returns IOA from list based on index
        /// </summary>
        /// <param name="index">Index of requested IOA in list</param>
        public int GetIOA(int index)
        {
            lock (this)
            {
                if (index > -1 && index < IOA.Count())
                {
                    return IOA[index];
                }
                else
                {
                    throw new Exception("Index out of range");
                }
            }
        }

        /// <summary>
        /// Returns the IEC-104 type ID for this object group
        /// </summary>
        public int GetType()
        {
            return Type;
        }

        /// <summary>
        /// Set value on specific IOA
        /// </summary>
        /// <param name="_IOA">IOA of object to set new value</param>
        /// <param name="_Value">Value to set</param>
        public void Set(int _IOA, Int16 _Value)
        {
            lock (this)
            {
                int index = IOA.BinarySearch(_IOA);
                if (index > -1)
                {
                    // Trigger the event if value has changed and a handler is present
                    if (Value[index] != _Value && ValueChanged != null)
                    {
                        ValueChanged(this, new IEC104_Database_EventArgs(_IOA, (short)_Value));
                    }

                    Value[index] = _Value;

                    // Trigger the event every time a value is updated and a handler is present
                    if (ValueUpdated != null)
                    {
                        ValueUpdated(this, new IEC104_Database_EventArgs(_IOA, (short)_Value));
                    }
                }
                else
                {
                    throw new Exception("IOA unknown");
                }
            }
        }

        /// <summary>
        /// Returns number of information objects in list
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            lock (this)
            {
                return IOA.Count();
            }
        }
    }

    // Set-point control objects, short floating point number
    class C_SE_NC
    {
        const int Type = (int)TypeID.C_SE_NC_1;
        List<int> IOA = new List<int>();
        List<float> Value = new List<float>();
        public delegate void MyEventHandler(object source, IEC104_Database_EventArgs e);
        /// <summary>
        /// Event is raised every time a value is updated
        /// </summary>
        public event MyEventHandler ValueUpdated;
        /// <summary>
        /// Event is raised only when value has changed
        /// </summary>
        public event MyEventHandler ValueChanged;

        public C_SE_NC()
        {
        }

        /// <summary>
        /// Creates specific object list
        /// </summary>
        /// <param name="firstIOA">First IOA address in array</param>
        /// <param name="count">Number of elements in array</param>
        public C_SE_NC(int firstIOA, int count)
        {
            for (int i = 0; i < count; i++)
            {
                IOA.Add(firstIOA + i);
                Value.Add(0);
            }
        }

        /// <summary>
        /// Add number of objects to list
        /// </summary>
        /// <param name="firstIOA">First IOA address to add</param>
        /// <param name="count">Number of objects to add</param>
        public void Add(int firstIOA, int count)
        {
            lock (this)
            {
                for (int i = 0; i < count; i++)
                {
                    IOA.Add(firstIOA + i);
                    Value.Add(0);
                }
            }
        }

        /// <summary>
        /// Returns value from specific IOA
        /// </summary>
        /// <param name="_IOA">Information Object Address</param>
        public float Get(int _IOA)
        {
            lock (this)
            {
                int index = IOA.BinarySearch(_IOA);
                if (index > -1)
                {
                    return Value[index];
                }
                else
                {
                    throw new Exception("IOA unknown");
                }
            }
        }

        /// <summary>
        /// Returns the IEC-104 type ID for this object group
        /// </summary>
        public int GetType()
        {
            return Type;
        }

        /// <summary>
        /// Returns value from list based on index
        /// </summary>
        /// <param name="index">Index of requested information object value in list</param>
        public float GetValue(int index)
        {
            lock (this)
            {
                if (index > -1 && index < IOA.Count())
                {
                    return Value[index];
                }
                else
                {
                    throw new Exception("Index out of range");
                }
            }
        }

        /// <summary>
        /// Returns IOA from list based on index
        /// </summary>
        /// <param name="index">Index of requested IOA in list</param>
        public int GetIOA(int index)
        {
            lock (this)
            {
                if (index > -1 && index < IOA.Count())
                {
                    return IOA[index];
                }
                else
                {
                    throw new Exception("Index out of range");
                }
            }
        }

        /// <summary>
        /// Set value on specific IOA
        /// </summary>
        /// <param name="_IOA">IOA of object to set new value</param>
        /// <param name="_Value">Value to set</param>
        public void Set(int _IOA, float _Value)
        {
            lock (this)
            {
                int index = IOA.BinarySearch(_IOA);
                if (index > -1)
                {
                    // Trigger the event if value has changed and a handler is present
                    if (Value[index] != _Value && ValueChanged != null)
                    {
                        ValueChanged(this, new IEC104_Database_EventArgs(_IOA, (float)_Value));
                    }

                    Value[index] = _Value;

                    // Trigger the event every time a value is updated and a handler is present
                    if (ValueUpdated != null)
                    {
                        ValueUpdated(this, new IEC104_Database_EventArgs(_IOA, (float)_Value));
                    }
                }
                else
                {
                    throw new Exception("IOA unknown");
                }
            }
        }

        /// <summary>
        /// Returns number of information objects in list
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            lock (this)
            {
                return IOA.Count();
            }
        }
    }

    // Time tag
    class CP56Time2a
    {
        byte[] TimeTag = new byte[7];
    }

    #endregion OBJECT_TYPES



    // Event argument gets sent to the function that handles the event
    public class IEC104_Database_EventArgs : EventArgs
    {
        public int IOA;
        public object NewValue;

        public IEC104_Database_EventArgs(int _IOA, object _Value)
        {
            IOA = _IOA;
            NewValue = _Value;
        }
    }
}

////   
////  CP56Time2a IEC 60870-5-104 time data type implementation   
////   


////   
////  Constructor: decode CP56Time2a data   
////   
//CP56Time2a::CP56Time2a(unsigned char *data)   
//{   
//    CP56Time2aToTime(data, &stime);   
//}   

//CP56Time2a::~CP56Time2a(void)   
//{   
//}   

////   
////  return time string of CP56Time2a decoded   
////   
//void CP56Time2a::GetTimeString(char *buf, size_t size)   
//{   
//    sprintf_s(buf, size,"%2.2d/%2.2d/%4.4d %2.2d:%2.2d:%2.2d.%3.3d", stime.wDay,   
//        stime.wMonth, stime.wYear, stime.wHour, stime.wMinute,   
//        stime.wSecond, stime.wMilliseconds);   
//    return;   
//}   

////   
////  return SYSTEMTIME structure of CP56Time2a decoded   
////   
//SYSTEMTIME CP56Time2a::_GetSystemTime(void)   
//{   
//    return stime;   
//}   

////   
////  return FILETIME structure of CP56Time2a decoded   
////   
//FILETIME CP56Time2a::_GetFileTime(void)   
//{   
//    FILETIME ft;   
//    SystemTimeToFileTime(&stime, &ft);   
//    return ft;   
//}   

////   
////  return CP56Time2a data of actual time.   
////   
//void CP56Time2a::ActualTimeToCP56Time(unsigned char *data)   
//{   
//    SYSTEMTIME st;   
//    GetSystemTime(&st);   
//    TimeToCP56Time2a(&st, data);   
//}   

////   
////  convert FILETIME to CP56Time2a   
////   
//void CP56Time2a::TimeToCP56Time2a(FILETIME *ft, unsigned char *data)   
//{   
//    SYSTEMTIME st;   
//    FileTimeToSystemTime(ft, &st);   
//    TimeToCP56Time2a(&st, data);   
//}   

////   
////  convert SYSTEMTIME to CP56Time2a   
////   
//void CP56Time2a::TimeToCP56Time2a(SYSTEMTIME *st, unsigned char *data)   
//{   
//    unsigned int m;   
//    m = st->wMilliseconds + 1000 * st->wSecond;   
//    data[0] = m & 0xFF;   
//    data[1] = (m & 0xFF00)>>8;   
//    data[2] = st->wMinute & 0x00FF;  // add valid flag and genuine flag   
//    data[3] = st->wHour & 0x00FF;    // add summer flag   
//    data[4] = ((st->wDayOfWeek%7)&0x03)<<5 | (st->wDay&0x1F);   
//    data[5] = st->wMonth & 0x0F;   
//    data[6] = st->wYear - 2000;   
//}   

////   
////  convert CP56Time2a to FILETIME   
////   
//void CP56Time2a::CP56Time2aToTime(unsigned char *data, FILETIME *ft)   
//{   
//    SYSTEMTIME st;   
//    CP56Time2aToTime(data, &st);   
//    SystemTimeToFileTime(&st, ft);   
//}   

////   
////  convert CP56Time2a to SYSTEMTIME   
////   
//void CP56Time2a::CP56Time2aToTime(unsigned char *data, SYSTEMTIME *st)   
//{   
//    unsigned int mili = data[0] | data[1]<<8;   
//    st->wSecond      = mili / 1000;   
//    st->wMilliseconds = mili - st->wSecond*1000;   

//    if(data[2] & 0x40)   
//        genuine = true;   
//    else   
//        genuine = false;   

//    if(data[2] & 0x80)   
//        valid = true;   
//    else   
//        valid = false;   

//    st->wMinute      = data[2] & 0x3F;;   
//    st->wHour        = data[3] & 0x1F;   

//    if(data[3] & 0x80)   
//        summer = true;   
//    else   
//        summer = false;   

//    st->wDay     = data[4] & 0x1F;   
//    st->wDayOfWeek = (data[4] & 0xE0 ) >> 5;   
//    if(st->wDayOfWeek)   // if zero day of week not used.   
//        st->wDayOfWeek = (st->wDayOfWeek + 1)%7;   
//    st->wMonth       = data[5] & 0x0F;   
//    st->wYear        = 2000 + (data[6] & 0x7F);   
//}
