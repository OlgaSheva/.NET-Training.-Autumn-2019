using System.Collections.Generic;

namespace Logic
{
    /// <summary>
    /// Generater new array. 
    /// </summary>
    internal static class GenerateNewArray
    {
        /// <summary>
        /// Generates the array.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="digit">The digit.</param>
        /// <returns>Returns a new array only with required numbers.</returns>
        internal static int[] GenerateArray(int[] array, int digit, IPredicate condition)
        {
            var resultList = new List<int>();

            for (int i = 0; i < array.Length; i++)
            {
                if (condition.IsMatch(array[i]))
                {
                    resultList.Add(array[i]);
                }
            }

            return resultList.ToArray();
        }

        internal static int[] GenerateArray(int[] array, IPredicate condition)
        {
            var resultList = new List<int>();

            for (int i = 0; i < array.Length; i++)
            {
                if (condition.IsMatch(array[i]))
                {
                    resultList.Add(array[i]);
                }
            }

            return resultList.ToArray();
        }
    }
}
