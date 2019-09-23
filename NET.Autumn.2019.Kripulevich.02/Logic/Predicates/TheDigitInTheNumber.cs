using System;

namespace Logic
{
    /// <summary>
    /// Predicate of the digit in the number.
    /// </summary>
    /// <exception cref="System.ArgumentOutOfRangeException">Throw if key is less than 0.</exception>
    public class TheDigitInTheNumberPredicate : IPredicate
    {
        private int key;

        public int Key {
            get
            {
                return key;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(value)} can't be less than zero.");
                }

                key = value;
            }
        }

        public TheDigitInTheNumberPredicate(int key)
        {
            Key = key;
        }

        /// <summary>
        /// Determines whether the specified number contains the given digit.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>
        ///   <c>true</c> if the specified number contains the given digit; otherwise, <c>false</c>.
        /// </returns>
        public bool IsMatch(int number)
        {
            return DoesThisNumberMeetTheCondition(number, Key);
        }

        /// <summary>
        /// Determines whether [is there the digit in this number] [the specified number].
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="key">The digit.</param>
        /// <returns>
        ///   <c>true</c> if [is there the digit in this number] [the specified number];
        ///   otherwise, <c>false</c>.
        /// </returns>
        private bool DoesThisNumberMeetTheCondition(int number, int key)
        {
            int absNumber = (number > 0) ? number : - number;

            if (absNumber == key)
            {
                return true;
            }

            while (absNumber != 0)
            {
                if (absNumber % 10 == key)
                {
                    return true;
                }

                absNumber /= 10;
            }

            return false;
        }        
    }
}
