
using EndPointsTest.Objects.Products;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using ShopApi.Controllers;
using ShopApi.DTOs.ProductDTOs;
using ShopApi.Interface;

namespace EndPointsTest;

public class ProductEndPointTest
{
    [Fact]
    public async void ADD_EndPoint__Return_Especific_Product()
    {
        ProductsDTOTest products = new();

        //ARRANGE
        IService<ProductDTO, string> Service = Substitute.For<IService<ProductDTO, string>>();
        Service.Add(products.DTOin).Returns(Task.FromResult(products.DTOOut));


        //ACT
        ProductController controller = new(Service);
        var response = await controller.Add(products.DTOin);
        var result = response.Result.As<OkObjectResult>();
        //ASSERT
        Assert.Equivalent(products.DTOOut, result.Value);
    }

    [Fact]
    public async void GET_EndPoint_Return_Product_By_Code()
    {
        //Arrange
        ProductsDTOTest products = new();
        IEnumerable<ProductDTO?> lst = [products.DTOOut];
        IService<ProductDTO, string> Service = Substitute.For<IService<ProductDTO, string>>();
        Service.Get("111").Returns(Task.FromResult(lst)!);


        //ACT
        ProductController controller = new(Service);
        var response = await controller.GetResult("111");
        var parse = response.Result.As<OkObjectResult>().Value.As<IEnumerable<ProductDTO>>();
        //ASSERT
        Assert.Contains(products.DTOOut, parse);

    }

    [Fact]
    public async void Update_EndPoint_Return_Upgraded_Product()
    {

        //ARRANGE
        ProductsDTOTest products = new();
        IService<ProductDTO, string> Service = Substitute.For<IService<ProductDTO, string>>();
        Service.Update(products.DTOin).Returns(Task.FromResult(products.DTOOut));

        //ACT
        ProductController controller = new(Service);
        var test = await controller.Update(products.DTOin);
        var parse = test.Result.As<OkObjectResult>().Value.As<ProductDTO>();
        //ASSERT
        Assert.Equivalent(products.DTOOut, parse);
    }
    [Fact]
    public async void Delete_EndPoint_Return_Deleted_Product()
    {
        //ARRANGE
        ProductsDTOTest products = new();
        IService<ProductDTO, string> Service = Substitute.For<IService<ProductDTO, string>>();
        Service.Delete(products.DTOin).Returns(Task.FromResult(products.DTOOut));
        ProductController controller = new(Service);
        //ACT
        var test = await controller.Delete(products.DTOin);
        var parse = test.Result.As<OkObjectResult>().Value.As<ProductDTO>();

        //ASSERT
        Assert.Equivalent(products.DTOOut, parse);

    }

}