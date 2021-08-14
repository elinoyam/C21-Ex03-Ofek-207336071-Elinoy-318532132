using System; //TODO does class in engine need system??
using System.Collections.Generic;

namespace Engine
{
    class Motorcycle : Vehicle
    {
        private eMotorcycleLicenseType m_LicenseType;                                                                                                                                      
        private int m_EngineCapacity;

        public eMotorcycleLicenseType LicenseType
        {
            get { return m_LicenseType; }
            set
            {
                if (System.Enum.IsDefined(typeof(eMotorcycleLicenseType), value))
                {
                    m_LicenseType = value;
                }
                else
                {
                    throw new ArgumentException(); // TODO think of the propper exception
                }
            }
        }

        public int EngineCapacity
        {
            get { return m_EngineCapacity; }
        }

        public enum eMotorcycleLicenseType //TODO maybe protected?
        {
            A,
            B1,
            Aa,
            Bb
        }

        public Motorcycle(List<string> i_CommonVehicleInfo, List<object> i_CommonTypeOfVehicleInfo)
                     : base(i_CommonVehicleInfo)
        {
            //TODO add exceptions
            m_LicenseType = (eMotorcycleLicenseType)i_CommonTypeOfVehicleInfo[0];                                                                                                                                      
            m_EngineCapacity = (int)i_CommonTypeOfVehicleInfo[1];
        }


       
        public Motorcycle(string i_ModelName, string i_LicenseNumber, float i_EnergyMeter, List<Tire> i_ListOfTires, eMotorcycleLicenseType i_LicenseType, int i_EngineCapacity) : base(i_ModelName, i_LicenseNumber, i_EnergyMeter, i_ListOfTires)
        {
            m_LicenseType = i_LicenseType;
            m_EngineCapacity = i_EngineCapacity;
        }
    }
}
