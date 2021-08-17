using System;
using System.Collections.Generic;

namespace Engine
{
    public class FuelCar : Car, Refuelable
    {
        private readonly FuelEngine r_CarEngine;

        public FuelEngine CarEngine
        {
            get
            {
                return r_CarEngine;

            }
        }

        public FuelCar(string i_LicenseNumber, int i_NumberOfTires, float i_TiresMaxAirPressure) : base(i_LicenseNumber, i_NumberOfTires, i_TiresMaxAirPressure)
        {
            r_CarEngine = new FuelEngine(FuelEngine.eVehicleFuelType.Octan95, 45, 0);
        }

        public FuelCar(string i_ModelName, string i_LicenseNumber, float i_EnergyPercentageMeter, List<Tire> i_ListOfTires,
              eCarColor i_CarColor, int i_NumberOfDoors,
              FuelEngine.eVehicleFuelType i_CarFuelType, float i_MaxFuelCapacity, float i_CurrentFuelCapacity)
              : base(i_ModelName, i_LicenseNumber, i_EnergyPercentageMeter, i_ListOfTires, i_CarColor, i_NumberOfDoors)
        {
            r_CarEngine = new FuelEngine(i_CarFuelType, i_MaxFuelCapacity, i_CurrentFuelCapacity);
        }

        public FuelCar(string i_ModelName, string i_LicenseNumber, float i_EnergyPercentageMeter, List<Tire> i_ListOfTires,
                       eCarColor i_CarColor, int i_NumberOfDoors,
                       FuelEngine i_FuelEngine)
                       : base(i_ModelName, i_LicenseNumber, i_EnergyPercentageMeter, i_ListOfTires, i_CarColor, i_NumberOfDoors)
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
                $" The {ListOfTires.Count} {ListOfTires[0].ManufactureName} tires filled with {ListOfTires[0].CurrentAirPressure} air pressure. " +
                $"The {CarEngine.FuelType} fuel status is: {CarEngine.CurrentFuelCapacity}. ";
        }

        public override List<string> ListOfQuestions()
        {
            List<string> listOfQuestions = base.ListOfQuestions();

            listOfQuestions.AddRange(r_CarEngine.ListOfQuestions());

            return listOfQuestions;
        }
    }
}
