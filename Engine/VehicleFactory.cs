using System;

namespace Ex03.GarageLogic
{
    public class VehicleFactory
    {
        private const int k_DefaultNumberOfCarTires = 4;
        private const int k_DefaultCarTiresMaxAirPressure = 32;
        private const int k_DefaultNumberOfMotorcycleTires = 2;
        private const int k_DefaultMotorcycleTiresMaxAirPressure = 30;
        private const int k_DefaultNumberOfTruckTires = 16;
        private const int k_DefaultTruckTiresMaxAirPressure = 26;
        private const int k_StartIndexOfEnum = 1;

        public enum eAvailableTypesOfVehicles
        {
            FuelMotorcycle = k_StartIndexOfEnum,
            ElectricMotorcycle,
            FuelCar,
            ElectricCar,
            Truck
        }

        public static Vehicle MakeNewVehicle(eAvailableTypesOfVehicles i_VehicleType, string i_LicenseNumber)
        {
            Vehicle vehicle;

            switch (i_VehicleType)
            {
                case eAvailableTypesOfVehicles.ElectricCar:
                    vehicle = new ElectricCar(i_LicenseNumber, k_DefaultNumberOfCarTires, k_DefaultCarTiresMaxAirPressure);
                    break;
                case eAvailableTypesOfVehicles.FuelCar:
                    vehicle = new FuelCar(i_LicenseNumber, k_DefaultNumberOfCarTires, k_DefaultCarTiresMaxAirPressure);
                    break;
                case eAvailableTypesOfVehicles.ElectricMotorcycle:
                    vehicle = new ElectricMotorcycle(i_LicenseNumber, k_DefaultNumberOfMotorcycleTires, k_DefaultMotorcycleTiresMaxAirPressure); 
                    break;
                case eAvailableTypesOfVehicles.FuelMotorcycle:
                    vehicle = new FuelMotorcycle(i_LicenseNumber, k_DefaultNumberOfMotorcycleTires, k_DefaultMotorcycleTiresMaxAirPressure);
                    break;
                case eAvailableTypesOfVehicles.Truck:
                    vehicle = new Truck(i_LicenseNumber, k_DefaultNumberOfTruckTires, k_DefaultTruckTiresMaxAirPressure);
                    break;
                default:
                    vehicle = null;
                    break;
            }

            return vehicle;
        }

        public static object TryParseToType(string i_InputFromUser, Type i_Type)
        {
            bool goodInput;
            object resultObject = new object();

            if (i_Type == typeof(int))
            {
                int integerNumber;

                goodInput = int.TryParse(i_InputFromUser, out integerNumber);
                if (!goodInput)
                {
                    throw new FormatException("You need to enter an integer number only!");
                }

                resultObject = integerNumber;
            }
            else if (i_Type == typeof(float))
            {
                float floatNumber;

                goodInput = float.TryParse(i_InputFromUser, out floatNumber);
                if (!goodInput)
                {
                    throw new FormatException("You need to enter an decimal number only!");
                }

                resultObject = floatNumber;
            }
            else if (i_Type == typeof(string))
            {
                if(i_InputFromUser.Equals(""))
                {
                    throw new ArgumentException("You can't enter an empty input.");
                }

                resultObject = i_InputFromUser;
            }
            else if (i_Type.BaseType == typeof(Enum))
            {
                int enumNumber;

                goodInput = int.TryParse(i_InputFromUser, out enumNumber);
                if (!Enum.IsDefined(i_Type, enumNumber)) // TODO check if 0 is valid|| enumNumber == 0 and if enum not allowed here
                {
                    int statingIndex = (int)Enum.GetValues(i_Type).GetValue(0);
                    int endingIndex = (int)Enum.GetValues(i_Type).GetValue(Enum.GetValues(i_Type).Length - 1);

                    throw new FormatException($"You need to enter an integer number only from the range {statingIndex} to {endingIndex}!");
                }

                resultObject = enumNumber;
            }
            else if (i_Type == typeof(bool))
            {
                bool boolType;
                int boolAsNumber; 
                const int trueAsNumber = 1;
                const int falseAsNumber = 0;

                goodInput = int.TryParse(i_InputFromUser, out boolAsNumber);
                if (!goodInput)
                {
                    throw new FormatException("You need to enter an integer number only! (1 for yes or 0 for no)");
                }

                if(boolAsNumber == trueAsNumber)
                {
                    boolType = true;
                }
                else if (boolAsNumber == falseAsNumber)
                {
                    boolType = false;
                }
                else
                {
                    throw new FormatException("You need to enter only 1 for yes, or 0 for no");
                }

                resultObject = boolType;
            }

            return resultObject;
        }
    }
}