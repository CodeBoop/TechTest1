using System;
using System.Collections.Generic;
using System.Text;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechTest1.Test.Moq;

namespace TechTest1.Test
{
    public class ApplicationFactory : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                services.AddScoped(provider => new ProductServiceMoq().Object);
                services.AddScoped(provider => new CategoryServiceMoq().Object);
            });
        }
    }
}
