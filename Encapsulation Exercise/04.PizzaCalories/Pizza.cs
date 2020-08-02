using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace _04.PizzaCalories
{
    public class Pizza
    {
        private const int MaxNameLength = 15;
        private const int MinNameLength = 1;
        private const int MaxToppingsCount = 10;

        private string name;
        private Dough dough;
        private readonly List<Topping> toppings;

        public Pizza(string name)
        {
            this.Name = name;
            this.toppings = new List<Topping>();
        }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < MinNameLength || value.Length > MaxNameLength)
                {
                    throw new ArgumentException($"Pizza name should be between {MinNameLength} and {MaxNameLength} symbols.");
                }

                this.name = value;
            }
        }

        public Dough Dough
        {
            get { return this.dough; }
            set { this.dough = value; }
        }

        public int CountOfToppings => this.toppings.Count;
        public double TotalCalories => CalculateTotalCalories();


        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count == MaxToppingsCount)
            {
                throw new ArgumentException($"Number of toppings should be in range [0..{MaxToppingsCount}].");
            }

            this.toppings.Add(topping);
        }

        private double CalculateTotalCalories()
        {
            double res = this.Dough.TotalCalories;

            foreach (Topping topping in this.toppings)
            {
                res += topping.TotalCalories;
            }

            return res;
        }
    }
}
