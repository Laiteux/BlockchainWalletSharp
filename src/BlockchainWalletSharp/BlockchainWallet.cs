using BlockchainWalletSharp.Extensions;
using BlockchainWalletSharp.Helpers;
using BlockchainWalletSharp.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlockchainWalletSharp
{
    public class BlockchainWallet
    {
        private readonly HttpRequester _httpRequester = new HttpRequester(new HttpClient());

        private readonly BlockchainWalletConfiguration _blockchainWalletConfiguration;

        /// <summary>
        ///     Initializes a new instance of the <see cref="BlockchainWallet"/> class
        /// </summary>
        /// <param name="blockchainWalletConfiguration">An instance of the <see cref="BlockchainWalletConfiguration"/> class</param>
        public BlockchainWallet(BlockchainWalletConfiguration blockchainWalletConfiguration)
        {
            _blockchainWalletConfiguration = blockchainWalletConfiguration;
        }

        /// <summary>
        ///     Generates a new address on your wallet
        /// </summary>
        /// <param name="label">Label to give to the address</param>
        /// <returns>An instance of the <see cref="NewAddress"/> class</returns>
        public async Task<NewAddress> NewAddressAsync(string label = null)
        {
            var uri = UriHelper.BuildMerchantApi(_blockchainWalletConfiguration, "new_address");

            if (!string.IsNullOrWhiteSpace(label))
                uri = uri.WithParameter("label", label);

            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri.Uri);

            var newAddress = await _httpRequester.SendAsync<NewAddress>(requestMessage).ConfigureAwait(false);

            return newAddress;
        }

        /// <summary>
        ///     List your wallet addresses
        /// </summary>
        /// <returns>An instance of the <see cref="AddressList"/> class</returns>
        public async Task<AddressList> AddressListAsync()
        {
            var uri = UriHelper.BuildMerchantApi(_blockchainWalletConfiguration, "list");

            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri.Uri);

            var addressList = await _httpRequester.SendAsync<AddressList>(requestMessage).ConfigureAwait(false);

            return addressList;
        }

        /// <summary>
        ///     Fetches your wallet balance
        /// </summary>
        /// <returns>A <see cref="long"/> of wallet balance in satoshis</returns>
        public async Task<long> WalletBalanceAsync()
        {
            var uri = UriHelper.BuildMerchantApi(_blockchainWalletConfiguration, "balance");

            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri.Uri);

            var response = await _httpRequester.SendAsync<dynamic>(requestMessage).ConfigureAwait(false);

            return response["balance"];
        }

        /// <summary>
        ///     Fetches a wallet address balance
        /// </summary>
        /// <param name="address">Bitcoin address</param>
        /// <returns>An instance of the <see cref="AddressBalance"/> class</returns>
        public async Task<AddressBalance> AddressBalanceAsync(string address)
        {
            var uri = UriHelper.BuildMerchantApi(_blockchainWalletConfiguration, "address_balance");

            uri = uri.WithParameter("address", address);

            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri.Uri);

            var addressBalance = await _httpRequester.SendAsync<AddressBalance>(requestMessage).ConfigureAwait(false);

            return addressBalance;
        }

        /// <summary>
        ///     Archives a wallet address
        /// </summary>
        /// <param name="address">Bitcoin address</param>
        /// <returns>A <see cref="string"/> of the archived address</returns>
        public async Task<string> ArchiveAddressAsync(string address)
        {
            var uri = UriHelper.BuildMerchantApi(_blockchainWalletConfiguration, "archive_address");

            uri = uri.WithParameter("address", address);

            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri.Uri);

            var response = await _httpRequester.SendAsync<dynamic>(requestMessage).ConfigureAwait(false);

            return response["archived"];
        }

        /// <summary>
        ///     Unarchives a wallet address
        /// </summary>
        /// <param name="address">Bitcoin address</param>
        /// <returns>A <see cref="string"/> of the unarchived address</returns>
        public async Task<string> UnarchiveAddressAsync(string address)
        {
            var uri = UriHelper.BuildMerchantApi(_blockchainWalletConfiguration, "unarchive_address");

            uri = uri.WithParameter("address", address);

            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri.Uri);

            var response = await _httpRequester.SendAsync<dynamic>(requestMessage).ConfigureAwait(false);

            return response["active"];
        }

        /// <summary>
        ///     Sends bitcoin from your wallet to multiple addresses
        /// </summary>
        /// <remarks>
        ///     It is recommended that transaction fees are specified using the fee_per_byte parameter, which will compute your final fee based on the size of the transaction. You can also set a static fee using the fee parameter, but doing so may result in a low fee-per-byte, leading to longer confirmation times.
        ///     It is recommended to specify a custom fee, transactions using the default 10000 satoshi fee may not confirm
        /// </remarks>
        /// <param name="recipients">Bitcoin addresses as keys and the satoshi amounts as values</param>
        /// <param name="from">Bitcoin address or account index to send from</param>
        /// <param name="feePerByte">Transaction fee-per-byte in satoshi</param>
        /// <param name="fee">Transaction fee in satoshi</param>
        /// <returns>An instance of the <see cref="Payment"/> class</returns>
        public async Task<Payment> PaymentAsync(IEnumerable<KeyValuePair<string, long>> recipients, string from = null, long? feePerByte = null, long? fee = null)
        {
            var uri = UriHelper.BuildMerchantApi(_blockchainWalletConfiguration, "sendmany");

            uri = uri.WithParameter("recipients", JsonConvert.SerializeObject(recipients));

            if(!string.IsNullOrWhiteSpace(from))
                uri = uri.WithParameter("from", from);

            if (feePerByte.HasValue)
                uri = uri.WithParameter("fee_per_byte", feePerByte.Value.ToString());

            if (fee.HasValue)
                uri = uri.WithParameter("fee", fee.Value.ToString());

            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri.Uri);

            var payment = await _httpRequester.SendAsync<Payment>(requestMessage).ConfigureAwait(false);

            return payment;
        }
    }
}
