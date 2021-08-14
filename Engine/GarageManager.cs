using System;
using System.Collections.Generic;

namespace Engine
{
    public class GarageManager
    {
        public enum eAvailableTypesOfVehicles
        {
            FuelMotorcycle,
            ElectricMotorcycle,
            FuelCar,
            ElectricCar,
            Truck
        }

        private Dictionary<string, GarageCard> m_VehiclesInGarage;

        public bool InsertNewVehicleToGarage(eAvailableTypesOfVehicles i_VehicleType, List<string> i_OwnerVehicleInfo,
                                             List<string> i_CommonVehicleInfo, List<object> i_CommonTypeOfVehicleInfo, List<object> i_SpecificTypeOfVehicleInfo)
        {
            Vehicle newVehicle = VehicleFactory.CreateNewVehicle(i_VehicleType, i_CommonVehicleInfo,
                i_CommonTypeOfVehicleInfo, i_SpecificTypeOfVehicleInfo);

            // create garage card
            GarageCard newVehicleCard = new GarageCard(i_OwnerVehicleInfo, newVehicle); //TODO
            //license = i_CommonVehicleInfo[0]
            m_VehiclesInGarage.Add(i_CommonVehicleInfo[0], newVehicleCard);


            return true; //TODO delete after implement
        }

        public bool IsVehicleInGarage(string licenseNumber)
        {
            return m_VehiclesInGarage.ContainsKey(licenseNumber);
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

        public List<string> GetLicensePlateInGarage(GarageCard.eVehicleState i_VehicleState)
        {
            List<string> licensePlatesList = new List<string>();

            foreach(GarageCard gc in m_VehiclesInGarage.Values)
            {
                if(gc.VehicleCurrentState == i_VehicleState)
                {
                    licensePlatesList.Add(gc.OwnerVehicle.LicenseNumber);
                }
            }

            return licensePlatesList;
        }

        public void ChangeVehicleStatus(string i_LicensePlate, GarageCard.eVehicleState i_NewVehicleState)
        {
            GarageCard garageCard = m_VehiclesInGarage[i_LicensePlate];
            garageCard.VehicleCurrentState = i_NewVehicleState;
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
            Vehicle vehicle = m_VehiclesInGarage[i_LicensePlate].OwnerVehicle;
            // vehicle - abstract method?

        }

        public void RefuelFuelVehicle(string i_LicensePlate, FuelEngine.eVehicleFuelType i_FuelType, float i_AmountToFill)
        {
            Vehicle vehicle = m_VehiclesInGarage[i_LicensePlate].OwnerVehicle;
            // vehicle - abstract method?
        }

        public string GetVehicleDetails(string i_LicensePlate)
        {
            Vehicle vehicle = m_VehiclesInGarage[i_LicensePlate].OwnerVehicle;

            return vehicle.ToString();
        }
    }
}
