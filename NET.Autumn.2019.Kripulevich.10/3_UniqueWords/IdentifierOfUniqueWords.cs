using System;
using System.Collections.Generic;

namespace _3_UniqueWords
{
    public static class IdentifierOfUniqueWords
    {
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
