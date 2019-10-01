using Algorithms.V1.Interfaces;
using System;

namespace Algorithms.V1.GcdImplementations
{
    /// <summary>
    /// Stein's algorithm of calculating GCD.
    /// </summary>
    /// <seealso cref="Algorithms.V1.Interfaces.Algorithm" />
    internal class SteinsAlgorithm : Algorithm
    {
        /// <summary>
        /// Calculate GCD of two numbers.
        /// </summary>
        /// <param name="first">The first number.</param>
        /// <param name="second">The second number.</param>
        /// <returns>Returns GCD of two numbers.</returns>
        /// <exception cref="System.ArgumentException">Arguments can't be less than -2'147'483'647.</exception>
        protected override int Action(int first, int second)
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

            // If v2 is even.
            if ((v1 & 1) == 0)
            {
                return ((v2 & 1) == 0)
                    ? this.Action(v1 >> 1, v2 >> 1) << 1       // If v2 is even GCD(v1, v2) = 2 * GCD(v1 / 2, v2 / 2)
                    : this.Action(v1 >> 1, v2);                // If v2 isn't even GCD(v1, v2) = GCD(v1 / 2, v2)
            }
            // If v2 isn't even.
            else
            {
                return ((v2 & 1) == 0)
                    ? this.Action(v1, v2 >> 1)                 // If v2 is even GCD(v1, v2) = 2 * GCD(v1, v2 / 2)
                    : this.Action(v2, Math.Abs(v1 - v2));      // If v2 isn't even GCD(v1, v2) = GCD(v2, |v1 - v2|)
            }
        }
    }
}
