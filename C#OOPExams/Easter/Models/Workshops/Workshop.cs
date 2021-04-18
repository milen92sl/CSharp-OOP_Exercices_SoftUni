using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
            while (bunny.Energy > 0 && bunny.Dyes.Any())
            {
                IDye currentEgg = bunny.Dyes.First();

                while (!egg.IsDone() && bunny.Energy > 0 && !currentEgg.IsFinished())
                {
                    egg.GetColored();
                    bunny.Work();
                    currentEgg.Use();
                }

                if (currentEgg.IsFinished())
                {
                    bunny.Dyes.Remove(currentEgg);
                }

                if (egg.IsDone())
                {
                    break;
                }
            }
        }
    }
}
