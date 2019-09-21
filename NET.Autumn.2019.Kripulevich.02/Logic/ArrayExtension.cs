﻿using System;

namespace Logic
{
    /// <summary>
    /// Array extension.
    /// </summary>
    public static class ArrayExtension
    {
        #region FindMaximumItem
        /// <summary>
        /// Finds the maximum item.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns>Maximum item.</returns>
        public static int FindMaximumItem(int[] array) => FindMaximumItem(array, 0);

        /// <summary>
        /// Finds the maximum item.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="recursiIndex">The index of recursion.</param>
        /// <returns>Maximum item.</returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty.</exception>
        public static int FindMaximumItem(int[] array, int recursiIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} can't be null.");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException($"{nameof(array)} can't be empty.");
            }

            if (recursiIndex < array.Length)
            {
                return Math.Max(array[recursiIndex], FindMaximumItem(array, ++recursiIndex));
            }
            else
            {
                return array[0];
            }
        }
        #endregion

        #region FindBalanceIndex        
        /// <summary>
        /// Finds the index of the balance.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns>
        /// Returns the index in the array for which the sums of left and right elements are equals
        /// or NULL if it doesn't exist.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">Throws if array is null.</exception>
        /// <exception cref="System.ArgumentException">Throws if array is empty.</exception>
        public static int? FindBalanceIndex(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} can't be null.");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException($"{nameof(array)} can't be empty.");
            }

            int? indexInArrayForWhichTheSumOfLeftAndRightElementsIsEqual =
                FinderOfIndexInArrayForWhichTheSumsOfLeftAndRightElementsAreEquals.FindIndex(array);

            return indexInArrayForWhichTheSumOfLeftAndRightElementsIsEqual;
        }
        #endregion

        #region FilterArrayByKey
        /// <summary>
        /// Filters the array by key.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="digit">The digit.</param>
        /// <returns>New array with elements that include the digit.</returns>
        /// <exception cref="System.ArgumentNullException">Throw if array is null.</exception>
        /// <exception cref="System.ArgumentException">Throw if array is empty.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Throw if digit is less than 0.</exception>
        public static int[] FilterArrayByKey(int[] array, int digit)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} can't be null.");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException($"{nameof(array)} can't be empty.");
            }

            if (digit < 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(digit)} can't be less than zero.");
            }

            var result = GeneraterOfArrayWithRequiredNumbers.GenerateArray(array, digit);

            return result;
        }
        #endregion
    }
}
