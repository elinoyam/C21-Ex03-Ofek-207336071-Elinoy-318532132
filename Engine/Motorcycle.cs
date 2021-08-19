using System; 
using System.Collections.Generic;

namespace Engine
{
    public abstract class Motorcycle : Vehicle
    {
        private eMotorcycleLicenseType m_LicenseType;                                                                                                                                      
        private int m_EngineVolume;
        private const int k_StartIndexOfEnum = 1;

        public eMotorcycleLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }

            set
            {
                if (System.Enum.IsDefined(typeof(eMotorcycleLicenseType), value))
                {
                    m_LicenseType = value;
                }
                else
                {
                    throw new ArgumentException("The given motorcycle license type isn't defined."); 
                }
            }
        }

        public int EngineVolume
        {
            get
            {
                return m_EngineVolume;
            }

            set
            {
                if(value > 0)
                {
                    m_EngineVolume = value;
                }
            }
        }

        public enum eMotorcycleLicenseType
        {
            A = k_StartIndexOfEnum,
            B1,
            Aa,
            Bb
        }

        public Motorcycle(string i_LicenseNumber, int i_NumberOfTires, float i_TiresMaxAirPressure) : base(i_LicenseNumber, i_NumberOfTires, i_TiresMaxAirPressure)
        {
        }

        public Motorcycle(string i_ModelName, string i_LicenseNumber, float i_EnergyPercentageMeter, List<Tire> i_ListOfTires, eMotorcycleLicenseType i_LicenseType, int i_EngineVolume) : base(i_ModelName, i_LicenseNumber, i_EnergyPercentageMeter, i_ListOfTires)
        {
            m_LicenseType = i_LicenseType;
            m_EngineVolume = i_EngineVolume;
        }

        public override void AddParams()
        {
            base.AddParams();
            Property propertyLicense = new Property("Motorcycle license type", "m_LicenseType", typeof(eMotorcycleLicenseType));
            Property propertyCapacity = new Property("Motorcycle engine capacity", "m_EngineVolume", typeof(int));

            propertyLicense.FormQuestion = "Enter your type of motorcycle license:";
            r_VehicleRequiredPropertiesDictionary.Add("m_LicenseType", propertyLicense);
            propertyCapacity.FormQuestion = "Enter your motorcycle engine volume:";
            r_VehicleRequiredPropertiesDictionary.Add("m_EngineVolume", propertyCapacity);
        }

        internal override void UpdateParameter(object i_ParsedUserInput, string i_MemberName)
        {
            switch(i_MemberName)
            {
                case "m_LicenseType":
                    m_LicenseType = (eMotorcycleLicenseType)i_ParsedUserInput; 
                    break;
                case "m_EngineVolume":
                    m_EngineVolume = (int)i_ParsedUserInput;
                    break;
                default:
                    base.UpdateParameter(i_ParsedUserInput, i_MemberName);
                    break;
            }
        }
    }
}