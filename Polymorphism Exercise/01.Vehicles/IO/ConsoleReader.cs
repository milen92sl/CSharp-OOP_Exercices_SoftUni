using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles.IO
{
   public class ConsoleReader : IReader
    {
        public string CustomReadLine()
        {
            return Console.ReadLine();
        }
    }
}
