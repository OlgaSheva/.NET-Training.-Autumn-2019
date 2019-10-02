using Extensions.Interfaces;
using System;
using System.Collections.Generic;

namespace Extensions
{        
    public static class ArrayExtension
    {
        private static int indexOfMaxItem = 0;

        public static int[] Filter(this int[] array, IPredicate predicate)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} can't be null.");
            }

            if (predicate == null)
            {
                throw new ArgumentNullException($"{nameof(predicate)} can't be null.");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException($"{nameof(array)} can't be empty.");
            }

            var result = GenerateArray(array, predicate);

            return result;
        }

        public static int Max(this int[] array)
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

        #region Private methods

        private static int FindIndexOfMaximumItem(int[] array)
        {
            return FindIndexOfMaximumItem(array, 0, array.Length - 1);
        }

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
