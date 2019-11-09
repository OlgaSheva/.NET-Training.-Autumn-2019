using System;
using Task_1_BasicXML.Interfaces;

namespace Task_1_BasicXML
{
    /// <summary>
    /// Uri string parser.
    /// </summary>
    /// <seealso cref="Task_1_BasicXML.Interfaces.IUriParser" />
    public class URIParser : IUriParser<string, Uri>
    {
        /// <summary>
        /// Parses the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>
        /// Uri.
        /// </returns>
        public Uri Parse(string source)
        {
            return new Uri(source);
        }

        /// <summary>
        /// Tries the parse.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="result">The result.</param>
        /// <returns>
        ///     <c>true</c> if the uri string can parsed; otherwise, <c>false</c>.
        /// </returns>
        public bool TryParse(string source, out Uri result)
        {
            return Uri.TryCreate(source, UriKind.Absolute, out result);
        }
    }
}
