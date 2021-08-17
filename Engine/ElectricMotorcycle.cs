using System;
using System.Collections.Generic;

namespace Engine
{
    public class ElectricMotorcycle : Motorcycle, Rechargable
    {
        private readonly ElectricEngine r_MotorcycleEngine;
        public ElectricEngine MotorcycleEngine
        {
            get { return r_MotorcycleEngine; }
        }

        public ElectricMotorcycle(string i_LicenseNumber, int i_NumberOfTires, float i_TiresMaxAirPressure) :base(i_LicenseNumber, i_NumberOfTires, i_TiresMaxAirPressure)
        {
            r_MotorcycleEngine = new ElectricEngine(1.8f, 0);
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
            return $"This is a {ModelName} electric mototrcycle with {LicenseNumber} license plate. " +
                $" The {ListOfTires.Count} {ListOfTires[0].ManufactureName} tires filled with {ListOfTires[0].CurrentAirPressure} air pressure. " +
                $"The battery status is: {MotorcycleEngine.BatteryTimeRemainingInHours}. ";
        }

        public void ReCharge(float i_MinutesToCharge)
        {
            r_MotorcycleEngine.Recharge(i_MinutesToCharge);
        }

        public override List<string> ListOfQuestions()
        {
            List<string> listOfQuestions = base.ListOfQuestions();

            listOfQuestions.AddRange(r_MotorcycleEngine.ListOfQuestions());

            return listOfQuestions;
        }
    }
}
