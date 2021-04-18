using System;
using System.Linq;
using System.Text;
using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Models.Workshops.Contracts;
using Easter.Repositories;
using Easter.Repositories.Contracts;
using Easter.Utilities.Messages;

namespace Easter.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IBunny> bunnies;
        private readonly IRepository<IEgg> eggs;

        public Controller()
        {
            this.bunnies = new BunnyRepository();
            this.eggs = new EggRepository();
        }
        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny;

            if (bunnyType == nameof(HappyBunny))
            {
                bunny = new HappyBunny(bunnyName);
            }
            else if (bunnyType == nameof(SleepyBunny))
            {
                bunny = new SleepyBunny(bunnyName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }

            this.bunnies.Add(bunny);

            var result = String.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);

            return result;
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            var currentBunny = this.bunnies.FindByName(bunnyName);

            if (currentBunny == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }

            IDye dye = new Dye(power);
            currentBunny.AddDye(dye);

            var result = String.Format(OutputMessages.DyeAdded, power, bunnyName);

            return result;
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);
            this.eggs.Add(egg);

            var result = String.Format(OutputMessages.EggAdded, eggName);

            return result;
        }

        public string ColorEgg(string eggName)
        {
            IWorkshop workshop = new Workshop();

            var egg = this.eggs.FindByName(eggName);
            var workingBunnies = this.bunnies.Models
                .Where(b => b.Energy >= 50)
                .OrderByDescending(b => b.Energy)
                .ToList();

            if (workingBunnies.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }

            while (workingBunnies.Any())
            {
                var currBunny = workingBunnies.First();

                workshop.Color(egg, currBunny);

                if (currBunny.Energy == 0)
                {
                    this.bunnies.Remove(currBunny);
                }

                if (currBunny.Dyes.Count == 0)
                {
                    workingBunnies.Remove(currBunny);
                }

                if (egg.IsDone())
                {
                    break;
                }
            }

            var message = egg.IsDone() ? OutputMessages.EggIsDone : OutputMessages.EggIsNotDone;
            var result = String.Format(message, eggName);

            return result;

        }

        public string Report()
        {
            var countColoredEggs = this.eggs.Models.Count();

            var sb = new StringBuilder();
            sb
                .AppendLine($"{countColoredEggs} eggs are done!")
                .AppendLine("Bunnies info:");

            foreach (IBunny bunny in this.bunnies.Models)
            {
                  sb.AppendLine($"Name: {bunny.Name}")
                    .AppendLine($"Energy: {bunny.Energy}")
                    .AppendLine($"Dyes: {bunny.Dyes.Count} not finished");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
