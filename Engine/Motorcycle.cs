using System; //TODO does class in engine need system??
using System.Collections.Generic;

namespace Engine
{
    class Motorcycle : Vehicle
    {
        private MotorcycleLicenseType m_LicenseType;                                                                                                                                      
        private int m_EngineCapacity;

        public MotorcycleLicenseType LicenseType
        {
            get { return m_LicenseType; }
            set
            {
                if (System.Enum.IsDefined(typeof(MotorcycleLicenseType), value))
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

        public enum MotorcycleLicenseType //TODO maybe protected?
        {
            A,
            B1,
            AA,
            BB
        }

        public Motorcycle(string i_ModelName, string i_LicenseNumber, float i_EnergyMeter, List<Tire> i_listOfTires, MotorcycleLicenseType i_LicenseType, int i_EngineCapacity) : base(i_ModelName, i_LicenseNumber, i_EnergyMeter, i_listOfTires)
        {
            m_LicenseType = i_LicenseType;
            m_EngineCapacity = i_EngineCapacity;
        }
    }
}
