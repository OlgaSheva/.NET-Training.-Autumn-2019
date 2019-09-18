namespace Algorithms.Tests.Comparers
{
    /// <summary>
    /// Countings the number of characters in the string.
    /// </summary>
    public static class CountingTheNumberOfCharactersInTheString
    {
        /// <summary>
        /// Countings the number of characters in the string.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="symbol">The symbol.</param>
        /// <returns>Count of the symbol in the number.</returns>
        public static int Counting(string number, char symbol)
        {
            int count = 0;
            foreach (char ch in number)
            {
                if (ch == symbol)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
