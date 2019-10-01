namespace Algorithms.V2.Interfaces
{
    /// <summary>
    /// Algorithm interface.
    /// </summary>
    public interface IAlgorithm
    {
        /// <summary>
        /// Abstract GCD calculation method.
        /// </summary>
        /// <param name="first">The first number.</param>
        /// <param name="second">The second number.</param>
        /// <returns>Returns the result of calculation.</returns>
        int Calculate(int first, int second);
    }
}