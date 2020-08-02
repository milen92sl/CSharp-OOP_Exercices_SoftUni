using System;
using ExplicitInterfaces.Interfaces;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                var command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }

                var input = command.Split();
                var currentCitizen = new Citizen(input[0], input[1], int.Parse(input[2]));
                IPerson person = currentCitizen;
                IResident resident = currentCitizen;
                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());
            }
        }
    }
}
