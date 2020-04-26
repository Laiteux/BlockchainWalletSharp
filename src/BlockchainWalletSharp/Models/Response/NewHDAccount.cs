using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BlockchainWalletSharp.Models.Response
{
    public class NewHDAccount
    {
        [JsonPropertyName("address_labels")]
        public List<string> AddressLabels { get; set; }

        [JsonPropertyName("archived")]
        public bool Archived { get; set; }

        [JsonPropertyName("cache")]
        public HDAccountCache Cache { get; set; }

        [JsonPropertyName("xpriv")]
        public string XPriv { get; set; }

        [JsonPropertyName("xpub")]
        public string XPub { get; set; }
    }

    public class HDAccountCache
    {
        [JsonPropertyName("changeAccount")]
        public string ChangeAccount { get; set; }

        [JsonPropertyName("receiveAccount")]
        public string ReceiveAccount { get; set; }
    }
}
