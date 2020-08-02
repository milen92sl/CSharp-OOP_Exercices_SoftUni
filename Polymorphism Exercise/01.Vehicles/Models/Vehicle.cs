using _01.Vehicles.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        private const double DefaultFuelQuantity = 0;
        private double fuelQuantity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity, bool hasAirConditioner = true)
        {
            this.TankCapacity = tankCapacity;
            this.FuelConsumption = fuelConsumption;
            this.FuelQuantity = fuelQuantity;
            this.HasAirConditioner = hasAirConditioner;
        }

        public double FuelQuantity
        {
            get => this.fuelQuantity;
            protected set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = DefaultFuelQuantity;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }

        public double FuelConsumption { get; }

        public bool HasAirConditioner { get; private set; }

        public abstract double AirConditionerFuelConsumption { get; }

        public double TankCapacity { get; }

        public bool Drive(double distance)
        {
            double spentFuel = distance * this.FuelConsumption;

            if (this.HasAirConditioner)
            {
                spentFuel += AirConditionerFuelConsumption * distance;
            }

            if (this.FuelQuantity < spentFuel)
            {
                return false;
            }

            this.FuelQuantity -= spentFuel;
            return true;
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException(ExceptinMessages.NegativeFuelAmount);
            }

            if (this.FuelQuantity + liters > this.TankCapacity)
            {
                string msg = string.Format(ExceptinMessages.InvalidFuelAmount, liters);
                throw new ArgumentException(msg);
            }
            
            this.FuelQuantity += liters;
        }

        public void StartAirContitioner()
        {
            this.HasAirConditioner = true;
        }

        public void StopAirContitioner()
        {
            this.HasAirConditioner = false;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
