using System;

namespace Engine
{
    class Tire
    {
        private readonly string r_ManufactorName;
        private float m_CurrentAirPressure = 0;
        private readonly float r_MaxAirPressureByManufactor = 0;

        public string ManufactorName
        {
            get { return r_ManufactorName; }
        }

        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
            set {
                if(value <= r_MaxAirPressureByManufactor)
                {
                    m_CurrentAirPressure = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(r_MaxAirPressureByManufactor, 0,$"You can't fill the tire over {r_MaxAirPressureByManufactor}!");
                }
            }
        }

        public float MaxAirPressure
        {
            get { return r_MaxAirPressureByManufactor; }
        }

        public Tire(string i_ManufactorName, float i_CurrentAirPressure, float i_MaxAirPressureByManufactor)
        {
            r_ManufactorName = i_ManufactorName;
            m_CurrentAirPressure = i_CurrentAirPressure;
            r_MaxAirPressureByManufactor = i_MaxAirPressureByManufactor;
        }

        public void TireInflating(float i_AirPressureToAdd) 
        {
            if((m_CurrentAirPressure + i_AirPressureToAdd) > r_MaxAirPressureByManufactor)
            {
                throw new ValueOutOfRangeException(r_MaxAirPressureByManufactor,0,"The given air pressure to add is too much.");
            }

            m_CurrentAirPressure += i_AirPressureToAdd;
        }
    }
}
