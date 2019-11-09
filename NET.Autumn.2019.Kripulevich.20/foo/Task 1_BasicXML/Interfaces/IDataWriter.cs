using System.Collections.Generic;

namespace Task_1_BasicXML.Interfaces
{
    /// <summary>
    /// URIAdress model to XML file writer interface.
    /// </summary>
    public interface IDataWriter<T>
    {
        /// <summary>
        /// Writes the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        void Write(IEnumerable<T> source);
    }
}
