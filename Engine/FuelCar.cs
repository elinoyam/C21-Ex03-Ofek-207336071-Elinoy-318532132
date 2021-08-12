using System;
using System.Collections.Generic;

namespace Engine
{
    class FuelCar : Car
    {
        private readonly FuelEngine m_CarEngine;

        public FuelEngine CarEngine
        {
            get { return m_CarEngine; }
        }

        public FuelCar(string i_ModelName, string i_LicenseNumber, float i_EnergyMeter, List<Tire> i_listOfTires,
              CarColor i_CarColor, int i_NumberOfDoors,
              FuelEngine.VehicleFuelType i_CarFuelType, float i_MaxFuelCapacity, float i_CurrentFuelCapacity)
              : base(i_ModelName, i_LicenseNumber, i_EnergyMeter, i_listOfTires, i_CarColor, i_NumberOfDoors)
        {
            m_CarEngine = new FuelEngine(i_CarFuelType, i_MaxFuelCapacity, i_CurrentFuelCapacity);
        }

        public FuelCar(string i_ModelName, string i_LicenseNumber, float i_EnergyMeter, List<Tire> i_listOfTires,
                       CarColor i_CarColor, int i_NumberOfDoors,
                       FuelEngine i_FuelEngine)
                       : base(i_ModelName, i_LicenseNumber, i_EnergyMeter, i_listOfTires, i_CarColor, i_NumberOfDoors)
        {
            m_CarEngine = i_FuelEngine;
        }

    }
}
