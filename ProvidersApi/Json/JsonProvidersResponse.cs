using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProviderApi.Json
{
    public class JsonProvidersResponse
    {
        public JsonProvidersResponse(
            int? page = null,
            int? perPage = null,
            int? totalPages = null,
            int? total = null,
            IReadOnlyCollection<JsonProviderResponse> providers = null)
        {
            Providers = providers;
            Page = page;
            PerPage = perPage;
            TotalPages = totalPages;
            Total = total;
        }

        [JsonProperty]
        public IReadOnlyCollection<JsonProviderResponse> Providers { get; }

        [JsonProperty]
        public int? Page { get; }

        [JsonProperty]
        public int? PerPage { get; }

        [JsonProperty]
        public int? TotalPages { get; }

        [JsonProperty]
        public int? Total { get; }
    }
}
