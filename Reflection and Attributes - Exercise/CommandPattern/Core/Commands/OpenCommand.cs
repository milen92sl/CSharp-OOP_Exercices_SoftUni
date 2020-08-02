using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Core.Commands
{
   public class OpenCommand : ICommand
    {
        public string Execute(string[] args)
        {
            return $"Open -> {args[0]}, {args[1]}";
        }
    }
}
