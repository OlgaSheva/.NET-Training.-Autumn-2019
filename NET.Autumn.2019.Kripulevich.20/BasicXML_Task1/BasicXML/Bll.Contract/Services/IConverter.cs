namespace Bll.Contract.Services
{
    /// <summary>
    /// Converter interface.
    /// </summary>
    /// <typeparam name="TSource">The type of the source.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IConverter<TSource, TResult>
    {
        /// <summary>
        /// Converts the specified t source.
        /// </summary>
        /// <param name="TSource">The t source.</param>
        /// <returns>The t result.</returns>
        TResult Convert(TSource source);
    }
}
