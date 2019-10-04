namespace Extensions.Interfaces
{
    /// <summary>
    /// Interface that tolds how to sort an array.
    /// </summary>
    /// <typeparam name="T">The type of object that is to be sortted.</typeparam>
    public interface ISorter<T>
    {
        T[] Sort(T[] array);
    }
}
