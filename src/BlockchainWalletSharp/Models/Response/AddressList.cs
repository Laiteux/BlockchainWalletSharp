using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BlockchainWalletSharp.Models.Response
{
    public class AddressList
    {
        [JsonPropertyName("addresses")]
        public List<AddressInfos> Addresses { get; set; }
    }

    public class AddressInfos
    {
        [JsonPropertyName("balance")]
        public long Balance { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("total_received")]
        public long TotalReceived { get; set; }
    }
}
