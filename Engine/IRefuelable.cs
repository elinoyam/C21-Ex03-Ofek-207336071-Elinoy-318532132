namespace Ex03.GarageLogic
{
    internal interface IRefuelable
    {
        void Refuel(FuelEngine.eVehicleFuelType i_FuelType, float i_AmountToFill);
    }
}
