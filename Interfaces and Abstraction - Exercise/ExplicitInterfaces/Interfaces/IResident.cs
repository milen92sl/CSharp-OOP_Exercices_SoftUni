using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitInterfaces.Interfaces
{
    public interface IResident
    {
        public string Name { get; }
        public int Age { get; }
        public string GetName()
        {
            return $"Mr/Ms/Mrs {this.Name}";
        }
    }
}
