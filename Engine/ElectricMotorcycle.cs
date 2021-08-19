using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : Motorcycle, IRechargeable
    {
        private readonly ElectricEngine r_MotorcycleEngine;
        private const float k_MaxBatteryTimeInHours = 1.8f;

        public ElectricEngine MotorcycleEngine
        {
            get
            {
                return r_MotorcycleEngine;
            }
        }

        public ElectricMotorcycle(string i_LicenseNumber, int i_NumberOfTires, float i_TiresMaxAirPressure) :base(i_LicenseNumber, i_NumberOfTires, i_TiresMaxAirPressure)
        {
            r_MotorcycleEngine = new ElectricEngine(k_MaxBatteryTimeInHours, 0);
        }

        public ElectricMotorcycle(string i_ModelName, string i_LicenseNumber, float i_EnergyPercentageMeter, List<Tire> i_ListOfTires,
                              eMotorcycleLicenseType i_LicenseType, int i_EngineCapacity,
                              float i_MaxBatteryTimeInHours, float i_BatteryTimeRemainingInHours)
            : base(i_ModelName, i_LicenseNumber, i_EnergyPercentageMeter, i_ListOfTires, i_LicenseType, i_EngineCapacity)
        {
            r_MotorcycleEngine = new ElectricEngine(i_MaxBatteryTimeInHours, i_BatteryTimeRemainingInHours);
        }

        public ElectricMotorcycle(string i_ModelName, string i_LicenseNumber, float i_EnergyPercentageMeter, List<Tire> i_ListOfTires,
                                  eMotorcycleLicenseType i_LicenseType, int i_EngineCapacity,
                                  ElectricEngine i_ElectricEngine)
            : base(i_ModelName, i_LicenseNumber, i_EnergyPercentageMeter, i_ListOfTires, i_LicenseType, i_EngineCapacity)
        {
            r_MotorcycleEngine = i_ElectricEngine;
        }

        public override string ToString()
        {
            return $"This is a {ModelName} electric motorcycle with {LicenseNumber} license plate.\n " +
                $"The {ListOfTires.Count} {ListOfTires[0].ManufactureName} tires filled with {ListOfTires[0].CurrentAirPressure} air pressure out of {ListOfTires[0].MaxAirPressure}.\n " +
                $"The battery status is: {MotorcycleEngine.BatteryTimeRemainingInHours} out of {MotorcycleEngine.MaxBatteryTimeInHours}.\n ";
        }

        public void ReCharge(float i_MinutesToCharge)
        {
            r_MotorcycleEngine.Recharge(i_MinutesToCharge);
        }

        public override void AddParams()
        {
            base.AddParams();
            Property batteryProperty = new Property("Battery remaining hours", "r_MotorcycleEngine.m_BatteryTimeRemainingInHours", typeof(float));

            batteryProperty.FormQuestion = "Enter the current value of battery of the motorcycle:";
            r_VehicleRequiredPropertiesDictionary.Add("r_MotorcycleEngine.m_BatteryTimeRemainingInHours", batteryProperty);
        }

        internal override void UpdateParameter(object i_ParsedUserInput, string i_MemberName)
        {
            switch (i_MemberName)
            {
                case "r_MotorcycleEngine.m_BatteryTimeRemainingInHours":
                    r_MotorcycleEngine.BatteryTimeRemainingInHours = (float)i_ParsedUserInput; 
                    EnergyPercentageMeter = r_MotorcycleEngine.BatteryTimeRemainingInHours / r_MotorcycleEngine.MaxBatteryTimeInHours;
                    break;
                default:
                    base.UpdateParameter(i_ParsedUserInput, i_MemberName);
                    break;
            }
        }
    }
}
