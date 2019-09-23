namespace Logic
{
    /// <summary>
    /// Predicate of polindrom.
    /// </summary>
    /// <seealso cref="Logic.IPredicate" />
    public class PalindromePredicate : IPredicate
    {
        /// <summary>
        /// Determines whether the specified number is polindrom.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>
        ///   <c>true</c> if the specified number is polindrom; otherwise, <c>false</c>.
        /// </returns>
        public bool IsMatch(int number)
        {
            var digits = IntToArray(number);
            return DoesThisArrayAPalindrome(digits, 0, digits.Length - 1);
        }

        /// <summary>
        /// Doeses the this array a palindrome.
        /// </summary>
        /// <param name="digits">The digits.</param>
        /// <param name="first">The first.</param>
        /// <param name="last">The last.</param>
        /// <returns>
        ///   <c>true</c> if the specified array is polindrom; otherwise, <c>false</c>.
        /// </returns>
        public bool DoesThisArrayAPalindrome(int[] digits, int first, int last)
        {
            if (first < digits.Length / 2)
            {
                if (digits[first] == digits[last])
                {
                    DoesThisArrayAPalindrome(digits, ++first, --last);
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Generate digit array from the number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>Returns int[].</returns>
        private static int[] IntToArray(int number)
        {
            int length = number.ToString().Length;
            int[] digits = new int[length];

            for (int j = length - 1; j >= 0; j--)
            {
                digits[j] = number % 10;
                number /= 10;
            }

            return digits;
        }
    }
}
