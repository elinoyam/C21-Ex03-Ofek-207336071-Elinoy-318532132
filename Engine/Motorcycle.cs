using System; //TODO does class in engine need system??
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine
{
    public class Motorcycle : Vehicle
    {
        private eMotorcycleLicenseType m_LicenseType;                                                                                                                                      
        private int m_EngineCapacity;

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

        public int EngineCapacity
        {
            get
            {
                return m_EngineCapacity;
            }

            set
            {
                if(value > 0)
                {
                    m_EngineCapacity = value;
                }
            }
        }

        public enum eMotorcycleLicenseType //TODO maybe protected?
        {
            A,
            B1,
            Aa,
            Bb
        }

        public Motorcycle(string i_LicenseNumber, int i_NumberOfTires, float i_TiresMaxAirPressure) :base(i_LicenseNumber, i_NumberOfTires, i_TiresMaxAirPressure)
        {
        }

        public Motorcycle(List<string> i_CommonVehicleInfo, List<object> i_CommonTypeOfVehicleInfo)
                     : base(i_CommonVehicleInfo)
        {
            //TODO add exceptions
           /* m_LicenseType = (eMotorcycleLicenseType)i_CommonTypeOfVehicleInfo[0];                                                                                                                                      
            m_EngineCapacity = (int)i_CommonTypeOfVehicleInfo[1];*/
        }

        public Motorcycle(string i_ModelName, string i_LicenseNumber, float i_EnergyPercentageMeter, List<Tire> i_ListOfTires, eMotorcycleLicenseType i_LicenseType, int i_EngineCapacity) : base(i_ModelName, i_LicenseNumber, i_EnergyPercentageMeter, i_ListOfTires)
        {
            m_LicenseType = i_LicenseType;
            m_EngineCapacity = i_EngineCapacity;
        }

        public override void AddParams()
        {
            base.AddParams();
            Property propertyLicense = new Property("Motorcycle license type", "m_LicenseType", typeof(eMotorcycleLicenseType));
            propertyLicense.FormQuestion = "Enter your type of motorcycle license:";
            r_VehicleRequiredProperties.Add("m_LicenseType", propertyLicense);
            Property propertyCapacity = new Property("Motorcycle engine capacity", "m_EngineCapacity", typeof(int));
            propertyCapacity.FormQuestion = "Enter your motorcycle engine capacity:";
            r_VehicleRequiredProperties.Add("m_EngineCapacity", propertyCapacity);
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
    }
}
