using FluentAssertions;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace NetCore2.IntegrationTests.Controllers
{
    [TestClass]
    public class ValuesControllerTests
    {
        private readonly TestServer testServer;
        private readonly HttpClient httpClient;

        public ValuesControllerTests()
        {
            var webHostBuilder = WebHost.CreateDefaultBuilder()
                                        .UseStartup<Startup>();

            testServer = new TestServer(webHostBuilder);
            httpClient = testServer.CreateClient();
        }

        [TestMethod]
        public void Given_Id_Returns_Player_Name()
        {
            ////http://localhost:6008/api/Values/5

            var response = httpClient.GetAsync("api/Values/5").Result;      //it works
            //var response = httpClient.GetAsync("api/values/5").Result;      //it works
            //var response = httpClient.GetAsync("api/Values?id=5").Result;   //it works                        

            //Assert
            Assert.IsTrue((int)response.StatusCode == 200);

            //FluentAssertions
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task Given_Id_Returns_Player_Name_Async()
        {
            ////http://localhost:6008/api/Values/5

            var response = httpClient.GetAsync("api/Values/5").Result;      //it works
            //var response = httpClient.GetAsync("api/values/5").Result;      //it works
            //var response = httpClient.GetAsync("api/Values?id=5").Result;   //it works

            //Assert
            Assert.IsTrue((int)response.StatusCode == 200);

            //FluentAssertions
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
