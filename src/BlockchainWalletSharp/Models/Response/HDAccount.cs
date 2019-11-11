using Newtonsoft.Json;

namespace BlockchainWalletSharp.Models.Response
{
    public class HDAccount
    {
        [JsonProperty("archived")]
        public bool Archived { get; set; }

        [JsonProperty("balance")]
        public long Balance { get; set; }

        [JsonProperty("extendedPrivateKey")]
        public string ExtendedPrivateKey { get; set; }

        [JsonProperty("extendedPublicKey")]
        public string ExtendedPublicKey { get; set; }

        [JsonProperty("index")]
        public long Index { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("lastUsedReceiveIndex")]
        public long? LastUsedReceiveIndex { get; set; }

        [JsonProperty("receiveAddress")]
        public string ReceiveAddress { get; set; }

        [JsonProperty("receiveIndex")]
        public long ReceiveIndex { get; set; }
    }
}
