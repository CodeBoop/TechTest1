using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Xunit;


namespace TechTest1.Test
{
    public abstract  class BaseControllerTest : IClassFixture<WebApplicationFactory<TechTest1.Startup>>
    {

        protected HttpClient Client { get; }

        protected BaseControllerTest(WebApplicationFactory<TechTest1.Startup> fixture)
        {
            Client = fixture.CreateClient();
        }


        protected async Task<T> Get<T>(string url)
        {
            var response = await Client.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }


    }
}
