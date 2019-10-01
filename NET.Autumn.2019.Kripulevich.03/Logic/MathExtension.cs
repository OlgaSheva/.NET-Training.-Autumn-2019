using System.Diagnostics;

namespace Logic
{
    /// <summary>
    /// Metod of calculation of the Nth root of a number.
    /// </summary>
    public static class MathExtension
    {
        #region FindNthRoot
        /// <summary>
        /// Finds the NTH root.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="rootDegree">The root degree.</param>
        /// <param name="accuracy">The accurancy.</param>
        /// <returns>Root Nth degrees of the number.</returns>
        public static double FindNthRoot(double number, int rootDegree, double accuracy)
        {
            return NewtonsMethod.NthRoot(number, rootDegree, accuracy);
        }

        /// <summary>
        /// Finds the NTH root.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="rootDegree">The root degree.</param>
        /// <returns>Root Nth degrees of the number.</returns>
        public static double FindNthRoot(double number, int rootDegree)
        {
            return FindNthRoot(number, rootDegree, 0.00001);
        }
        #endregion

        #region FindGcd  

        /// <summary>
        /// Finds the GCD by Euclidean algorithm.
        /// </summary>
        /// <param name="val1">The val1.</param>
        /// <param name="val2">The val2.</param>
        /// <returns>Returns GCD of two numbers.</returns>
        public static long FindGcdByEuclid(long val1, long val2)
            => FindGcd(new EuclideanAlgorithm(), val1, val2);

        /// <summary>
        /// Finds the GCD by Euclidean algorithm.
        /// </summary>
        /// <param name="val1">The val1.</param>
        /// <param name="val2">The val2.</param>
        /// <param name="val3">The val3.</param>
        /// <returns>Returns GCD of three numbers.</returns>
        public static long FindGcdByEuclid(long val1, long val2, long val3)
            => FindGcd(new EuclideanAlgorithm(), val1, val2, val3);

        /// <summary>
        /// Finds the GCD by Euclidean algorithm.
        /// </summary>
        /// <param name="numbers">The numbers.</param>
        /// <returns>Returns GCD of several numbers.</returns>
        public static long FindGcdByEuclid(params long[] numbers)
            => FindGcd(new EuclideanAlgorithm(), numbers);

        /// <summary>
        /// Finds the GCD by Euclidean algorithm.
        /// </summary>
        /// <param name="algoritmTime">The algoritm time.</param>
        /// <param name="val1">The val1.</param>
        /// <param name="val2">The val2.</param>
        /// <returns>Returns GCD of two numbers.</returns>
        public static long FindGcdByEuclid(out double algoritmTime, long val1, long val2)
            => FindGcd(new EuclideanAlgorithm(), out algoritmTime, val1, val2);

        /// <summary>
        /// Finds the GCD by Euclidean algorithm.
        /// </summary>
        /// <param name="algoritmTime">The algoritm time.</param>
        /// <param name="val1">The val1.</param>
        /// <param name="val2">The val2.</param>
        /// <param name="val3">The val3.</param>
        /// <returns>Returns GCD of three numbers.</returns>
        public static long FindGcdByEuclid(out double algoritmTime, long val1, long val2, long val3)
            => FindGcd(new EuclideanAlgorithm(), out algoritmTime, val1, val2, val3);

        /// <summary>
        /// Finds the GCD by Euclidean algorithm.
        /// </summary>
        /// <param name="algoritmTime">The algoritm time.</param>
        /// <param name="numbers">The numbers.</param>
        /// <returns>Returns GCD of several numbers.</returns>
        public static long FindGcdByEuclid(out double algoritmTime, params long[] numbers)
            => FindGcd(new EuclideanAlgorithm(), out algoritmTime, numbers);

        /// <summary>
        /// Finds the GCD by Stein algorithm.
        /// </summary>
        /// <param name="val1">The val1.</param>
        /// <param name="val2">The val2.</param>
        /// <returns>Returns GCD of two numbers.</returns>
        public static long FindGcdByStein(long val1, long val2)
            => FindGcd(new SteinsAlgorithm(), val1, val2);

        /// <summary>
        /// Finds the GCD by Stein algorithm.
        /// </summary>
        /// <param name="val1">The val1.</param>
        /// <param name="val2">The val2.</param>
        /// <param name="val3">The val3.</param>
        /// <returns>Returns GCD of three numbers.</returns>
        public static long FindGcdByStein(long val1, long val2, long val3)
            => FindGcd(new SteinsAlgorithm(), val1, val2, val3);

        /// <summary>
        /// Finds the GCD by Stein algorithm.
        /// </summary>
        /// <param name="numbers">The numbers.</param>
        /// <returns>Returns GCD of several numbers.</returns>
        public static long FindGcdByStein(params long[] numbers)
            => FindGcd(new SteinsAlgorithm(), numbers);

        /// <summary>
        /// Finds the GCD by Stein algorithm.
        /// </summary>
        /// <param name="algoritmTime">The algoritm time.</param>
        /// <param name="val1">The val1.</param>
        /// <param name="val2">The val2.</param>
        /// <returns>Returns GCD of two numbers.</returns>
        public static long FindGcdByStein(out double algoritmTime, long val1, long val2)
            => FindGcd(new SteinsAlgorithm(), out algoritmTime, val1, val2);

        /// <summary>
        /// Finds the GCD by Stein algorithm.
        /// </summary>
        /// <param name="algoritmTime">The algoritm time.</param>
        /// <param name="val1">The val1.</param>
        /// <param name="val2">The val2.</param>
        /// <param name="val3">The val3.</param>
        /// <returns>Returns GCD of three numbers.</returns>
        public static long FindGcdByStein(out double algoritmTime, long val1, long val2, long val3)
            => FindGcd(new SteinsAlgorithm(), out algoritmTime, val1, val2, val3);

        /// <summary>
        /// Finds the GCD by Stein algorithm.
        /// </summary>
        /// <param name="algoritmTime">The algoritm time.</param>
        /// <param name="numbers">The numbers.</param>
        /// <returns>Returns GCD of several numbers.</returns>
        public static long FindGcdByStein(out double algoritmTime, params long[] numbers)
            => FindGcd(new SteinsAlgorithm(), out algoritmTime, numbers);


        private static long FindGcd(Algorithm algorithm, long val1, long val2)
            => algorithm.GCD(val1, val2);
                
        private static long FindGcd(Algorithm algorithm, long val1, long val2, long val3)
            => algorithm.GCD(val1, val2, val3);

        private static long FindGcd(Algorithm algorithm, params long[] numbers)
            => algorithm.GCD(numbers);        
                
        private static long FindGcd(Algorithm algorithm, out double algoritmTime, long val1, long val2)
        {
            Stopwatch watch = Stopwatch.StartNew();

            long result = algorithm.GCD(val1, val2);

            watch.Stop();
            algoritmTime = watch.Elapsed.TotalMilliseconds;

            return result;
        }

        private static long FindGcd(Algorithm algorithm, out double algoritmTime, long val1, long val2, long val3)
        {
            Stopwatch watch = Stopwatch.StartNew();

            long result = algorithm.GCD(val1, val2, val3);

            watch.Stop();
            algoritmTime = watch.Elapsed.TotalMilliseconds;

            return result;
        }

        private static long FindGcd(Algorithm algorithm, out double algoritmTime, params long[] numbers)
        {
            Stopwatch watch = Stopwatch.StartNew();

            long result = algorithm.GCD(numbers);

            watch.Stop();
            algoritmTime = watch.Elapsed.TotalMilliseconds;

            return result;
        }

        #endregion
    }
}
