using System;

namespace ArrayEx
{
    /// <summary>
    /// Array extension.
    /// </summary>
    public static class ArrayExtension
    {
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
        /// <param name="i">The index of recurcy.</param>
        /// <returns>Maximum item.</returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty.</exception>
        public static int FindMaximumItem(int[] array, int i)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} can't be null.");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException($"{nameof(array)} can't be empty.");
            }

            if (i < array.Length)
            {
                return Math.Max(array[i], FindMaximumItem(array, ++i));
            }
            else
            {
                return array[0];
            }
        }
    }
}
