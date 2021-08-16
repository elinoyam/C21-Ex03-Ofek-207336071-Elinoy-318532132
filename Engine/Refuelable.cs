using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    interface Refuelable
    {
        void Refuel(FuelEngine.eVehicleFuelType i_FuelType, float i_AmountToFill);
    }
}
