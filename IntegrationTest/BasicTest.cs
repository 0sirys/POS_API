using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using ShopApi.DTOs.ProductDTOs;
namespace IntegrationTest;

public class BasicTest(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
{

    [Theory]
    [InlineData("api/Products")]
    [InlineData("api/Users")]
    [InlineData("api/Invoices")]
    public async Task Get_EndPointReturnSuccesActionResultProductsList(string url)
    {
        //ARRANGE

        var client = factory.CreateClient();
        //ACT
        var response = await client.GetAsync(url);
        //ASSERT
        response.EnsureSuccessStatusCode();


    }
}