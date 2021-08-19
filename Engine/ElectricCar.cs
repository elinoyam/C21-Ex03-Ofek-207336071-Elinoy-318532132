using System;
using System.Collections.Generic;

namespace Engine
{
    public class ElectricCar : Car, IRechargable
    {
        private readonly ElectricEngine r_CarEngine;
        public ElectricEngine CarEngine
        {
            get
            {
                return r_CarEngine;
            }
        }

        public ElectricCar(string i_LicenseNumber, int i_NumberOfTires, float i_TiresMaxAirPressure) : base(i_LicenseNumber, i_NumberOfTires, i_TiresMaxAirPressure)
        {
            r_CarEngine = new ElectricEngine(3.2f, 0);
           // AddParams();
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
            return $"This is a {ModelName} electric car with {LicenseNumber} license plate. " +
                $" The {ListOfTires.Count} {ListOfTires[0].ManufactureName} tires filled with {ListOfTires[0].CurrentAirPressure} air pressure. " +
                $"The battery status is: {CarEngine.BatteryTimeRemainingInHours}. ";
        }
        public override void AddParams()
        {
            base.AddParams();
            Property property = new Property("Battery remaining hours", "r_CarEngine.m_BatteryTimeRemainingInHours", typeof(float));
            property.FormQuestion = "Enter the current value of battery of the car:"; 
            r_VehicleRequiredProperties.Add("r_CarEngine.m_BatteryTimeRemainingInHours", property);
        }

        public override List<string> ListOfQuestions()
        {
            List<string> listOfQuestions = base.ListOfQuestions();

            listOfQuestions.AddRange(r_CarEngine.ListOfQuestions());

            return listOfQuestions;
        }

        internal override void UpdateParameter(object i_ParsedUserInput, string i_MemberName)
        {
            switch (i_MemberName)
            {
                case "r_CarEngine.m_BatteryTimeRemainingInHours": //m_CurrentFuelCapacity
                    r_CarEngine.BatteryTimeRemainingInHours = (float)i_ParsedUserInput; //TODO not readonly anymore think how to do full engine
                    EnergyPercentageMeter = r_CarEngine.BatteryTimeRemainingInHours / r_CarEngine.MaxBatteryTimeInHours;
                    break;
                default:
                    base.UpdateParameter(i_ParsedUserInput, i_MemberName);
                    break;
            }
        }
    }
}
