using System;
using System.Collections.Generic;
using Bll.Contract.Services;
using Dal.Contract.Storages;

namespace Bll.Implementation.ServiceImplementation
{
    public class ExportDataService<TSource, TResult> : IExportDataService
    {
        private IDataLoader<IEnumerable<TSource>> loader;
        private IDataWriter<TResult> writer;
        private IConverter<IEnumerable<TSource>, IEnumerable<TResult>> converter;

        public ExportDataService(
            IDataLoader<IEnumerable<TSource>> loader,
            IDataWriter<TResult> writer,
            IConverter<IEnumerable<TSource>, IEnumerable<TResult>> converter)
        {
            this.loader = loader ?? throw new ArgumentNullException(nameof(loader));
            this.writer = writer ?? throw new ArgumentNullException(nameof(writer));
            this.converter = converter ?? throw new ArgumentNullException(nameof(converter));
        }

        public void Run()
        {
            writer.Write(converter.Convert(loader.Load()));
        }
    }
}