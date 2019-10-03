using Extensions.Interfaces;

namespace ExtensionsTests.Predicates
{
    /// <summary>
    /// Predicate of even.
    /// </summary>
    /// <seealso cref="Logic.IPredicate" />
    public class EvenPredicate<T> : IPredicate<T>
    {
        /// <summary>
        /// Determines whether the specified number is even.
        /// </summary>
        /// <param name="value">The number.</param>
        /// <returns>
        ///   <c>true</c> if the specified number is even; otherwise, <c>false</c>.
        /// </returns>
        public bool IsMatch(T value)
        {
            if (value is int)
            {
                return (dynamic)value % 2 == 0;
            }

            return false;
        }
    }
}
