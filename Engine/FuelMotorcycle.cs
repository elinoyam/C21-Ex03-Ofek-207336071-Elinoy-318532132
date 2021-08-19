using System;
using System.Collections.Generic;

namespace Engine
{
    public class FuelMotorcycle : Motorcycle, IRefuelable
    {
        private FuelEngine r_MotorcycleEngine;
        public FuelEngine MotorcycleEngine
        {
            get
            {
                return r_MotorcycleEngine;

            }
        }

        public FuelMotorcycle(string i_LicenseNumber, int i_NumberOfTires, float i_TiresMaxAirPressure) : base(i_LicenseNumber, i_NumberOfTires, i_TiresMaxAirPressure)
        {
            r_MotorcycleEngine = new FuelEngine(FuelEngine.eVehicleFuelType.Octan98, 6, 0);
            //AddParams();
        }

        public FuelMotorcycle(List<string> i_CommonVehicleInfo,
                              List<object> i_CommonTypeOfVehicleInfo, List<object> i_SpecificTypeOfVehicleInfo)
                            : base (i_CommonVehicleInfo, i_CommonTypeOfVehicleInfo)
        {
            // i_SpecificTypeOfVehicleInfo - 0- 1-  // TODO: check if we want to delete this method
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
            return $"This is a {ModelName} fuel motorcycle with {LicenseNumber} license plate. " +
                $" The {ListOfTires.Count} {ListOfTires[0].ManufactureName} tires filled with {ListOfTires[0].CurrentAirPressure} air pressure. " +
                $"The {MotorcycleEngine.FuelType} fuel status is: {MotorcycleEngine.CurrentFuelCapacity}. ";
        }

        public void Refuel(FuelEngine.eVehicleFuelType i_FuelType, float i_AmountToFill)
        {
            r_MotorcycleEngine.Refuel(i_FuelType, i_AmountToFill);
        }

        public override void AddParams()
        {
            base.AddParams();
            Property property = new Property("Current amount of fuel", "r_MotorcycleEngine.m_CurrentFuelCapacity", typeof(float));
            property.FormQuestion = "Enter the current amount of fuel of the motorcycle:";
            string name = r_MotorcycleEngine.GetType().Name; //TODO fine if it return r_MotorcycleEngine
            r_VehicleRequiredProperties.Add("r_MotorcycleEngine.m_CurrentFuelCapacity", property);
        }

        public override List<string> ListOfQuestions()
        {
            List<string> listOfQuestions = base.ListOfQuestions();

            listOfQuestions.AddRange(r_MotorcycleEngine.ListOfQuestions());

            return listOfQuestions;
        }

        public virtual void UpdateVehicle(List<string> i_SpecificTypeOfVehicleInfo, ref int i_CurrentQuestion)
        {   // TODO: check if we need to change this to override - in all the needed places
            UpdateVehicle(i_SpecificTypeOfVehicleInfo, ref i_CurrentQuestion);
            // i need to do 2 questions
            int index = NumberOfQuestions(); //3+2

            for (; i_CurrentQuestion < index; ++i_CurrentQuestion)
            {
                //0 -module, 1- tire manufacture, 2-air pressure
                //read 2
            }
        }

        internal override void UpdateParameter(object i_ParsedUserInput, string i_MemberName)
        {
            switch (i_MemberName)
            {
                case "r_MotorcycleEngine.m_CurrentFuelCapacity": //m_CurrentFuelCapacity
                    r_MotorcycleEngine.CurrentFuelCapacity = (float)i_ParsedUserInput; //TODO not readonly anymore think how to do full engine
                    EnergyPercentageMeter = r_MotorcycleEngine.CurrentFuelCapacity / r_MotorcycleEngine.MaxFuelCapacity;
                    break;
                default:
                    base.UpdateParameter(i_ParsedUserInput, i_MemberName);
                    break;
            }
        }
    }
}