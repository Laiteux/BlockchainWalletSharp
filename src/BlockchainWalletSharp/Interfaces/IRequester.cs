using System.Net.Http;
using System.Threading.Tasks;

namespace BlockchainWalletSharp.Interfaces
{
    public interface IRequester
    {
        Task<T> SendAsync<T>(HttpClient httpClient, HttpRequestMessage httpRequestMessage);
    }
}
