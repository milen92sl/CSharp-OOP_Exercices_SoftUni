using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private Random random;

        public string RandomString()
        {
            int index = random.Next(0, this.Count);
            string input = this[index];
            this.Add(input);
            this.Remove(input);
            return input;
        }
    }
}
