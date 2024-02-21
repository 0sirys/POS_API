using EndPointsTest.Objects.Products;
using FluentAssertions;
using FluentValidation;
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
        IValidator<UserDTO> validator = Substitute.For<IValidator<UserDTO>>();
        repository.Add(user.userDTOInput).Returns(Task.FromResult(user.userDTOOutput));
        validator.Validate(user.userDTOInput).IsValid.Returns(true);
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
        IValidator<UserDTO> validator = Substitute.For<IValidator<UserDTO>>();
        validator.Validate(user.userDTOInput).IsValid.Returns(true);
        repository.Get(user.userDTOInput.Name).Returns(Task.FromResult(usercollection));
        //Act
        UserController controller = new(repository, validator);
        var response = await controller.GetUser(user.userDTOInput.Name);
        var cast = response.Result.As<OkObjectResult>().Value.As<IEnumerable<UserDTO>>()!;
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
        IValidator<UserDTO> validator = Substitute.For<IValidator<UserDTO>>();
        validator.Validate(user.userDTOInput).IsValid.Returns(true);
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
        repository.Delete(user.userDTOInput).Returns(Task.FromResult(user.userDTOOutput));
        IValidator<UserDTO> validator = Substitute.For<IValidator<UserDTO>>();
        validator.Validate(user.userDTOInput).IsValid.Returns(true);
        //Act
        UserController controller = new(repository,validator);
        var response = await controller.Delete(user.userDTOInput);
        var cast = response.Result.As<OkObjectResult>().Value.As<UserDTO>()!;
        //Assert
        Assert.Equivalent(user.userDTOOutput, cast);
    }


}