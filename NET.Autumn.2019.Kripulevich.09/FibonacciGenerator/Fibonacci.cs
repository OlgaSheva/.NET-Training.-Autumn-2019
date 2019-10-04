using System;
using System.Collections.Generic;

namespace FibonacciGenerator
{
    public static class Fibonacci
    {
        public static IEnumerable<int> Generate(int numbers)
        {
            if (numbers == 0)
            {
                throw new ArgumentException($"{nameof(numbers)} must be larger than zero.");
            }

            if (numbers == 1)
            {
                yield return 0;
                yield break;
            }

            yield return 0;
            yield return 1;

            int last = 0;
            int current = 1;

            while (numbers-- > 2)
            {
                int next = last + current;
                yield return next;
                last = current;
                current = next;
            }
        }
    }
}
