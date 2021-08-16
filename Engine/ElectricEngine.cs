using System;

namespace Engine
{
    public class ElectricEngine : Engine
    {
        private readonly float r_MaxBatteryTimeInHours;
        private float m_BatteryTimeRemainingInHours;

        public float MaxBatteryTimeInHours
        {
            get
            {
                return r_MaxBatteryTimeInHours;
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
                if (m_BatteryTimeRemainingInHours > r_MaxBatteryTimeInHours)
                {
                    throw new ValueOutOfRangeException(r_MaxBatteryTimeInHours, 0, "The given amount of time of remaining electricity in the battery is more than the maximum hours of the battery."); //TODO look at it again
                }

                m_BatteryTimeRemainingInHours = value;
            }
        }

        public ElectricEngine(float i_MaxBatteryTimeInHours, float i_BatteryTimeRemainingInHours)
        {
            r_MaxBatteryTimeInHours = i_MaxBatteryTimeInHours;
            m_BatteryTimeRemainingInHours = i_BatteryTimeRemainingInHours;
        }

        public void Recharge (float i_AmoutOfHoursToAdd)
        {
            if (m_BatteryTimeRemainingInHours + i_AmoutOfHoursToAdd > r_MaxBatteryTimeInHours)
            {
                throw new ValueOutOfRangeException(r_MaxBatteryTimeInHours, 0, "The amount of hours to add exceeds what is allowed in this engine.");
            }
            else
            {
                m_BatteryTimeRemainingInHours += i_AmoutOfHoursToAdd;
            }
        }
    }
}
