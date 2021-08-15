using System;
using System.Collections.Generic;
using static Engine.FuelEngine;
using static Engine.FuelEngine.eVehicleFuelType;
using static Engine.GarageManager; // TODO y i need this? I just want the enum

namespace Engine
{
    public class VehicleFactory
    {
        public static Vehicle CreateNewVehicle(eAvailableTypesOfVehicles i_VehicleType, List<string> i_CommonVehicleInfo, 
                                               List<object> i_CommonTypeOfVehicleInfo, List<object> i_SpecificTypeOfVehicleInfo)
        {
            Vehicle newVehicle = null;
            string licenseNumber;
            string modelName;
            float energyPercentageMeter;
            List<Tire> tiresList;

            getVehicleDetails(i_CommonVehicleInfo, out licenseNumber, out modelName);

            float r_MaxAirPressure;
            int r_NumOfTires;
            int engineCapacity;
            Motorcycle.eMotorcycleLicenseType motorcycleLicenseType;

            Car.eCarColor colorType;
            int numberOfDoors;
            switch (i_VehicleType)
            {
                case eAvailableTypesOfVehicles.FuelMotorcycle:
                    r_MaxAirPressure = 30;
                    r_NumOfTires = 2;
                    eVehicleFuelType fuelMotorcycleTypeEngine = Octan98;
                    float maxEngineCapacity = 6;

                    tiresList = makeTires(i_CommonVehicleInfo, r_NumOfTires, r_MaxAirPressure);
                    getMotorcycleDetails(i_CommonTypeOfVehicleInfo, out motorcycleLicenseType, out engineCapacity);
                    FuelEngine fuelMotorcycleEngine = getFuelEngineDetails(i_SpecificTypeOfVehicleInfo, fuelMotorcycleTypeEngine, maxEngineCapacity, out energyPercentageMeter);
                    newVehicle = new FuelMotorcycle( modelName, licenseNumber, energyPercentageMeter, tiresList,
                            motorcycleLicenseType, engineCapacity,
                            fuelMotorcycleEngine);

                    break;

                case eAvailableTypesOfVehicles.ElectricMotorcycle:
                    r_MaxAirPressure = 30;
                    r_NumOfTires = 2;
                    float maxElectricCapacity = 1.8f;

                    tiresList = makeTires(i_CommonVehicleInfo, r_NumOfTires, r_MaxAirPressure);
                    getMotorcycleDetails(i_CommonTypeOfVehicleInfo, out motorcycleLicenseType, out engineCapacity);
                    ElectricEngine ElectricMotorcycleEngine = getElectricEngineDetails(i_SpecificTypeOfVehicleInfo, maxElectricCapacity, out energyPercentageMeter);
                    newVehicle = new ElectricMotorcycle(modelName, licenseNumber, energyPercentageMeter, tiresList,
                        motorcycleLicenseType, engineCapacity,
                        ElectricMotorcycleEngine);
                    break;

                case eAvailableTypesOfVehicles.FuelCar:
                    r_NumOfTires = 4;
                    r_MaxAirPressure = 32;
                    eVehicleFuelType fuelCarTypeEngine = Octan95;
                    maxEngineCapacity = 45;

                    tiresList = makeTires(i_CommonVehicleInfo, r_NumOfTires, r_MaxAirPressure);
                    getCarDetails(i_CommonTypeOfVehicleInfo, out colorType, out numberOfDoors);
                    FuelEngine fuelCarEngine = getFuelEngineDetails(i_SpecificTypeOfVehicleInfo, fuelCarTypeEngine, maxEngineCapacity, out energyPercentageMeter);
                    newVehicle = new FuelCar(modelName, licenseNumber, energyPercentageMeter, tiresList,
                        colorType, numberOfDoors,
                        fuelCarEngine);

                    break;

                case eAvailableTypesOfVehicles.ElectricCar:
                    r_NumOfTires = 4;
                    r_MaxAirPressure = 32;
                    maxEngineCapacity = 3.2f;

                    tiresList = makeTires(i_CommonVehicleInfo, r_NumOfTires, r_MaxAirPressure);
                    getCarDetails(i_CommonTypeOfVehicleInfo, out colorType, out numberOfDoors);
                    ElectricEngine electricCarEngine = getElectricEngineDetails(i_SpecificTypeOfVehicleInfo, maxEngineCapacity, out energyPercentageMeter);
                    newVehicle = new ElectricCar(modelName, licenseNumber, energyPercentageMeter, tiresList,
                        colorType, numberOfDoors,
                        electricCarEngine);

                    break;

                case eAvailableTypesOfVehicles.Truck:
                    r_NumOfTires = 16;
                    r_MaxAirPressure = 26;
                    eVehicleFuelType fuelTruckTypeEngine = Soler;
                    maxEngineCapacity = 120;
                    bool isCarryingDangerousMatirelas;
                    float maxCarryWeight;

                    tiresList = makeTires(i_CommonVehicleInfo, r_NumOfTires, r_MaxAirPressure);
                    getTruckDetails(i_CommonTypeOfVehicleInfo, out isCarryingDangerousMatirelas, out maxCarryWeight);
                    FuelEngine fuelTruckEngine = getFuelEngineDetails(i_SpecificTypeOfVehicleInfo, fuelTruckTypeEngine, maxEngineCapacity, out energyPercentageMeter);
                    newVehicle = new Truck(modelName, licenseNumber, energyPercentageMeter, tiresList,
                        isCarryingDangerousMatirelas, maxCarryWeight,
                        fuelTruckEngine);
                    break;
            }
            
            return newVehicle; //TODO delete after implement
        }

