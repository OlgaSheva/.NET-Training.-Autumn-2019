using System;

namespace LogicNETFramework
{
    /// <summary>
    /// Creater binary char array.
    /// </summary>
    static class CreateBinaryArrayFromTheNumber
    {
        /// <summary>
        /// Creates the array of '0' and '1'.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>Returns char binary array.</returns>
        internal static char[] CreateArray(int number)
        {
            string binaryNumber = Convert.ToString(number, 2);
            char[] binaryCharNumber = binaryNumber.ToCharArray();
            Array.Reverse(binaryCharNumber);

            var charList = new char[32];
            for (int i = charList.Length - 1; i >= charList.Length - binaryCharNumber.Length; i--)
            {
                charList[i] = binaryCharNumber[31 - i];
            }

            return charList;
        }
    }
}
