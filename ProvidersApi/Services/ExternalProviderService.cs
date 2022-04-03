using System.Threading.Tasks;
using System.Net.Http;

namespace ProviderApi.Services
{
    public class ExternalProviderService : IExternalProviderService
    {
        private readonly HttpClient client;

        public ExternalProviderService(HttpClient httpClient)
        {
            client = httpClient;
        }

        public async Task<string> GetProviderStringAsync(string providerId)
        {
            var url = $"{client.BaseAddress}/v1/providers/{providerId}";

            return await CallExternalApi(url);
        }

        public async Task<string> GetProviderIds(string queryString)
        {
            var url = $"{client.BaseAddress}/v1/providers?{queryString}";

            return await CallExternalApi(url);
        }

        private async Task<string> CallExternalApi(string url)
        {
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();

            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }
        }
    }
}
