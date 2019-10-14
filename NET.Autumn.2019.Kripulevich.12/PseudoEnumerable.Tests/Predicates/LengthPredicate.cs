using PseudoEnumerable.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoEnumerable.Tests
{
    /// <summary>
    /// Predicate of even.
    /// </summary>
    /// <seealso cref="Logic.IPredicate" />
    public class LengthPredicate<T> : IPredicate<T>
    {
        /// <summary>
        /// Determines whether the specified number is even.
        /// </summary>
        /// <param name="value">The number.</param>
        /// <returns>
        ///   <c>true</c> if the specified number is even; otherwise, <c>false</c>.
        /// </returns>
        public bool IsMatching(T value)
        {
            if (value is string)
            {
                return (value as string).Length > 5;
            }

            return false;
        }
    }
}
