using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Citizen : IBuyer
    {
        private string name;
        private string id;
        private int age;
        private int food;
        private string birthDay;

        public Citizen(string name, int age, string id, string birthDay)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.BirthDay = birthDay;
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
        public string Id
        {
            get => this.id;
            private set { this.id = value; }
        }
        public string BirthDay
        {
            get => this.birthDay;
            private set { this.birthDay = value; }
        }
        public void BuyFood()
        {
            this.food += 10;
        }
    }
}
