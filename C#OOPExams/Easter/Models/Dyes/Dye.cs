using System;
using System.Collections.Generic;
using System.Text;
using Easter.Models.Dyes.Contracts;

namespace Easter.Models.Dyes
{
    public class Dye : IDye
    {
        private const int PowerToDecreaseByUse = 10;

        private int power;
        public Dye(int power)
        {
            this.Power = power;
        }

        public int Power
        {
            get => this.power;
            private set => this.power = value > 0 ? value : 0;
        }

        public void Use()=>this.Power -= PowerToDecreaseByUse;

        public bool IsFinished() => this.Power == 0;
    }
}
