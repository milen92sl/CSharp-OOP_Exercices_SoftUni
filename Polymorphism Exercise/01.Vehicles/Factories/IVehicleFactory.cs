using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles.Factories
{
   public  interface IVehicleFactory
   {
       IVehicle CreateVehicle(string type, double fuelQuantity, double fuelConsumption,double tankCapacity, bool hasAirConditioner = true);

   }
}
