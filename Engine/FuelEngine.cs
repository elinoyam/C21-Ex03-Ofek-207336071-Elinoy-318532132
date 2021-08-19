using System;
using System.Collections.Generic;

namespace Engine
{
    public class FuelEngine
    {
        private eVehicleFuelType m_VehicleFuelType; 
        private readonly float r_MaxFuelCapacity = 0;
        private float m_CurrentFuelCapacity = 0;
        private const int k_StartIndexOfEnum = 1;

        public enum eVehicleFuelType
        {
            Soler = k_StartIndexOfEnum,
            Octan95,
            Octan96,
            Octan98
        }

        public eVehicleFuelType FuelType
        {
            get
            {
                return m_VehicleFuelType;
            }
            set
            {
                if (System.Enum.IsDefined(typeof(eVehicleFuelType), value))
                {
                    m_VehicleFuelType = value;
                }
                else
                {
                    throw new ArgumentException("The given value to the engine fuel type is not defined.");
                }
            }
        }

        public float MaxFuelCapacity
        {
            get
            {
                return r_MaxFuelCapacity;
            }
        }

        public float CurrentFuelCapacity
        {
            get
            {
                return m_CurrentFuelCapacity;
            }

            set
            {
                if (value <= r_MaxFuelCapacity)
                {
                    m_CurrentFuelCapacity = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(r_MaxFuelCapacity, 0, $"The given fuel amount exceeds the maximum range. The maximum fuel capacity is: {r_MaxFuelCapacity}.");
                }
            }
        }

        public FuelEngine(eVehicleFuelType i_VehicleFuelType, float i_MaxFuelCapacity, float i_CurrentFuelCapacity)
        {
            m_VehicleFuelType = i_VehicleFuelType;
            r_MaxFuelCapacity = i_MaxFuelCapacity;
            m_CurrentFuelCapacity = i_CurrentFuelCapacity;
        }

        public void Refuel(eVehicleFuelType i_FuelType, float i_FuelAmountToAdd)
        {
            if (i_FuelType != m_VehicleFuelType)
            {
                throw new ArgumentException($"The given fuel type is invalid. This vehicle can only be refueled with {m_VehicleFuelType}.");
            }

            if (m_CurrentFuelCapacity + i_FuelAmountToAdd > r_MaxFuelCapacity)
            {
                throw new ValueOutOfRangeException(r_MaxFuelCapacity, 0, 
                    $"You tried to refuel the vehicle with {i_FuelAmountToAdd}, but the vehicle already had {m_CurrentFuelCapacity}.\n"
                    + $"Therefore you passed the maximum engine capacity {r_MaxFuelCapacity}. You can't add that much!");
            }

            CurrentFuelCapacity += i_FuelAmountToAdd;
        }
    }
}
