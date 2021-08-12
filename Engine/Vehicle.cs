using System;
using System.Collections.Generic;

namespace Engine
{
    class Vehicle
    {
        private readonly string m_ModelName;
        private readonly string m_LicenseNumber; 
        private float m_EnergyMeter = 0;
        private List<Tire> m_ListOfTires;

        public Vehicle(string i_ModelName, string i_LicenseNumber, float i_EnergyMeter, List<Tire> i_listOfTires)
        {
            m_ModelName = i_ModelName;
            m_LicenseNumber = i_LicenseNumber;
            m_EnergyMeter = i_EnergyMeter;
            m_ListOfTires = i_listOfTires; // TODO check if I can get list in ctor..
        }

        public string ModelName
        {
            get { return m_ModelName; }
        }

        public string LicenseNumber
        {
            get { return m_LicenseNumber; }
        }

        public float EnergyMeter
        {
            get { return m_EnergyMeter; }
            set { m_EnergyMeter = value; }
        }

        public List<Tire> ListOfTires
        {
            get { return m_ListOfTires; }
            // TODO do we need set?
        }
    }
}
