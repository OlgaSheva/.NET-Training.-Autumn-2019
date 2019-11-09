using System;
using Task_1_BasicXML.Interfaces;

namespace Task_1_BasicXML
{
    /// <summary>
    /// Uri string validator.
    /// </summary>
    /// <seealso cref="Task_1_BasicXML.Interfaces.IURIValidator" />
    public class URIValidator : IURIValidator<string>
    {
        /// <summary>
        /// Returns true if uri string is valid.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>
        /// <c>true</c> if the uri string is valid; otherwise, <c>false</c>.
        /// </returns>
        public bool IsValid(string source)
        {
            return Uri.IsWellFormedUriString(source, UriKind.Absolute);
        }
    }
}
