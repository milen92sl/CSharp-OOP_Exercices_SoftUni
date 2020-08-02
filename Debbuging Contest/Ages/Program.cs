using System;

namespace Ages
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            try
            {
                if (int.Parse(input) >= 0 && int.Parse(input) <= 2)
                {
                    Console.WriteLine($"baby");
                }
                else if (int.Parse(input) >= 3 && int.Parse(input) <= 13)
                {
                    Console.WriteLine($"child");
                }
                else if (int.Parse(input) >= 14 && int.Parse(input) <= 19)
                {
                    Console.WriteLine($"teenager");
                }
                else if (int.Parse(input) >= 20 && int.Parse(input) <= 65)
                {
                    Console.WriteLine($"adult");
                }
                else if (int.Parse(input) >= 66)
                {
                    Console.WriteLine($"elder");
                }
                if (int.Parse(input) < 0)
                {
                    throw new ArgumentException("Error");
                }
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"Input {input} can not be negative!", ex);
            }
        }
    }
}
