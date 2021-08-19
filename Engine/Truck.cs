namespace Ex03.GarageLogic
{
    public class Truck : Vehicle, IRefuelable
    {
        private bool m_IsCarryingDangerousMaterials;
        private float m_MaxCarryingWeight;
        private readonly FuelEngine r_TruckFuelEngine;
        private const float k_MaxFuelCapacity = 120f;

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
            r_TruckFuelEngine = new FuelEngine(FuelEngine.eVehicleFuelType.Soler, k_MaxFuelCapacity, 0);
        }

        public override string ToString()
        {
            return $"This is a {ModelName} truck with {LicenseNumber} license plate.\n" +
                $"The {ListOfTires.Count} {ListOfTires[0].ManufactureName} tires filled with {ListOfTires[0].CurrentAirPressure} air pressure out of {ListOfTires[0].MaxAirPressure}.\n " +
                $"The {TruckEngine.FuelType} fuel status is: {TruckEngine.CurrentFuelCapacity} out of {TruckEngine.MaxFuelCapacity}.\n";
        }

        public void Refuel(FuelEngine.eVehicleFuelType i_FuelType, float i_AmountToFill)
        {
            r_TruckFuelEngine.Refuel(i_FuelType, i_AmountToFill);
        }

        public override void AddParams()
        {
            base.AddParams();
            Property propertyPermission = new Property("Permission to carry dangerous materials", "m_IsCarryingDangerousMaterials", typeof(bool));
            Property propertyMaxCarryWeight = new Property("Truck maximum carry weight", "m_MaxCarryingWeight", typeof(float));
            Property propertyCurrentAmountOfFuel = new Property("Current amount of fuel", "r_TruckFuelEngine.m_CurrentFuelCapacity", typeof(float));

            propertyPermission.FormQuestion = "Are you allowed to carry dangerous materials? (enter 1 - true or 0 - false)";
            r_VehicleRequiredPropertiesDictionary.Add("m_IsCarryingDangerousMaterials", propertyPermission);
            propertyMaxCarryWeight.FormQuestion = "Enter your maximum carry weight:";
            r_VehicleRequiredPropertiesDictionary.Add("m_MaxCarryingWeight", propertyMaxCarryWeight);
            propertyCurrentAmountOfFuel.FormQuestion = "Enter the current amount of fuel of the Truck:";
            r_VehicleRequiredPropertiesDictionary.Add("r_TruckFuelEngine.m_CurrentFuelCapacity", propertyCurrentAmountOfFuel);
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
                case "r_TruckFuelEngine.m_CurrentFuelCapacity": 
                    r_TruckFuelEngine.CurrentFuelCapacity = (float)i_ParsedUserInput;
                    EnergyPercentageMeter = (r_TruckFuelEngine.CurrentFuelCapacity / r_TruckFuelEngine.MaxFuelCapacity);
                    break;
                default:
                    base.UpdateParameter(i_ParsedUserInput, i_MemberName);
                    break;
            }
        }
    }
}
