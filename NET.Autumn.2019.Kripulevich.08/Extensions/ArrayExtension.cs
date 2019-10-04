﻿using Extensions.Interfaces;
using System;
using System.Collections.Generic;

namespace Extensions
{     
    /// <summary>
    /// Class with array extinsion methods.
    /// </summary>
    public static class ArrayExtension
    {
        private static int indexOfMaxItem = 0;

        /// <summary>
        /// Ordering the array of strings according to same rule.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="comparisonRule">The </param>
        /// <returns>Ordering array.</returns>
        public static T[] OrderAccordingTo<T>(this T[] array, ISorter<T> comparisonRule)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} can't be null.");
            }

            if (comparisonRule == null)
            {
                throw new ArgumentNullException($"{nameof(comparisonRule)} can't be null.");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException($"{nameof(array)} can't be empty.");
            }

            T[] result = comparisonRule.Sort(array);

            return result;
        }

        /// <summary>
        /// Converts elements in the array to string representation.
        /// </summary>
        /// <typeparam name="TSource">The TSourse.</typeparam>
        /// <typeparam name="TResult">The TResult.</typeparam>
        /// <param name="array">The array.</param>
        /// <param name="convertor">The convertor.</param>
        /// <returns>The array with string items.</returns>
        public static TResult[] Transform<TSource, TResult>(this TSource[] array, IConvertor<TSource, TResult> convertor)
        {
            TResult[] result = new TResult[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                result[i] = convertor.Convert(array[i]);
            }

            return result;
        }

        /// <summary>
        /// Filter array by the same type.
        /// </summary>
        /// <typeparam name="T">The T.</typeparam>
        /// <param name="array">The array.</param>
        /// <returns>Filtered array.</returns>
        public static T[] FilterByType<T>(this object[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"An {nameof(array)} can't be null.");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException($"An {nameof(array)} must contain at least one element.");
            }

            var result = new List<T>();
            foreach (var item in array)
            {
                if (item is T)
                {
                    result.Add((T)item);
                    //yield return (T)item;
                }
            }
            return result.ToArray();
        }

        /// <summary>
        /// Filter array by pridicate.
        /// </summary>
        /// <typeparam name="T">The T.</typeparam>
        /// <param name="array">The array.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns>Filtered array.</returns>
        public static T[] Filter<T>(this T[] array, IPredicate<T> predicate)
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

        /// <summary>
        /// Finds the largest element in the array.
        /// </summary>
        /// <typeparam name="T">The T where T : IComparable<T>.</typeparam>
        /// <param name="array">The array.</param>
        /// <returns>The largest element.</returns>
        public static T Max<T>(this T[] array) where T : IComparable<T>
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

        private static int FindIndexOfMaximumItem<T>(T[] array) where T : IComparable<T>
        {
            return FindIndexOfMaximumItem<T>(array, 0, array.Length - 1);
        }

        private static int FindIndexOfMaximumItem<T>(T[] array, int lowIndex, int highIndex) where T: IComparable<T>
        {
            if (lowIndex < highIndex)
            {
                int middleIndex = (lowIndex + highIndex) / 2;
                FindIndexOfMaximumItem(array, lowIndex, middleIndex);
                FindIndexOfMaximumItem(array, middleIndex + 1, highIndex);
            }

            if (array[lowIndex].CompareTo(array[indexOfMaxItem]) > 0 
                || array[highIndex].CompareTo(array[indexOfMaxItem]) > 0)
            {
                indexOfMaxItem = (array[lowIndex].CompareTo(array[highIndex]) > 0) ? lowIndex : highIndex;
            }

            return indexOfMaxItem;
        }

        private static T[] GenerateArray<T>(T[] array, IPredicate<T> predicate)
        {
            var resultList = new List<T>();

            foreach (var item in array)
            { 
                if (predicate.IsMatch(item))
                {
                    resultList.Add(item);
                }
            }

            return resultList.ToArray();
        }

        #endregion
    }
}