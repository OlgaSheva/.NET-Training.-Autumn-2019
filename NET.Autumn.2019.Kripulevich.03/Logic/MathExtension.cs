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
        /// <param name="method">The method.</param>
        /// <returns>Root Nth degrees of the number.</returns>
        public static double FindNthRoot(double number, int rootDegree, double accuracy, IMethod method)
        {
            return method.NthRoot(number, rootDegree, accuracy);
        }

        /// <summary>
        /// Finds the NTH root.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="rootDegree">The root degree.</param>
        /// <param name="accuracy">The accurancy.</param>
        /// <returns>Root Nth degrees of the number.</returns>
        public static double FindNthRoot(double number, int rootDegree, double accuracy)
        {
            return FindNthRoot(number, rootDegree, accuracy, new NewtonsMethod());
        }

        /// <summary>
        /// Finds the NTH root.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="rootDegree">The root degree.</param>
        /// <returns>Root Nth degrees of the number.</returns>
        public static double FindNthRoot(double number, int rootDegree)
        {
            return FindNthRoot(number, rootDegree, 0.00001, new NewtonsMethod());
        }
        #endregion

        #region FindGcd       
        /// <summary>
        /// Finds the GCD.
        /// </summary>
        /// <param name="val1">The val1.</param>
        /// <param name="val2">The val2.</param>
        /// <param name="algorithm">The algorithm.</param>
        /// <returns>Returns GCD of several numbers.</returns>
        public static long FindGcd(Algorithm algorithm, long val1, long val2)
        {
            return algorithm.GCD(val1, val2);
        }

        /// <summary>
        /// Finds the GCD.
        /// </summary>
        /// <param name="val1">The val1.</param>
        /// <param name="val2">The val2.</param>
        /// <param name="val3">The val3.</param>
        /// <param name="algorithm">The algorithm.</param>
        /// <returns>Returns GCD of several numbers.</returns>
        public static long FindGcd(Algorithm algorithm, long val1, long val2, long val3)
        {
            return algorithm.GCD(val1, val2, val3);
        }

        /// <summary>
        /// Finds the GCD.
        /// </summary>
        /// <param name="algorithm">The algorithm.</param>
        /// <param name="numbers">The numbers.</param>
        /// <returns>Returns GCD of several numbers.</returns>
        public static long FindGcd(Algorithm algorithm, params long[] numbers)
        {
            return algorithm.GCD(numbers);
        }        
        #endregion
    }
}
