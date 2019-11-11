using Newtonsoft.Json;

namespace BlockchainWalletSharp.Models.Response
{
    public class NewAddress
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
        public string Label { get; set; }
    }
}
