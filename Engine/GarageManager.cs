using System;
using System.Collections.Generic;
using static Engine.VehicleFactory;

namespace Engine
{
    public class GarageManager
    {
        private readonly Dictionary<string, GarageCard> r_VehiclesInGarage = new Dictionary<string, GarageCard>();

        public Dictionary<string, Property> InsertNewVehicleToGarage(eAvailableTypesOfVehicles i_VehicleType, string i_LicenseNumber, List<string> i_OwnerVehicleInfo)
        {
            Vehicle newVehicle = MakeNewVehicle(i_VehicleType, i_LicenseNumber);
            GarageCard newVehicleCard = new GarageCard(i_OwnerVehicleInfo, newVehicle);

            r_VehiclesInGarage.Add(i_LicenseNumber, newVehicleCard);

            return newVehicle.VehicleRequiredPropertiesDictionary;
        }

        public bool IsVehicleInGarage(string i_LicenseNumber)
        {
            return r_VehiclesInGarage.ContainsKey(i_LicenseNumber);
        }

        public List<string> GetLicensePlateInGarage()
        {
            List<string> licensePlatesList = new List<string>();

            foreach(GarageCard gc in r_VehiclesInGarage.Values)
            {
                licensePlatesList.Add(gc.OwnerVehicle.LicenseNumber);
            }

            return licensePlatesList;
        }

        public List<string> GetLicensePlateInGarage(string i_VehicleState)
        {
            GarageCard.eVehicleState vehicleState = GarageCard.eVehicleState.InRepair;
            List<string> licensePlatesList = new List<string>();
            bool goodInput = false;
            int enumNumber;

            goodInput = int.TryParse(i_VehicleState, out enumNumber);

            if(goodInput)
            {
                goodInput = false;
                if (Enum.IsDefined(typeof(GarageCard.eVehicleState), enumNumber))
                {
                    goodInput = Enum.TryParse(i_VehicleState, out vehicleState);
                }

                if(goodInput)
                {
                    foreach(GarageCard gc in r_VehiclesInGarage.Values)
                    {
                        if(gc.VehicleCurrentState == vehicleState)
                        {
                            licensePlatesList.Add(gc.OwnerVehicle.LicenseNumber);
                        }
                    }
                }
                else
                {
                    throw new FormatException("The status you entered is not a valid status in this garage.");
                }
            }
            else
            {
                throw new FormatException("The status you entered is not a valid status in this garage.");
            }

            return licensePlatesList;
        }

        public void ChangeVehicleStatus(string i_LicensePlateNumber, GarageCard.eVehicleState i_NewVehicleState)
        {
            if(IsVehicleInGarage(i_LicensePlateNumber))
            {
                r_VehiclesInGarage[i_LicensePlateNumber].VehicleCurrentState = i_NewVehicleState;
            }
            else
            {
                throw new ArgumentException("The given license plate number doesn't exists in the garage system.");
            }
        }

        public void ChangeVehicleStatus(string i_LicensePlateNumber, string i_NewVehicleState)
        {
            GarageCard.eVehicleState newState;
            bool isGoodInput;
            GarageCard garageCard;
            int enumNumber;

            if (IsVehicleInGarage(i_LicensePlateNumber))
            {
                isGoodInput = int.TryParse(i_NewVehicleState, out enumNumber);
                if(isGoodInput)
                {
                    garageCard = r_VehiclesInGarage[i_LicensePlateNumber];
                    if(Enum.IsDefined(typeof(GarageCard.eVehicleState), enumNumber)) 
                    {
                        isGoodInput = Enum.TryParse(i_NewVehicleState, out newState);
                        if(isGoodInput)
                        {
                            garageCard.VehicleCurrentState = newState;
                        }
                    }
                    else
                    {
                        throw new FormatException("The status you entered is not a valid status in this garage.");
                    }
                }
                else
                {
                    throw new FormatException("The status you entered is not a valid status in this garage.");
                }
            }
            else
            {
                throw new ArgumentException("The given license plate number doesn't exists in the garage system.");
            }
        }

        public void InflateTiresAirToMaximum(string i_LicensePlateNumber)
        {
            if(!IsVehicleInGarage(i_LicensePlateNumber))
            {
                throw new ArgumentException("The given license plate number doesn't exists in the garage system.");
            }
            
            Vehicle vehicle = r_VehiclesInGarage[i_LicensePlateNumber].OwnerVehicle;
            for (int i = 0; i < vehicle.ListOfTires.Count; ++i)
            {
                Tire tire = vehicle.ListOfTires[i];
                tire.TireInflating(tire.MaxAirPressure - tire.CurrentAirPressure);
                vehicle.ListOfTires[i] = tire;
            }
        }

        public void ChargeElectricVehicle(string i_LicensePlate, float i_MinutesToCharge)
        {
            IRechargeable vehicle = r_VehiclesInGarage[i_LicensePlate].OwnerVehicle as IRechargeable;

            if(vehicle != null)
            {
                vehicle.ReCharge(i_MinutesToCharge);
            }
            else
            {
                throw new ArgumentException("The given vehicle isn't electric.");
            }
        }

        public void RefuelFuelVehicle(string i_LicensePlateNumber, string i_FuelType, float i_AmountToFill)
        {
            FuelEngine.eVehicleFuelType fuelType;
            bool goodInput = Enum.TryParse(i_FuelType, out fuelType);
            IRefuelable vehicle = r_VehiclesInGarage[i_LicensePlateNumber].OwnerVehicle as IRefuelable;
            
            if (vehicle != null)
            {
                vehicle.Refuel(fuelType, i_AmountToFill);
            }
            else
            {
                throw new ArgumentException("The given vehicle doesn't work on fuel.");
            }
        }

        public string GetVehicleDetails(string i_LicensePlateNumber)
        {
            if (!IsVehicleInGarage(i_LicensePlateNumber))
            {
                throw new ArgumentException("The given license plate number doesn't exists in the garage system.");
            }

            Vehicle vehicle = r_VehiclesInGarage[i_LicensePlateNumber].OwnerVehicle;

            return vehicle.ToString();
        }

        public object TryParseToType(string i_InputFromUser,Type i_Type)
        {
            return VehicleFactory.TryParseToType(i_InputFromUser, i_Type);
        }

        public void addParam(string i_LicensePlateNumber, object i_ParsedUserInput, string i_StringMemberName)
        {
            if (!IsVehicleInGarage(i_LicensePlateNumber))
            {
                throw new ArgumentException("The given license plate number doesn't exists in the garage system.");
            }

            r_VehiclesInGarage[i_LicensePlateNumber].OwnerVehicle.UpdateParameter(i_ParsedUserInput, i_StringMemberName);
        }
    }
}
