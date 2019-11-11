using Newtonsoft.Json;
using System.Collections.Generic;

namespace BlockchainWalletSharp.Models.Response
{
    public class AddressList
    {
        [JsonProperty("addresses")]
        public List<AddressInfos> Addresses { get; set; }
    }

    public class AddressInfos
    {
        [JsonProperty("balance")]
        public long Balance { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("total_received")]
        public long TotalReceived { get; set; }
    }
}
