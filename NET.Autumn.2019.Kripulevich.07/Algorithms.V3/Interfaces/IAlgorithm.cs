namespace Algorithms.V3.Interfaces
{
    /// <summary>
    /// Algorithm interface.
    /// </summary>
    internal interface IAlgorithm
    {
        /// <summary>
        /// GCD calculation method.
        /// </summary>
        /// <param name="first">The first number.</param>
        /// <param name="second">The second number.</param>
        /// <returns>Returns the result of calculation.</returns>
        int Calculate(int first, int second);
    }
}