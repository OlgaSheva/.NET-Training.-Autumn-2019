using System;

namespace Logic
{
    /// <summary>
    /// Newton's method for calculating the root of the Nth power of a number.
    /// </summary>
    internal class NewtonsMethod : IMethod
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public NewtonsMethod()
        {
        }

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
                x0 = (1 / n) * (((n - 1) * x1) + (number / Pow(x1, n - 1)));
            }
            while (Math.Abs(x0 - x1) > accuracy);            

            x0 = Math.Round(x0, RoundIndex(accuracy));
            
            return x0;
        }

        /// <summary>
        /// Calculation of a rounding index based on a given accuracy.
        /// </summary>
        /// <param name="accuracy">The precision.</param>
        /// <returns>Returns round index.</returns>
        private static int RoundIndex(double accuracy)
        {
            int round = 1;

            for (int i = (int)(1 / accuracy); i > 10; i /= 10)
            {
                round++;
            }

            return round;
        }

        /// <summary>
        /// The exponentiation.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="degree">The degree.</param>
        /// <returns>The result of exponentiation.</returns>
        private static double Pow(double number, double degree)
        {
            double result = 1;

            for (int i = 0; i < degree; i++)
            {
                result *= number;
            }

            return result;
        }
    }
}
