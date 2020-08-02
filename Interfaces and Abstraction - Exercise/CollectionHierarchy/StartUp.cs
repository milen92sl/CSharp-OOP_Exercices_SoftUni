using System;
using System.Collections.Generic;
using System.Linq;
using CollectionHierarchy.Interfaces;

namespace CollectionHierarchy
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            var n = int.Parse(Console.ReadLine()); // number of remove operations
            var myCollection = new MyCollection(input);
            var myAddCollection = new AddCollection(input);
            var myAddRemoveCollection = new AddRemoveCollection(input);
            var myList = new MyList(input);
            Console.WriteLine(string.Join(" ", myAddCollection.Add(input.ToList())));
            Console.WriteLine(string.Join(" ", myAddRemoveCollection.Add(input.ToList())));
            Console.WriteLine(string.Join(" ", myList.Add(input.ToList())));
            Console.WriteLine(string.Join(" ", myAddRemoveCollection.Remove(input, n)));
            Console.WriteLine(string.Join(" ", myList.Remove(input, n)));
        }
    }
}
