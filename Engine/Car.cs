using System;
using System.Collections.Generic;

namespace Engine
{
    public class Car : Vehicle
    {
        private eCarColor m_CarColor;
        private int m_NumberOfDoors = 2;

        public eCarColor Color
        {
            get
            {
                return m_CarColor;

            }

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
            get
            {
                return m_NumberOfDoors;

            }

            set
            {
                if (2 <= value && value <= 5)
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

        public enum eNumberOfCarDoors
        {
            Two = 2,
            Three,
            Four,
            Five
        }

        public Car(string i_LicenseNumber, int i_NumberOfTires, float i_TiresMaxAirPressure) : base(i_LicenseNumber, i_NumberOfTires, i_TiresMaxAirPressure)
        {
        }

        public Car(string i_ModelName, string i_LicenseNumber, float i_EnergyPercentageMeter, List<Tire> i_ListOfTires, eCarColor i_CarColor, int i_NumberOfDoors) : base(i_ModelName, i_LicenseNumber, i_EnergyPercentageMeter, i_ListOfTires)
        {
            m_CarColor = i_CarColor;
            m_NumberOfDoors = i_NumberOfDoors;
        }

        public override List<string> ListOfQuestions()
        {
            List<string> listOfQuestions = base.ListOfQuestions();
            string question = "Please write your type of color: "; //TODO add print enum colors
            listOfQuestions.Add(question);
            question = "Please write the amount of doors: ";
            listOfQuestions.Add(question);

            return listOfQuestions;
        }
    }
}