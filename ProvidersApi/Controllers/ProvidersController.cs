using ProviderApi.Json;
using ProviderApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ProviderApi.Controllers
{
    [ApiController]
    [Route("v1/providers")]
    public class ProvidersController : ControllerBase
    {
        private readonly IProviderManager providerManager;

        public ProvidersController(IProviderManager providerManager)
        {
            this.providerManager = providerManager;
        }

        /// <summary>
        /// Gets a collection of paged providers with optional query parameters
        /// </summary>
        /// <param name="region"></param>
        /// <param name="inspectionDirectorate"></param>
        /// <param name="page"></param>
        /// <param name="perPage"></param>
        /// <response code="200">Providers were returned successfully</response> 
        [HttpGet]
        public async Task<JsonProvidersResponse> GetProvidersAsync(
            [FromQuery] string region,
            [FromQuery] string inspectionDirectorate,
            [FromQuery] int page = 1,
            [FromQuery] int perPage = 100)
        {
            var queryString = Helper.CreateProvidersQuery(
                page: page, perPage: perPage, region: region, inspectionDirectorate: inspectionDirectorate);

            return await this.providerManager.GetProvidersAsync(queryString);
        }

        /// <summary>
        /// Get provider with providerId
        /// </summary>
        /// /// <param name="providerId"></param>
        /// <response code="200">Provider was returned successfully</response> 
        [Route("{providerId}")]
        [HttpGet]
        public async Task<JsonProviderResponse> GetProviderAsync([FromRoute] string providerId)
        {
            return await this.providerManager.GetProviderAsync(providerId);
        }
    }
}
