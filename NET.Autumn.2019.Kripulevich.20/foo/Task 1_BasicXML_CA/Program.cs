using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Task_1_BasicXML;
using Task_1_BasicXML.Interfaces;
using Task_1_BasicXML.Models;
using Task_1_BasicXML.StringUriLoaders;
using Task_1_BasicXML.UriExtensions;
using Task_1_BasicXML.XmlWriters;

namespace Task_1_BasicXML_CA
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataLoader<IEnumerable<string>> loader = new TxtLoader();
            URIParser parser = new URIParser();
            var uris = loader.Load("URL-adress.txt");

            //var writer = new XmlWriterTechnology();
            //var writer = new XmlDomTechnology();
            var writer = new XDomTechnology();
            IEnumerable<URIAdress> uriModels = uris.Select(u => parser.Parse(u).ToURIAdressModel());
            writer.Write(uriModels);
        }
    }
}
