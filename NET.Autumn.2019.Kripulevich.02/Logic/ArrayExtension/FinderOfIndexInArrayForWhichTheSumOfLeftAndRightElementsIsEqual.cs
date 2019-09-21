namespace Logic
{
    /// <summary>
    /// Finder of the index in the array for which the sums of left and right elements are equals.
    /// </summary>
    internal static class FinderOfIndexInArrayForWhichTheSumOfLeftAndRightElementsAreEquals
    {
        /// <summary>
        /// Finds the index.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns>Returns the index in the array for which the sums of left and right elements are equals.</returns>
        internal static int? FindIndex(int[] array)
        {
            int sumLeft;
            int sumRight;
            int? indexInArrayForWhichTheSumOfLeftAndRightElementsIsEqual = null;

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
                    indexInArrayForWhichTheSumOfLeftAndRightElementsIsEqual = j;
                    break;
                }
            }

            return indexInArrayForWhichTheSumOfLeftAndRightElementsIsEqual;
        }
    }
}
