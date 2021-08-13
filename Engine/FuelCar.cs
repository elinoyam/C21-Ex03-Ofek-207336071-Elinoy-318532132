using System;
using System.Collections.Generic;

namespace Engine
{
    class FuelCar : Car
    {
        private readonly FuelEngine r_CarEngine;

        public FuelEngine CarEngine
        {
            get { return r_CarEngine; }
        }

        public FuelCar(string i_ModelName, string i_LicenseNumber, float i_EnergyMeter, List<Tire> i_ListOfTires,
              eCarColor i_CarColor, int i_NumberOfDoors,
              FuelEngine.eVehicleFuelType i_CarFuelType, float i_MaxFuelCapacity, float i_CurrentFuelCapacity)
              : base(i_ModelName, i_LicenseNumber, i_EnergyMeter, i_ListOfTires, i_CarColor, i_NumberOfDoors)
        {
            r_CarEngine = new FuelEngine(i_CarFuelType, i_MaxFuelCapacity, i_CurrentFuelCapacity);
        }

        public FuelCar(string i_ModelName, string i_LicenseNumber, float i_EnergyMeter, List<Tire> i_ListOfTires,
                       eCarColor i_CarColor, int i_NumberOfDoors,
                       FuelEngine i_FuelEngine)
                       : base(i_ModelName, i_LicenseNumber, i_EnergyMeter, i_ListOfTires, i_CarColor, i_NumberOfDoors)
        {
            r_CarEngine = i_FuelEngine;
        }

        public void Refuel(FuelEngine.eVehicleFuelType i_FuelType, float i_AmountToFill)
        {
            r_CarEngine.Refuel(i_FuelType, i_AmountToFill);
        }

        public override string ToString()
        {
            return $"This is a {ModelName} fuel car with {LicenseNumber} license plate. " +
                $" The {ListOfTires.Count} {ListOfTires[0].ManufactorName} tires filled with {ListOfTires[0].CurrentAirPressure} air pressure. " +
                $"The {CarEngine.FuelType} fuel status is: {CarEngine.CurrentFuelCapacity}. ";
        }
    }
}
