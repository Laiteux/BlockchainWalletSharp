using Newtonsoft.Json;
using System.Collections.Generic;

namespace BlockchainWalletSharp.Models
{
    public class AddressList
    {
        /// <summary>
        ///     A list of <see cref="AddressInfos"/>
        /// </summary>
        [JsonProperty("addresses")]
        public List<AddressInfos> Addresses { get; set; }
    }

    public class AddressInfos
    {
        /// <summary>
        ///     The address balance in satoshis
        /// </summary>
        [JsonProperty("balance")]
        public long Balance { get; set; }

        /// <summary>
        ///     The address string
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; }

        /// <summary>
        ///     The address label, if any
        /// </summary>
        [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
        public string Label { get; set; }

        /// <summary>
        ///    The address all time received satoshis
        /// </summary>
        [JsonProperty("total_received")]
        public long TotalReceived { get; set; }
    }
}
