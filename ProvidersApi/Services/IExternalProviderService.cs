using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProviderApi.Services
{
    public interface IExternalProviderService
    {
        Task<string> GetProviderIds(string queryString);

        Task<string> GetProviderStringAsync(string providerId);
    }
}
