using Bll.Contract.Entities;
using Bll.Contract.Services;
using Moq;
using NUnit.Framework;

namespace Bll.Contract.Tests
{
    public class ConverterTest
    {
        [Test]
        public void ConverterMockTest()
        {
            var mockConverter = new Mock<IConverter<string, URIAdress>>();

            IConverter<string, URIAdress> converter = mockConverter.Object;

            converter.Convert("https://github.com/AnzhelikaKravchuk/2017-2018.MMF.BSU");

            mockConverter.Verify();
        }
    }
}
