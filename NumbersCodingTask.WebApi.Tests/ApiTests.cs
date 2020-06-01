using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.SelfHost;

namespace NumbersCodingTask.WebApi.Tests
{
    // TODO: add tests that check return status codes for each endpoint
    // TODO: add tests that post single and batched path calculation requests and checks if path search history is returned correctly
    [TestFixture]
    public class ApiTests
    {
        [Test]
        [Ignore("Test not finished")]
        public async Task GetReturnsSuccessStatusCode()
        {
            string baseAddress = "https://localhost:5001";
            HttpSelfHostConfiguration configuration = new HttpSelfHostConfiguration(baseAddress);
            HttpSelfHostServer server = new HttpSelfHostServer(configuration); 
            using HttpClient client = new HttpClient(server);

            HttpResponseMessage response = await client.GetAsync("paths");

            Assert.That(
                response.IsSuccessStatusCode,
                Is.True
            );
        }
    }
}
