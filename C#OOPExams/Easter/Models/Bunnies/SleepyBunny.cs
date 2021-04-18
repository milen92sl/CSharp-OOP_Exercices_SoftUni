using System;
using System.Collections.Generic;
using System.Text;
using Easter.Models.Bunnies.Contracts;

namespace Easter.Models.Bunnies
{
    public class SleepyBunny : Bunny, IBunny
    {
        private const int InitialEnery = 50;
        private const int AdditionalWorkEnergyToDecrease = 5;
        public SleepyBunny(string name) : base(name, InitialEnery)
        {
        }
        public override void Work()
        {
            base.Work();
            this.Energy -= AdditionalWorkEnergyToDecrease;
        }
    }
}
