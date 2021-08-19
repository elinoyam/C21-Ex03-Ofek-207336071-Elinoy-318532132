using System;
using System.Collections.Generic;

namespace Engine
{
    public class FuelCar : Car, IRefuelable
    {
        private readonly FuelEngine r_CarEngine;
        private const float k_MaxFuelCapacity = 45f;

        public FuelEngine CarEngine
        {
            get
            {
                return r_CarEngine;
            }
        }

        public FuelCar(string i_LicenseNumber, int i_NumberOfTires, float i_TiresMaxAirPressure) : base(i_LicenseNumber, i_NumberOfTires, i_TiresMaxAirPressure)
        {
            r_CarEngine = new FuelEngine(FuelEngine.eVehicleFuelType.Octan95, k_MaxFuelCapacity, 0);
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
            return $"This is a {ModelName} fuel car with {LicenseNumber} license plate.\n" +
                $"The {ListOfTires.Count} {ListOfTires[0].ManufactureName} tires filled with {ListOfTires[0].CurrentAirPressure} air pressure out of {ListOfTires[0].MaxAirPressure}.\n" +
                $"The {CarEngine.FuelType} fuel status is: {CarEngine.CurrentFuelCapacity} out of {CarEngine.MaxFuelCapacity}.\n";
        }

        public override void AddParams()
        {
            base.AddParams();
            Property fuelAmountProperty = new Property("Current amount of fuel", "r_CarEngine.m_CurrentFuelCapacity", typeof(float));

            fuelAmountProperty.FormQuestion = "Enter the current amount of fuel of the car:";
            r_VehicleRequiredPropertiesDictionary.Add("r_CarEngine.m_CurrentFuelCapacity", fuelAmountProperty);
        }

        internal override void UpdateParameter(object i_ParsedUserInput, string i_MemberName)
        {
            switch (i_MemberName)
            {
                case "r_CarEngine.m_CurrentFuelCapacity": 
                    r_CarEngine.CurrentFuelCapacity = (float)i_ParsedUserInput; 
                    EnergyPercentageMeter = r_CarEngine.CurrentFuelCapacity / r_CarEngine.MaxFuelCapacity;
                    break;
                default:
                    base.UpdateParameter(i_ParsedUserInput, i_MemberName);
                    break;
            }
        }
    }
}
