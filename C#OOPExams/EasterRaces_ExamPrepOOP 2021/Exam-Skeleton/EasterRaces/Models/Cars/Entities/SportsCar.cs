﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{

    public class SportsCar : Car
    {
        private const double CubicCentimetersSportsCar = 3000;
        private const int MinHorsePowerSportsCar = 250;
        private const int MaxHorsePowerSportsCar = 450;
        public SportsCar(string model, int horsePower)
            : base(model, horsePower, CubicCentimetersSportsCar, MinHorsePowerSportsCar, MaxHorsePowerSportsCar)
        {
        }
    }
}
