using System;
using System.Collections.Generic;

namespace Engine
{
    public class GarageCard
    {
        private readonly string r_OwnerName;
        private readonly string r_OwnerPhoneNumber;
        private eVehicleState m_VehicleCurrentState;
        private Vehicle m_OwnerVehicle;
        private const int k_StartIndexOfEnum = 1;

        public enum eVehicleState
        {
            InRepair = k_StartIndexOfEnum,
            Fixed,
            PaidUp
        }

        public string OwnerName
        {
            get
            {
                return r_OwnerName;
            }
        }

        public string OwnerPhoneNumber
        {
            get
            {
                return r_OwnerPhoneNumber;
            }
        }

        public eVehicleState VehicleCurrentState
        {
            get
            {
                return m_VehicleCurrentState;
            }

            set
            {
                if(Enum.IsDefined(typeof(eVehicleState), value))
                {
                    m_VehicleCurrentState = value;
                }
                else
                {
                    throw new ArgumentException("The given value isn't defined as a vehicle state.");
                }
            }
        }

        public Vehicle OwnerVehicle
        {
            get
            {
                return m_OwnerVehicle;
            }

            set
            {
                if(value != null)
                {
                    m_OwnerVehicle = value;
                }
            }
        }

        public GarageCard(List<string> i_OwnerVehicleInfo, Vehicle i_VehiclePointer)
        {
            r_OwnerName = i_OwnerVehicleInfo[0];
            r_OwnerPhoneNumber = i_OwnerVehicleInfo[1];
            m_VehicleCurrentState = eVehicleState.InRepair;
            m_OwnerVehicle = i_VehiclePointer;
        }

        public GarageCard(string i_OwnerName, string i_OwnerPhoneNumber, eVehicleState i_VehicleCurrentState)
        {
            r_OwnerName = i_OwnerName;
            r_OwnerPhoneNumber = i_OwnerPhoneNumber;
            m_VehicleCurrentState = i_VehicleCurrentState;
        }
    }
}
