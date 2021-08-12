using System;
using System.Collections.Generic;

namespace Engine
{
    class Truck : Vehicle
    {
        private readonly bool r_IsCarryingDangerousMaterials;
        private readonly float r_MaxCarryingWeight;

        public bool IsCarryingDangerousMaterials
        {
            get { return r_IsCarryingDangerousMaterials; }
        }

        public float MaxCarryingWeight
        {
            get { return r_MaxCarryingWeight; }
        }

        public Truck(string i_ModelName, string i_LicenseNumber, float i_EnergyMeter, List<Tire> i_ListOfTires, bool i_DrivesDangerousMaterials, int i_MaxCarryingWeight) : base(i_ModelName, i_LicenseNumber, i_EnergyMeter, i_ListOfTires)
        {
            r_IsCarryingDangerousMaterials = i_DrivesDangerousMaterials;
            r_MaxCarryingWeight = i_MaxCarryingWeight;
        }

    }
}
