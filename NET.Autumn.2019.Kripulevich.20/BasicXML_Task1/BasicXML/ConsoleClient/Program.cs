using DependencyResolver;
using Microsoft.Extensions.DependencyInjection;
using Bll.Contract.Services;

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
