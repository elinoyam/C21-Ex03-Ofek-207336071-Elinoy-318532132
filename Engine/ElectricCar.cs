using System;
using System.Collections.Generic;

namespace Engine
{
    class ElectricCar : Car
    {
        private readonly ElectricEngine r_CarEngine;

        public ElectricEngine CarEngine
        {
            get { return r_CarEngine; }
        }


        public ElectricCar(string i_ModelName, string i_LicenseNumber, float i_EnergyMeter, List<Tire> i_ListOfTires,
                           eCarColor i_CarColor, int i_NumberOfDoors,
                           float i_MaxBatteryTimeInHours, float i_BatteryTimeRemainingInHours)
            : base(i_ModelName, i_LicenseNumber, i_EnergyMeter, i_ListOfTires, i_CarColor, i_NumberOfDoors)
        {
            r_CarEngine = new ElectricEngine(i_MaxBatteryTimeInHours,i_BatteryTimeRemainingInHours);
        }

        public ElectricCar(string i_ModelName, string i_LicenseNumber, float i_EnergyMeter, List<Tire> i_ListOfTires,
                           eCarColor i_CarColor, int i_NumberOfDoors,
                           ElectricEngine i_ElectricEngine)
            : base(i_ModelName, i_LicenseNumber, i_EnergyMeter, i_ListOfTires, i_CarColor, i_NumberOfDoors)
        {
            r_CarEngine = i_ElectricEngine;
        }
        

        public void Refuel(float i_MinutesToCharge)
        {
            r_CarEngine.Refuel(i_MinutesToCharge);
        }

        public override string ToString()
        {
            return $"This is a {ModelName} electric car with {LicenseNumber} license plate. " +
                $" The {ListOfTires.Count} {ListOfTires[0].ManufactureName} tires filled with {ListOfTires[0].CurrentAirPressure} air pressure. " +
                $"The battery status is: {CarEngine.BatteryTimeRemainingInHours}. ";
        }
    }
}
