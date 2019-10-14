using System;
using System.Collections.Generic;

namespace CorrectParentheses
{
    public static class Parentheses
    {
        private static readonly string openingBrackets = "({[<";
        private static readonly string closingBrackets = ")}]>";

        public static bool Correct(string @string)
        {
            if (@string == null)
            {
                throw new ArgumentNullException($"The {nameof(@string)} can't be null.");
            }

            if (@string.Length == 0)
            {
                return true;
            }

            var stack = new Stack<char>();

            foreach (var item in @string)
            {
                if (openingBrackets.Contains(item) || closingBrackets.Contains(item))
                {
                    for (int i = 0; i < openingBrackets.Length; i++)
                    {
                        if (item == closingBrackets[i])
                        {
                            if (stack.Peek() == openingBrackets[i])
                            {
                                stack.Pop();
                            }
                            else
                            {
                                stack.Push(item);
                            }
                        }
                        else if (item == openingBrackets[i])
                        {
                            stack.Push(item);
                        }
                    }
                }
            }

            return stack.Count == 0;
        }
    }
}
