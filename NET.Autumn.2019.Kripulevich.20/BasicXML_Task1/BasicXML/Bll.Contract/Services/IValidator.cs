namespace Bll.Contract.Services
{
    /// <summary>
    /// Uri string validator.
    /// </summary>
    public interface IValidator<T>
    {
        /// <summary>
        /// Returns true if uri is valid.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>
        ///   <c>true</c> if the uri string is valid; otherwise, <c>false</c>.
        /// </returns>
        bool IsValid(T source);
    }
}
