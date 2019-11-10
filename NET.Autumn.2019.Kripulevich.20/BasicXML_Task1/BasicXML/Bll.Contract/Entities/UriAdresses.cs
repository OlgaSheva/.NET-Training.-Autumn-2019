using System.Collections.Generic;
using System.Xml.Serialization;

namespace Bll.Contract.Entities
{
    [XmlRoot("uriAdresses", Namespace = "")]
    public class UriAdresses
    {
        [XmlElement("uriAdress")]
        public List<URIAdress> uriAdresses { get; set; }
    }
}
