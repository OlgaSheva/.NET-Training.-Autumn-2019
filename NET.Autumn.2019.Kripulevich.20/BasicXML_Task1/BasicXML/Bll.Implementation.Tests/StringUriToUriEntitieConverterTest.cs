using System;
using System.Collections.Generic;
using System.Linq;
using Bll.Contract.Entities;
using Bll.Contract.Services;
using Bll.Implementation.ServiceImplementation;
using Bll.Implementation.ServiceImplementation.UriExtensions;
using Moq;
using NUnit.Framework;

namespace Bll.Implementation.Tests
{
    public class StringUriToUriEntitiesConverterTest
    {
        [Test]
        public void ToURIAdressModelTest_StringUri_ValidUriAdressModel()
        {
            string uri = "https://github.com/AnzhelikaKravchuk?tab=repositories";
            var expected = new URIAdress
            {
                Host = new Host { Name = "github.com" },
                URNSegments = new List<string>() { "AnzhelikaKravchuk" },
                Parameters = new List<URNParameters>() { new URNParameters() { Value = "tab", Key = "repositories", } },
            };
            var parser = new URIParser();
            var actual = parser.Parse(uri).ToURIAdressModel();

            Assert.AreEqual(expected.Host.Name, actual.Host.Name);
            Assert.AreEqual(expected.URNSegments, actual.URNSegments);
            Assert.AreEqual(expected.Parameters[0].Key, actual.Parameters[0].Key);
            Assert.AreEqual(expected.Parameters[0].Value, actual.Parameters[0].Value);
        }
    }

    public class StringUriToUriEntitieConverterMoqTest
    {
        private IParser<string, Uri> parser;
        private IValidator<string> validator;
        private ILogger logger;

        [OneTimeSetUp]
        public void SetUp()
        {
            parser = Mock.Of<IParser<string, Uri>>();
            validator = Mock.Of<IValidator<string>>();
            logger = Mock.Of<ILogger>();
        }

        [Test]
        public void CreateStringUriCollectionToUriAdressModelCollectionConverter_ParserIsNull_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() =>
                new StringUriToUriEntitieConverter(logger, validator, null));

        [Test]
        public void CreateStringUriCollectionToUriAdressModelCollectionConverter_ValidatorIsNull_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() =>
                new StringUriToUriEntitieConverter(logger, null, parser));

        [Test]
        public void CreateStringUriCollectionToUriAdressModelCollectionConverter_LoggerIsNull_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() =>
                new StringUriToUriEntitieConverter(null, validator, parser));

        [Test]
        public void Convert_SourceIsNull_ThrowsArgumentNullException()
        {
            var converter = new StringUriToUriEntitieConverter(logger, validator, parser);

            Assert.Throws<ArgumentNullException>(() => converter.Convert(null).ToList());
        }

        //[Test]
        //public void Convert_ValidData_IgnoresByLogger()
        //{
        //    validator = Mock.Of<IValidator<string>>(v => v.IsValid(It.IsAny<string>()) == true);

        //    var converter = new StringUriToUriEntitieConverter(logger, validator, parser);

        //    converter.Convert(new string[] { "http://test.com/" }).ToList();

        //    Mock.Get(logger).Verify(l => l.Error(It.IsAny<string>()), Times.Never);
        //}

        //[Test]
        //public void Convert_ValidData_ByParser()
        //{
        //    validator = Mock.Of<IValidator<string>>(v => v.IsValid(It.IsAny<string>()) == true);

        //    var converter = new StringUriToUriEntitieConverter(logger, validator, parser);

        //    converter.Convert(new string[] { "http://test.com/" }).ToList();

        //    Mock.Get(logger).Verify(l => l.Error(It.IsAny<string>()), Times.Never);
        //    Mock.Get(parser).Verify(p => p.Parse(It.IsAny<string>()), Times.Once);
        //}

        [Test]
        public void Convert_InvalidData_IgnoresByParser()
        {
            validator = Mock.Of<IValidator<string>>(v => v.IsValid(It.IsAny<string>()) == false);

            var converter = new StringUriToUriEntitieConverter(logger, validator, parser);

            converter.Convert(new string[] { "http://test.com/" }).ToList();

            Mock.Get(parser).Verify(p => p.Parse(It.IsAny<string>()), Times.Never);
            Mock.Get(logger).Verify(l => l.Error(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void Convert_InvalidData_ByLogger()
        {
            validator = Mock.Of<IValidator<string>>(v => v.IsValid(It.IsAny<string>()) == false);

            var converter = new StringUriToUriEntitieConverter(logger, validator, parser);

            converter.Convert(new string[] { "http://test.com/" }).ToList();

            Mock.Get(logger).Verify(l => l.Error(It.IsAny<string>()), Times.Once);
        }
    }
}
