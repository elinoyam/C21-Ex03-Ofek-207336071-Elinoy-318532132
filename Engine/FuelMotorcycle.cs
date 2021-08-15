﻿using System;
using System.Collections.Generic;

namespace Engine
{
    public class FuelMotorcycle : Motorcycle
    {
        private readonly FuelEngine r_MotorcycleEngine;
        public FuelEngine MotorcycleEngine
        {
            get { return r_MotorcycleEngine; }
        }

        public FuelMotorcycle(List<string> i_CommonVehicleInfo,
                              List<object> i_CommonTypeOfVehicleInfo, List<object> i_SpecificTypeOfVehicleInfo)
                            : base (i_CommonVehicleInfo, i_CommonTypeOfVehicleInfo)
        {
            // i_SpecificTypeOfVehicleInfo - 0- 1-
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
    }
}