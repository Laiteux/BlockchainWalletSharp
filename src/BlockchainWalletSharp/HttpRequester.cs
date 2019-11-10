using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlockchainWalletSharp
{
    internal class HttpRequester
    {
        private readonly HttpClient _httpClient;

        public HttpRequester(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> SendAsync<T>(HttpRequestMessage httpRequestMessage)
        {
            using var responseMessage = await _httpClient.SendAsync(httpRequestMessage).ConfigureAwait(false);

            return await DeserializeResponseMessageAsync<T>(responseMessage).ConfigureAwait(false);
        }

        private async Task<T> DeserializeResponseMessageAsync<T>(HttpResponseMessage httpResponseMessage)
        {
            using var content = httpResponseMessage.Content;

            var contentString = await content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonConvert.DeserializeObject<T>(contentString);
        }
    }
}
