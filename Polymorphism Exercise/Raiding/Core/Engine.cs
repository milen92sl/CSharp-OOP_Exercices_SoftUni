
using System;
using System.Collections.Generic;
using System.Linq;
using Raiding.Contracts;
using Raiding.Factories;


namespace Raiding.Core
{
    class Engine : IEngine
    {
        private List<IBaseHero> heroes;
        private HeroFactory factory;
        public Engine()
        {
            this.heroes = new List<IBaseHero>();
            this.factory = new HeroFactory();
        }
        public void Run()
        {
            var counter = 0;
            var n = int.Parse(Console.ReadLine()); // number of commands
            while (counter != n)
            {
                var name = Console.ReadLine();
                var type = Console.ReadLine();
                try
                {
                    IBaseHero hero = this.factory.ProduceHero(type, name);
                    heroes.Add(hero);
                    counter++;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }
            }

            var bossPower = int.Parse(Console.ReadLine());
            var heroesPowr = heroes.Sum(x => x.Power);
            foreach (var hero in this.heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }

            if (heroesPowr >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }

        }
    }
}
