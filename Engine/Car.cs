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
            Red = 1,
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
           // AddParams();
        }

        public Car(string i_ModelName, string i_LicenseNumber, float i_EnergyPercentageMeter, List<Tire> i_ListOfTires, eCarColor i_CarColor, int i_NumberOfDoors) : base(i_ModelName, i_LicenseNumber, i_EnergyPercentageMeter, i_ListOfTires)
        {
            m_CarColor = i_CarColor;
            m_NumberOfDoors = i_NumberOfDoors;
        }

        public override void AddParams()
        {
            base.AddParams();
            Property property = new Property("Car color", "m_CarColor", typeof(eCarColor));
            property.FormQuestion = "Enter your type of color:";
            r_VehicleRequiredProperties.Add("m_CarColor", property);

            property = new Property("Number of car doors", "m_NumberOfDoors", typeof(eNumberOfCarDoors));
            property.FormQuestion = "Enter your amount of doors:";
            r_VehicleRequiredProperties.Add("m_NumberOfDoors", property);
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

        internal override void UpdateParameter(object i_ParsedUserInput, string i_MemberName)
        {
            switch (i_MemberName)
            {
                case "m_CarColor":
                    eCarColor vehicleColor;
                    Enum.TryParse(((int)i_ParsedUserInput).ToString(), out vehicleColor);
                    Color = vehicleColor;
                    break;
                case "m_NumberOfDoors":
                    NumberOfDoors = (int)i_ParsedUserInput;
                    break;
                default:
                    base.UpdateParameter(i_ParsedUserInput, i_MemberName);
                    break;
            }
        }
    }
}