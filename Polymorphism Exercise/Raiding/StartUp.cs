using System;
using Raiding.Core;

namespace Raiding
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var engine = new Engine();
            engine.Run();
        }
    }
}
