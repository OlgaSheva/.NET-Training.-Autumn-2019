using System;
using System.Collections.Generic;
using System.Numerics;

namespace PrimeNumbers
{
    public static class PrimeNumberGenerator
    {
        public static IEnumerable<BigInteger> GetPrimeNumbers(BigInteger MaxNumber)
        {
            if (MaxNumber < 2)
            {
                throw new ArgumentException($"The {nameof(MaxNumber)} should be larger than 1.");
            }

            var simple = new List<int>();

            for (int i = 2; i <= MaxNumber; i++)
            {
                if (IsSimple(i))
                {
                    yield return i;
                }
            }
        }

        private static bool IsSimple(BigInteger number)
        {
            for (int i = 2; i <= (number / 2); i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }
    }
}
