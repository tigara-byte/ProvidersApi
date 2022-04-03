using ProviderApi.Json;
using System.Collections.Generic;

namespace ProvidersApiTests.Creators
{
    public static class JsonProvidersResponseCreator
    {
        public static JsonProvidersResponse Default() => With();

        public static JsonProvidersResponse WithSingleProvider(string providerId) =>
            With(providers: new[] { JsonProviderResponseCreator.With(providerId: providerId) });

        public static JsonProvidersResponse With(
            int? page = null,
            int? perPage = null,
            int? totalPages = null,
            int? total = null,
            IReadOnlyCollection<JsonProviderResponse> providers = null) =>
            new JsonProvidersResponse(
                page: page,
                perPage: perPage,
                totalPages: totalPages,
                total: total,
                providers: providers == null ? new[] { JsonProviderResponseCreator.Minimum() } : providers);
    }
}
