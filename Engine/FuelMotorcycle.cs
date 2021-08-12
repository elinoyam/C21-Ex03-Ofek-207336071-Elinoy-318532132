using System;
using System.Collections.Generic;

namespace Engine
{
    class FuelMotorcycle : Motorcycle
    {
        private readonly FuelEngine m_MotorcycleEngine;
        public FuelEngine MotorcycleEngine
        {
            get { return m_MotorcycleEngine; }
        }

        public FuelMotorcycle(string i_ModelName, string i_LicenseNumber, float i_EnergyMeter, List<Tire> i_listOfTires, 
                              MotorcycleLicenseType i_LicenseType, int i_EngineCapacity,
                              FuelEngine.VehicleFuelType i_MotorcycleFuelType, float i_MaxFuelCapacity, float i_CurrentFuelCapacity) 
                              : base(i_ModelName, i_LicenseNumber, i_EnergyMeter, i_listOfTires, i_LicenseType, i_EngineCapacity)
        {
            m_MotorcycleEngine = new FuelEngine(i_MotorcycleFuelType, i_MaxFuelCapacity, i_CurrentFuelCapacity);
        }

        public FuelMotorcycle(string i_ModelName, string i_LicenseNumber, float i_EnergyMeter, List<Tire> i_listOfTires,
                              MotorcycleLicenseType i_LicenseType, int i_EngineCapacity,
                              FuelEngine i_FuelEngine)
                              : base(i_ModelName, i_LicenseNumber, i_EnergyMeter, i_listOfTires, i_LicenseType, i_EngineCapacity)
        {
            m_MotorcycleEngine = i_FuelEngine;
        }
    }
}
