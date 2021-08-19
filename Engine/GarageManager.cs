using System;
using System.Collections.Generic;
using static Engine.VehicleFactory;

namespace Engine
{
    public class GarageManager
    {
        private readonly Dictionary<string, GarageCard> m_VehiclesInGarage = new Dictionary<string, GarageCard>();

        public Dictionary<string, Property> InsertNewVehicleToGarage(eAvailableTypesOfVehicles i_VehicleType, string i_LicenseNumber, List<string> i_OwnerVehicleInfo)
        {
            Vehicle newVehicle = MakeNewVehicle(i_VehicleType, i_LicenseNumber);
            GarageCard newVehicleCard = new GarageCard(i_OwnerVehicleInfo, newVehicle);
            m_VehiclesInGarage.Add(i_LicenseNumber, newVehicleCard);

            return newVehicle.Dictionary;
        }

        /*public List<string> InsertNewVehicleToGarage(eAvailableTypesOfVehicles i_VehicleType, string str)
        {
            Vehicle v = MakeNewVehicle(i_VehicleType, str);

            return v.ListOfQuestions();
        }*/

        /*public bool InsertNewVehicleToGarage(eAvailableTypesOfVehicles i_VehicleType, List<string> i_OwnerVehicleInfo,
                                             List<string> i_CommonVehicleInfo, List<object> i_CommonTypeOfVehicleInfo, List<object> i_SpecificTypeOfVehicleInfo)
        {
            Vehicle newVehicle = VehicleFactory.CreateNewVehicle(i_VehicleType, i_CommonVehicleInfo,
                i_CommonTypeOfVehicleInfo, i_SpecificTypeOfVehicleInfo);

            // create garage card
            GarageCard newVehicleCard = new GarageCard(i_OwnerVehicleInfo, newVehicle); 
            //license = i_CommonVehicleInfo[0]
            m_VehiclesInGarage.Add(i_CommonVehicleInfo[0], newVehicleCard);
            

            return true; //TODO delete after implement
        }*/

        public bool IsVehicleInGarage(string i_LicenseNumber)
        {
            return m_VehiclesInGarage.ContainsKey(i_LicenseNumber);
        }

        public List<string> GetLicensePlateInGarage()
        {
            List<string> licensePlatesList = new List<string>();

            foreach(GarageCard gc in m_VehiclesInGarage.Values)
            {
                licensePlatesList.Add(gc.OwnerVehicle.LicenseNumber);
            }

            return licensePlatesList;
        }

        public List<string> GetLicensePlateInGarage(string i_VehicleState)
        {
            GarageCard.eVehicleState vehicleState;
            List<string> licensePlatesList = new List<string>();

            bool goodInput = Enum.TryParse(i_VehicleState, out vehicleState);

            if (goodInput) { 
                foreach(GarageCard gc in m_VehiclesInGarage.Values)
                {
                    if(gc.VehicleCurrentState == vehicleState)
                    {
                        licensePlatesList.Add(gc.OwnerVehicle.LicenseNumber);
                    }
                }
            }
            else
            {
                throw new FormatException("The status you entered is not a valid status.");
            }

            return licensePlatesList;
        }

        public void ChangeVehicleStatus(string i_LicensePlateNumber, GarageCard.eVehicleState i_NewVehicleState)
        {
            GarageCard garageCard = m_VehiclesInGarage[i_LicensePlateNumber];
            garageCard.VehicleCurrentState = i_NewVehicleState;
        }

        public void ChangeVehicleStatus(string i_LicensePlateNumber, string i_NewVehicleState)
        {
            GarageCard.eVehicleState newState;
            bool goodInput;

            GarageCard garageCard = m_VehiclesInGarage[i_LicensePlateNumber];
            goodInput = GarageCard.eVehicleState.TryParse(i_NewVehicleState,out newState);
            if (goodInput)
            {
                garageCard.VehicleCurrentState = newState;
            }
        }

        public void InflateTiresAirToMaximum(string i_LicensePlate)
        {
            Vehicle vehicle = m_VehiclesInGarage[i_LicensePlate].OwnerVehicle;
            foreach(Tire tire in vehicle.ListOfTires)
            {
                tire.TireInflating(tire.MaxAirPressure);
            }
        }

        public void ChargeElectricVehicle(string i_LicensePlate, float i_MinutesToCharge)
        {
            IRechargable vehicle = m_VehiclesInGarage[i_LicensePlate].OwnerVehicle as IRechargable;

            if(vehicle != null)
            {
                vehicle.ReCharge(i_MinutesToCharge);
            }
        }

        public void RefuelFuelVehicle(string i_LicensePlateNumber, string i_FuelType, float i_AmountToFill)
        {
            FuelEngine.eVehicleFuelType fuelType;
            bool goodInput = FuelEngine.eVehicleFuelType.TryParse(i_FuelType, out fuelType);

            IRefuelable vehicle = m_VehiclesInGarage[i_LicensePlateNumber].OwnerVehicle as IRefuelable;
            if (vehicle != null)
            {
                vehicle.Refuel(fuelType, i_AmountToFill);
            }
        }

        public string GetVehicleDetails(string i_LicensePlate)
        {
            Vehicle vehicle = m_VehiclesInGarage[i_LicensePlate].OwnerVehicle;

            return vehicle.ToString();
        }

        public void UpdateVehicle(string i_LicenseNumber,List<string> i_SpecificTypeOfVehicleInfo)
        {
            int current = 0;
            Vehicle vehicle = m_VehiclesInGarage[i_LicenseNumber].OwnerVehicle;
            vehicle.UpdateVehicle(i_SpecificTypeOfVehicleInfo, ref current);
        }


        public object TryParseToType(string i_InputFromUser,Type i_Type)
        {
            return VehicleFactory.TryParseToType(i_InputFromUser, i_Type);
        }


        public void addParam(string i_LicenseNumber, object i_ParsedUserInput, string i_StringMemberName)
        {
            m_VehiclesInGarage[i_LicenseNumber].OwnerVehicle.UpdateParameter(i_ParsedUserInput, i_StringMemberName);

        }

    }
}
