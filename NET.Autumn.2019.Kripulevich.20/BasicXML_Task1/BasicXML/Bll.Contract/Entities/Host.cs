
using System.Xml.Serialization;

namespace Bll.Contract.Entities
{
    public class Host
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
    }
}
