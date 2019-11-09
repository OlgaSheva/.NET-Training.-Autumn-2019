using System.Collections.Generic;
using System.Xml.Linq;
using Task_1_BasicXML.Interfaces;
using Task_1_BasicXML.Models;

namespace Task_1_BasicXML.XmlWriters
{
    /// <summary>
    /// X-Dom xml writer.
    /// </summary>
    /// <seealso cref="Task_1_BasicXML.Interfaces.IDataWriter{Task_1_BasicXML.Models.URIAdress}" />
    public class XDomTechnology : IDataWriter<URIAdress>
    {
        /// <summary>
        /// Writes the specified URIs.
        /// </summary>
        /// <param name="uris">The URIs.</param>
        public void Write(IEnumerable<URIAdress> uris)
        {
            XDocument xDocument = new XDocument();
            XElement uriAdresses = new XElement("uriAdresses");
            xDocument.Add(uriAdresses);
            foreach (var uri in uris)
            {
                XElement uriAdress =
                    new XElement("uriAdress",
                        new XElement("host",
                            new XAttribute("name", uri.HostName)));
                uriAdresses.Add(uriAdress);

                if (uri.URNSegments.Count > 0)
                {
                    XElement urn = new XElement("urn");
                    foreach (var s in uri.URNSegments)
                    {
                        urn.Add(new XElement("segment", s));
                    }
                    uriAdress.Add(urn);

                    if (uri.Parameters.Count > 0)
                    {
                        XElement parameters = new XElement("parameters");
                        foreach (var p in uri.Parameters)
                        {
                            parameters.Add(new XElement("parameter", new XAttribute("value", p.Value), new XAttribute("key", p.Key)));
                        }
                        uriAdress.Add(parameters);
                    }
                }                
            }

            xDocument.Save("xmluri.xml");
        }
    }
}
