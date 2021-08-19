using System.Collections.Generic;

namespace Engine
{
    public class FuelMotorcycle : Motorcycle, IRefuelable
    {
        private readonly FuelEngine r_MotorcycleEngine;
        private const float k_MaxFuelCapacity = 6f;

        public FuelEngine MotorcycleEngine
        {
            get
            {
                return r_MotorcycleEngine;
            }
        }

        public FuelMotorcycle(string i_LicenseNumber, int i_NumberOfTires, float i_TiresMaxAirPressure) : base(i_LicenseNumber, i_NumberOfTires, i_TiresMaxAirPressure)
        {
            r_MotorcycleEngine = new FuelEngine(FuelEngine.eVehicleFuelType.Octan98, k_MaxFuelCapacity, 0);
        }
        
        public FuelMotorcycle(string i_ModelName, string i_LicenseNumber, float i_EnergyPercentageMeter, List<Tire> i_ListOfTires, 
                              eMotorcycleLicenseType i_LicenseType, int i_EngineCapacity,
                              FuelEngine.eVehicleFuelType i_MotorcycleFuelType, float i_MaxFuelCapacity, float i_CurrentFuelCapacity) 
                              : base(i_ModelName, i_LicenseNumber, i_EnergyPercentageMeter, i_ListOfTires, i_LicenseType, i_EngineCapacity)
        {
            r_MotorcycleEngine = new FuelEngine(i_MotorcycleFuelType, i_MaxFuelCapacity, i_CurrentFuelCapacity);
        }

        public FuelMotorcycle(string i_ModelName, string i_LicenseNumber, float i_EnergyPercentageMeter, List<Tire> i_ListOfTires,
                              eMotorcycleLicenseType i_LicenseType, int i_EngineCapacity,
                              FuelEngine i_FuelEngine)
                              : base(i_ModelName, i_LicenseNumber, i_EnergyPercentageMeter, i_ListOfTires, i_LicenseType, i_EngineCapacity)
        {
            r_MotorcycleEngine = i_FuelEngine;
        }

        public override string ToString()
        {
            return $"This is a {ModelName} fuel motorcycle with {LicenseNumber} license plate.\n" +
                $"The {ListOfTires.Count} {ListOfTires[0].ManufactureName} tires filled with {ListOfTires[0].CurrentAirPressure} air pressure out of {ListOfTires[0].MaxAirPressure}.\n" +
                $"The {MotorcycleEngine.FuelType} fuel status is: {MotorcycleEngine.CurrentFuelCapacity} out of {MotorcycleEngine.MaxFuelCapacity}.\n";
        }

        public void Refuel(FuelEngine.eVehicleFuelType i_FuelType, float i_AmountToFill)
        {
            r_MotorcycleEngine.Refuel(i_FuelType, i_AmountToFill);
        }

        public override void AddParams()
        {
            base.AddParams();
            Property fuelAmountProperty = new Property("Current amount of fuel", "r_MotorcycleEngine.m_CurrentFuelCapacity", typeof(float));

            fuelAmountProperty.FormQuestion = "Enter the current amount of fuel of the motorcycle:";
            r_VehicleRequiredPropertiesDictionary.Add("r_MotorcycleEngine.m_CurrentFuelCapacity", fuelAmountProperty);
        }

        internal override void UpdateParameter(object i_ParsedUserInput, string i_MemberName)
        {
            switch (i_MemberName)
            {
                case "r_MotorcycleEngine.m_CurrentFuelCapacity":
                    r_MotorcycleEngine.CurrentFuelCapacity = (float)i_ParsedUserInput;
                    EnergyPercentageMeter = r_MotorcycleEngine.CurrentFuelCapacity / r_MotorcycleEngine.MaxFuelCapacity;
                    break;
                default:
                    base.UpdateParameter(i_ParsedUserInput, i_MemberName);
                    break;
            }
        }
    }
}