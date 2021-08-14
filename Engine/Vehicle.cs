using System;
using System.Collections.Generic;

namespace Engine
{
    public abstract class Vehicle
    {
        private readonly string r_ModelName; 
        private readonly string r_LicenseNumber; 
        private float m_EnergyMeter = 0;
        private List<Tire> m_ListOfTires;
        
        public Vehicle(List<string> i_CommonVehicleInfo) // 0-licenseNumber, 1- ModelName , 2- m_EnergyMeter , tires: 3- manufactureName, 4- current air pressure , 5- max air pressure
        {
            r_LicenseNumber = i_CommonVehicleInfo[0];
            r_ModelName = i_CommonVehicleInfo[1];
            bool goodInput;
            string stringEnergyMeter = i_CommonVehicleInfo[2];
            goodInput = float.TryParse(stringEnergyMeter, out m_EnergyMeter); //TODO do it with try and catch - this is a tester for good input

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
            }
        }

        public Vehicle(string i_ModelName, string i_LicenseNumber, float i_EnergyMeter, List<Tire> i_ListOfTires)
        {
            r_ModelName = i_ModelName;
            r_LicenseNumber = i_LicenseNumber;
            m_EnergyMeter = i_EnergyMeter;
            m_ListOfTires = i_ListOfTires; // TODO check if I can get list in ctor..
        }

        public string ModelName
        {
            get { return r_ModelName; }
        }

        public string LicenseNumber
        {
            get { return r_LicenseNumber; }
        }

        public float EnergyMeter
        {
            get { return m_EnergyMeter; }
            set { m_EnergyMeter = value; }
        }

        public List<Tire> ListOfTires
        {
            get { return m_ListOfTires; }
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

            return base.Equals(obj);
        }
    }
}