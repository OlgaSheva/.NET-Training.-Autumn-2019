using System.Diagnostics;

namespace Algorithms.V1.Interfaces
{
    /// <summary>
    /// Abstract algorithm of calculating GCD.
    /// </summary>
    internal abstract class Algorithm
    {
        /// <summary>
        /// Abstract method Action call.
        /// </summary>
        /// <param name="first">The first number.</param>
        /// <param name="second">The second number.</param>
        /// <returns>Result of calculation.</returns>
        public int Calculate(int first, int second)
        {
            return Action(first, second);
        }

        /// <summary>
        /// Abstract method Action call with calculating algorithm time.
        /// </summary>
        /// <param name="first">The first number.</param>
        /// <param name="second">The second number.</param>
        /// <param name="milliseconds">The milliseconds.</param>
        /// <returns>Result of calculation.</returns>
        public int Calculate(int first, int second, out long milliseconds)
        {
            Stopwatch watch = Stopwatch.StartNew();

            int result = Action(first, second);

            watch.Stop();
            milliseconds = watch.ElapsedMilliseconds;

            return result;
        }

        /// <summary>
        /// Abstract method of calculate GCD of two numbers.
        /// </summary>
        /// <param name="first">The first number.</param>
        /// <param name="second">The second number.</param>
        /// <returns>Returns GCD of two numbers.</returns>
        protected abstract int Action(int first, int second);
    }
}