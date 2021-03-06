﻿namespace SantaWorkshop.Models.Dwarfs
{
    public class SleepyDwarf : Dwarf
    {
        private const int SleepyDwarfInitialEnergy = 50;
        private const int SleepyDwarfWorkDecrement = 5;
        public SleepyDwarf(string name) 
            : base(name, SleepyDwarfInitialEnergy)
        {

        }

        public override void Work()
        {
            base.Work();
            this.Energy -= SleepyDwarfWorkDecrement;
        }
    }
}
