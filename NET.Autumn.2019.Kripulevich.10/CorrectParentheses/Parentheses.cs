using System;
using System.Collections.Generic;

namespace CorrectParentheses
{
    /// <summary>
    /// A class for determining the correct placement of brackets.
    /// </summary>
    public static class Parentheses
    {
        private static readonly string openingBrackets = "({[<";
        private static readonly string closingBrackets = ")}]>";

        /// <summary>
        /// Corrects the specified string.
        /// </summary>
        /// <param name="string">The string.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">The {nameof(@string)} can't be null.</exception>
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
