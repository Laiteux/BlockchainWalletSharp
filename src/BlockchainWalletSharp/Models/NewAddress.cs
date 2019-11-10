using Newtonsoft.Json;

namespace BlockchainWalletSharp.Models
{
    public class NewAddress
    {
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
    }
}
