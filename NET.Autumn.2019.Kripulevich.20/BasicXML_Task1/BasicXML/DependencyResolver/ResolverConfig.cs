using System;
using System.Collections.Generic;
using System.IO;
using Bll.Contract.Entities;
using Bll.Contract.Services;
using Bll.Implementation.ServiceImplementation;
using Dal.Contract.Storages;
using Dal.Contract.Services;
using Dal.Implementation.StringUriLoaders;
using Dal.Implementation.XmlWriters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Dal.Implementation.ServiceImplementation;

namespace DependencyResolver
{
    public class ResolverConfig
    {
        public static IConfigurationRoot ConfigurationRoot { get; } =
            new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

        public IServiceProvider CreateServiceProvider()
        {
            string sourceFilePath = CreateValidPath("sourceFilePath") ?? throw new ArgumentNullException("CreateValidPath(\"sourceFilePath\")");
            string targetFilePath = CreateValidPath("targetFilePath") ?? throw new ArgumentNullException("CreateValidPath(\"targetFilePath\")");

            return new ServiceCollection()
                .AddTransient<IConverter<IEnumerable<string>, IEnumerable<URIAdress>>, StringUriToUriEntitieConverter>(
                    c => new StringUriToUriEntitieConverter(new NLogLogger(), new URIValidator(), new URIParser()))
                .AddTransient<IDataLoader<IEnumerable<string>>, TxtLoader>(t => new TxtLoader(sourceFilePath))
                .AddTransient<IDataWriter<URIAdress>, XDomTechnology>(x => new XDomTechnology(targetFilePath))
                .AddTransient<IExportDataService, ExportDataService<string, URIAdress>>()
                .BuildServiceProvider();
        }

        private string CreateValidPath(string path) =>
            Path.Combine(Directory.GetCurrentDirectory(), ConfigurationRoot[path]);
    }
}
