using System;

namespace Engine
{
    class Tire
    {
        private readonly string m_ManufactorName;
        private float m_CurrentAirPressure = 0;
        private readonly float m_MaxAirPressureByManufactor = 0;

        public string ManufactorName
        {
            get { return m_ManufactorName; }
        }

        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
            set {
                if(value <= m_MaxAirPressureByManufactor)
                {
                    m_CurrentAirPressure = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(m_MaxAirPressureByManufactor, 0,$"You can't fill the tire over {m_MaxAirPressureByManufactor}!");
                }
            }
        }

        public float MaxAirPressure
        {
            get { return m_MaxAirPressureByManufactor; }
        }

        public Tire(string i_ManufactorName, float i_CurrentAirPressure, float i_MaxAirPressureByManufactor)
        {
            m_ManufactorName = i_ManufactorName;
            m_CurrentAirPressure = i_CurrentAirPressure;
            m_MaxAirPressureByManufactor = i_MaxAirPressureByManufactor;
        }

        public void TireInflating(float i_AirPressureToAdd) 
        {
            if((m_CurrentAirPressure + i_AirPressureToAdd) > m_MaxAirPressureByManufactor)
            {
                throw new ValueOutOfRangeException(m_MaxAirPressureByManufactor,0,"The given air pressure to add is too much.");
            }

            m_CurrentAirPressure += i_AirPressureToAdd;
        }
    }
}
