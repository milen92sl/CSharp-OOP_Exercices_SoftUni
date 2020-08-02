using System;
using System.Collections.Generic;
using System.Text;
using Bo;

namespace BorderControl
{
    public class Citizen : IIdentifiable, ILivable
    {
        public string id;
        public int age;
        public string name;
        public string birthday;
        public Citizen(string name, int age, string id, string birthday)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthday = birthday;
        }
        public string Birthday
        {
            get => this.birthday;
            private set { this.birthday = value; }
        }
        public string Id
        {
            get => this.id;
            private set { this.id = value; }
        }

        public int Age
        {
            get => this.age;
            private set { this.age = value; }
        }

        public string Name
        {
            get => this.name;
            private set { this.name = value; }
        }

       
    }
}