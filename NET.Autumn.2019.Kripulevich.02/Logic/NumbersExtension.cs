using System;

namespace Logic
{
    /// <summary>
    /// Numbers Extension.
    /// </summary>
    public static class NumbersExtension
    {
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
            if  ((numberSource > int.MaxValue || numberIn > int.MaxValue)
                || (numberSource < int.MinValue || numberIn < int.MinValue))
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

            char[] binaryCharNumberSource = CreateBinaryArrayFromTheNumber.CreateArray(numberSource);
            char[] binaryCharNumberIn = CreateBinaryArrayFromTheNumber.CreateArray(numberIn);

            var resultList = NewArray.CreateNewBinaryArray(binaryCharNumberSource, binaryCharNumberIn, i, j);
            
            int result = Convert.ToInt32(new string(resultList), 2);

            return result;
        }
    }
}
