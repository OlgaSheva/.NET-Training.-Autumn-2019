using System;

namespace Logic
{
    /// <summary>
    /// Interface to alrorithms of calculation of the GCD of several numbers.
    /// </summary>
    internal abstract class Algorithm
    {
        /// <summary>
        /// Calculate the GCD of several numbers.
        /// </summary>
        /// <param name="val1">The val1.</param>
        /// <param name="val2">The val2.</param>
        /// <returns>Returns GCD of several numbers.</returns>
        internal abstract long GCD(long val1, long val2);

        /// <summary>
        /// Calculate the GCD of several numbers.
        /// </summary>
        /// <param name="val1">The val1.</param>
        /// <param name="val2">The val2.</param>
        /// <param name="val3">The val3.</param>
        /// <returns>Returns GCD of several numbers.</returns>
        internal long GCD(long val1, long val2, long val3)
        {
            bool flag = false;
            if (val1 != 0 || val2 != 0 || val3 != 0)
            {
                flag = true;
            }

            if (flag)
            {
                return GCD(GCD(val1, val2), val3);
            }
            else
            {
                throw new ArgumentException($"All elements can't be zero.");
            }
        }

        /// <summary>
        /// Calculate the GCD of several numbers.
        /// </summary>
        /// <param name="numbers">The nambers.</param>
        /// <returns>Returns GCD of several numbers.</returns>
        internal long GCD(params long[] numbers)
        {
            bool flag = false;
            foreach (var item in numbers)
            {
                if (item != 0)
                {
                    flag = true;
                    break;
                }
            }

            if (flag)
            {
                long gcd = 0;

                for (int i = 0; i < numbers.Length; i++)
                {
                    gcd = GCD(numbers[i], gcd);
                }

                return gcd;
            }
            else
            {
                throw new ArgumentException($"All elements of {nameof(numbers)} can't be zero.");
            }
        }
    }
}
