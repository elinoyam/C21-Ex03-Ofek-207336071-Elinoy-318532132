using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class ElectricEngine 
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
                if (value > r_MaxBatteryTimeInHours)
                {
                    throw new ValueOutOfRangeException(r_MaxBatteryTimeInHours, 0, $"The given amount of time of remaining electricity in the battery is more than the {r_MaxBatteryTimeInHours} maximum hours of the battery."); //TODO look at it again
                }

                m_BatteryTimeRemainingInHours = value;
            }
        }

        public ElectricEngine(float i_MaxBatteryTimeInHours, float i_BatteryTimeRemainingInHours)
        {
            r_MaxBatteryTimeInHours = i_MaxBatteryTimeInHours;
            m_BatteryTimeRemainingInHours = i_BatteryTimeRemainingInHours;
        }

        public void Recharge (float i_AmountOfHoursToAdd)
        {
            if (m_BatteryTimeRemainingInHours + i_AmountOfHoursToAdd > r_MaxBatteryTimeInHours)
            {
                throw new ValueOutOfRangeException(r_MaxBatteryTimeInHours, 0,
                    $"You tried to recharge the vehicle with {i_AmountOfHoursToAdd}, but the vehicle already had {m_BatteryTimeRemainingInHours}.\n"
                    + $"Therefore you passed the maximum engine capacity {r_MaxBatteryTimeInHours}. You can't add that much!");
            }

            m_BatteryTimeRemainingInHours += i_AmountOfHoursToAdd;
        }
    }
}
