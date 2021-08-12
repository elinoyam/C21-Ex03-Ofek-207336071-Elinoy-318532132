using System;

namespace Engine
{
    class FuelEngine
    {
        public enum VehicleFuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }

        private VehicleFuelType m_VehicleFuelType; 
        private readonly float m_MaxFuelCapacity = 0;
        private float m_CurrentFuelCapacity = 0;

        public VehicleFuelType FuelType
        {
            get
            {
                return m_VehicleFuelType;
            }
            set
            {
                if (System.Enum.IsDefined(typeof(VehicleFuelType), value))
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
                return m_MaxFuelCapacity;
            }
        }

        public float CurrentFuelCapacity
        {
            get { return m_CurrentFuelCapacity; }
            set
            {
                if (value <= m_MaxFuelCapacity)
                {
                    m_CurrentFuelCapacity = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(m_MaxFuelCapacity, 0, $"The given fuel amout exceeds the maximum range. The maximum fuel capacity is: {m_MaxFuelCapacity}.");
                }
            }
        }

        public FuelEngine(VehicleFuelType i_VehicleFuelType, float i_MaxFuelCapacity, float i_CurrentFuelCapacity)
        {
            m_VehicleFuelType = i_VehicleFuelType;
            m_MaxFuelCapacity = i_MaxFuelCapacity;
            m_CurrentFuelCapacity = i_CurrentFuelCapacity;
        }

        public void Refuel(VehicleFuelType i_FuelType, float i_FuelAmoutToAdd)
        {
            if (i_FuelType != m_VehicleFuelType)
            {
                throw new ArgumentException("The given fuel type is invalid. This car can only be refueled with {m_CarFuelType}.");
            }
            else if (m_CurrentFuelCapacity + i_FuelAmoutToAdd > m_MaxFuelCapacity)
            {
                throw new ValueOutOfRangeException(m_MaxFuelCapacity, 0, "The amount of fuel to add exceeds what is allowed.");
            }
            else
            {
                CurrentFuelCapacity += i_FuelAmoutToAdd;
            }
        }
    }
}
