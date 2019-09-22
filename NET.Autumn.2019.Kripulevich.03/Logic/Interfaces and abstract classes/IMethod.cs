namespace Logic
{
    /// <summary>
    /// Interface to method of calculation of the Nth root of a number.
    /// </summary>
    public interface IMethod
    {
        /// <summary>
        /// Calculation of the root of the Nth degree of a number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="rootDegree">The root degree.</param>
        /// <param name="accuracy">The precision.</param>
        /// <returns>Root Nth degrees of the number.</returns>
        double NthRoot(double number, int rootDegree, double accuracy);
    }
}
