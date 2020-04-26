using System.Text.Json.Serialization;

namespace BlockchainWalletSharp.Models.Response
{
    public class AddressBalance
    {
        [JsonPropertyName("balance")]
        public long Balance { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("total_received")]
        public long TotalReceived { get; set; }
    }
}
