using Newtonsoft.Json;
using System.Collections.Generic;

namespace BlockchainWalletSharp.Models.Response
{
    public class NewHDAccount
    {
        [JsonProperty("address_labels")]
        public List<string> AddressLabels { get; set; }

        [JsonProperty("archived")]
        public bool Archived { get; set; }

        [JsonProperty("cache")]
        public HDAccountCache Cache { get; set; }

        [JsonProperty("xpriv")]
        public string XPriv { get; set; }

        [JsonProperty("xpub")]
        public string XPub { get; set; }
    }

    public class HDAccountCache
    {
        [JsonProperty("changeAccount")]
        public string ChangeAccount { get; set; }

        [JsonProperty("receiveAccount")]
        public string ReceiveAccount { get; set; }
    }
}
