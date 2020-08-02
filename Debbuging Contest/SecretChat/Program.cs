using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace SecretChat
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string input = Console.ReadLine();

            StringBuilder secretMessege = new StringBuilder(message);

            while (input != "Reveal")
            {


                string[] tokens = input.Split(":|:");

                //Inserts a single empty space at the given index. The given index will always be valid.
                if (tokens[0] == "InsertSpace")
                {
                    int index = int.Parse(tokens[1]);
                    secretMessege.Insert(index, " ");
                }
                else if (tokens[0] == "Reverse")
                {
                    string substring = tokens[1];

                    substring.Reverse();
                }
                else if (tokens[0] == "ChangeAll")
                {

                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"You have a new text message: {secretMessege}");
        }
    }
}
