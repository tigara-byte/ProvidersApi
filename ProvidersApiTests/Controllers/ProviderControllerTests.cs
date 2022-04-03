using ProviderApi.Controllers;
using ProviderApi.Json;
using ProvidersApiTests.Creators;
using NUnit.Framework;
using System.Threading.Tasks;

namespace ProvidersApiTests.Controllers
{
    public class ProviderControllerTests
    {
        // ToDo: flesh this test out further, checking that the full object is returned, currently only checks the id
        [TestCase("foobar")]
        [TestCase("1-000585")]
        public async Task Returns_Provider_response_when_provider_manager_returns_successfully(string providerId)
        {
            var providerManager = ProviderManagerCreator.GetProviderAsyncSuccess(providerId);

            var controller = new ProvidersController(providerManager);

            JsonProviderResponse result = await controller.GetProviderAsync(providerId);

            Assert.That(result.ProviderId, Is.EqualTo(providerId));
        }

        // Tests to add
        //    Returns_Providers_response_when_provider_manager_returns_successfully
        //        Test cases here: no query parameters supplied
        //        Test cases here: have all supplied
        //        Test cases here: have different paramater values supplied

        // Obviously the production code is all "happy path" so discussions on what (if any) failure paths to
        // have and how they wished to be returned to the users.
    }
}
