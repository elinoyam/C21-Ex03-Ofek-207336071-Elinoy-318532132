using System;
using System.Collections.Generic;

namespace Engine
{
    class ElectricMotorcycle : Motorcycle
    {
        private readonly ElectricEngine m_MotorcycleEngine;
        public ElectricEngine MotorcycleEngine
        {
            get { return m_MotorcycleEngine; }
        }

        public ElectricMotorcycle(string i_ModelName, string i_LicenseNumber, float i_EnergyMeter, List<Tire> i_listOfTires,
                              MotorcycleLicenseType i_LicenseType, int i_EngineCapacity,
                              float i_MaxBatteryTimeInHours, float i_BatteryTimeRemainingInHours)
            : base(i_ModelName, i_LicenseNumber, i_EnergyMeter, i_listOfTires, i_LicenseType, i_EngineCapacity)
        {
            m_MotorcycleEngine = new ElectricEngine(i_MaxBatteryTimeInHours, i_BatteryTimeRemainingInHours);
        }

        public ElectricMotorcycle(string i_ModelName, string i_LicenseNumber, float i_EnergyMeter, List<Tire> i_listOfTires,
                                  MotorcycleLicenseType i_LicenseType, int i_EngineCapacity,
                                  ElectricEngine i_ElectricEngine)
            : base(i_ModelName, i_LicenseNumber, i_EnergyMeter, i_listOfTires, i_LicenseType, i_EngineCapacity)
        {
            m_MotorcycleEngine = i_ElectricEngine;
        }
    }
}
