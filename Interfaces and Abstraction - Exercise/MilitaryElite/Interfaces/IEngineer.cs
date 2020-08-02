using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public interface IEngineer
    {
        IReadOnlyList<Repair> Repairs { get; }
    }
}