using System;
using System.Collections.Generic;

namespace CorrectParentheses
{
    public static class Parentheses
    {
        public static bool Correct(string @string)
        {
            if (@string == null)
            {
                throw new ArgumentNullException($"The {nameof(@string)} can't be null.");
            }

            var list = new LinkedList<char>();

            foreach (var symbol in @string)
            {
                if(symbol == '(' || symbol == ')' || symbol == '[' || symbol == ']' || symbol == '{' || symbol == '}')
                {
                    switch (symbol)
                    {
                        case ')':
                            if (list.Last.Value == '(')
                            {
                                list.RemoveLast();
                            }
                            break;
                        case ']':
                            if (list.Last.Value == '[')
                            {
                                list.RemoveLast();
                            }
                            break;
                        case '}':
                            if (list.Last.Value == '{')
                            {
                                list.RemoveLast();
                            }
                            break;
                        default:
                            list.AddLast(symbol);
                            break;
                    }
                }
            }

            return list.Count == 0;
        }
    }
}
