namespace Logic
{
    /// <summary>
    /// Interface to alrorithms of calculation of the GCD of several numbers.
    /// </summary>
    public abstract class Algorithm
    {
        /// <summary>
        /// Calculate the GCD of several numbers.
        /// </summary>
        /// <param name="val1">The val1.</param>
        /// <param name="val2">The val2.</param>
        /// <returns>Returns GCD of several numbers.</returns>
        public abstract long GCD(long val1, long val2);

        /// <summary>
        /// Calculate the GCD of several numbers.
        /// </summary>
        /// <param name="val1">The val1.</param>
        /// <param name="val2">The val2.</param>
        /// <param name="val3">The val3.</param>
        /// <returns>Returns GCD of several numbers.</returns>
        public long GCD(long val1, long val2, long val3)
        {
            return GCD(GCD(val1, val2), val3);
        }

        /// <summary>
        /// Calculate the GCD of several numbers.
        /// </summary>
        /// <param name="numbers">The nambers.</param>
        /// <returns>Returns GCD of several numbers.</returns>
        public long GCD(params long[] numbers)
        {
            long gcd = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                gcd = GCD(numbers[i], gcd);
            }

            return gcd;
        }
    }
}
