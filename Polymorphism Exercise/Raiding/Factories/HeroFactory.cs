using System;
using Raiding.Contracts;
using Raiding.Models;

namespace Raiding.Factories
{
    public class HeroFactory
    {
        public IBaseHero ProduceHero(string type, string name)
        {
            IBaseHero hero = null;
            if (type == "Druid")
            {
                hero = new Druid(name, 80);
            }
            else if (type == "Paladin")
            {
                hero = new Paladin(name, 100);
            }
            else if (type == "Rogue")
            {
                hero = new Rogue(name, 80);
            }
            else if (type == "Warrior")
            {
                hero = new Warrior(name, 100);
            }
            else
            {
                throw new ArgumentException("Invalid hero!");
            }

            return hero;
        }
    }

}

