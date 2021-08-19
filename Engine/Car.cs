using System;
using System.Collections.Generic;

namespace Engine
{
    public abstract class Car : Vehicle
    {
        private eCarColor m_CarColor;
        private int m_NumberOfDoors = 2;
        private const int k_StartIndexOfEnumCarColor = 1;
        private const int k_StartIndexOfEnumCarDoors = 2;


        public enum eCarColor
        {
            Red = k_StartIndexOfEnumCarColor,
            Silver,
            White,
            Black
        }

        public enum eNumberOfCarDoors
        {
            Two = k_StartIndexOfEnumCarDoors,
            Three,
            Four,
            Five
        }

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
                    throw new ArgumentException("The given value isn't defined as a color."); 
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
                if (Enum.IsDefined(typeof(eNumberOfCarDoors), value))       // 2 <= value <= 5
                {
                    m_NumberOfDoors = value;
                }
                else
                {
                    int minVal = (int)Enum.GetValues(typeof(eNumberOfCarDoors)).GetValue(0);
                    int length = Enum.GetValues(typeof(eNumberOfCarDoors)).Length;
                    int maxVal = (int)Enum.GetValues(typeof(eNumberOfCarDoors)).GetValue(length - 1);
                    throw new ValueOutOfRangeException(maxVal, minVal, $"The given number of doors {value} isn't valid. The value must be between {minVal}-{maxVal}.");
                }
            }
        }
        
        public Car(string i_LicenseNumber, int i_NumberOfTires, float i_TiresMaxAirPressure) : base(i_LicenseNumber, i_NumberOfTires, i_TiresMaxAirPressure)
        {
        }

        public Car(string i_ModelName, string i_LicenseNumber, float i_EnergyPercentageMeter, List<Tire> i_ListOfTires, eCarColor i_CarColor, int i_NumberOfDoors) : base(i_ModelName, i_LicenseNumber, i_EnergyPercentageMeter, i_ListOfTires)
        {
            m_CarColor = i_CarColor;
            m_NumberOfDoors = i_NumberOfDoors;
        }

        public override void AddParams()
        {
            base.AddParams();
            Property colorProperty = new Property("Car color", "m_CarColor", typeof(eCarColor));
            Property numberOfDoorsProperty = new Property("Number of car doors", "m_NumberOfDoors", typeof(eNumberOfCarDoors));

            colorProperty.FormQuestion = "Enter your type of color:";
            r_VehicleRequiredPropertiesDictionary.Add("m_CarColor", colorProperty);
            numberOfDoorsProperty.FormQuestion = "Enter your amount of doors:";
            r_VehicleRequiredPropertiesDictionary.Add("m_NumberOfDoors", numberOfDoorsProperty);
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