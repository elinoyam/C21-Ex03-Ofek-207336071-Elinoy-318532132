using System;
using System.Collections.Generic;

namespace Engine
{
    public abstract class Vehicle
    {
        private /*readonly*/ string r_ModelName;
        private readonly string r_LicenseNumber; 
        private float m_EnergyPercentageMeter = 0;
        private readonly List<Tire> r_ListOfTires;
        protected readonly Dictionary<string, Property> r_VehicleRequiredProperties = new Dictionary<string, Property>();

        public Vehicle(List<string> i_CommonVehicleInfo) // 0-licenseNumber, 1- ModelName , 2- m_EnergyPercentageMeter , tires: 3- manufactureName, 4- current air pressure , 5- max air pressure
        {
           /* r_LicenseNumber = i_CommonVehicleInfo[0];
            r_ModelName = i_CommonVehicleInfo[1];
            bool goodInput;
            string stringEnergyMeter = i_CommonVehicleInfo[2];
            goodInput = float.TryParse(stringEnergyMeter, out m_EnergyPercentageMeter); //TODO do it with try and catch - this is a tester for good input

            //tires: 3- manufactureName, 4- current air pressure , 5- max air pressure
            string manufactureName = i_CommonVehicleInfo[3]; //TODO think of better names
            string stringCurrentAirPressure = i_CommonVehicleInfo[4];
            string stringMaxAirPressure = i_CommonVehicleInfo[5];

            float currentAirPressure, maxAirPressure;
            goodInput = float.TryParse(stringCurrentAirPressure, out currentAirPressure); //TODO do it with try and catch - this is a tester for good input
            goodInput = float.TryParse(stringMaxAirPressure, out maxAirPressure); //TODO do it with try and catch - this is a tester for good input

            m_ListOfTires = new List<Tire>();
            Tire tire = new Tire(manufactureName, currentAirPressure, maxAirPressure);

            string stringAmountOfTires = i_CommonVehicleInfo[6];
            int amountOfTires;
            goodInput = int.TryParse(stringAmountOfTires, out amountOfTires); //TODO do it with try and catch - this is a tester for good input

            for(int i = 0; i < amountOfTires; i++)
            {
                m_ListOfTires.Add(tire); //TODO very important add to the function amout of 
            }*/
        }

        public Vehicle(string i_LicenseNumber, int i_NumberOfTires, float i_TiresMaxAirPressure)
        {
            r_LicenseNumber = i_LicenseNumber;
            r_ListOfTires = new List<Tire>(i_NumberOfTires);
            for(int i = 0; i < i_NumberOfTires; ++i)
            {
                r_ListOfTires.Add(new Tire(i_TiresMaxAirPressure));
            }
        }

        public Vehicle(string i_ModelName, string i_LicenseNumber, float i_EnergyPercentageMeter, List<Tire> i_ListOfTires)
        {
            r_ModelName = i_ModelName;
            r_LicenseNumber = i_LicenseNumber;
            m_EnergyPercentageMeter = i_EnergyPercentageMeter;
            r_ListOfTires = i_ListOfTires; // TODO check if I can get list in ctor..
        }

        public string ModelName
        {
            get
            {
                return r_ModelName;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return r_LicenseNumber;
            }
        }

        public float EnergyPercentageMeter
        {
            get
            {
                return m_EnergyPercentageMeter;
            }

            set
            {
                if(value > 0 && value <=100)
                {
                    m_EnergyPercentageMeter = value;
                }
            }
        }

        public List<Tire> ListOfTires
        {
            get
            {
                return r_ListOfTires;
            }
            // TODO do we need set?
        }

        public override int GetHashCode()
        {
            return LicenseNumber.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            bool isEqual = false;

            Vehicle vehicle = obj as Vehicle;
            if(vehicle != null)
            {
                isEqual = this.LicenseNumber == vehicle.LicenseNumber;
            }

            return isEqual;
        }

        public virtual void AddParams()
        {
            Property property = new Property("Car model name", "r_ModelName", typeof(string));
            
            property.FormQuestion = "Enter the model name of the car:";
            r_VehicleRequiredProperties.Add("r_ModelName", property);
        }

        public void UpdateParams(Dictionary<string,Property> i_PropertiesToUpdate)
        {
            Type typeToCast = i_PropertiesToUpdate[r_ModelName].MemberType;
            //r_ModelName = i_PropertiesToUpdate[r_ModelName].MemberValue as typeTo
            // TODO: understand how do we cast to the real object type
        }

        public virtual List<string> ListOfQuestions()
        {
            List<string> listOfQuestions = new List<String>();

            string question = "Please write the vehicle module name: ";
            listOfQuestions.Add(question);
            question = "Please write the name of the tire manufacture: ";
            listOfQuestions.Add(question);
            question = "Please write the current air pressure of the tire: ";
            listOfQuestions.Add(question);

            return listOfQuestions;
        }

        public int NumberOfQuestions()
        {
            List<string> listOfQuestions = ListOfQuestions();

            return listOfQuestions.Count;
        }

        public virtual void UpdateVehicle(List<string> i_SpecificTypeOfVehicleInfo, ref int i_CurrentQuestion)
        {   // TODO: to delete?
            int index = NumberOfQuestions(); //3
            for(i_CurrentQuestion = 0; i_CurrentQuestion < index; ++i_CurrentQuestion)
            {
                //0 -module, 1- tire manufacture, 2-air pressure
                //read 3
                //list 
            }
            //return
        }
    }
}