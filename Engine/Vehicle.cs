using System;
using System.Collections.Generic;

namespace Engine
{
    class Vehicle
    {
        private readonly string r_ModelName; //TODO read only r_blabla
        private readonly string r_LicenseNumber; 
        private float m_EnergyMeter = 0;
        private List<Tire> m_ListOfTires;

        public Vehicle(string i_ModelName, string i_LicenseNumber, float i_EnergyMeter, List<Tire> i_ListOfTires)
        {
            r_ModelName = i_ModelName;
            r_LicenseNumber = i_LicenseNumber;
            m_EnergyMeter = i_EnergyMeter;
            m_ListOfTires = i_ListOfTires; // TODO check if I can get list in ctor..
        }

        public string ModelName
        {
            get { return r_ModelName; }
        }

        public string LicenseNumber
        {
            get { return r_LicenseNumber; }
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
