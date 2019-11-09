using System.Collections.Generic;
using System.IO;
using Task_1_BasicXML.Interfaces;

namespace Task_1_BasicXML.StringUriLoaders
{
    /// <summary>
    /// Lines loader from text file.
    /// </summary>
    /// <seealso cref="Task_1_BasicXML.Interfaces.IDataLoader{System.Collections.Generic.IEnumerable{System.String}}" />
    public class TxtLoader : IDataLoader<IEnumerable<string>>
    {
        /// <summary>
        /// Loads the specified path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>String URIs.</returns>
        public IEnumerable<string> Load(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
    }
}
