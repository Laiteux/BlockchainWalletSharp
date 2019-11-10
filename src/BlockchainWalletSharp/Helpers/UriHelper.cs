using BlockchainWalletSharp.Extensions;
using BlockchainWalletSharp.Models;
using System;
using System.Collections.Generic;

namespace BlockchainWalletSharp.Helpers
{
    internal static class UriHelper
    {
        public static UriBuilder BuildMerchantApi(Wallet wallet, string endpoint)
        {
            var uriBuilder = new UriBuilder($"{wallet.Host}/merchant/{wallet.Identifier}/{endpoint}");

            uriBuilder = uriBuilder.WithParameters(new Dictionary<string, string>
            {
                { "password", wallet.Password },
                { "second_password", wallet.SecondPassword },
                { "api_code", wallet.ApiCode }
            });

            return uriBuilder;
        }
    }
}
