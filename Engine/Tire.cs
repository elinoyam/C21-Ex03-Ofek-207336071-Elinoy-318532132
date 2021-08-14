using System;

namespace Engine
{
    public class Tire
    {
        private readonly string r_ManufactureName;
        private float m_CurrentAirPressure = 0;
        private readonly float r_MaxAirPressureByManufacture = 0;

        public string ManufactureName
        {
            get { return r_ManufactureName; }
        }

        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
            set {
                if(value <= r_MaxAirPressureByManufacture)
                {
                    m_CurrentAirPressure = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(r_MaxAirPressureByManufacture, 0,$"You can't fill the tire over {r_MaxAirPressureByManufacture}!");
                }
            }
        }

        public float MaxAirPressure
        {
            get { return r_MaxAirPressureByManufacture; }
        }

        public Tire(string i_ManufactureName, float i_CurrentAirPressure, float i_MaxAirPressureByManufacture)
        {
            r_ManufactureName = i_ManufactureName;
            m_CurrentAirPressure = i_CurrentAirPressure;
            r_MaxAirPressureByManufacture = i_MaxAirPressureByManufacture;
        }

        public void TireInflating(float i_AirPressureToAdd) 
        {
            if((m_CurrentAirPressure + i_AirPressureToAdd) > r_MaxAirPressureByManufacture)
            {
                throw new ValueOutOfRangeException(r_MaxAirPressureByManufacture,0,"The given air pressure to add is too much.");
            }

            m_CurrentAirPressure += i_AirPressureToAdd;
        }
    }
}
