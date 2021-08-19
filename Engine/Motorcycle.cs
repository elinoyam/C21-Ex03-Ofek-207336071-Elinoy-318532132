using System; //TODO does class in engine need system??
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine
{
    public class Motorcycle : Vehicle
    {
        private eMotorcycleLicenseType m_LicenseType;                                                                                                                                      
        private int m_EngineVolume;

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

        public enum eMotorcycleLicenseType //TODO maybe protected?
        {
            A = 1,
            B1,
            Aa,
            Bb
        }

        public Motorcycle(string i_LicenseNumber, int i_NumberOfTires, float i_TiresMaxAirPressure) :base(i_LicenseNumber, i_NumberOfTires, i_TiresMaxAirPressure)
        {
            //AddParams();
        }

        public Motorcycle(List<string> i_CommonVehicleInfo, List<object> i_CommonTypeOfVehicleInfo)
                     : base(i_CommonVehicleInfo)
        {
            //TODO add exceptions
           /* m_LicenseType = (eMotorcycleLicenseType)i_CommonTypeOfVehicleInfo[0];                                                                                                                                      
            m_EngineVolume = (int)i_CommonTypeOfVehicleInfo[1];*/
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
            propertyLicense.FormQuestion = "Enter your type of motorcycle license:";
            r_VehicleRequiredProperties.Add("m_LicenseType", propertyLicense);
            Property propertyCapacity = new Property("Motorcycle engine capacity", "m_EngineVolume", typeof(int));
            propertyCapacity.FormQuestion = "Enter your motorcycle engine volume:";
            r_VehicleRequiredProperties.Add("m_EngineVolume", propertyCapacity);
        }

        public override List<string> ListOfQuestions()
        {
            int index = 1;
            StringBuilder stringBuilder = new StringBuilder("");
            List<string> listOfQuestions = base.ListOfQuestions();
            string question = "Please write your type of license: ";
            
            stringBuilder.Append("(");
            foreach (string name in Enum.GetNames(typeof(eMotorcycleLicenseType)))
            {
                if (index != 1)
                {
                    stringBuilder.Append(",");
                }

                stringBuilder.Append($" {index} - {name}");
                ++index;
            }

            stringBuilder.Append(" )");
            question = $"{question} \n{stringBuilder}";
            listOfQuestions.Add(question);
            question = "Please write your engine capacity: ";
            listOfQuestions.Add(question);

            return listOfQuestions;
        }

        public virtual void UpdateVehicle(List<string> i_SpecificTypeOfVehicleInfo, ref int i_CurrentQuestion)
        {
            UpdateVehicle(i_SpecificTypeOfVehicleInfo, ref i_CurrentQuestion);
            // i need to do 2 questions
            int index = NumberOfQuestions(); //3+2
           
            for(; i_CurrentQuestion < index; ++i_CurrentQuestion)
            {
                //0 -module, 1- tire manufacture, 2-air pressure
                //read 2
            }
        }


        internal override void UpdateParameter(object i_ParsedUserInput, string i_MemberName)
        {
            switch(i_MemberName)
            {
                case "m_LicenseType":
                    m_LicenseType = (eMotorcycleLicenseType)i_ParsedUserInput; //TODO not readonly anymore
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
