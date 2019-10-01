using System;
using Algorithms.V1.GcdImplementations;
using Algorithms.V1.Interfaces;

namespace Algorithms.V1.StaticClasses
{
    /// <summary>
    /// Static class of call of calculation methods of GCD.
    /// </summary>
    public static class GCDAlgorithms
    {
        #region Euclidean Algorithms (API)

        /// <summary>
        /// Finds the GCD by euclidean.
        /// </summary>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <returns>Returns GCD of two numbers.</returns>
        public static int FindGcdByEuclidean(int first, int second)
                    => Gcd(first, second, new EuclideanAlgorithm());

        /// <summary>
        /// Finds the GCD by euclidean.
        /// </summary>
        /// <param name="milliseconds">The milliseconds.</param>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <returns>Returns GCD of two numbers.</returns>
        public static int FindGcdByEuclidean(out long milliseconds, int first, int second)
            => Gcd(first, second, out milliseconds, new EuclideanAlgorithm());

        /// <summary>
        /// Finds the GCD by euclidean.
        /// </summary>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <param name="third">The third.</param>
        /// <returns>Returns GCD of three numbers.</returns>
        public static int FindGcdByEuclidean(int first, int second, int third)
            => Gcd(first, second, third, new EuclideanAlgorithm());

        /// <summary>
        /// Finds the GCD by euclidean.
        /// </summary>
        /// <param name="milliseconds">The milliseconds.</param>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <param name="third">The third.</param>
        /// <returns>Returns GCD of three numbers.</returns>
        public static int FindGcdByEuclidean(out long milliseconds, int first, int second, int third)
            => Gcd(first, second, third, out milliseconds, new EuclideanAlgorithm());

        /// <summary>
        /// Finds the GCD by euclidean.
        /// </summary>
        /// <param name="numbers">The numbers.</param>
        /// <returns>Returns GCD of several numbers.</returns>
        public static int FindGcdByEuclidean(params int[] numbers)
            => Gcd(new EuclideanAlgorithm(), numbers);

        /// <summary>
        /// Finds the GCD by euclidean.
        /// </summary>
        /// <param name="milliseconds">The milliseconds.</param>
        /// <param name="numbers">The numbers.</param>
        /// <returns>Returns GCD of several numbers.</returns>
        public static int FindGcdByEuclidean(out long milliseconds, params int[] numbers)
            => Gcd(new EuclideanAlgorithm(), out milliseconds, numbers);

        #endregion

        #region Steins Algorithms (API)

        public static int SteinsAlgorithm(int first, int second)
                    => Gcd(first, second, new SteinsAlgorithm());

        public static int SteinsAlgorithm(out long milliseconds, int first, int second)
            => Gcd(first, second, out milliseconds, new SteinsAlgorithm());

        public static int SteinsAlgorithm(int first, int second, int third)
            => Gcd(first, second, third, new SteinsAlgorithm());

        public static int SteinsAlgorithm(out long milliseconds, int first, int second, int third)
            => Gcd(first, second, third, out milliseconds, new SteinsAlgorithm());

        public static int SteinsAlgorithm(params int[] numbers)
            => Gcd(new SteinsAlgorithm(), numbers);

        public static int SteinsAlgorithm(out long milliseconds, params int[] numbers)
            => Gcd(new SteinsAlgorithm(), out milliseconds, numbers);

        #endregion

        #region Helper methods

        private static int Gcd(int first, int second, Algorithm algorithm)
            => algorithm.Calculate(first,second);

        private static int Gcd(int first, int second, out long milliseconds, Algorithm algorithm)
            => algorithm.Calculate(first,second, out milliseconds);

        private static int Gcd(int first, int second, int third, Algorithm algorithm)
        {
            bool flag = false;
            if (first != 0 || second != 0 || third != 0)
            {
                flag = true;
            }

            if (flag)
            {
                return algorithm.Calculate(algorithm.Calculate(first, second), third);
            }
            else
            {
                throw new ArgumentException($"All elements can't be zero.");
            }
        }

        private static int Gcd(int first, int second, int third, out long milliseconds, Algorithm algorithm)
            => algorithm.Calculate(algorithm.Calculate(first, second), third, out milliseconds);

        private static int Gcd(Algorithm algorithm, params int[] numbers)
        {
            bool flag = false;
            foreach (var item in numbers)
            {
                if (item != 0)
                {
                    flag = true;
                    break;
                }
            }

            if (flag)
            {
                int gcd = 0;

                for (int i = 0; i < numbers.Length; i++)
                {
                    gcd = algorithm.Calculate(numbers[i], gcd);
                }

                return gcd;
            }
            else
            {
                throw new ArgumentException($"All elements of {nameof(numbers)} can't be zero.");
            }
        }

        private static int Gcd(Algorithm algorithm, out long milliseconds, params int[] numbers)
            => Gcd(algorithm, out milliseconds, numbers);
        
        #endregion

    }
}