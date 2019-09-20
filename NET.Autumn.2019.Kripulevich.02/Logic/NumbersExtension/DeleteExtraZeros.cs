using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    /// <summary>
    /// Deletes extra zeros from binary number.
    /// </summary>
    static class DeleteExtraZeros
    {
        /// <summary>
        /// Deletes extra zeros from binary number.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns>The Array without extra zeros.</returns>
        public static char[] Delete(ref char[] array)
        {
            int i = 0;
            for (; i < array.Length; i++)
            {
                if (array[i].Equals('1'))
                {
                    break;
                }
            }

            var newArray = new char[array.Length - i];
            int k = 0;
            for (int j = array.Length - newArray.Length; j < array.Length; j++)
            {
                newArray[k++] = array[j];
            }

            return newArray;
        }
    }
}
