using Bll.Contract.Services;
using Moq;
using NUnit.Framework;

namespace Bll.Contract.Tests
{
    public class LoggerTest
    {
        [Test]
        public void LoggerMockTest()
        {
            var mockLogger = new Mock<ILogger>();

            ILogger logger = mockLogger.Object;

            logger.Info("message");

            mockLogger.Verify();
        }
    }
}
