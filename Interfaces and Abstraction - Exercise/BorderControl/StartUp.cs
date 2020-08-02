using System;
using System.Collections.Generic;
using BorderControl;

namespace Bo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var inhabitants = new List<ILivable>();
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                var tokens = input.Split();
                var type = tokens[0];
                if (type == "Robot")
                {
                    var model = tokens[1];
                    var id = tokens[2];
                    var currentRobot = new Robot(model, id);
                  //  inhabitants.Add(currentRobot);
                }
                else if (type == "Citizen")
                {
                    var name = tokens[1];
                    var age = int.Parse(tokens[2]);
                    var id = tokens[3];
                    var birthDay = tokens[4];
                    var currentCitizen = new Citizen(name, age, id, birthDay);
                    inhabitants.Add(currentCitizen);
                }
                else if (type == "Pet")
                {
                    var name = tokens[1];
                    var birthDay = tokens[2];
                    var currentPet = new Pet(name, birthDay);
                    inhabitants.Add(currentPet);
                }
            }

            var date = Console.ReadLine();
              inhabitants.FindAll(x => x.Birthday.EndsWith(date)).ForEach(y => Console.WriteLine(y.Birthday));

           
        }
    }
}
