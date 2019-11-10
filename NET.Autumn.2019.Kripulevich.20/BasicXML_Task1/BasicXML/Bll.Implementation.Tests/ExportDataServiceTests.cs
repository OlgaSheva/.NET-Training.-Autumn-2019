using Bll.Contract.Entities;
using Bll.Contract.Services;
using Bll.Implementation.ServiceImplementation;
using Dal.Contract.Storages;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Bll.Implementation.Tests
{
    public class ExportDataServiceTests
    {
        private IDataLoader<IEnumerable<string>> loader;
        private IDataWriter<URIAdress> writer;
        private IConverter<IEnumerable<string>, IEnumerable<URIAdress>> converter;
        readonly IEnumerable<URIAdress> uriAdresses = new URIAdress[] { new URIAdress {
        Host = new Host {Name = "github.com" },
        URNSegments = new List<string> { "AnzhelikaKravchuk", "2017 - 2018.MMF.BSU" },
        Parameters = new List<URNParameters>(), } };
        readonly IEnumerable<string> uriStrings = new string[] { "https://github.com/AnzhelikaKravchuk/2017-2018.MMF.BSU" };

        [OneTimeSetUp]
        public void SetUp()
        {
            loader = Mock.Of<IDataLoader<IEnumerable<string>>>();
            writer = Mock.Of<IDataWriter<URIAdress>>();
            converter = Mock.Of<IConverter<IEnumerable<string>, IEnumerable<URIAdress>>>();
        }

        [Test]
        public void CreateURLStringCollectionToUrlAdressModelCollection_LoaderIsNull_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() =>
                new ExportDataService<string, URIAdress>(null, writer, converter));

        [Test]
        public void CreateURLStringCollectionToUrlAdressModelCollection_WriterIsNull_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() =>
                new ExportDataService<string, URIAdress>(loader, null, converter));

        [Test]
        public void CreateURLStringCollectionToUrlAdressModelCollection_ConverterIsNull_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() =>
                new ExportDataService<string, URIAdress>(loader, writer, null));

        [Test]
        public void ExportDataService_SourceIsNull_ThrowsArgumentNullException()
        {
            var service = new ExportDataService<string, URIAdress>(loader, writer, converter);
            service.Run();

            Mock.Get(loader).Verify(loader => loader.Load(), Times.AtLeastOnce());
            //Mock.Get(converter).Verify(converter => converter.Convert(uriStrings), Times.AtLeastOnce());
            //Mock.Get(writer).Verify(writer => writer.Write(uriAdresses), Times.AtLeastOnce());
        }
    }
}
