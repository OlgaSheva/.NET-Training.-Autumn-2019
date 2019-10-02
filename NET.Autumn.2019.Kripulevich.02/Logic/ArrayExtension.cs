using System;
using System.Collections.Generic;

namespace Logic
{
    /// <summary>
    /// Array extension.
    /// </summary>
    public static class ArrayExtension
    {
        #region FindMaximumItem
        /// <summary>
        /// Index of the max item in the array.
        /// </summary>
        private static int indexOfMaxItem = 0;

        /// <summary>
        /// Finds the maximum item.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns>Maximum item.</returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty.</exception>
        public static int FindMaximumItem(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} can't be null.");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException($"{nameof(array)} can't be empty.");
            }

            return array[FindIndexOfMaximumItem(array)];
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

            if (array.Length == 2)
            {
                return null;
            }

            int? indexInArrayForWhichTheSumOfLeftAndRightElementsIsEqual = FindIndex(array);

            return indexInArrayForWhichTheSumOfLeftAndRightElementsIsEqual;
        }
        #endregion

        #region FilterArray
        /// <summary>
        /// Filters the array by key.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns>New array with elements that include the digit.</returns>
        /// <exception cref="System.ArgumentNullException">Throw if array is null.</exception>
        /// <exception cref="System.ArgumentException">Throw if array is empty.</exception>
        public static int[] FilterArray(this int[] array, IPredicate predicate)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} can't be null.");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException($"{nameof(array)} can't be empty.");
            }

            var result = GenerateArray(array, predicate);

            return result;
        }
        #endregion

        #region Private methods 
        
        /// <summary>
        /// Find index of maximum item in the array.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="lowIndex">The low index.</param>
        /// <param name="highIndex">The high index.</param>
        /// <returns>Return an index of maximum item in the array.</returns>
        private static int FindIndexOfMaximumItem(int[] array, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                int middleIndex = (lowIndex + highIndex) / 2;
                FindIndexOfMaximumItem(array, lowIndex, middleIndex);
                FindIndexOfMaximumItem(array, middleIndex + 1, highIndex);
            }

            if (array[lowIndex] > array[indexOfMaxItem] || array[highIndex] > array[indexOfMaxItem])
            {
                indexOfMaxItem = (array[lowIndex] > array[highIndex]) ? lowIndex : highIndex;
            }

            return indexOfMaxItem;
        }

        /// <summary>
        /// Find index of maximum item in the array.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns>Return an index of maximum item in the array.</returns>
        private static int FindIndexOfMaximumItem(int[] array)
        {
            return FindIndexOfMaximumItem(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Finds the index in the array for which the sums of left and right elements are equals.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns>
        /// Returns the index in the array for which the sums of left and right elements are equals.
        /// </returns>
        private static int? FindIndex(int[] array)
        {
            int sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            int sumLeft = array[0];
            int sumRight = sum - array[0] - array[1];

            for (int i = 1; i < array.Length - 1; i++)
            {
                if (sumLeft == sumRight)
                {
                    return i;
                }

                sumLeft += array[i];
                sumRight -= array[i + 1];
            }

            return null;
        }

        /// <summary>
        /// Generates the array.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns>Returns a new array only with required numbers.</returns>
        private static int[] GenerateArray(int[] array, IPredicate predicate)
        {
            var resultList = new List<int>();

            for (int i = 0; i < array.Length; i++)
            {
                if (predicate.IsMatch(array[i]))
                {
                    resultList.Add(array[i]);
                }
            }

            return resultList.ToArray();
        }
        #endregion
    }
}
