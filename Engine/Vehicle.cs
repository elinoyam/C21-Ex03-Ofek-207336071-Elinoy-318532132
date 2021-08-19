using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_ModelName; 
        private readonly string r_LicenseNumber; 
        private float m_EnergyPercentageMeter = 0;
        private readonly List<Tire> r_ListOfTires;
        protected readonly Dictionary<string, Property> r_VehicleRequiredPropertiesDictionary = new Dictionary<string, Property>();

        protected Vehicle(string i_LicenseNumber, int i_NumberOfTires, float i_TiresMaxAirPressure)
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
            m_ModelName = i_ModelName;
            r_LicenseNumber = i_LicenseNumber;
            m_EnergyPercentageMeter = i_EnergyPercentageMeter;
            r_ListOfTires = i_ListOfTires; 
        }

        public Dictionary<string, Property> VehicleRequiredPropertiesDictionary 
        {
            get
            {
                if (r_VehicleRequiredPropertiesDictionary.Count == 0)
                {
                    AddParams();
                }

                return r_VehicleRequiredPropertiesDictionary;
            }
        }

        public string ModelName
        {
            get
            {
                return m_ModelName;
            }

            set
            {
                m_ModelName = value;
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
                if(value >= 0 && value <= 100)
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
            Property property = new Property("Car model name", "m_ModelName", typeof(string));

            property.FormQuestion = "Enter the model name of the vehicle:";
            r_VehicleRequiredPropertiesDictionary.Add("m_ModelName", property);
            property = new Property("Tire manufacture name", "r_ListOfTires.m_ManufactureName", typeof(string));
            property.FormQuestion = "Enter the name of the tire manufacture:";
            r_VehicleRequiredPropertiesDictionary.Add("r_ListOfTires.m_ManufactureName", property);
            property = new Property("Tire current air pressure", "r_ListOfTires.m_CurrentAirPressure", typeof(float));
            property.FormQuestion = "Enter the current air pressure of the tire:";
            r_VehicleRequiredPropertiesDictionary.Add("r_ListOfTires.m_CurrentAirPressure", property);
        }

        internal virtual void UpdateParameter(object i_ParsedUserInput, string i_MemberName)
        {
            switch(i_MemberName)
            {
                case "m_ModelName":
                    ModelName = (string)i_ParsedUserInput;
                    break;
                case "m_EnergyPercentageMeter":
                    EnergyPercentageMeter = (float)i_ParsedUserInput;
                    break;
                case "r_ListOfTires.m_ManufactureName":
                    Tire tire;
                    for (int i = 0; i < r_ListOfTires.Count; ++i)
                    {
                        tire = r_ListOfTires[i];
                        tire.ManufactureName = (string)i_ParsedUserInput;
                        r_ListOfTires[i] = tire;
                    }
                    break;
                case "r_ListOfTires.m_CurrentAirPressure": 
                    for (int i = 0; i < r_ListOfTires.Count; ++i)
                    {
                        tire = r_ListOfTires[i];
                        tire.CurrentAirPressure = (float)i_ParsedUserInput;
                        r_ListOfTires[i] = tire;
                    }
                    break;
                default:
                    throw new ArgumentException("There is no member named " + i_MemberName +"in this vehicle");
            }
        }
    }
}