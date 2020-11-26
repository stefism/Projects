using Microsoft.AspNetCore.Mvc.Testing;
using MyFirstAspNetCoreApplication;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace MyApp.Tests
{
    // Microsoft.AspNetCore.Mvc.Testing
    public class WebTests
    {
        [Fact]
        public async Task HomePageShouldContainModelName()
        {
            var webApplicationFactory = new WebApplicationFactory<Startup>();
            HttpClient client = webApplicationFactory.CreateClient();

            var response = await client.GetAsync("/");
            response.EnsureSuccessStatusCode();

            var html = await response.Content.ReadAsStringAsync();

            Assert.Contains("<h1 class=\"display-4\">Welcome, Stefan</h1>", html);
        }

        [Fact]
        public async Task HomePageShouldContainHeaderXPoweredBy()
        {
            var webApplicationFactory = new WebApplicationFactory<Startup>();
            HttpClient client = webApplicationFactory.CreateClient();

            var response = await client.GetAsync("/");          

            Assert.True(response.Headers.Contains("x-powered-by"));
        }

        [Fact]
        public async Task FormTest()
        {
            var webApplicationFactory = new WebApplicationFactory<Startup>();
            HttpClient client = webApplicationFactory.CreateClient();

            var response = await client.GetAsync("/");

            //client.PostAsync("/Recipes/Add", new FormUrlEncodedContent());
            
            await client.PostAsync("/Recipes/Add", new StringContent("{}"));
        }
    }
}
