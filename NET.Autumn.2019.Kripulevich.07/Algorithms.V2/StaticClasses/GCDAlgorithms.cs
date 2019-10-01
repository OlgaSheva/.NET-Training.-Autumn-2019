using Algorithms.V2.ExtensionMethods;
using Algorithms.V2.GcdImplementations;
using Algorithms.V2.Interfaces;

namespace Algorithms.V2.StaticClasses
{
    /// <summary>
    /// Static class of call of calculation methods of GCD.
    /// </summary>
    public static class GCDAlgorithms
    {
        #region Euclidean Algorithms (API)

        /// <summary>
        /// The algorithm.
        /// </summary>
        static IAlgorithm algorithm = new EuclideanAlgorithm();

        /// <summary>
        /// Finds the GCD by euclidean.
        /// </summary>
        /// <param name="first">The first number.</param>
        /// <param name="second">The second number.</param>
        /// <returns>Returns GCD of two numbers.</returns>
        public static int FindGcdByEuclidean(int first, int second) 
            => algorithm.Calculate(first, second);

        /// <summary>
        /// Finds the GCD by euclidean.
        /// </summary>
        /// <param name="milliseconds">The milliseconds.</param>
        /// <param name="first">The first number.</param>
        /// <param name="second">The second number.</param>
        /// <returns>Returns GCD of two numbers.</returns>
        public static int FindGcdByEuclidean(out long milliseconds, int first, int second) 
            => algorithm.Calculate(out milliseconds, first, second);

        /// <summary>
        /// Finds the GCD by euclidean.
        /// </summary>
        /// <param name="first">The first number.</param>
        /// <param name="second">The second number.</param>
        /// <param name="third">The third number.</param>
        /// <returns>Returns GCD of three numbers.</returns>
        public static int FindGcdByEuclidean(int first, int second, int third) 
            => algorithm.Calculate(first, second, third);

        /// <summary>
        /// Finds the GCD by euclidean.
        /// </summary>
        /// <param name="milliseconds">The milliseconds.</param>
        /// <param name="first">The first number.</param>
        /// <param name="second">The second number.</param>
        /// <param name="third">The third number.</param>
        /// <returns>Returns GCD of three numbers.</returns>
        public static int FindGcdByEuclidean(out long milliseconds, int first, int second, int third) 
            => algorithm.Calculate(out milliseconds, first, second, third);

        /// <summary>
        /// Finds the GCD by euclidean.
        /// </summary>
        /// <param name="numbers">The numbers.</param>
        /// <returns>Returns GCD of several numbers.</returns>
        public static int FindGcdByEuclidean(params int[] numbers)
            => algorithm.Calculate(numbers);

        /// <summary>
        /// Finds the GCD by euclidean.
        /// </summary>
        /// <param name="milliseconds">The milliseconds.</param>
        /// <param name="numbers">The numbers.</param>
        /// <returns>Returns GCD of several numbers.</returns>
        public static int FindGcdByEuclidean(out long milliseconds, params int[] numbers)
            => algorithm.Calculate(out milliseconds, numbers);

        #endregion
    }
}