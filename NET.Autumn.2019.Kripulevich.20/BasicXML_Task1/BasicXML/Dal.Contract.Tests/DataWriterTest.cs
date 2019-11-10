using Moq;
using Dal.Contract.Storages;
using NUnit.Framework;

namespace Dal.Contract.Tests
{
    public class DataWriterTest
    {
        [Test]
        public void WriteDataMoqTest()
        {
            var mockDataWriter = new Mock<IDataWriter<object>>();

            IDataWriter<object> dataWriter = mockDataWriter.Object;

            dataWriter.Write(new object[] { });

            mockDataWriter.Verify();
        }
    }
}
