using System;
using System.Collections.Generic;
using System.Text;
using Easter.Models.Eggs.Contracts;
using Easter.Utilities.Messages;

namespace Easter.Models.Eggs
{
    public class Egg : IEgg
    {
        private const int EnergyForDecreaseByGetColored = 10;

        private string name;
        private int energyRequired;
        
        public Egg(string name, int energyRequired)
        {
            this.Name = name;
            this.EnergyRequired = energyRequired;
        }
        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidEggName);
                }

                this.name = value;
            }
        }

        public int EnergyRequired
        {
            get => this.energyRequired;
            private set => this.energyRequired = value > 0 ? value : 0;
        }

        public void GetColored()=> this.EnergyRequired -= EnergyForDecreaseByGetColored;

        public bool IsDone() => this.EnergyRequired == 0;
    }
}
