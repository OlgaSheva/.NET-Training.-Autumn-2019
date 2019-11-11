using System;
using System.Collections.Generic;
using Bll.Contract.Entities;
using Bll.Contract.Services;
using Bll.Implementation.ServiceImplementation.UriExtensions;

namespace Bll.Implementation.ServiceImplementation
{
    public class StringUriToUriEntitieConverter : IConverter<IEnumerable<string>, IEnumerable<URIAdress>>
    {
        private ILogger logger;
        private IValidator<string> validator;
        private IParser<string, Uri> parser;

        public StringUriToUriEntitieConverter(ILogger logger, IValidator<string> validator, IParser<string, Uri> parser)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.validator = validator ?? throw new ArgumentNullException(nameof(validator));
            this.parser = parser ?? throw new ArgumentNullException(nameof(parser));
        }

        public IEnumerable<URIAdress> Convert(IEnumerable<string> source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            foreach (var item in source)
            {
                yield return Convert(item);
            }
        }

        private URIAdress Convert(string source)
        {
            if (!validator.IsValid(source))
            {
                logger.Error($"'{source}' is not valid URI.");
                return null;
            }

            return (parser.Parse(source)).ToURIAdressModel();
        }
    }
}
