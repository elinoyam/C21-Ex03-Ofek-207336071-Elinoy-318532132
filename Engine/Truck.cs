using System;
using System.Collections.Generic;
using static Engine.FuelEngine;

namespace Engine
{
    public class Truck : Vehicle, IRefuelable
    {
        private bool m_IsCarryingDangerousMaterials;
        private float m_MaxCarryingWeight;
        private readonly FuelEngine r_TruckFuelEngine;

        public FuelEngine TruckEngine
        {
            get
            {
                return r_TruckFuelEngine;
            }
        }

        public bool IsCarryingDangerousMaterials
        {
            get
            {
                return m_IsCarryingDangerousMaterials;
            }

            set
            {
                m_IsCarryingDangerousMaterials = value;
            }
        }

        public float MaxCarryingWeight
        {
            get { return m_MaxCarryingWeight; }
        }

        public Truck(string i_LicenseNumber, int i_NumberOfTires, float i_TiresMaxAirPressure) :base(i_LicenseNumber, i_NumberOfTires,i_TiresMaxAirPressure)
        {
            r_TruckFuelEngine = new FuelEngine(FuelEngine.eVehicleFuelType.Soler, 120, 0);
        }

        public Truck(string i_ModelName, string i_LicenseNumber, float i_EnergyPercentageMeter, List<Tire> i_ListOfTires, bool i_DrivesDangerousMaterials, float i_MaxCarryingWeight, eVehicleFuelType i_VehicleFuelType, float i_MaxFuelCapacity, float i_CurrentFuelCapacity) : base(i_ModelName, i_LicenseNumber, i_EnergyPercentageMeter, i_ListOfTires)
        {
            m_IsCarryingDangerousMaterials = i_DrivesDangerousMaterials;
            m_MaxCarryingWeight = i_MaxCarryingWeight;
            r_TruckFuelEngine = new FuelEngine(i_VehicleFuelType, i_MaxFuelCapacity, i_CurrentFuelCapacity);
        }

        public Truck(string i_ModelName, string i_LicenseNumber, float i_EnergyPercentageMeter, List<Tire> i_ListOfTires, bool i_DrivesDangerousMaterials, float i_MaxCarryingWeight, FuelEngine i_FuelEngine) : base(i_ModelName, i_LicenseNumber, i_EnergyPercentageMeter, i_ListOfTires)
        {
            m_IsCarryingDangerousMaterials = i_DrivesDangerousMaterials;
            m_MaxCarryingWeight = i_MaxCarryingWeight;
            r_TruckFuelEngine = i_FuelEngine;
        }

        public override string ToString()
        {
            return $"This is a {ModelName} fuel car with {LicenseNumber} license plate. " +
                $" The {ListOfTires.Count} {ListOfTires[0].ManufactureName} tires filled with {ListOfTires[0].CurrentAirPressure} air pressure. " +
                $"The {TruckEngine.FuelType} fuel status is: {TruckEngine.CurrentFuelCapacity}. ";
        }

        public void Refuel(FuelEngine.eVehicleFuelType i_FuelType, float i_AmountToFill)
        {
            r_TruckFuelEngine.Refuel(i_FuelType, i_AmountToFill);
        }

        public override void AddParams()
        {
            base.AddParams();
            Property propertyPermission = new Property("Permission to carry dangerous materials", "m_IsCarryingDangerousMaterials", typeof(bool));
            propertyPermission.FormQuestion = "Are you allowed to carry dangerous materials? (enter \'true\' or \' false \')";
            r_VehicleRequiredProperties.Add("m_IsCarryingDangerousMaterials", propertyPermission);
            Property propertyMaxCarryWeight = new Property("Truck maximum carry weight", "m_MaxCarryingWeight", typeof(float));
            propertyMaxCarryWeight.FormQuestion = "Enter your maximum carry weight:";
            r_VehicleRequiredProperties.Add("m_MaxCarryingWeight", propertyMaxCarryWeight);
            Property property = new Property("Current amount of fuel", "r_TruckFuelEngine.m_CurrentFuelCapacity", typeof(float));
            property.FormQuestion = "Enter the current amount of fuel of the Truck:";
            r_VehicleRequiredProperties.Add("r_TruckFuelEngine.m_CurrentFuelCapacity", property);
        }

        public override List<string> ListOfQuestions()
        {
            List<string> listOfQuestions = base.ListOfQuestions();

            listOfQuestions.AddRange(r_TruckFuelEngine.ListOfQuestions());

            return listOfQuestions;
        }

        internal override void UpdateParameter(object i_ParsedUserInput, string i_MemberName)
        {
            switch (i_MemberName)
            {
                case "m_IsCarryingDangerousMaterials":
                    IsCarryingDangerousMaterials = (bool)i_ParsedUserInput;
                    break;
                case "m_MaxCarryingWeight":
                    m_MaxCarryingWeight = (float)i_ParsedUserInput;
                    break;
                case "r_TruckFuelEngine.m_CurrentFuelCapacity": //m_CurrentFuelCapacity
                    r_TruckFuelEngine.CurrentFuelCapacity = (int)i_ParsedUserInput; //TODO not readonly anymore think how to do full engine
                    EnergyPercentageMeter = r_TruckFuelEngine.CurrentFuelCapacity / r_TruckFuelEngine.MaxFuelCapacity;
                    break;
                default:
                    base.UpdateParameter(i_ParsedUserInput, i_MemberName);
                    break;
            }
        }
    }
}
