using Extensions.Interfaces;

namespace ExtensionsTests.Predicates
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
            if (number < 11)
            {
                return false;
            }
            else
            {
                string n = number.ToString();

                for (int i = 0, j = n.Length - 1; i < j; i++, j--)
                {
                    if (n[i] != n[j])
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
}
