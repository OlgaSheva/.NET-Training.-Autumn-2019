using Algorithms.V4.GcdImplementations;
using Algorithms.V4.StopWatcherImplementations;
using Algorithms.V4.LoggerImplementations;

namespace Algorithms.V4.StaticClasses
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
        public static TimeDecorator timeDecorator = new TimeDecorator(new EuclideanAlgorithm(), new StopWatcher());
        //static LoggerDecorator loggerDecorator = new LoggerDecorator(new EuclideanAlgorithm(), new NLogger());

        /// <summary>
        /// Finds the GCD by euclidean.
        /// </summary>
        /// <param name="first">The first number.</param>
        /// <param name="second">The second number.</param>
        /// <returns>Returns GCD of two numbers.</returns>
        public static int FindGcdByEuclidean(int first, int second) 
            => timeDecorator.Calculate(first, second);
        
        ///// <summary>
        ///// Finds the GCD by euclidean.
        ///// </summary>
        ///// <param name="first">The first number.</param>
        ///// <param name="second">The second number.</param>
        ///// <param name="third">The third number.</param>
        ///// <returns>Returns GCD of three numbers.</returns>
        //public static int FindGcdByEuclidean(int first, int second, int third) 
        //    => timeDecorator.Calculate(first, second, third);

        ///// <summary>
        ///// Finds the GCD by euclidean.
        ///// </summary>
        ///// <param name="numbers">The numbers.</param>
        ///// <returns>Returns GCD of several numbers.</returns>
        //public static int FindGcdByEuclidean(params int[] numbers)
        //    => timeDecorator.Calculate(numbers);

        #endregion
    }
}