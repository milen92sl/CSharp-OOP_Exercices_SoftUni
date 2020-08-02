using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class MyCollection
    {
        private List<string> input;

        public MyCollection(string[] input)
        {
            this.input = new List<string>(input);
        }
    }
}
