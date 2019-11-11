using Newtonsoft.Json;

namespace BlockchainWalletSharp.Models.Response
{
    public class AddressBalance
    {
        [JsonProperty("balance")]
        public long Balance { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("total_received")]
        public long TotalReceived { get; set; }
    }
}
