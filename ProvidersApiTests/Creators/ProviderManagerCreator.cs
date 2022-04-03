using ProviderApi.Services;
using Moq;

namespace ProvidersApiTests.Creators
{
    public static class ProviderManagerCreator
    {
        public static IProviderManager GetProviderAsyncSuccess(string providerId)
        {
            var providerManager = new Mock<IProviderManager>();
            providerManager.Setup(pm => pm.GetProviderAsync(It.IsAny<string>()))
                .ReturnsAsync(JsonProviderResponseCreator.With(providerId: providerId));

            return providerManager.Object;
        }
    }
}
