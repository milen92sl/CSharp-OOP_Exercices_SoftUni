using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        public Car(int horsePower, double fuel) : base(horsePower, fuel)
        {

        }
        private const double DefaultCarFuelConsumption = 3;

        public override double FuelConsumption => DefaultCarFuelConsumption;

        public override void Drive(double km)
        {
            double fuelAfterDrive = Fuel - km * FuelConsumption;

            if (fuelAfterDrive >= 0)
            {
                Fuel = fuelAfterDrive;
            }
        }
    }
}
