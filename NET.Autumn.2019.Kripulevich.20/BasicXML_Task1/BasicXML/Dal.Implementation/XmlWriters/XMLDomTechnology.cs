using System;
using System.Collections.Generic;
using System.Xml;
using Bll.Contract.Entities;
using Dal.Contract.Storages;

namespace Dal.Implementation.XmlWriters
{
    /// <summary>
    /// XML-Dom writer.
    /// </summary>
    /// <seealso cref="Task_1_BasicXML.Interfaces.IDataWriter" />
    public class XmlDomTechnology : IDataWriter<URIAdress>
    {
        private readonly string path;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlDomTechnology"/> class.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <exception cref="ArgumentNullException">path</exception>
        public XmlDomTechnology(string path)
        {
            this.path = path ?? throw new ArgumentNullException(nameof(path));
        }

        /// <summary>
        /// Writes the specified URIs.
        /// </summary>
        /// <param name="uris">The URIs.</param>
        public void Write(IEnumerable<URIAdress> uris)
        {
            XmlDocument doc = new XmlDocument();
            doc.AppendChild(doc.CreateXmlDeclaration("1.0", null, "yes"));
            XmlElement uriAdresses = doc.CreateElement("uriAdresses");
            foreach (var uri in uris)
            {
                XmlElement uriAdress = doc.CreateElement("uriAdress");

                XmlElement host = doc.CreateElement("host");
                XmlAttribute name = doc.CreateAttribute("name");
                name.Value = uri.Host.Name;
                host.Attributes.Append(name);
                uriAdress.AppendChild(host);

                if (uri.URNSegments.Count > 0)
                {
                    XmlElement urn = doc.CreateElement("urn");
                    foreach (var s in uri.URNSegments)
                    {
                        XmlElement segment = doc.CreateElement("segment");
                        segment.AppendChild(doc.CreateTextNode(s));
                        urn.AppendChild(segment);
                    }

                    uriAdress.AppendChild(urn);
                    if (uri.Parameters?.Count > 0)
                    {
                        XmlElement parameters = doc.CreateElement("parameters");
                        foreach (var p in uri.Parameters)
                        {
                            XmlElement parameter = doc.CreateElement("parameter");
                            XmlAttribute value = doc.CreateAttribute("value");
                            XmlAttribute key = doc.CreateAttribute("key");
                            value.Value = p.Value;
                            key.Value = p.Key;
                            parameter.Attributes.Append(value);
                            parameter.Attributes.Append(key);
                            parameters.AppendChild(parameter);
                        }

                        uriAdress.AppendChild(parameters);
                    }
                }

                uriAdresses.AppendChild(uriAdress);
            }

            doc.AppendChild(uriAdresses);
            doc.Save(path);
        }
    }
}
