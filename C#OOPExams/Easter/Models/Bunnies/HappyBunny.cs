using System;
using System.Collections.Generic;
using System.Text;
using Easter.Models.Bunnies.Contracts;

namespace Easter.Models.Bunnies
{
    public class HappyBunny : Bunny, IBunny
    {
        private const int InitialEnery = 100;
        public HappyBunny(string name)
            : base(name, InitialEnery)
        {
        }
    }
}
