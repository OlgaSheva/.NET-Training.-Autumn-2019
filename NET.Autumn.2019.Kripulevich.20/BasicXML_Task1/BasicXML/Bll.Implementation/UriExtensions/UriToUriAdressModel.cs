using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bll.Contract.Entities;

namespace Bll.Implementation.ServiceImplementation.UriExtensions
{
    public static class UriToUriAdressExtinsion
    {
        public static URIAdress ToURIAdressModel(this Uri uri)
        {
            if (uri == null)
            {
                throw new ArgumentNullException(nameof(uri));
            }

            var values = HttpUtility.ParseQueryString(uri.Query);
            string[] parameters = uri.Query != string.Empty ? uri.Query.Trim('?').Split('&') : null;
            var uriModel = new URIAdress
            {
                HostName = uri.Host,
                URNSegments = uri.AbsolutePath.Split('/').Where(s => s.Length > 0).ToList(),
                Parameters = parameters == null
                ? new List<URNParameters>() 
                : parameters.Select(s => s.Split('=')).Select(s => new URNParameters
                {
                    Value = s[0],
                    Key = s[1],
                }).ToList(),
            };

            return uriModel;
        }
    }
}