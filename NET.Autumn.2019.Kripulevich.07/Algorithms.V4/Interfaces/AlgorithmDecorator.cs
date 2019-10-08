using System;

namespace Algorithms.V4.Interfaces
{
    /// <summary>
    /// The decorator of the IAlgorithm.
    /// </summary>
    /// <seealso cref="Algorithms.V4.Interfaces.IAlgorithm" />
    public abstract class AlgorithmDecorator : IAlgorithm
    {
        protected IAlgorithm Algorithm { get; }

        public AlgorithmDecorator(IAlgorithm algorithm)
        {
            Algorithm = algorithm ?? throw new ArgumentNullException($"{nameof(algorithm)} can't be null.");
        }

        /// <summary>
        /// Calculates the specified first.
        /// </summary>
        /// <param name="first">The first number.</param>
        /// <param name="second">The second number.</param>
        /// <returns>The result of calcultion.</returns>
        public abstract int Calculate(int first, int second);

        /// <summary>
        /// Calculates the specified first.
        /// </summary>
        /// <param name="first">The first number.</param>
        /// <param name="second">The second number.</param>
        /// <param name="third">The third number.</param>
        /// <returns>The result of calcultion.</returns>
        public abstract int Calculate(int first, int second, int third);

        /// <summary>
        /// Calculates the specified numbers.
        /// </summary>
        /// <param name="numbers">The numbers.</param>
        /// <returns>The result of calcultion.</returns>
        public abstract int Calculate(params int[] numbers);
    }
}
