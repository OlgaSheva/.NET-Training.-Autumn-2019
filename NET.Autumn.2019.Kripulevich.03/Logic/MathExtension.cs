namespace Logic
{
    /// <summary>
    /// Metod of calculation of the Nth root of a number.
    /// </summary>
    public static class MathExtension
    {
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
    }
}
