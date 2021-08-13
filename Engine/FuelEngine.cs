using System;

namespace Engine
{
    public class FuelEngine
    {
        public enum eVehicleFuelType
        {
            Soler = 0,
            Octan95 = 1,
            Octan96 = 2,
            Octan98 = 3
        }

        private eVehicleFuelType m_VehicleFuelType; 
        private readonly float r_MaxFuelCapacity = 0;
        private float m_CurrentFuelCapacity = 0;

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
                    throw new ArgumentException(); // TODO think of the propper exception
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
            get { return m_CurrentFuelCapacity; }
            set
            {
                if (value <= r_MaxFuelCapacity)
                {
                    m_CurrentFuelCapacity = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(r_MaxFuelCapacity, 0, $"The given fuel amout exceeds the maximum range. The maximum fuel capacity is: {r_MaxFuelCapacity}.");
                }
            }
        }

        public FuelEngine(eVehicleFuelType i_VehicleFuelType, float i_MaxFuelCapacity, float i_CurrentFuelCapacity)
        {
            m_VehicleFuelType = i_VehicleFuelType;
            r_MaxFuelCapacity = i_MaxFuelCapacity;
            m_CurrentFuelCapacity = i_CurrentFuelCapacity;
        }

        public void Refuel(eVehicleFuelType i_FuelType, float i_FuelAmoutToAdd)
        {
            if (i_FuelType != m_VehicleFuelType)
            {
                throw new ArgumentException("The given fuel type is invalid. This car can only be refueled with {m_CarFuelType}.");
            }
            else if (m_CurrentFuelCapacity + i_FuelAmoutToAdd > r_MaxFuelCapacity)
            {
                throw new ValueOutOfRangeException(r_MaxFuelCapacity, 0, "The amount of fuel to add exceeds what is allowed.");
            }
            else
            {
                CurrentFuelCapacity += i_FuelAmoutToAdd;
            }
        }
    }
}
