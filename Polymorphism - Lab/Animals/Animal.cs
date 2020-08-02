using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Animals
{
    public class Animal
    {
        public string Name { get; protected set; }

        public string FavoriteFood { get; protected set; }

        public Animal(string name, string favoriteFood)
        {
            this.Name = name;
            this.FavoriteFood = favoriteFood;
        }

        public virtual string ExplainSelf()
        {
            return $"I am {this.Name} and my favorite food is {this.FavoriteFood}";
        }
    }
}
