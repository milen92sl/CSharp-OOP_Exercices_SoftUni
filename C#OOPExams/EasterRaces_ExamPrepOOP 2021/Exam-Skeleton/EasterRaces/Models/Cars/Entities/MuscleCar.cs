using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private const double CubicCentimetersMuscleCar = 5000;
        private const int MinHorsePowerMuscleCar = 400;
        private const int MaxHorsePowerMuscleCar = 600;

        public MuscleCar(string model, int horsePower)
            : base(model, horsePower, CubicCentimetersMuscleCar, MinHorsePowerMuscleCar, MaxHorsePowerMuscleCar)
        {
        }

    }
}

