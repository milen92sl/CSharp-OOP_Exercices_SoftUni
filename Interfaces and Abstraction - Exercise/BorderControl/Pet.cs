using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Pet : ILivable,IIdentifiable
    {
        public string name;
        public string birthday;
        public Pet(string name, string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
        }
        public string Name
        {
            get => this.name;
            private set { this.name = value; ; }
        }
        public string Birthday
        {
            get => this.birthday;
            private set { this.birthday = value; }
        }

        public string Id { get; }
    }
}
