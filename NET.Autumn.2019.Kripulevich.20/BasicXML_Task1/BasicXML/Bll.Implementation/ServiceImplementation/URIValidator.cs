using System;
using Bll.Contract.Services;

namespace Bll.Implementation.ServiceImplementation
{
    /// <summary>
    /// Uri string validator.
    /// </summary>
    /// <seealso cref="Task_1_BasicXML.Interfaces.IURIValidator" />
    public class URIValidator : IValidator<string>
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
