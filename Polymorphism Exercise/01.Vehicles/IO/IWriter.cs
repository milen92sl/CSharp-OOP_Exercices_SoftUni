using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles.IO
{
   public interface IWriter
   {
       void CustomWriteLine(string text);

       void CustomWrite(string text);
   }
}
