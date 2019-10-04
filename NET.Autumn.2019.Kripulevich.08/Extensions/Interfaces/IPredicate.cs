namespace Extensions.Interfaces
{
    /// <summary>
    /// The interface of predicate.
    /// </summary>
    /// <typeparam name="T">The type of object.</typeparam>
    public interface IPredicate<T>
    {
        bool IsMatch(T value);
    }
}
