using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectionHierarchy
{
    public class AddCollection : MyCollection, IAddCollection
    {
        public int[] Add(List<string> item)
        {
            var result = new int[item.Count];
            for (int i = 0; i < item.Count; i++)
            {
                result[i] = i;

            }
            return result;
        }


        public AddCollection(string[] input) : base(input)
        {
        }
    }
}
