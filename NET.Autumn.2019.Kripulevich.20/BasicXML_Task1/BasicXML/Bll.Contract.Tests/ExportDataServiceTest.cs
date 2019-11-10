using Bll.Contract.Services;
using Moq;
using NUnit.Framework;

namespace Bll.Contract.Tests
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
