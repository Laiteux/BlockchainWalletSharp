using BlockchainWalletSharp.Extensions;
using BlockchainWalletSharp.Models;
using System;

namespace BlockchainWalletSharp.Helpers
{
    internal static class UriHelper
    {
        public static UriBuilder BuildMerchantApi(BlockchainWalletConfiguration wallet, string endpoint)
        {
            var uriBuilder = new UriBuilder($"{wallet.Host}/merchant/{wallet.Identifier}/{endpoint}");

            uriBuilder.WithParameter("password", wallet.Password);

            if (!string.IsNullOrWhiteSpace(wallet.SecondPassword))
                uriBuilder.WithParameter("second_password", wallet.SecondPassword);

            if(!string.IsNullOrWhiteSpace(wallet.ApiCode))
                uriBuilder.WithParameter("api_code", wallet.ApiCode);

            return uriBuilder;
        }
    }
}
