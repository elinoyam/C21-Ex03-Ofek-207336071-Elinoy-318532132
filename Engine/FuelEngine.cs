using System;
using System.Collections.Generic;

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
                    throw new ArgumentException("The given value to the engine fuel type is not defined.");                 }
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
                throw new ArgumentException("The given fuel type is invalid. This car can only be refueled with {m_CarFuelType}.");
            }
            else if (m_CurrentFuelCapacity + i_FuelAmountToAdd > r_MaxFuelCapacity)
            {
                throw new ValueOutOfRangeException(r_MaxFuelCapacity, 0, "The amount of fuel to add exceeds what is allowed.");
            }
            else
            {
                CurrentFuelCapacity += i_FuelAmountToAdd;
            }
        }

        public List<string> ListOfQuestions()
        {
            List<string> listOfQuestions = new List<String>();

            string question = "Please write the current amount of fuel: "; //TODO add print enum colors
            listOfQuestions.Add(question);

            return listOfQuestions;
        }
    }
}
