using System;
using System.Collections.Generic;

namespace Engine
{
    class Car : Vehicle
    {
        private eCarColor m_CarColor;
        private int m_NumberOfDoors = 2;

        public eCarColor Color
        {
            get { return m_CarColor; }
            set
            {
                if (System.Enum.IsDefined(typeof(eCarColor), value))
                {
                    m_CarColor = value;
                }
                else
                {
                    throw new ArgumentException(); // TODO think of the propper exception
                }
            }
        }

        public int NumberOfDoors
        {
            get { return m_NumberOfDoors; }
            set
            {
                if(2<= value && value <= 5)
                {
                    m_NumberOfDoors = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(5, 2, $"The given number of doors {value} isn't valid.");
                }
            }
        }

        public enum eCarColor
        {
            Red,
            Silver,
            White,
            Black
        }

        public Car(string i_ModelName, string i_LicenseNumber, float i_EnergyMeter, List<Tire> i_ListOfTires, eCarColor i_CarColor, int i_NumberOfDoors) : base(i_ModelName, i_LicenseNumber, i_EnergyMeter, i_ListOfTires)
        {
            m_CarColor = i_CarColor;
            m_NumberOfDoors = i_NumberOfDoors;
        }

    }
}
