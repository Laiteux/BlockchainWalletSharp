using BlockchainWalletSharp.Extensions;
using BlockchainWalletSharp.Helpers;
using BlockchainWalletSharp.Models;
using BlockchainWalletSharp.Models.Response;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlockchainWalletSharp
{
    public class BlockchainWallet
    {
        private readonly HttpClient _httpClient;

        private readonly BlockchainWalletConfiguration _blockchainWalletConfiguration;

        /// <summary>
        ///     Initializes a new instance of the <see cref="BlockchainWallet"/> instance
        /// </summary>
        /// <param name="httpClient">A <see cref="HttpClient"/> instance</param>
        /// <param name="blockchainWalletConfiguration">A <see cref="BlockchainWalletConfiguration"/> instance</param>
        public BlockchainWallet(HttpClient httpClient, BlockchainWalletConfiguration blockchainWalletConfiguration)
        {
            _httpClient = httpClient;
            _blockchainWalletConfiguration = blockchainWalletConfiguration;
        }

        /// <summary>
        ///     Generates a new address on your wallet
        /// </summary>
        /// <param name="label">Label to give to the address</param>
        /// <returns>A <see cref="NewAddress"/> instance</returns>
        public async Task<NewAddress> NewAddressAsync(string label = null)
        {
            var uri = UriHelper.BuildMerchantApi(_blockchainWalletConfiguration, "new_address");

            if (!string.IsNullOrWhiteSpace(label))
                uri = uri.WithParameter("label", label);

            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri.Uri);

            using var responseMessage = await _httpClient.SendAsync(requestMessage).ConfigureAwait(false);

            var newAddress = await responseMessage.DeserializeAsync<NewAddress>().ConfigureAwait(false);

            return newAddress;
        }

        /// <summary>
        ///     Lists your wallet addresses
        /// </summary>
        /// <returns>A <see cref="AddressList"/> instance</returns>
        public async Task<AddressList> AddressListAsync()
        {
            var uri = UriHelper.BuildMerchantApi(_blockchainWalletConfiguration, "list");

            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri.Uri);

            using var responseMessage = await _httpClient.SendAsync(requestMessage).ConfigureAwait(false);

            var addressList = await responseMessage.DeserializeAsync<AddressList>().ConfigureAwait(false);

            return addressList;
        }

        /// <summary>
        ///     Fetches your wallet balance
        /// </summary>
        /// <returns>A <see cref="long"/> of wallet balance in satoshi</returns>
        public async Task<long> WalletBalanceAsync()
        {
            var uri = UriHelper.BuildMerchantApi(_blockchainWalletConfiguration, "balance");

            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri.Uri);

            using var responseMessage = await _httpClient.SendAsync(requestMessage).ConfigureAwait(false);

            var dynamic = await responseMessage.DeserializeAsync<dynamic>().ConfigureAwait(false);

            return dynamic["balance"];
        }

        /// <summary>
        ///     Fetches a wallet address balance
        /// </summary>
        /// <param name="address">Bitcoin address</param>
        /// <returns>A <see cref="AddressBalance"/> instance</returns>
        public async Task<AddressBalance> AddressBalanceAsync(string address)
        {
            var uri = UriHelper.BuildMerchantApi(_blockchainWalletConfiguration, "address_balance");

            uri = uri.WithParameter("address", address);

            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri.Uri);

            using var responseMessage = await _httpClient.SendAsync(requestMessage).ConfigureAwait(false);

            var addressBalance = await responseMessage.DeserializeAsync<AddressBalance>().ConfigureAwait(false);

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

            using var responseMessage = await _httpClient.SendAsync(requestMessage).ConfigureAwait(false);

            var dynamic = await responseMessage.DeserializeAsync<dynamic>().ConfigureAwait(false);

            return dynamic["archived"];
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

            using var responseMessage = await _httpClient.SendAsync(requestMessage).ConfigureAwait(false);

            var dynamic = await responseMessage.DeserializeAsync<dynamic>().ConfigureAwait(false);

            return dynamic["active"];
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
        /// <returns>A <see cref="Payment"/> instance</returns>
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

            using var responseMessage = await _httpClient.SendAsync(requestMessage).ConfigureAwait(false);

            var payment = await responseMessage.DeserializeAsync<Payment>().ConfigureAwait(false);

            return payment;
        }

        #region HD Account
        /// <summary>
        ///     This will upgrade a wallet to an HD (Hierarchical Deterministic) Wallet, which allows the use of accounts. See BIP32 for more information on HD wallets and accounts.
        /// </summary>
        public async Task EnableHDAsync()
        {
            var uri = UriHelper.BuildMerchantApi(_blockchainWalletConfiguration, "enableHD");

            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri.Uri);

            var responseMessage = await _httpClient.SendAsync(requestMessage).ConfigureAwait(false);
        }

        /// <summary>
        ///     Creates a new HD account
        /// </summary>
        /// <returns>A <see cref="NewHDAccount"/> instance</returns>
        public async Task<NewHDAccount> NewHDAccountAsync()
        {
            var uri = UriHelper.BuildMerchantApi(_blockchainWalletConfiguration, "accounts/create");

            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri.Uri);

            var responseMessage = await _httpClient.SendAsync(requestMessage).ConfigureAwait(false);

            var newHDAccount = await responseMessage.DeserializeAsync<NewHDAccount>().ConfigureAwait(false);

            return newHDAccount;
        }

        /// <summary>
        ///     Lists active HD accounts
        /// </summary>
        /// <returns>A <see cref="List{HDAccount}"/></returns>
        public async Task<List<HDAccount>> ActiveHDAccountsListAsync()
        {
            var uri = UriHelper.BuildMerchantApi(_blockchainWalletConfiguration, "accounts");

            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri.Uri);

            var responseMessage = await _httpClient.SendAsync(requestMessage).ConfigureAwait(false);

            var hdAccounts = await responseMessage.DeserializeAsync<List<HDAccount>>().ConfigureAwait(false);

            return hdAccounts;
        }

        /// <summary>
        ///     Lists HD xPubs
        /// </summary>
        /// <returns>A <see cref="List{string}"/> of HD xPubs</returns>
        public async Task<List<string>> HDxPubsListAsync()
        {
            var uri = UriHelper.BuildMerchantApi(_blockchainWalletConfiguration, "accounts/xpubs");

            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri.Uri);

            var responseMessage = await _httpClient.SendAsync(requestMessage).ConfigureAwait(false);

            var hdXPubs = await responseMessage.DeserializeAsync<List<string>>().ConfigureAwait(false);

            return hdXPubs;
        }

        /// <summary>
        ///     Gets single HD account
        /// </summary>
        /// <param name="xPubOrIndex">Account xPub or index</param>
        /// <returns>A <see cref="HDAccount"/> instance</returns>
        public async Task<HDAccount> GetHDAccount(string xPubOrIndex)
        {
            var uri = UriHelper.BuildMerchantApi(_blockchainWalletConfiguration, $"accounts/{xPubOrIndex}");

            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri.Uri);

            var responseMessage = await _httpClient.SendAsync(requestMessage).ConfigureAwait(false);

            var hdAccount = await responseMessage.DeserializeAsync<HDAccount>().ConfigureAwait(false);

            return hdAccount;
        }

        /// <summary>
        ///     Gets HD account receiving address
        /// </summary>
        /// <param name="xPubOrIndex">Account xPub or index</param>
        /// <returns>A <see cref="string"/> of the receiving address</returns>
        public async Task<string> HDAccountReceivingAddress(string xPubOrIndex)
        {
            var uri = UriHelper.BuildMerchantApi(_blockchainWalletConfiguration, $"accounts/{xPubOrIndex}/receiveAddress");

            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri.Uri);

            var responseMessage = await _httpClient.SendAsync(requestMessage).ConfigureAwait(false);

            var dynamic = await responseMessage.DeserializeAsync<dynamic>().ConfigureAwait(false);

            return dynamic["address"];
        }

        /// <summary>
        ///     Gets HD account balance
        /// </summary>
        /// <param name="xPubOrIndex">Account xPub or index</param>
        /// <returns>A <see cref="long"/> of HD account balance in satoshi</returns>
        public async Task<long> HDAccountBalance(string xPubOrIndex)
        {
            var uri = UriHelper.BuildMerchantApi(_blockchainWalletConfiguration, $"accounts/{xPubOrIndex}/balance");

            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri.Uri);

            var responseMessage = await _httpClient.SendAsync(requestMessage).ConfigureAwait(false);

            var dynamic = await responseMessage.DeserializeAsync<dynamic>().ConfigureAwait(false);

            return dynamic["balance"];
        }

        /// <summary>
        ///     Archives HD account
        /// </summary>
        /// <param name="xPubOrIndex">Account xPub or index</param>
        /// <returns>A <see cref="HDAccount"/> instance of the archived HD account</returns>
        public async Task<HDAccount> ArchiveHDAccount(string xPubOrIndex)
        {
            var uri = UriHelper.BuildMerchantApi(_blockchainWalletConfiguration, $"accounts/{xPubOrIndex}/archive");

            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri.Uri);

            var responseMessage = await _httpClient.SendAsync(requestMessage).ConfigureAwait(false);

            var hdAccount = await responseMessage.DeserializeAsync<HDAccount>().ConfigureAwait(false);

            return hdAccount;
        }

        /// <summary>
        ///     Unarchives HD account
        /// </summary>
        /// <param name="xPubOrIndex">Account xPub or index</param>
        /// <returns>A <see cref="HDAccount"/> instance of the unarchived HD account</returns>
        public async Task<HDAccount> UnarchiveHDAccount(string xPubOrIndex)
        {
            var uri = UriHelper.BuildMerchantApi(_blockchainWalletConfiguration, $"accounts/{xPubOrIndex}/unarchive");

            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri.Uri);

            var responseMessage = await _httpClient.SendAsync(requestMessage).ConfigureAwait(false);

            var hdAccount = await responseMessage.DeserializeAsync<HDAccount>().ConfigureAwait(false);

            return hdAccount;
        }
        #endregion
    }
}
