using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class ElectricCar : Car, IRechargeable
    {
        private readonly ElectricEngine r_CarEngine;
        private const float k_MaxBatteryTimeInHours = 3.2f;

        public ElectricEngine CarEngine
        {
            get
            {
                return r_CarEngine;
            }
        }

        public ElectricCar(string i_LicenseNumber, int i_NumberOfTires, float i_TiresMaxAirPressure) : base(i_LicenseNumber, i_NumberOfTires, i_TiresMaxAirPressure)
        {
            r_CarEngine = new ElectricEngine(k_MaxBatteryTimeInHours, 0);
        }

        public ElectricCar(string i_ModelName, string i_LicenseNumber, float i_EnergyPercentageMeter, List<Tire> i_ListOfTires,
                           eCarColor i_CarColor, int i_NumberOfDoors,
                           float i_MaxBatteryTimeInHours, float i_BatteryTimeRemainingInHours)
            : base(i_ModelName, i_LicenseNumber, i_EnergyPercentageMeter, i_ListOfTires, i_CarColor, i_NumberOfDoors)
        {
            r_CarEngine = new ElectricEngine(i_MaxBatteryTimeInHours,i_BatteryTimeRemainingInHours);
        }

        public ElectricCar(string i_ModelName, string i_LicenseNumber, float i_EnergyPercentageMeter, List<Tire> i_ListOfTires,
                           eCarColor i_CarColor, int i_NumberOfDoors,
                           ElectricEngine i_ElectricEngine)
            : base(i_ModelName, i_LicenseNumber, i_EnergyPercentageMeter, i_ListOfTires, i_CarColor, i_NumberOfDoors)
        {
            r_CarEngine = i_ElectricEngine;
        }

        public void ReCharge(float i_MinutesToCharge)
        {
            r_CarEngine.Recharge(i_MinutesToCharge);
        }

        public override string ToString()
        {
            return $"This is a {ModelName} electric car with {LicenseNumber} license plate.\n" +
                $"The {ListOfTires.Count} {ListOfTires[0].ManufactureName} tires filled with {ListOfTires[0].CurrentAirPressure} air pressure out of {ListOfTires[0].MaxAirPressure}.\n" +
                $"The battery status is: {CarEngine.BatteryTimeRemainingInHours} out of {CarEngine.MaxBatteryTimeInHours}.\n";
        }

        public override void AddParams()
        {
            base.AddParams();
            Property batteryProperty = new Property("Battery remaining hours", "r_CarEngine.m_BatteryTimeRemainingInHours", typeof(float));

            batteryProperty.FormQuestion = "Enter the current value of battery of the car:"; 
            r_VehicleRequiredPropertiesDictionary.Add("r_CarEngine.m_BatteryTimeRemainingInHours", batteryProperty);
        }
        
        internal override void UpdateParameter(object i_ParsedUserInput, string i_MemberName)
        {
            switch (i_MemberName)
            {
                case "r_CarEngine.m_BatteryTimeRemainingInHours": 
                    r_CarEngine.BatteryTimeRemainingInHours = (float)i_ParsedUserInput;
                    EnergyPercentageMeter = r_CarEngine.BatteryTimeRemainingInHours / r_CarEngine.MaxBatteryTimeInHours;
                    break;
                default:
                    base.UpdateParameter(i_ParsedUserInput, i_MemberName);
                    break;
            }
        }
    }
}
