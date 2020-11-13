using System;
using System.Collections.Generic;
using System.Web;

namespace BlockchainWalletSharp.Extensions
{
    internal static class UriBuilderExtensions
    {
        internal static UriBuilder WithParameter(this UriBuilder uriBuilder, string name, string value)
        {
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);

            query[name] = value;

            uriBuilder.Query = query.ToString();

            return uriBuilder;
        }

        internal static UriBuilder WithParameters(this UriBuilder uriBuilder, IDictionary<string, string> parameters)
        {
            foreach (var parameter in parameters)
            {
                uriBuilder.WithParameter(parameter.Key, parameter.Value);
            }

            return uriBuilder;
        }
    }
}
