using ProviderApi.Json;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProviderApi.Services
{
    public class ProviderManager : IProviderManager
    {
        private readonly IExternalProviderService externalProviderService;
        private readonly IDistributedCache distributedCache;

        public ProviderManager(
            IExternalProviderService externalProviderService,
            IDistributedCache distributedCache)
        {
            this.externalProviderService = externalProviderService;
            this.distributedCache = distributedCache;
        }

        public async Task<JsonProviderResponse> GetProviderAsync(string providerId)
        {
            var providerAsString = await this.distributedCache.GetStringAsync(providerId);

            if (string.IsNullOrEmpty(providerAsString))
            {            
                var valueFromExternal = await this.externalProviderService.GetProviderStringAsync(providerId);
                await AddToCache(key: providerId, value: valueFromExternal);
                providerAsString = valueFromExternal;
            }

            return JsonConvert.DeserializeObject<JsonProviderResponse>(providerAsString);
        }

        public async Task<JsonProvidersResponse> GetProvidersAsync(string queryString)
        {
            var providersResponseCache = await this.distributedCache.GetStringAsync(queryString);

            if(!string.IsNullOrEmpty(providersResponseCache))
            {
                return JsonConvert.DeserializeObject<JsonProvidersResponse>(providersResponseCache);
            }

            var providerIdsPagedAsString = await this.externalProviderService.GetProviderIds(queryString);

            var providerIdsAndPaginationDetails = JsonConvert.DeserializeObject<JsonProvidersResponse>(providerIdsPagedAsString);
            var providers = new List<JsonProviderResponse>();

            foreach (var providerId in providerIdsAndPaginationDetails.Providers.Select(p => p.ProviderId))
            {
                var provider = await GetProviderAsync(providerId);
                providers.Add(provider);
            }

            var providersReponse = new JsonProvidersResponse(
                providers: providers.ToArray(),
                page: providerIdsAndPaginationDetails.Page,
                perPage: providerIdsAndPaginationDetails.PerPage,
                totalPages: providerIdsAndPaginationDetails.TotalPages,
                total: providerIdsAndPaginationDetails.Total);

            var providerResponseAsString = JsonConvert.SerializeObject(providersReponse);

            await AddToCache(key: queryString, value: providerResponseAsString);

            return providersReponse;
        }

        private async Task AddToCache(string key, string value)
        {
            DistributedCacheEntryOptions options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = Helper.CalculateAMonthFromNow()
            };

            await distributedCache.SetStringAsync(key: key, value: value, options);
        }
    }
}
