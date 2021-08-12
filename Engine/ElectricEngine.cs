using System;

namespace Engine
{
    class ElectricEngine
    {
        private readonly float m_MaxBatteryTimeInHours;
        private float m_BatteryTimeRemainingInHours;

        public float MaxBatteryTimeInHours
        {
            get
            {
                return m_MaxBatteryTimeInHours;
            }
        }

        public float BatteryTimeRemainingInHours
        {
            get
            {
                return m_BatteryTimeRemainingInHours;
            }
            set
            {
                if (m_BatteryTimeRemainingInHours > m_MaxBatteryTimeInHours)
                {
                    throw new ValueOutOfRangeException(m_MaxBatteryTimeInHours, 0, "The given amount of time of remaining electricity in the battery is more than the maximum hours of the battery."); //TODO look at it again
                }

                m_BatteryTimeRemainingInHours = value;
            }
        }

        public ElectricEngine(float i_MaxBatteryTimeInHours, float i_BatteryTimeRemainingInHours)
        {
            m_MaxBatteryTimeInHours = i_MaxBatteryTimeInHours;
            m_BatteryTimeRemainingInHours = i_BatteryTimeRemainingInHours;
        }

        public void Refuel(float i_AmoutOfHoursToAdd)
        {
            if (m_BatteryTimeRemainingInHours + i_AmoutOfHoursToAdd > m_MaxBatteryTimeInHours)
            {
                throw new ValueOutOfRangeException(m_MaxBatteryTimeInHours, 0, "The amount of hours to add exceeds what is allowed in this engine.");
            }
            else
            {
                m_BatteryTimeRemainingInHours += i_AmoutOfHoursToAdd;
            }
        }
    }
}
