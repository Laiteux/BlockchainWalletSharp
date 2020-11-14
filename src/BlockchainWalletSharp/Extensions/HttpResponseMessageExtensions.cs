using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlockchainWalletSharp.Extensions
{
    internal static class HttpResponseMessageExtensions
    {
        internal static async Task<T> DeserializeJsonAsync<T>(this HttpResponseMessage responseMessage)
        {
            var contentString = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonSerializer.Deserialize<T>(contentString);
        }
    }
}
