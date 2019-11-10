using Bll.Contract.Services;
using Moq;
using NUnit.Framework;
using System;

namespace Bll.Contract.Tests
{
    public class ParserTest
    {
        [Test]
        public void ParserMockTest()
        {
            var mockParser = new Mock<IParser<string, Uri>>();

            IParser<string, Uri> parser = mockParser.Object;

            parser.Parse("https://github.com/AnzhelikaKravchuk/2017-2018.MMF.BSU");
            parser.TryParse("https://github.com/AnzhelikaKravchuk/2017-2018.MMF.BSU", out Uri result);

            mockParser.Verify();
        }
    }
}
