using BlockchainWalletSharp.Extensions;
using BlockchainWalletSharp.Models;
using System;

namespace BlockchainWalletSharp.Helpers
{
    internal static class UriHelper
    {
        internal static UriBuilder BuildMerchantApi(BlockchainWalletConfiguration blockchainWalletConfiguration, string endpoint)
        {
            var uriBuilder = new UriBuilder($"{blockchainWalletConfiguration.Host}/merchant/{blockchainWalletConfiguration.Identifier}/{endpoint}");

            uriBuilder.WithParameter("password", blockchainWalletConfiguration.Password);

            if (!string.IsNullOrWhiteSpace(blockchainWalletConfiguration.SecondPassword))
                uriBuilder.WithParameter("second_password", blockchainWalletConfiguration.SecondPassword);

            if(!string.IsNullOrWhiteSpace(blockchainWalletConfiguration.ApiCode))
                uriBuilder.WithParameter("api_code", blockchainWalletConfiguration.ApiCode);

            return uriBuilder;
        }
    }
}
