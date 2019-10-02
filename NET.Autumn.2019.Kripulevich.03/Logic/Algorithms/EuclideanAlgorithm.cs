using System;

namespace Logic
{
    /// <summary>
    /// Euclidean algorithm of calculation of the GCD of several numbers.
    /// </summary>
    /// <seealso cref="Logic.Algorithm" />
    internal class EuclideanAlgorithm : Algorithm
    {
        /// <summary>
        /// Calculate the GCD of several numbers.
        /// </summary>
        /// <param name="val1">The val1.</param>
        /// <param name="val2">The val2.</param>
        /// <returns>
        /// Returns GCD of two numbers.
        /// </returns>
        internal override long GCD(long val1, long val2)
        {
            if (val1 == long.MinValue || val2 == long.MinValue)
            {
                throw new ArgumentException("Numbers can't be less than -9223372036854775807");
            }

            var v1 = Math.Abs(val1);
            var v2 = Math.Abs(val2);

            if (v1 == 0)
            {
                return v2;
            }

            if (v2 == 0 || v1 == v2)
            {
                return v1;
            }

            if (v1 == 1 || v2 == 1)
            {
                return 1;
            }

            while ((v1 != 0) && (v2 != 0))
            {
                if (v1 > v2)
                {
                    v1 -= v2;
                }
                else
                {
                    v2 -= v1;
                }
            }

            return (v1 > v2) ? v1 : v2;
        }
    }
}
