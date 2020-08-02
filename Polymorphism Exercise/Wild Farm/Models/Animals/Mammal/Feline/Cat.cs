

using System;
using System.Collections.Generic;
using WildFarm.Models.Food;

namespace WildFarm.Models.Animals.Mammal.Feline
{
    public class Cat : Feline
    {
        private const double weightIncrese = 0.3;

        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override double WightMultiplier => weightIncrese;
        public override ICollection<Type> PrefferedFoods => new List<Type>(){typeof(Meat), typeof(Vegetable)};

    public override string ProduceSound()
        {
            return $"Meow";
        }
    }
}
