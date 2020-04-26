using System.Text.Json.Serialization;

namespace BlockchainWalletSharp.Models.Response
{
    public class HDAccount
    {
        [JsonPropertyName("archived")]
        public bool Archived { get; set; }

        [JsonPropertyName("balance")]
        public long Balance { get; set; }

        [JsonPropertyName("extendedPrivateKey")]
        public string ExtendedPrivateKey { get; set; }

        [JsonPropertyName("extendedPublicKey")]
        public string ExtendedPublicKey { get; set; }

        [JsonPropertyName("index")]
        public long Index { get; set; }

        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("lastUsedReceiveIndex")]
        public long? LastUsedReceiveIndex { get; set; }

        [JsonPropertyName("receiveAddress")]
        public string ReceiveAddress { get; set; }

        [JsonPropertyName("receiveIndex")]
        public long ReceiveIndex { get; set; }
    }
}
