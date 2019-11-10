using Bll.Contract.Entities;
using Dal.Contract.Storages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Dal.Implementation.XmlWriters
{
    /// <summary>
    /// Xml serializer.
    /// </summary>
    /// <seealso cref="Dal.Contract.Storages.IDataWriter{Bll.Contract.Entities.URIAdress}" />
    public class XmlSerializeTechnology : IDataWriter<URIAdress>
    {
        private readonly string path;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlSerializeTechnology"/> class.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <exception cref="ArgumentNullException">path</exception>
        public XmlSerializeTechnology(string path)
        {
            this.path = path ?? throw new ArgumentNullException(nameof(path));
        }

        public void Write(IEnumerable<URIAdress> uris)
        {
            UriAdresses uriAdresses = new UriAdresses { uriAdresses = uris.ToList() };
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            XmlSerializer ser = new XmlSerializer(typeof(UriAdresses));
            using (var writer = new StreamWriter(path))
            {
                ser.Serialize(writer, uriAdresses, namespaces);
            }
        }
    }
}
