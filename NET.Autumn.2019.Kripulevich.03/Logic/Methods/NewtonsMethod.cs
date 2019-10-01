using System;

namespace Logic
{
    /// <summary>
    /// Newton's method for calculating the root of the Nth power of a number.
    /// </summary>
    internal static class NewtonsMethod
    {
        /// <summary>
        /// Method for calculating the root of the Nth power of a number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="rootDegree">the root degree.</param>
        /// <param name="accuracy">The precision.</param>
        /// <returns>Root Nth degrees of the number.</returns>
        public static double NthRoot(double number, int rootDegree, double accuracy)
        {
            if (number == double.PositiveInfinity || number == double.NegativeInfinity)
            {
                throw new ArgumentException($"{nameof(number)} can't be infinity.");
            }

            if (number < 0 && rootDegree % 2 == 0)
            {
                throw new ArgumentException($"{nameof(number)} can't be negative if root degree is even.");
            }

            if (rootDegree < 0)
            {
                throw new ArgumentException($"{nameof(rootDegree)} can't be less than 0.");
            }

            if (accuracy < 0)
            {
                throw new ArgumentException($"{nameof(accuracy)} can't be less than 0.");
            }

            var x0 = number;
            var x1 = number / rootDegree;
            do
            {
                x1 = x0;
                x0 = (1.0 / rootDegree) * (((rootDegree - 1) * x1) + (number / Math.Pow(x1, rootDegree - 1)));
            }
            while (Math.Abs(x0 - x1) > accuracy);            
            
            return x0;
        }
    }
}
