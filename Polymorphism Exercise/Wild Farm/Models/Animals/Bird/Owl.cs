using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Contracts;
using WildFarm.Models.Food;

namespace WildFarm.Models.Animals.Bird
{
    public class Owl : Bird
    {
        private const double weightIncrese = 0.25;

        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override double WightMultiplier => weightIncrese;
        public override ICollection<Type> PrefferedFoods => new List<Type>(){typeof(Meat)};

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
