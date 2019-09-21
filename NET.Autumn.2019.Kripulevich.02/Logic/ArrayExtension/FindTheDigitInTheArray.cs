namespace Logic
{
    /// <summary>
    /// Finder the digit in the number.
    /// </summary>
    internal static class FinderTheDigitInTheNumber
    {
        /// <summary>
        /// Determines whether [is there the digit in this number] [the specified number].
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="digit">The digit.</param>
        /// <returns>
        ///   <c>true</c> if [is there the digit in this number] [the specified number];
        ///   otherwise, <c>false</c>.
        /// </returns>
        internal static bool IsThereTheDigitInThisNumber(int number, int digit)
        {
            int absNumber = (number > 0) ? number : - number;

            if (absNumber == digit)
            {
                return true;
            }

            while (absNumber != 0)
            {
                if (absNumber % 10 == digit)
                {
                    return true;
                }

                absNumber /= 10;
            }

            return false;
        }
    }
}
