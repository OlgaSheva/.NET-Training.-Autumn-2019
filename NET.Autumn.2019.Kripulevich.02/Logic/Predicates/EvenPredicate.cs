namespace Logic
{
    /// <summary>
    /// Predicate of even.
    /// </summary>
    /// <seealso cref="Logic.IPredicate" />
    public class EvenPredicate : IPredicate
    {
        /// <summary>
        /// Determines whether the specified number is even.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>
        ///   <c>true</c> if the specified number is even; otherwise, <c>false</c>.
        /// </returns>
        public bool IsMatch(int number)
        {
            return number % 2 == 0;
        }
    }
}
