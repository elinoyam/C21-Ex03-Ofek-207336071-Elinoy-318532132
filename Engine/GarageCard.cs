using System;
using System.Collections.Generic;

namespace Engine
{
    class GarageCard
    {
        public enum VehicleState{ 
        IN_REPAIR,
        FIXED,
        PAID_UP
        }

        private readonly string m_OwnerName;
        private readonly string m_OwnerPhoneNumber;
        private VehicleState m_VehicleCurrentState;
        
        public string OwnerName
        {
            get { return m_OwnerName; }
        }
        public string OwnerPhoneNumber
        {
            get { return m_OwnerPhoneNumber; }
        }
        public VehicleState VehicleCurrentState
        {
            get { return m_VehicleCurrentState; }
            set { m_VehicleCurrentState = value; }
        }

        public GarageCard(string i_OwnerName, string i_OwnerPhoneNumber, VehicleState i_VehicleCurrentState)
        {
            m_OwnerName = i_OwnerName;
            m_OwnerPhoneNumber = i_OwnerPhoneNumber;
            m_VehicleCurrentState = i_VehicleCurrentState;
        }
    }
}
