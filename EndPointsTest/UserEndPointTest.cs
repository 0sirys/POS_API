using EndPointsTest.Objects.Products;
using FluentAssertions;
using FluentValidation;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using ShopApi.Controllers;
using ShopApi.DTOs.UserDTOs;
using ShopApi.Interface;

namespace EndPointsTest;

public class UserEndPointTest
{

    [Fact]
    public async void UserAdd()
    {

        //Arrange
        UserDTOTest user = new();
        IService<UserDTO, string> repository = Substitute.For<IService<UserDTO, string>>();
        InlineValidator<UserDTO> validator = [];
        validator.RuleFor(x => x).Must(x => true);
        repository.Add(user.userDTOInput).Returns(Task.FromResult(user.userDTOOutput));
        //Act
        UserController controller = new(repository, validator);
        var response = await controller.Add(user.userDTOInput);
        var cast = response.Result.As<OkObjectResult>().Value.As<UserDTO>()!;
        //Assert
        Assert.Equivalent(user.userDTOOutput, cast);


    }



    [Fact]
    public async void Userget()
    {

        //Arrange
        UserDTOTest user = new();
        IEnumerable<UserDTO> usercollection = [user.userDTOOutput];
        IService<UserDTO, string> repository = Substitute.For<IService<UserDTO, string>>();
        InlineValidator<UserDTO> validator = [];
        validator.RuleFor(x => x).Must(x => true);
        repository.Get(user.userDTOInput.Name).Returns(Task.FromResult(usercollection));
        //Act
        UserController controller = new(repository, validator);
        var response = await controller.GetUser(user.userDTOInput.Name);
        var cast = response.Result.As<OkObjectResult>().Value.As<IEnumerable<UserDTO?>>();
        //Assert
        Assert.Contains(user.userDTOOutput, cast);

    }
    [Fact]
    public async void UserUpdate()
    {

        //Arrange
        UserDTOTest user = new();
        IEnumerable<UserDTO> usercollection = [user.userDTOOutput];
        IService<UserDTO, string> repository = Substitute.For<IService<UserDTO, string>>();
        repository.Update(user.userDTOInput).Returns(Task.FromResult(user.userDTOOutput));
        InlineValidator<UserDTO> validator = [];
        validator.RuleFor(x => x).Must(x => true);
        //Act
        UserController controller = new(repository, validator);
        var response = await controller.Update(user.userDTOInput);
        var cast = response.Result.As<OkObjectResult>().Value.As<UserDTO>()!;
        //Assert
        Assert.Equivalent(user.userDTOOutput, cast);

    }

    [Fact]
    public async void UserDelete()
    {

        //Arrange
        UserDTOTest user = new();
        IEnumerable<UserDTO> usercollection = [user.userDTOOutput];
        IService<UserDTO, string> repository = Substitute.For<IService<UserDTO, string>>();
        InlineValidator<UserDTO> validator = [];
        validator.RuleFor(x => x).Must(x => true);
        repository.Delete(user.userDTOInput).Returns(Task.FromResult(user.userDTOOutput));
        //Act
        UserController controller = new(repository, validator);
        var response = await controller.Delete(user.userDTOInput);
        var cast = response.Result.As<OkObjectResult>().Value.As<UserDTO>();
        //Assert
        Assert.Equivalent(user.userDTOOutput, cast);

    }


}