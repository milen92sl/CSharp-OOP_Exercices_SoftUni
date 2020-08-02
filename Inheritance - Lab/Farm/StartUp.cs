using System;

namespace Farm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dog dog = new Animal();
            dog.Eat();
            dog.Bark();

            Cat cat = new Animal();
            cat.Eat();
            cat.Meow();

        }
    }
}
