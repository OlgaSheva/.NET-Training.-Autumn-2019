using System.Collections.Generic;
using System.IO;
using Dal.Contract.Storages;

namespace Dal.Implementation.StringUriLoaders
{
    /// <summary>
    /// Lines loader from text file.
    /// </summary>
    /// <seealso cref="Task_1_BasicXML.Interfaces.IDataLoader{System.Collections.Generic.IEnumerable{System.String}}" />
    public class TxtLoader : IDataLoader<IEnumerable<string>>
    {
        private readonly string path;

        /// <summary>
        /// Initializes a new instance of the <see cref="TxtLoader"/> class.
        /// </summary>
        /// <param name="path">The path.</param>
        public TxtLoader(string path)
        {
            this.path = path;
        }

        /// <summary>
        /// Loads the specified path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>String URIs.</returns>
        public IEnumerable<string> Load()
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
