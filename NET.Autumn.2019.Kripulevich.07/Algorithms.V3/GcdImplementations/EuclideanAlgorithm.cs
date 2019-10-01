using Algorithms.V3.Interfaces;
using System;

namespace Algorithms.V3.GcdImplementations
{
    /// <summary>
    /// Euclidean algorithm of calculating GCD.
    /// </summary>
    /// <seealso cref="Algorithms.V1.Interfaces.Algorithm" />
    public class EuclideanAlgorithm : IAlgorithm
    {
        /// <summary>
        /// Calculate GCD of two numbers.
        /// </summary>
        /// <param name="first">The first number.</param>
        /// <param name="second">The second number.</param>
        /// <returns>Returns GCD of two numbers.</returns>
        /// <exception cref="System.ArgumentException">Arguments can't be less than -2'147'483'647.</exception>
        public int Calculate(int first, int second)
        {
            if (first == int.MinValue || second == int.MinValue)
            {
                throw new ArgumentException("Arguments can't be less than -2'147'483'647.");
            }

            var v1 = Math.Abs(first);
            var v2 = Math.Abs(second);

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