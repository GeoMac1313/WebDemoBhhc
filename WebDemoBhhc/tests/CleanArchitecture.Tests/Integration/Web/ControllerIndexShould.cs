using CleanArchitecture.Web;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.Tests.Integration.Web
{
    public class ControllerIndexShould : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public ControllerIndexShould(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task ReturnHomeViewWithCorrectMessage()
        {
            //Arrange
            HttpResponseMessage response = await _client.GetAsync("/");

            //Act
            response.EnsureSuccessStatusCode();
            string stringResponse = await response.Content.ReadAsStringAsync();

            //Assert
            Assert.Contains("BHHC Demo", stringResponse);
        }

        [Fact]
        public async Task ReturnMaintViewWithCorrectMessage()
        {
            //Arrange
            HttpResponseMessage response = await _client.GetAsync("/Maintenance");

            //Act
            response.EnsureSuccessStatusCode();
            string stringResponse = await response.Content.ReadAsStringAsync();

            //Assert
            Assert.Contains("Reason Maintenance", stringResponse);
        }

        [Fact]
        public async Task ReturnAboutViewWithCorrectMessage()
        {
            //Arrange
            HttpResponseMessage response = await _client.GetAsync("/About");

            //Act
            response.EnsureSuccessStatusCode();
            string stringResponse = await response.Content.ReadAsStringAsync();

            //Assert
            Assert.Contains("Resources Used for this Demo", stringResponse);
        }

    }
}
