using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTest;


public class CustomWebApplicationFactory<TProgram>
    : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.ConfigureHttpClientDefaults(p =>
            {
                p.ConfigureHttpClient(d => d.DefaultRequestHeaders.Add("Code", "111"));
            });
        });

        builder.UseEnvironment("Development");
    }
}