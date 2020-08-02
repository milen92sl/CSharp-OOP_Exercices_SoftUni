using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace FoodShortage
{
    public class Rebel : IBuyer
    {
        private string name;
        private int age;
        private int food;
        private string group;
        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
        }
        public string Name
        {
            get => this.name;
            private set { this.name = value; }
        }
        public int Age
        {
            get => this.age;
            private set { this.age = value; }
        }
        public int Food
        {
            get => this.food;
            private set { this.food = value; }
        }

        public string Group
        {
            get => this.group;
            private set { this.group = value; }
        }
        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}
