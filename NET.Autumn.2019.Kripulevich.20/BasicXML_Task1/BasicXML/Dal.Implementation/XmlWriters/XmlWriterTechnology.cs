using System;
using System.Collections.Generic;
using System.Xml;
using Bll.Contract.Entities;
using Dal.Contract.Storages;

namespace Dal.Implementation.XmlWriters
{
    /// <summary>
    /// XML writer.
    /// </summary>
    /// <seealso cref="Task_1_BasicXML.Interfaces.IDataWriter" />
    public class XmlWriterTechnology : IDataWriter<URIAdress>
    {
        private readonly string path;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlWriterTechnology"/> class.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <exception cref="ArgumentNullException">path</exception>
        public XmlWriterTechnology(string path)
        {
            this.path = path ?? throw new ArgumentNullException(nameof(path));
        }

        /// <summary>
        /// Writes the specified URIs.
        /// </summary>
        /// <param name="uris">The URIs.</param>
        public void Write(IEnumerable<URIAdress> uris)
        {
            using(XmlWriter writer = XmlWriter.Create(path))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("uriAdresses");
                foreach (var uri in uris)
                {
                    writer.WriteStartElement("uriAdress");

                    writer.WriteStartElement("host");
                    writer.WriteAttributeString("name", uri.Host.Name);
                    writer.WriteEndElement();

                    if (uri.URNSegments.Count > 0)
                    {
                        writer.WriteStartElement("urn");
                        foreach (var segment in uri.URNSegments)
                        {
                            writer.WriteElementString("segment", segment);
                        }
                        writer.WriteEndElement();

                        if (uri.Parameters?.Count > 0)
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
