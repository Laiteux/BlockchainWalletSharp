using System.Text.Json.Serialization;

namespace BlockchainWalletSharp.Models.Response
{
    public class NewAddress
    {
        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("label")]
        public string Label { get; set; }
    }
}
