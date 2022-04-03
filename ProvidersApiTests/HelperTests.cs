using ProviderApi;
using NUnit.Framework;

namespace ProvidersApiTests
{
    public class HelperTests
    {
        [TestCase(1, 3, "", "", "page=1&perPage=3", TestName = "Optional query parameters not supplied")]
        [TestCase(100, 99, "foo", "bar", "page=100&perPage=99&region=foo&inspectionDirectorate=bar", TestName = "Optional query parameters not supplied")]
        [TestCase(1, 3, "North West", "", "page=1&perPage=3&region=North+West", TestName = "Optional query parameters not supplied")]
        public void Formats_query_string_correctly(
            int page, int perPage, string region, string inspectionDirectorate, string expectedResult)
        {
            var result = Helper.CreateProvidersQuery(page, perPage, region, inspectionDirectorate);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