        private static void getVehicleDetails(List<string> i_CommonVehicleInfo, out string o_LicenseNumber, out string o_ModelName)
        {
            // 0-licenseNumber, 1- ModelName , 2- m_EnergyPercentageMeter

            o_LicenseNumber = i_CommonVehicleInfo[0];
            o_ModelName = i_CommonVehicleInfo[1];
            string stringEnergyMeter = i_CommonVehicleInfo[2];
            bool goodInput;
            //goodInput = float.TryParse(stringEnergyMeter, out o_EnergyPercentageMeter); //TODO do it with try and catch - this is a tester for good input
            //if(!goodInput)
            //{
            //    throw new FormatException("Energy meter needs to be a float number");
            //}
        }

        private static List<Tire> makeTires(List<string> i_CommonVehicleInfo, int i_NumberOfTires, float i_MaxAirPressure)
        {
            bool goodInput;
            List<Tire> tiresList = new List<Tire>(i_NumberOfTires);
            float currentAirPressure;
            //tires: 2- manufactureName, 3- current air pressure 
            string manufactureName = i_CommonVehicleInfo[2]; 
            string stringCurrentAirPressure = i_CommonVehicleInfo[3];

            goodInput = float.TryParse(stringCurrentAirPressure, out currentAirPressure); //TODO do it with try and catch - this is a tester for good input
            if(!goodInput)
            {
                throw new FormatException("Current air pressure meter needs to be a float number");
            }

            //Tire tire = new Tire(manufactureName, currentAirPressure, i_MaxAirPressure);
            for (int i = 0; i < i_NumberOfTires; i++)
            {
                tiresList.Add(new Tire(manufactureName, currentAirPressure, i_MaxAirPressure)); 
            }

            return tiresList;
        }

        private static void getMotorcycleDetails(List<object> i_CommonTypeOfVehicleInfo, out Motorcycle.eMotorcycleLicenseType o_LicenseType, out int o_EngineCapacity)
        {
            //o_LicenseType = (Motorcycle.eMotorcycleLicenseType) i_CommonTypeOfVehicleInfo[0];
            bool isGood = Motorcycle.eMotorcycleLicenseType.TryParse((string)i_CommonTypeOfVehicleInfo[0], out o_LicenseType);

            isGood = int.TryParse((string)i_CommonTypeOfVehicleInfo[1], out o_EngineCapacity);
            if (!isGood)
            {
                throw new FormatException("Engine capacity needs to be a int number");
            }
        }

        private static FuelEngine getFuelEngineDetails(List<object> i_SpecificTypeOfVehicleInfo, eVehicleFuelType i_FuelType, float i_MaxFuelCapacity, out float o_EnergyPercentageMeter)
        {
            // r_MotorcycleEngine = new FuelEngine(i_MotorcycleFuelType, i_MaxFuelCapacity, i_CurrentFuelCapacity);
            float currentAmountOfFuel;
            bool isGood = float.TryParse((string)i_SpecificTypeOfVehicleInfo[0], out currentAmountOfFuel);
            FuelEngine engine;

            if (!isGood)
            {
                throw new FormatException("Current fuel capacity needs to be a float number");

            }

            o_EnergyPercentageMeter = currentAmountOfFuel / i_MaxFuelCapacity;

            engine = new FuelEngine(i_FuelType, i_MaxFuelCapacity, currentAmountOfFuel);

            return engine;
        }

        private static ElectricEngine getElectricEngineDetails(List<object> i_SpecificTypeOfVehicleInfo, float i_MaxBatteryCapacity, out float o_EnergyPercentageMeter)
        {
            float currentAmountOfEnergy;
            bool isGood = float.TryParse((string)i_SpecificTypeOfVehicleInfo[0], out currentAmountOfEnergy);
            ElectricEngine engine;

            if (!isGood)
            {
                throw new FormatException("Current battery energy capacity needs to be a float number");

            }

            o_EnergyPercentageMeter = currentAmountOfEnergy / i_MaxBatteryCapacity;

            engine = new ElectricEngine(i_MaxBatteryCapacity, currentAmountOfEnergy);

            return engine;
        }

        private static void getCarDetails(List<object> i_CommonTypeOfVehicleInfo, out Car.eCarColor o_CarColor, out int o_NumberOfDoors)
        {
            //o_LicenseType = (Motorcycle.eMotorcycleLicenseType) i_CommonTypeOfVehicleInfo[0];
            bool isGood = Car.eCarColor.TryParse((string)i_CommonTypeOfVehicleInfo[0], out o_CarColor);

            isGood = int.TryParse((string)i_CommonTypeOfVehicleInfo[1], out o_NumberOfDoors);
            if (!isGood)
            {
                throw new FormatException("Number of doors needs to be a int number");
            }
        }

        private static void getTruckDetails(List<object> i_CommonTypeOfVehicleInfo, out bool o_IsCarryingDangerousMaterials, out float o_MaxCarryWeight)
        {
            //o_LicenseType = (Motorcycle.eMotorcycleLicenseType) i_CommonTypeOfVehicleInfo[0];
            bool isGood = bool.TryParse((string)i_CommonTypeOfVehicleInfo[0], out o_IsCarryingDangerousMaterials);
            bool toPrase = (string)i_CommonTypeOfVehicleInfo[1] == 'Y';

            isGood = float.TryParse(toPrase, out o_MaxCarryWeight);
            if (!isGood)
            {
                throw new FormatException("Number of doors needs to be a int number");
            }
        }

    }
}
