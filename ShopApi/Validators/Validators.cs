using FluentValidation;
using ShopApi.DTOs.ProductDTOs;
using ShopApi.DTOs.UserDTOs;
using ShopApi.Models;
namespace ShopApi;


public class UserValidator : AbstractValidator<UserDTO>
{
    public UserValidator()
    {
        RuleFor(U => U.Name).NotEmpty().NotNull();
        RuleFor(U => U.Contry).NotEmpty().NotNull();
        RuleFor(U => U.Phone).NotEmpty();
        RuleFor(U => U.Date).NotNull();
    }
}

public class ProductValidator : AbstractValidator<ProductDTO>
{
    public ProductValidator()
    {

    }
}
