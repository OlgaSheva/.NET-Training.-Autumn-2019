namespace Task_1_BasicXML.Interfaces
{
    /// <summary>
    /// Uri string parser.
    /// </summary>
    public interface IUriParser<TSource, TResult>
    {
        /// <summary>
        /// Parses the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>TResult.</returns>
        TResult Parse(TSource source);

        /// <summary>
        /// Tries the parse.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="result">The result.</param>
        /// <returns>
        ///     <c>true</c> if the TSource string can parsed; otherwise, <c>false</c>.
        /// </returns>
        bool TryParse(TSource source, out TResult result);
    }
}
