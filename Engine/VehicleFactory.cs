using System;
using System.Collections.Generic;
using static Engine.GarageManager; // TODO y i need this? I just want the enum

namespace Engine
{
    class VehicleFactory
    {
        public static Vehicle CreateNewVehicle(eAvailableTypesOfVehicles i_VehicleType, List<string> i_CommonVehicleInfo, 
                                               List<object> i_CommonTypeOfVehicleInfo, List<object> i_SpecificTypeOfVehicleInfo)
        {
            Vehicle newVehicle = null;
            switch (i_VehicleType)
            {
                case eAvailableTypesOfVehicles.FuelMotorcycle:
                    newVehicle = new FuelMotorcycle(i_CommonVehicleInfo, i_CommonTypeOfVehicleInfo, i_SpecificTypeOfVehicleInfo);

                    break;
                case eAvailableTypesOfVehicles.ElectricMotorcycle:
                    //newVehicle = new Car(i_VehicleLicense, i_VehicleType, i_GeneralProperties, i_SpecificProperties);
                    break;

                case eAvailableTypesOfVehicles.FuelCar:
                    break;

                case eAvailableTypesOfVehicles.ElectricCar:
                    //newVehicle = new Motorcycle(i_VehicleLicense, i_VehicleType, i_GeneralProperties, i_SpecificProperties);
                    break;

                case eAvailableTypesOfVehicles.Truck:
                    //newVehicle = new Truck(i_VehicleLicense, i_VehicleType, i_GeneralProperties, i_SpecificProperties);
                    break;
            }
            VehicleList.Add(i_VehicleLicense, newVehicle);

            return true; //TODO delete after implement
        }

    }
}
