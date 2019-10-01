using Algorithms.V3;
using Algorithms.V3.GcdImplementations;

namespace Algorithms.V3.StaticClasses
{
    /// <summary>
    /// Static class of call of calculation methods of GCD.
    /// </summary>
    public static class GCDAlgorithms
    {
        #region Euclidean Algorithms (API)

        /// <summary>
        /// The decorator.
        /// </summary>
        static Decorator decorator = new Decorator(new EuclideanAlgorithm());

        /// <summary>
        /// Finds the GCD by euclidean.
        /// </summary>
        /// <param name="first">The first number.</param>
        /// <param name="second">The second number.</param>
        /// <returns>Returns GCD of two numbers.</returns>
        public static int FindGcdByEuclidean(int first, int second) 
            => decorator.Calculate(first, second);

        public static long milliseconds = decorator.Milliseconds;

        /// <summary>
        /// Finds the GCD by euclidean.
        /// </summary>
        /// <param name="first">The first number.</param>
        /// <param name="second">The second number.</param>
        /// <param name="third">The third number.</param>
        /// <returns>Returns GCD of three numbers.</returns>
        public static int FindGcdByEuclidean(int first, int second, int third) 
            => decorator.Calculate(first, second, third);

        /// <summary>
        /// Finds the GCD by euclidean.
        /// </summary>
        /// <param name="numbers">The numbers.</param>
        /// <returns>Returns GCD of several numbers.</returns>
        public static int FindGcdByEuclidean(params int[] numbers)
            => decorator.Calculate(numbers);

        #endregion
    }
}