using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HA.DNS.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;

namespace DNS_HousingAnywhere.IntegrationTest
{
    public class DNSControllerTest : IClassFixture<WebApplicationFactory<DNS_HousingAnywhere.Startup>>
    {
        private readonly WebApplicationFactory<DNS_HousingAnywhere.Startup> _factory;

        public DNSControllerTest(
            WebApplicationFactory<DNS_HousingAnywhere.Startup> factory
            )
        {
            _factory = factory;
        }


        [Fact]
        public async Task ValidateGetBankLocationJsonResponse()
        {
            //Arrange
            var _client = _factory.CreateClient();
            string coordsString = "{'vel': '20.0','x': '123.12','y': '456.56','z': '789.89'}";
            var content = new StringContent(coordsString.ToString(), Encoding.UTF8, "application/json");

            //Actc
            var response = await _client.PostAsync("api/dns/banklocation", content);

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Console.Write(responseString.ToString());
            Assert.Contains("{\"loc\":1389.57}", responseString);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);


        }
    }
}
