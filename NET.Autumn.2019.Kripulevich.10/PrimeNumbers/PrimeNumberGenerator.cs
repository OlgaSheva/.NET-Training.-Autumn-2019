using System;
using System.Collections.Generic;
using System.Numerics;

namespace PrimeNumbers
{
    /// <summary>
    /// Genegator of prime numbers.
    /// </summary>
    public static class PrimeNumberGenerator
    {
        /// <summary>
        /// Gets the prime numbers.
        /// </summary>
        /// <param name="MaxNumber">The maximum number.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">The {nameof(MaxNumber)} should be larger than 1.</exception>
        public static IEnumerable<BigInteger> GetPrimeNumbers(BigInteger MaxNumber)
        {
            if (MaxNumber < 2)
            {
                throw new ArgumentException($"The {nameof(MaxNumber)} should be larger than 1.");
            }

            yield return 2;

            for (int i = 3; i <= MaxNumber; i += 2)
            {
                if (IsSimple(i))
                {
                    yield return i;
                }
            }
        }

        private static bool IsSimple(BigInteger number)
        {
            for (int i = 2; i <= (number / 2); i ++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }
    }
}
