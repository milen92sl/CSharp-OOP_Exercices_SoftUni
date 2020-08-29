using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            Stack<string> inputStack = new Stack<string>();
            inputStack.Peek();

            if (inputStack.Count > 0)
            {
                return true;
            }

            return false;
        }

        public Stack<string> AddRange()
        {
            string input = Console.ReadLine();

            Stack<string> inputStack = new Stack<string>();

            inputStack.Push(input);

            return inputStack;
        }
    }
}
