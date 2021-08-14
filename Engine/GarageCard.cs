using System;
using System.Collections.Generic;

namespace Engine
{
    public class GarageCard
    {
        public enum eVehicleState{ 
        InRepair,
        Fixed,
        PaidUp
        }

        private readonly string r_OwnerName;
        private readonly string r_OwnerPhoneNumber;
        private eVehicleState m_VehicleCurrentState;
        private Vehicle m_OwnerVehicle; //TODO pointer to vehicle
        
        public string OwnerName
        {
            get { return r_OwnerName; }
        }

        public string OwnerPhoneNumber
        {
            get { return r_OwnerPhoneNumber; }
        }

        public eVehicleState VehicleCurrentState
        {
            get { return m_VehicleCurrentState; }
            set { m_VehicleCurrentState = value; }
        }

        public Vehicle OwnerVehicle
        {
            get { return m_OwnerVehicle; }
            set { m_OwnerVehicle = value; }
        }

        public GarageCard(string i_OwnerName, string i_OwnerPhoneNumber, eVehicleState i_VehicleCurrentState)
        {
            r_OwnerName = i_OwnerName;
            r_OwnerPhoneNumber = i_OwnerPhoneNumber;
            m_VehicleCurrentState = i_VehicleCurrentState;
        }
    }
}
