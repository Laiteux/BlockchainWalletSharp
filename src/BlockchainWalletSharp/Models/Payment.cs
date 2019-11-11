using Newtonsoft.Json;
using System.Collections.Generic;

namespace BlockchainWalletSharp.Models
{
    public class Payment
    {
        /// <summary>
        ///     A list of the recipients Bitcoin addresses
        /// </summary>
        [JsonProperty("to")]
        public List<string> To { get; set; }

        /// <summary>
        ///     A list of the senders Bitcoin addresses
        /// </summary>
        [JsonProperty("from")]
        public List<string> From { get; set; }

        /// <summary>
        ///     A list of the sent amounts in satoshi
        /// </summary>
        [JsonProperty("amounts")]
        public List<long> Amounts { get; set; }

        /// <summary>
        ///     The transaction fee
        /// </summary>
        [JsonProperty("fee")]
        public long Fee { get; set; }

        /// <summary>
        ///     The transaction id/hash
        /// </summary>
        [JsonProperty("txid")]
        public string TXID { get; set; }

        /// <summary>
        ///     If the transaction has been pushed
        /// </summary>
        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}
