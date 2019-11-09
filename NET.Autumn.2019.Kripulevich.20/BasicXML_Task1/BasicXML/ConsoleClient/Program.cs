using DependencyResolver;
using Dal.Contract.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ResolverConfig();
            var servise = config.CreateServiceProvider().GetService<IExportDataService>();
            servise.Run();
        }
    }
}
