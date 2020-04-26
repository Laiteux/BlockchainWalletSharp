using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BlockchainWalletSharp.Models.Response
{
    public class Payment
    {
        [JsonPropertyName("to")]
        public List<string> To { get; set; }

        [JsonPropertyName("from")]
        public List<string> From { get; set; }

        [JsonPropertyName("amounts")]
        public List<long> Amounts { get; set; }

        [JsonPropertyName("fee")]
        public long Fee { get; set; }

        [JsonPropertyName("txid")]
        public string TXID { get; set; }

        [JsonPropertyName("success")]
        public bool Success { get; set; }
    }
}
