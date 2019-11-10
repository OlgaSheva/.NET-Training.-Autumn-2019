using System;
using System.Collections.Generic;
using Bll.Contract.Services;
using Bll.Implementation.ServiceImplementation;
using Moq;
using NUnit.Framework;

namespace Bll.Implementation.Tests
{
    public class StringUriToUriEntitieConverterTest
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

        //[Test]
        //public void Convert_SourceIsNull_ThrowsArgumentNullException()
        //{
        //    var converter = new StringUriToUriEntitieConverter(logger, validator, parser);

        //    Assert.Throws<ArgumentNullException>(() => converter.Convert(null));
        //}

        [Test]
        public void Convert_ValidData_IgnoresByLogger()
        {
            validator = Mock.Of<IValidator<string>>(v => v.IsValid(It.IsAny<string>()) == true);

            var converter = new StringUriToUriEntitieConverter(logger, validator, parser);

            converter.Convert(new string[] { "http://test.com/" });

            Mock.Get(logger).Verify(l => l.Error(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void Convert_ValidData_ByParser()
        {
            validator = Mock.Of<IValidator<string>>(v => v.IsValid(It.IsAny<string>()) == true);

            var converter = new StringUriToUriEntitieConverter(logger, validator, parser);

            converter.Convert(new string[] { "http://test.com/" });

            Mock.Get(logger).Verify(l => l.Error(It.IsAny<string>()), Times.Never);
            //Mock.Get(parser).Verify(p => p.Parse(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void Convert_InvalidData_IgnoresByParser()
        {
            validator = Mock.Of<IValidator<string>>(v => v.IsValid(It.IsAny<string>()) == false);

            var converter = new StringUriToUriEntitieConverter(logger, validator, parser);

            converter.Convert(new string[] { "http://test.com/" });

            Mock.Get(parser).Verify(p => p.Parse(It.IsAny<string>()), Times.Never);
            //Mock.Get(logger).Verify(l => l.Error(It.IsAny<string>()), Times.Once);
        }

        //[Test]
        //public void Convert_InvalidData_ByLogger()
        //{
        //    validator = Mock.Of<IValidator<string>>(v => v.IsValid(It.IsAny<string>()) == false);

        //    var converter = new StringUriToUriEntitieConverter(logger, validator, parser);

        //    converter.Convert(new string[] { "http://test.com/" });

        //    Mock.Get(logger).Verify(l => l.Error(It.IsAny<string>()), Times.Once);
        //}
    }
}
