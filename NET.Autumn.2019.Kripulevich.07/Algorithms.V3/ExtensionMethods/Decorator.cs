using System;
using Algorithms.V3.Interfaces;
using System.Diagnostics;

namespace Algorithms.V3
{
    /// <summary>
    /// Class decorator of interface IAlgorithm.
    /// </summary>
    /// <seealso cref="Algorithms.V3.Interfaces.IAlgorithm" />
    public class Decorator : IAlgorithm
    {
        /// <summary>
        /// The algorithm.
        /// </summary>
        private readonly IAlgorithm algorithm;

        /// <summary>
        /// Gets milliseconds that the algorithm requires.
        /// </summary>
        /// <value>
        /// The milliseconds.
        /// </value>
        internal long Milliseconds { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Decorator"/> class.
        /// </summary>
        /// <param name="algorithm">The algorithm.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public Decorator(IAlgorithm algorithm)
        {
            if (algorithm == null)
            {
                throw new ArgumentNullException($"{nameof(algorithm)} can't be null.");
            }

            this.algorithm = algorithm;
        }

        /// <summary>
        /// GCD calculation method.
        /// </summary>
        /// <param name="first">The first number.</param>
        /// <param name="second">The second number.</param>
        /// <returns>
        /// Returns the GCD of two numbers.
        /// </returns>
        public int Calculate(int first, int second)
        {
            Stopwatch watch = Stopwatch.StartNew();

            int result = algorithm.Calculate(first, second);

            watch.Stop();
            Milliseconds = watch.ElapsedMilliseconds;

            return result;
        }

        /// <summary>
        /// GCD calculation method.
        /// </summary>
        /// <param name="first">The first number.</param>
        /// <param name="second">The second number.</param>
        /// <param name="third">The third number.</param>
        /// <returns>Returns the GCD of three numbers.</returns>
        public int Calculate(int first, int second, int third)
        {
            Stopwatch watch = Stopwatch.StartNew();
            watch.Start();

            int preResult = algorithm.Calculate(first, second);
            int result = algorithm.Calculate(preResult, third);

            watch.Stop();
            watch.Reset();

            Milliseconds = watch.ElapsedMilliseconds;

            return result;
        }

        /// <summary>
        /// GCD calculation method.
        /// </summary>
        /// <param name="numbers">The numbers.</param>
        /// <returns>Returns the GCD of several numbers.</returns>
        public int Calculate(params int[] numbers)
        {
            Stopwatch watch = Stopwatch.StartNew();
            watch.Start();
            int gcd = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                gcd = algorithm.Calculate(numbers[i], gcd);
            }

            watch.Stop();
            watch.Reset();

            Milliseconds = watch.ElapsedMilliseconds;

            return gcd;
        }
    }
}
