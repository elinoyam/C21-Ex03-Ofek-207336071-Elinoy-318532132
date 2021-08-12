﻿using System;
using System.Collections.Generic;

namespace Engine
{
    class GarageCard
    {
        public enum eVehicleState{ 
        InRepair,
        Fixed,
        PaidUp
        }

        private readonly string r_OwnerName;
        private readonly string r_OwnerPhoneNumber;
        private eVehicleState m_VehicleCurrentState;
        
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

        public GarageCard(string i_OwnerName, string i_OwnerPhoneNumber, eVehicleState i_VehicleCurrentState)
        {
            r_OwnerName = i_OwnerName;
            r_OwnerPhoneNumber = i_OwnerPhoneNumber;
            m_VehicleCurrentState = i_VehicleCurrentState;
        }
    }
}
