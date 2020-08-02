using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public interface IVehicle
    {
        double FuelQuantity { get; }

        double FuelConsumption {get;}

        bool HasAirConditioner { get; }

        double AirConditionerFuelConsumption { get; }

        double TankCapacity { get; }

        bool Drive(double distance);

        void Refuel(double liters);

        void StartAirContitioner();

        void StopAirContitioner();
    }
}
