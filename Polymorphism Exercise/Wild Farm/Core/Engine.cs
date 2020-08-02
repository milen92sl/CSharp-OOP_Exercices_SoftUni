using System;
using System.Collections.Generic;
using WildFarm.Contracts;
using WildFarm.Factories;
using WildFarm.Models.Animals.Bird;
using WildFarm.Models.Animals.Mammal;
using WildFarm.Models.Animals.Mammal.Feline;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private List<IAnimal> animals;
        private FoodFactory foodFactory;
        public Engine()
        {
            this.animals = new List<IAnimal>();
            this.foodFactory = new FoodFactory();
        }
        public void Run()
        {

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                var tokens = input.Split();
                var animalType = tokens[0];
                var name = tokens[1];
                var weight = double.Parse(tokens[2]);
                var foods = Console.ReadLine().Split();
                var type = foods[0];
                var quantity = int.Parse(foods[1]);
                IFood food = this.foodFactory.ProduceFood(type, quantity);
                IAnimal animal = null;
                if (animalType == "Owl")
                {
                    var wingSize = double.Parse(tokens[3]);
                    animal = new Owl(name, weight, wingSize);

                }
                else if (animalType == "Hen")
                {
                    var wingSize = double.Parse(tokens[3]);
                    animal = new Hen(name, weight, wingSize);

                }
                else if (animalType == "Dog")
                {
                    var livingRegion = tokens[3];
                    animal = new Dog(name, weight, livingRegion);
                }
                else if (animalType == "Mouse")
                {
                    var livingRegion = tokens[3];
                    animal = new Mouse(name, weight, livingRegion);

                }
                else if (animalType == "Cat")
                {
                    var livingRegion = tokens[3];
                    var breed = tokens[4];
                    animal = new Cat(name, weight, livingRegion, breed);


                }
                else if (animalType == "Tiger")
                {
                    var livingRegion = tokens[3];
                    var breed = tokens[4];
                    animal = new Tiger(name, weight, livingRegion, breed);
                }

                try
                {
                    Console.WriteLine(animal.ProduceSound());
                    animals.Add(animal);
                    animal.Feed(food);

                }
                catch (Exception uex)
                {
                    Console.WriteLine(uex.Message);

                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
