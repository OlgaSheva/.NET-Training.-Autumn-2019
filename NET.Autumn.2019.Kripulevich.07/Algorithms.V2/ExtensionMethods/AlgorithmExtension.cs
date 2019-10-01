using Algorithms.V2.Interfaces;
using System.Diagnostics;

namespace Algorithms.V2.ExtensionMethods
{  
    /// <summary>
    /// Class decorator of the interface IAlgorithm.
    /// </summary>
    public static class AlgorithmExtension
    {
        /// <summary>
        /// Calculates the GCD.
        /// </summary>
        /// <param name="algorithm">The algorithm.</param>
        /// <param name="milliseconds">The milliseconds.</param>
        /// <param name="first">The first number.</param>
        /// <param name="second">The second number.</param>
        /// <returns>Returns GCD of two numbers.</returns>
        public static int Calculate(this IAlgorithm algorithm, out long milliseconds, int first, int second)
        {
            Stopwatch watch = Stopwatch.StartNew();

            int result = algorithm.Calculate(first, second);

            watch.Stop();
            milliseconds = watch.ElapsedMilliseconds;

            return result;
        }

        /// <summary>
        /// Calculates the GCD.
        /// </summary>
        /// <param name="algorithm">The algorithm.</param>
        /// <param name="first">The first number.</param>
        /// <param name="second">The second number.</param>
        /// <param name="third">The third number.</param>
        /// <returns>Returns GCD of three numbers.</returns>
        public static int Calculate(this IAlgorithm algorithm, int first, int second, int third)
        {
            return algorithm.Calculate(algorithm.Calculate(first, second), third);
        }

        /// <summary>
        /// Calculates the GCD.
        /// </summary>
        /// <param name="algorithm">The algorithm.</param>
        /// <param name="milliseconds">The milliseconds.</param>
        /// <param name="first">The first number.</param>
        /// <param name="second">The second number.</param>
        /// <param name="third">The third number.</param>
        /// <returns>Returns GCD of three numbers.</returns>
        public static int Calculate(this IAlgorithm algorithm, out long milliseconds, int first, int second, int third)
        {
            Stopwatch watch = Stopwatch.StartNew();

            int result = algorithm.Calculate(first, second, third);

            watch.Stop();
            milliseconds = watch.ElapsedMilliseconds;

            return result;
        }

        /// <summary>
        /// Calculates the GCD.
        /// </summary>
        /// <param name="algorithm">The algorithm.</param>
        /// <param name="numbers">The numbers.</param>
        /// <returns>Returns GCD of several numbers.</returns>
        public static int Calculate(this IAlgorithm algorithm, params int[] numbers)
        {
            int gcd = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                gcd = algorithm.Calculate(numbers[i], gcd);
            }

            return gcd;
        }

        /// <summary>
        /// Calculates the GCD.
        /// </summary>
        /// <param name="algorithm">The algorithm.</param>
        /// <param name="milliseconds">The milliseconds.</param>
        /// <param name="numbers">The numbers.</param>
        /// <returns>Returns GCD of several numbers.</returns>
        public static int Calculate(this IAlgorithm algorithm, out long milliseconds, params int[] numbers)
        {
            Stopwatch watch = Stopwatch.StartNew();

            int result = algorithm.Calculate(numbers);

            watch.Stop();
            milliseconds = watch.ElapsedMilliseconds;

            return result;
        }
    }
}
