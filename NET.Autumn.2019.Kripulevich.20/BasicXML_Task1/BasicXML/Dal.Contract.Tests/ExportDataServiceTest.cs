using Moq;
using Dal.Contract.Services;
using NUnit.Framework;

namespace Dal.Contract.Tests
{
    public class ExportDataServiceTest
    {
        [Test]
        public void ExportDataServiceMockTest()
        {
            var mockExportDataService = new Mock<IExportDataService>();

            IExportDataService exportDataService = mockExportDataService.Object;

            exportDataService.Run();

            mockExportDataService.Verify();
        }
    }
}
