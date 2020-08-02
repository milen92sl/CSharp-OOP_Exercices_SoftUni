using System;
using System.Collections.Generic;
using WildFarm.Contracts;

namespace WildFarm.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        private const string UneatableFoodMsg = "{0} does not eat {1}!";
        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }
        public string Name { get; private set; }
        public double Weight { get; private set; }
        public int FootEaten { get; private set; }
        public int FoodEaten { get; protected set; }

        public abstract double WightMultiplier { get; }
        public abstract ICollection<Type> PrefferedFoods { get; }
        public abstract string ProduceSound();

        public void Feed(IFood food)
        {

            if (!this.PrefferedFoods.Contains(food.GetType()))
            {
                throw new ArgumentException(string.Format(UneatableFoodMsg, this.GetType().Name, food.GetType().Name));
            }

            this.Weight += this.WightMultiplier * food.Quantity;
            this.FoodEaten += food.Quantity;
        }


    }
}
