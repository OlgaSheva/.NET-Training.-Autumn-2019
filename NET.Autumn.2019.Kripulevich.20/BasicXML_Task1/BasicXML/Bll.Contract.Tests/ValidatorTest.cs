using Bll.Contract.Services;
using Moq;
using NUnit.Framework;

namespace Bll.Contract.Tests
{
    public class ValidatorTest
    {
        [Test]
        public void ValidatorMockTest()
        {
            var mockValidator = new Mock<IValidator<string>>();

            IValidator<string> validator = mockValidator.Object;

            validator.IsValid("https://github.com/AnzhelikaKravchuk/2017-2018.MMF.BSU");

            mockValidator.Verify();
        }
    }
}
