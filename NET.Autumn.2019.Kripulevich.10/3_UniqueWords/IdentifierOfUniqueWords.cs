using System;
using System.Collections.Generic;

namespace _3_UniqueWords
{
    /// <summary>
    /// Identifier of unique words.
    /// </summary>
    public static class IdentifierOfUniqueWords
    {
        /// <summary>
        /// Finds the specified string.
        /// </summary>
        /// <param name="string">The string.</param>
        /// <param name="separators">The separators.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// The {nameof(@string)} can't be null.
        /// or
        /// The {nameof(separators)} can't be null.
        /// </exception>
        public static IEnumerable<string> Find(string @string, string separators)
        {
            if (@string == null)
            {
                throw new ArgumentNullException($"The {nameof(@string)} can't be null.");
            }

            if (separators == null)
            {
                throw new ArgumentNullException($"The {nameof(separators)} can't be null.");
            }

            char[] sep = separators.ToCharArray();
            var set = new HashSet<string>(@string.Split(sep, StringSplitOptions.RemoveEmptyEntries),
                StringComparer.CurrentCultureIgnoreCase);

            return set;
        }
    }
}
