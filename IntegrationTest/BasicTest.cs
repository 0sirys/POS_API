
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
namespace IntegrationTest;

public class BasicTest(CustomWebApplicationFactory<Program> factory) : IClassFixture<CustomWebApplicationFactory<Program>>
{


    [Fact]
    public async Task Get_EndPointReturnSuccesActionResultProductsList()
    {

        //ARRANGE

        var client = factory.CreateClient(new WebApplicationFactoryClientOptions());
        //ACT
        var response = await client.GetAsync("api/Products");
        //ASSERT
        response.EnsureSuccessStatusCode();


    }
}