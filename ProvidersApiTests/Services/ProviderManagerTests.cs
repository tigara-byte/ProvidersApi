namespace ProvidersApiTests.Services
{
    public class ProviderManagerTests
    {
        // The most interesting of the test classes, and I should stop for the moment.

        // ToD: Create creator methods for the IDistributedCache methods & IExternalProviderService

        // Tests for GetProvierAsunc
        //    When cache returns an empty string for key: providerId
        //          the external providerServices's GetProviderString is called with expected values
        //          the cache has SetStringAsync called with expected values
        //          the expected JsonProviderResponse is returned
        //    When cache finds a record for key: providerId
        //          the external providerServices's GetProviderString is NOT called
        //          the cache does NOT have SetStringAsync called
        //          the expected JsonProviderResponse is returned

        // Tests for GetProvidersAsync
        //    When cache returns an empty string for key: queryString
        //          the external providerServices's GetProviderIds is called with expected values
        //          for each providerId returned the cache is called
        //          for each cache call per key: provierId if the call
        //              returns a record then SetStringAsync is not called
        //              returns an empty string then SetStringAsync is called
        //          the cache has SetStringAsync for key: queryString with expected values
        //          the expected JsonProvidersResponse is returned
        //    When cache returns a value for key: queryString
        //          the external providerServices's GetProviderIds is NOT called
        //          the cache does NOT have SetStringAsync called at all
        //          the expected JsonProviderResponse is returned
    }
}
