using Newtonsoft.Json;
using System.Collections.Generic;

namespace BlockchainWalletSharp.Models.Response
{
    public class Payment
    {
        [JsonProperty("to")]
        public List<string> To { get; set; }

        [JsonProperty("from")]
        public List<string> From { get; set; }

        [JsonProperty("amounts")]
        public List<long> Amounts { get; set; }

        [JsonProperty("fee")]
        public long Fee { get; set; }

        [JsonProperty("txid")]
        public string TXID { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}
