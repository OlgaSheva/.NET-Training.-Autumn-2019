using System;

namespace Logic
{
    /// <summary>
    /// Newton's method for calculating the root of the Nth power of a number.
    /// </summary>
    internal class NewtonsMethod : IMethod
    {
        /// <summary>
        /// Method for calculating the root of the Nth power of a number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="rootDegree">the root degree.</param>
        /// <param name="accuracy">The precision.</param>
        /// <returns>Root Nth degrees of the number.</returns>
        public double NthRoot(double number, int rootDegree, double accuracy)
        {
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

            double n = rootDegree;
            var x0 = number;
            var x1 = number / n;
            do
            {
                x1 = x0;
                x0 = (1 / n) * (((n - 1) * x1) + (number / Math.Pow(x1, n - 1)));
            }
            while (Math.Abs(x0 - x1) > accuracy);            
            
            return x0;
        }
    }
}
