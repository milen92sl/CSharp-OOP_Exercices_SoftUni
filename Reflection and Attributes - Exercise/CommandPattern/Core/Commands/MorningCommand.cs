using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Core.Commands
{
    public class MorningCommand : ICommand
    {
        public string Execute(string[] args)
        {
            string res = $"Morning, {args[0]}";
            return res;
        }
    }
}
