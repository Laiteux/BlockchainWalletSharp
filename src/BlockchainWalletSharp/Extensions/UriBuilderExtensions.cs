using System;
using System.Collections.Generic;
using System.Web;

namespace BlockchainWalletSharp.Extensions
{
    internal static class UriBuilderExtensions
    {
        public static UriBuilder WithParameter(this UriBuilder uriBuilder, string name, string value)
        {
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);

            query[name] = value;

            uriBuilder.Query = query.ToString();

            return uriBuilder;
        }

        public static UriBuilder WithParameters(this UriBuilder uriBuilder, IEnumerable<KeyValuePair<string, string>> parameters)
        {
            foreach (var parameter in parameters)
            {
                uriBuilder = uriBuilder.WithParameter(parameter.Key, parameter.Value);
            }

            return uriBuilder;
        }
    }
}
