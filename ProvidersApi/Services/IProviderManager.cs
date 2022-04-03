using ProviderApi.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProviderApi.Services
{
    public interface IProviderManager
    {
        Task<JsonProviderResponse> GetProviderAsync(string providerId);

        Task<JsonProvidersResponse> GetProvidersAsync(string queryString);
    }
}
