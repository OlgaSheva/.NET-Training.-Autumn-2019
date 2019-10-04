namespace Extensions.Interfaces
{
    /// <summary>
    /// Interface that tolds how to convert one type to another.
    /// </summary>
    /// <typeparam name="TSource">The type of the source.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IConvertor<TSource, TResult>
    {
        TResult Convert(TSource source);
    }
}