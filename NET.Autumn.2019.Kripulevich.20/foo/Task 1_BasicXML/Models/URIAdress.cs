using System.Collections.Generic;

namespace Task_1_BasicXML.Models
{
    /// <summary>
    /// Url adress model.
    /// </summary>
    public class URIAdress
    {
        /// <summary>
        /// Gets or sets the name of the host.
        /// </summary>
        /// <value>
        /// The name of the host.
        /// </value>
        public string HostName { get; set; }

        /// <summary>
        /// Gets or sets the segments.
        /// </summary>
        /// <value>
        /// The segments.
        /// </value>
        public List<string> URNSegments { get; set; }

        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        /// <value>
        /// The parameters.
        /// </value>
        public List<URNParameters> Parameters { get; set; }
    }
}
