using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine()); // read number of people rebels or citizens
            var inhabitants = new HashSet<IBuyer>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                var name = input[0];
                var age = int.Parse(input[1]);
                if (input.Length == 4)
                {
                    var id = input[2];
                    var birthday = input[3];
                    var currentCitizen = new Citizen(name, age, id, birthday);
                    inhabitants.Add(currentCitizen);

                }
                else if (input.Length == 3)
                {
                    var group = input[2];
                    var currentRebel = new Rebel(name, age, group);
                    inhabitants.Add(currentRebel);
                }

            }
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                var buyer = inhabitants.FirstOrDefault(x => x.Name == input);
                if (buyer != null)
                {
                    buyer.BuyFood();
                }
                
            }

            Console.WriteLine(inhabitants.Sum(x=>x.Food));
        }
    }
}
