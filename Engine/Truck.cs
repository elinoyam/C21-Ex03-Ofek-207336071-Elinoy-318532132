using System;
using System.Collections.Generic;
using static Engine.FuelEngine;

namespace Engine
{
    public class Truck : Vehicle, Refuelable
    {
        private bool m_IsCarryingDangerousMaterials;
        private float m_MaxCarryingWeight;
        private readonly FuelEngine r_TruckfuelEngine;

        public FuelEngine TruckEngine
        {
            get { return r_TruckfuelEngine; }
        }
        public bool IsCarryingDangerousMaterials
        {
            get { return m_IsCarryingDangerousMaterials; }
        }

        public float MaxCarryingWeight
        {
            get { return m_MaxCarryingWeight; }
        }

        public Truck(string i_LicenseNumber, int i_NumberOfTires, float i_TiresMaxAirPressure) :base(i_LicenseNumber, i_NumberOfTires,i_TiresMaxAirPressure)
        {
            r_TruckfuelEngine = new FuelEngine(FuelEngine.eVehicleFuelType.Soler, 120, 0);
        }

        public Truck(string i_ModelName, string i_LicenseNumber, float i_EnergyPercentageMeter, List<Tire> i_ListOfTires, bool i_DrivesDangerousMaterials, float i_MaxCarryingWeight, eVehicleFuelType i_VehicleFuelType, float i_MaxFuelCapacity, float i_CurrentFuelCapacity) : base(i_ModelName, i_LicenseNumber, i_EnergyPercentageMeter, i_ListOfTires)
        {
            m_IsCarryingDangerousMaterials = i_DrivesDangerousMaterials;
            m_MaxCarryingWeight = i_MaxCarryingWeight;
            r_TruckfuelEngine = new FuelEngine(i_VehicleFuelType, i_MaxFuelCapacity, i_CurrentFuelCapacity);
        }

        public Truck(string i_ModelName, string i_LicenseNumber, float i_EnergyPercentageMeter, List<Tire> i_ListOfTires, bool i_DrivesDangerousMaterials, float i_MaxCarryingWeight, FuelEngine i_FuelEngine) : base(i_ModelName, i_LicenseNumber, i_EnergyPercentageMeter, i_ListOfTires)
        {
            m_IsCarryingDangerousMaterials = i_DrivesDangerousMaterials;
            m_MaxCarryingWeight = i_MaxCarryingWeight;
            r_TruckfuelEngine = i_FuelEngine;
        }

        public override string ToString()
        {
            return $"This is a {ModelName} fuel car with {LicenseNumber} license plate. " +
                $" The {ListOfTires.Count} {ListOfTires[0].ManufactureName} tires filled with {ListOfTires[0].CurrentAirPressure} air pressure. " +
                $"The {TruckEngine.FuelType} fuel status is: {TruckEngine.CurrentFuelCapacity}. ";
        }

        public void Refuel(FuelEngine.eVehicleFuelType i_FuelType, float i_AmountToFill)
        {
            r_TruckfuelEngine.Refuel(i_FuelType, i_AmountToFill);
        }

        public override List<string> ListOfQuestions()
        {
            List<string> listOfQuestions = base.ListOfQuestions();

            listOfQuestions.AddRange(r_TruckfuelEngine.ListOfQuestions());

            return listOfQuestions;
        }
    }
}
