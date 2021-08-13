using System;
using System.Collections.Generic;

namespace Engine
{
    class ElectricMotorcycle : Motorcycle
    {
        private readonly ElectricEngine r_MotorcycleEngine;
        public ElectricEngine MotorcycleEngine
        {
            get { return r_MotorcycleEngine; }
        }

        public ElectricMotorcycle(string i_ModelName, string i_LicenseNumber, float i_EnergyMeter, List<Tire> i_ListOfTires,
                              eMotorcycleLicenseType i_LicenseType, int i_EngineCapacity,
                              float i_MaxBatteryTimeInHours, float i_BatteryTimeRemainingInHours)
            : base(i_ModelName, i_LicenseNumber, i_EnergyMeter, i_ListOfTires, i_LicenseType, i_EngineCapacity)
        {
            r_MotorcycleEngine = new ElectricEngine(i_MaxBatteryTimeInHours, i_BatteryTimeRemainingInHours);
        }

        public ElectricMotorcycle(string i_ModelName, string i_LicenseNumber, float i_EnergyMeter, List<Tire> i_ListOfTires,
                                  eMotorcycleLicenseType i_LicenseType, int i_EngineCapacity,
                                  ElectricEngine i_ElectricEngine)
            : base(i_ModelName, i_LicenseNumber, i_EnergyMeter, i_ListOfTires, i_LicenseType, i_EngineCapacity)
        {
            r_MotorcycleEngine = i_ElectricEngine;
        }

        public override string ToString()
        {
            return $"This is a {ModelName} electric mototrcycle with {LicenseNumber} license plate. " +
                $" The {ListOfTires.Count} {ListOfTires[0].ManufactorName} tires filled with {ListOfTires[0].CurrentAirPressure} air pressure. " +
                $"The battery status is: {MotorcycleEngine.BatteryTimeRemainingInHours}. ";
        }
    }
}
