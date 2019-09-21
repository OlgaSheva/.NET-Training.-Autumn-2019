using System;

namespace LogicNETFramework
{
    /// <summary>
    /// Creater of a new binary array.
    /// </summary>
    static class NewArray
    {
        /// <summary>
        /// Creates the new binary array.
        /// </summary>
        /// <param name="binaryCharNumberSource">The binary character number source.</param>
        /// <param name="binaryCharNumberIn">The binary character number in.</param>
        /// <param name="i">The i bit.</param>
        /// <param name="j">The j bit.</param>
        /// <returns>Returns concatenation of two arrays.</returns>
        internal static char[] CreateNewBinaryArray(char[] binaryCharNumberSource, char[] binaryCharNumberIn, int i, int j)
        {
            Array.Reverse(binaryCharNumberSource);
            Array.Reverse(binaryCharNumberIn);

            var resultList = binaryCharNumberSource;
            for (int ind = 0; ind <= j; ind++)
            {
                if (ind >= i && ind <= j)
                {
                    resultList[ind] = binaryCharNumberIn[ind - i];
                }
            }

            Array.Reverse(resultList);
            resultList = DeleteExtraZeros.Delete(ref resultList);

            return resultList;
        }
    }
}
