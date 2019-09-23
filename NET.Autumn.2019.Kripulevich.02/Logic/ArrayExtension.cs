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
                return Max(array[recursiIndex], FindMaximumItem(array, ++recursiIndex));
            }
            else
            {
                return array[0];
            }
        }

        static int Max(int a, int b)
        {
            return a > b ? a : b;
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
        /// Finds the index in the array for which the sums of left and right elements are equals.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns>
        /// Returns the index in the array for which the sums of left and right elements are equals.
        /// </returns>
        private static int? FindIndex(int[] array)
        {
            int sumLeft;
            int sumRight;
            int? indexInArrayForWhichTheSumsOfLeftAndRightElementsAreEquals = null;

            for (int j = 1; j < array.Length - 1; j++)
            {
                sumLeft = 0;
                sumRight = 0;

                for (int i = 0; i < array.Length; i++)
                {
                    if (i < j)
                    {
                        sumLeft += array[i];
                    }
                    else if (i > j)
                    {
                        sumRight += array[i];
                    }
                }

                if (sumLeft - sumRight == 0)
                {
                    indexInArrayForWhichTheSumsOfLeftAndRightElementsAreEquals = j;
                    break;
                }
            }

            return indexInArrayForWhichTheSumsOfLeftAndRightElementsAreEquals;
        }

        /// <summary>
        /// Generates the array.
        /// </summary>
        /// <param name="array">The array.</param>
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
