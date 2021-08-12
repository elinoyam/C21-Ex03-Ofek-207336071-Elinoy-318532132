using System;
using System.Collections.Generic;

namespace Engine
{
    class ElectricCar : Car
    {
        private readonly ElectricEngine m_CarEngine;

        public ElectricEngine CarEngine
        {
            get { return m_CarEngine; }
        }


        public ElectricCar(string i_ModelName, string i_LicenseNumber, float i_EnergyMeter, List<Tire> i_listOfTires,
                           CarColor i_CarColor, int i_NumberOfDoors,
                           float i_MaxBatteryTimeInHours, float i_BatteryTimeRemainingInHours)
            : base(i_ModelName, i_LicenseNumber, i_EnergyMeter, i_listOfTires, i_CarColor, i_NumberOfDoors)
        {
            m_CarEngine = new ElectricEngine(i_MaxBatteryTimeInHours,i_BatteryTimeRemainingInHours);
        }

        public ElectricCar(string i_ModelName, string i_LicenseNumber, float i_EnergyMeter, List<Tire> i_listOfTires,
                           CarColor i_CarColor, int i_NumberOfDoors,
                           ElectricEngine i_ElectricEngine)
            : base(i_ModelName, i_LicenseNumber, i_EnergyMeter, i_listOfTires, i_CarColor, i_NumberOfDoors)
        {
            m_CarEngine = i_ElectricEngine;
        }
    }
}
