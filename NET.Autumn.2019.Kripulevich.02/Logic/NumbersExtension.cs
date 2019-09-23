using System;

namespace Logic
{
    /// <summary>
    /// Numbers Extension.
    /// </summary>
    public static class NumbersExtension
    {
        #region InsertNumberIntoAnother
        /// <summary>
        /// Algorithm for inserting the first (j - i + 1) bits of the second number into 
        /// the first so that the bits of the second number take positions from bit i to bit j.
        /// </summary>
        /// <param name="numberSource">The number source.</param>
        /// <param name="numberIn">The number in.</param>
        /// <param name="i">The i bit.</param>
        /// <param name="j">The j bit.</param>
        /// <returns>Returns combined number.</returns>
        /// <exception cref="ArgumentException">
        /// Throw if numberSource or numberIn don't included in the possible range of values
        /// or if index j lager than index i.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Throw if index i or j don't included in the possible range of values (from 0 to 31).
        /// </exception>
        public static int InsertNumberIntoAnother(int numberSource, int numberIn, int i, int j)
        {
            if  ((numberSource > int.MaxValue || numberIn > int.MaxValue) ||
                (numberSource < int.MinValue || numberIn < int.MinValue))
            {
                throw new ArgumentException(
                    $"{nameof(numberIn)} and {nameof(numberSource)} must be a must be at range from {int.MinValue} to {int.MinValue}.");
            }

            if (i > j)
            {
                throw new ArgumentException($"{nameof(i)} can't be larger than {nameof(j)}.");
            }

            if (i < 0 || j < 0 || i >= 32 || j >= 32)
            {
                throw new ArgumentOutOfRangeException(
                    $"{nameof(i)} and {nameof(j)} can't be less than 0 or larger than 31.");
            }

            uint bitMaskNumberSource = ~CreateBitMask(i, j - i + 1);
            uint bitMaskNumberIn = CreateBitMask(0, j - i + 1);

            var numberSourceAfterMask = numberSource & bitMaskNumberSource;
            var numberInAfterMask = numberIn & bitMaskNumberIn;
            numberInAfterMask <<= i;

            var result = numberInAfterMask ^ numberSourceAfterMask;

            return (int)result;
        }
        #endregion

        #region FindPreviousLessThan        
        /// <summary>
        /// Finds the previous number less than given number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>Returns the previous number less than given number.</returns>
        /// <exception cref="ArgumentException">Throw if number is less than zero.</exception>
        public static int? FindPreviousLessThan(int number)
        {
            if (number <= 0)
            {
                throw new ArgumentException($"{nameof(number)} can't be less than zero.");
            }

            if (number < 10)
            {
                return null;
            }

            int length = number.ToString().Length;
            var digits = IntToArray(number);

            int index = 0;
            // Start from the right most digit and find the first digit that is bigger than the digit next to it.
            for (index = length - 1; index > 0; index--)
                if (digits[index] < digits[index - 1])
                    break;

            // If no such digit is found then there cannot be a greater number with same set of digits.
            if (index == 0)
            {
                return null;
            }
            else
            {
                // Find the index of the largest digit from the right of the digits[index].
                int indexOfLargestDigitFromRightSize = index;
                for (int j = index + 1; j < digits.Length; j++)
                {
                    if (digits[j] > digits[indexOfLargestDigitFromRightSize])
                    {
                        indexOfLargestDigitFromRightSize = j;
                    }
                }

                Swap(ref digits[index - 1], ref digits[indexOfLargestDigitFromRightSize]);

                // Sort the digits after (index) in order.
                for (int k = index; k < digits.Length; k++)
                {
                    for (int j = index; j < digits.Length; j++)
                    {
                        if (digits[j] < digits[k])
                        {
                            Swap(ref digits[k], ref digits[j]);
                        }
                    }
                }

                int newNumber = ArrayToInt(digits);

                return newNumber;
            }
        }        
        #endregion

        #region Private methods
        /// <summary>
        /// Creates the bit mask.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="length">The length.</param>
        /// <returns>Returns the bit mask.</returns>
        private static uint CreateBitMask(int start, int length)
        {
            uint mask = 0xffffffff;
            mask >>= 32 - length;
            mask <<= start;
            return mask;
        }

        /// <summary>
        /// Generate digit array from the number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>Returns int[].</returns>
        private static int[] IntToArray(int number)
        {
            int length = number.ToString().Length;
            int[] digits = new int[length];

            for (int j = length - 1; j >= 0; j--)
            {
                digits[j] = number % 10;
                number /= 10;
            }

            return digits;
        }

        /// <summary>
        /// Generate a number from the digit array.
        /// </summary>
        /// <param name="digits">The digit array.</param>
        /// <returns>The number.</returns>
        private static int ArrayToInt(int[] digits)
        {
            int number = digits[0];

            for (int j = 1; j < digits.Length; j++)
            {
                number *= 10;
                number += digits[j];
            }

            return number;
        }

        /// <summary>
        /// Function to swap two digit.
        /// </summary>
        /// <param name="a">The first parameter.</param>
        /// <param name="b">The second parameter.</param>
        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        #endregion
    }
}
