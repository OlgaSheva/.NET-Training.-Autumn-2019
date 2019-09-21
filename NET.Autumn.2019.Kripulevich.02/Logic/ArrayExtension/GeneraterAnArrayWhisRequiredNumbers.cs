using System.Collections.Generic;

namespace Logic
{
    /// <summary>
    /// Generater or a array with required numbers. 
    /// </summary>
    internal static class GeneraterOfArrayWithRequiredNumbers
    {
        /// <summary>
        /// Generates the array.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="digit">The digit.</param>
        /// <returns>Returns a new array only with required numbers.</returns>
        internal static int[] GenerateArray(int[] array, int digit)
        {
            var resultList = new List<int>();

            for (int i = 0; i < array.Length; i++)
            {
                if (FinderTheDigitInTheNumber.IsThereTheDigitInThisNumber(array[i], digit))
                {
                    resultList.Add(array[i]);
                }
            }

            return resultList.ToArray();
        }
    }
}
