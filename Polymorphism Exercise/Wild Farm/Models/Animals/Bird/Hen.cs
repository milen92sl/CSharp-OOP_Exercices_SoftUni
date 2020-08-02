using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Contracts;
using WildFarm.Models.Food;

namespace WildFarm.Models.Animals.Bird
{
    public class Hen : Bird
    {
        private const double weightIncrese = 0.35;

        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override double WightMultiplier => weightIncrese;
        public override ICollection<Type> PrefferedFoods => new List<Type>()
        {
            typeof(Fruit),
            typeof(Meat),
            typeof(Seeds),
            typeof(Vegetable),
        };

    public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
