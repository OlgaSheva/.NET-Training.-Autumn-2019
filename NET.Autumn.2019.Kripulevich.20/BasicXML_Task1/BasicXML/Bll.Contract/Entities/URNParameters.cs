using System.Xml.Serialization;

namespace Bll.Contract.Entities
{
    /// <summary>
    /// Url parameters model.
    /// </summary>
    [XmlRoot("parameter")]
    public class URNParameters
    {
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        [XmlAttribute("value")]
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        [XmlAttribute("key")]
        public string Key { get; set; }
    }
}
