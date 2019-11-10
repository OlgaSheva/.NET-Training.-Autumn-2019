using System.Collections.Generic;
using System.Xml.Serialization;

namespace Bll.Contract.Entities
{
    /// <summary>
    /// Url adress model.
    /// </summary>
    [XmlRoot("uriAdress")]
    public class URIAdress
    {
        /// <summary>
        /// Gets or sets the host.
        /// </summary>
        /// <value>
        /// The host.
        /// </value>
        [XmlElement("host")]
        public Host Host { get; set; }

        /// <summary>
        /// Gets or sets the segments.
        /// </summary>
        /// <value>
        /// The segments.
        /// </value>
        [XmlArray("urn")]
        [XmlArrayItem(ElementName = "segment")]
        public List<string> URNSegments { get; set; }

        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        /// <value>
        /// The parameters.
        /// </value>
        [XmlArray("parameters")]
        [XmlArrayItem(ElementName = "parameter")]
        public List<URNParameters> Parameters { get; set; }
    }
}
