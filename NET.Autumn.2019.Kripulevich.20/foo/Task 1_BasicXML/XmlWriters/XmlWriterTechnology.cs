using System.Collections.Generic;
using System.Xml;
using Task_1_BasicXML.Interfaces;
using Task_1_BasicXML.Models;

namespace Task_1_BasicXML.XmlWriters
{
    /// <summary>
    /// XML writer.
    /// </summary>
    /// <seealso cref="Task_1_BasicXML.Interfaces.IDataWriter" />
    public class XmlWriterTechnology : IDataWriter<URIAdress>
    {
        /// <summary>
        /// Writes the specified URIs.
        /// </summary>
        /// <param name="uris">The URIs.</param>
        public void Write(IEnumerable<URIAdress> uris)
        {
            using(XmlWriter writer = XmlWriter.Create("xmluri.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("uriAdresses");
                foreach (var uri in uris)
                {
                    writer.WriteStartElement("uriAdress");

                    writer.WriteStartElement("host");
                    writer.WriteAttributeString("name", uri.HostName);
                    writer.WriteEndElement();

                    if (uri.URNSegments.Count > 0)
                    {
                        writer.WriteStartElement("urn");
                        foreach (var segment in uri.URNSegments)
                        {
                            writer.WriteElementString("segment", segment);
                        }
                        writer.WriteEndElement();

                        if (uri.Parameters.Count > 0)
                        {
                            writer.WriteStartElement("parameters");
                            foreach (var parameter in uri.Parameters)
                            {
                                writer.WriteStartElement("parameter");
                                writer.WriteAttributeString("value", parameter.Value);
                                writer.WriteAttributeString("key", parameter.Key);
                                writer.WriteEndElement();
                            }
                            writer.WriteEndElement();
                        }
                    }

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
    }
}
