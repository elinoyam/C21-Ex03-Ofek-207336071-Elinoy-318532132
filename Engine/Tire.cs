namespace Engine
{
    public struct Tire
    {
        private string m_ManufactureName;
        private float m_CurrentAirPressure;
        private readonly float r_MaxAirPressureByManufacture;

        public string ManufactureName
        {
            get
            {
                return m_ManufactureName;
            }

            set
            {
                m_ManufactureName = value;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }

            set {
                if(value <= r_MaxAirPressureByManufacture && value > 0)
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
            get
            {
                return r_MaxAirPressureByManufacture;
            }
        }

        public Tire(float i_MaxAirPressureByManufacture)
        {
            r_MaxAirPressureByManufacture = i_MaxAirPressureByManufacture;
            m_ManufactureName = null;
            m_CurrentAirPressure = 0;
        }

        public Tire(string i_ManufactureName, float i_CurrentAirPressure, float i_MaxAirPressureByManufacture)
        {
            m_ManufactureName = i_ManufactureName;
            m_CurrentAirPressure = i_CurrentAirPressure;
            r_MaxAirPressureByManufacture = i_MaxAirPressureByManufacture;
        }

        public void TireInflating(float i_AirPressureToAdd) 
        {
            if((m_CurrentAirPressure + i_AirPressureToAdd) > r_MaxAirPressureByManufacture)
            {
                throw new ValueOutOfRangeException(
                    r_MaxAirPressureByManufacture, 0,
                    $"You tried to inflate the tire with {i_AirPressureToAdd} psi, but the tire already had {m_CurrentAirPressure} psi.\n"
                    + $"Therefore you passed the maximum air pressure that was set by the manufacture {r_MaxAirPressureByManufacture} psi. You can't add that much!");
            }

            m_CurrentAirPressure += i_AirPressureToAdd;
        }
    }
}
