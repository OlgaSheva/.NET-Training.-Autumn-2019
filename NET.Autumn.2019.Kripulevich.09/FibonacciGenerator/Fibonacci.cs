using System;
using System.Collections.Generic;
using System.Numerics;

namespace FibonacciGenerator
{
    /// <summary>
    /// Class generator fibonacci numbers.
    /// </summary>
    public static class Fibonacci
    {
        /// <summary>
        /// Generates the fibonacci numbers.
        /// </summary>
        /// <param name="count">The count of numbers.</param>
        /// <returns>The fibonacci numbers.</returns>
        /// <exception cref="ArgumentException">Throws when number is zero.</exception>
        public static IEnumerable<BigInteger> Generate(int count)
        {
            if (count < 0)
            {
                throw new ArgumentException($"{nameof(count)} can't be less than zero.");
            }

            if (count == 0)
            {
                return new BigInteger[0];
            }

            return GenerateFibonacci(count);            
        }

        private static IEnumerable<BigInteger> GenerateFibonacci(int c)
        {
            BigInteger last = 0,
                       current = 1;

            for (int i = 0; i < c; i++)
            {
                yield return last;
                var temp = current;
                current = last + current;
                last = temp;
            }
        }
    }
}
