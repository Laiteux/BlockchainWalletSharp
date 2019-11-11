using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlockchainWalletSharp.Extensions
{
    internal static class HttpResponseMessageExtensions
    {
        public static async Task<T> DeserializeAsync<T>(this HttpResponseMessage responseMessage)
        {
            using var content = responseMessage.Content;

            var contentString = await content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonConvert.DeserializeObject<T>(contentString);
        }
    }
}
