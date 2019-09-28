using System.Collections.Generic;

namespace TransformerLogic.Interfaces
{
    /// <summary>
    /// Dictionary factory interface.
    /// </summary>
    public interface IDictionaryFactory
    {
        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>The dictionary.</returns>
        IDictionary<char, string> Create();
    }
}
