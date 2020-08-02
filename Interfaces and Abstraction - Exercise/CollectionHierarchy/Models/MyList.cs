using System;
using System.Collections.Generic;
using System.Text;
using CollectionHierarchy.Interfaces;

namespace CollectionHierarchy
{
    public class MyList : MyCollection, IAddCollection, IAddRemoveCollection, IMyList
    {
        public int[] Add(List<string> item)
        {
            var result = new int[item.Count];
            for (int i = 0; i < result.Length; i++)
            {
                var currentCelement = item[i];
                item.Insert(0, currentCelement);
                result[i] = item.IndexOf(currentCelement);
            }

            return result;
        }

        public string[] Remove(string[] input, int n)
        {
            var result = new string[n];
            var helper = new Stack<string>(input);
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = helper.Pop();
            }
            return result;
        }

        public int Used { get; }

        public MyList(string[] input) : base(input)
        {
        }
    }
}
