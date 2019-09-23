namespace Logic
{
    /// <summary>
    /// Finder the digit in the number.
    /// </summary>
    public class TheDigitInTheNumber : IPredicate
    {
        int Key { get; }

        public TheDigitInTheNumber(int key)
        {
            Key = key;
        }

        /// <summary>
        /// Determines whether [is there the digit in this number] [the specified number].
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="digit">The digit.</param>
        /// <returns>
        ///   <c>true</c> if [is there the digit in this number] [the specified number];
        ///   otherwise, <c>false</c>.
        /// </returns>
        public bool DoesThisNumberMeetTheCondition(int number, int digit)
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

        public bool IsMatch(int number)
        {
            return DoesThisNumberMeetTheCondition(number, Key);
        }
    }
}
