using System;
using System.Collections.Generic;

namespace Engine
{
    class Truck : Vehicle
    {
        private readonly bool m_IsCarryingDangerousMaterials;
        private readonly float m_MaxCarryingWeight;

        public bool IsCarryingDangerousMaterials
        {
            get { return m_IsCarryingDangerousMaterials; }
        }

        public float MaxCarryingWeight
        {
            get { return m_MaxCarryingWeight; }
        }

        public Truck(string i_ModelName, string i_LicenseNumber, float i_EnergyMeter, List<Tire> i_listOfTires, bool i_DrivesDangerousMaterials, int i_MaxCarryingWeight) : base(i_ModelName, i_LicenseNumber, i_EnergyMeter, i_listOfTires)
        {
            m_IsCarryingDangerousMaterials = i_DrivesDangerousMaterials;
            m_MaxCarryingWeight = i_MaxCarryingWeight;
        }

    }
}
