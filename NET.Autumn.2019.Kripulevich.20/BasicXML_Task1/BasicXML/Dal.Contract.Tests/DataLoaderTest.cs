using Dal.Contract.Storages;
using Moq;
using NUnit.Framework;

namespace Dal.Contract.Tests
{
    public class DataLoaderTest
    {
        [Test]
        public void LoadDataMoqTest()
        {
            var mockDataLoader = new Mock<IDataLoader<string>>();

            IDataLoader<string> dataLoader = mockDataLoader.Object;

            dataLoader.Load();

            mockDataLoader.Verify();
        }
    }
}