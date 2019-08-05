using CleanArchitecture.Core.Entities;
using CleanArchitecture.Web;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.Tests.Integration.Web
{
    public class ApiReasonController : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public ApiReasonController(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        /// <summary>
        /// Test the Get API
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ReturnsTwoItems()
        {
            //Arrange
            var response = await _client.GetAsync("/api/reasons");

            //Act
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<Reason>>(stringResponse).ToList();

            //Assert
            Assert.Equal(2, result.Count());
            Assert.Equal(1, result.Count(a => a.Description == "Description Test 1"));
            Assert.Equal(1, result.Count(a => a.Description == "Description Test 2"));
        }

    }
}
