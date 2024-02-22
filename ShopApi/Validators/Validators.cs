using System.Data;
using FluentValidation;
using ShopApi.DTOs.InvoiceDTOs;
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
        RuleFor(P => P.Cost).NotEmpty().NotNull().GreaterThan(0);
        RuleFor(P => P.Price).NotEmpty().NotNull().GreaterThan(0);
        RuleFor(P => P.Code).NotEmpty().NotNull().GreaterThan(0);
        RuleFor(P => P.Name).NotEmpty().NotNull();
        RuleFor(P => P.Type).NotEmpty().NotNull();


    }
}

public class InvoiceValidator : AbstractValidator<InvoiceDTO>
{
    public InvoiceValidator()
    {
        RuleFor(I => I.Code).NotEmpty().NotNull().GreaterThan(0);
        RuleFor(I => I.Total).NotEmpty().NotNull().GreaterThan(0);
        RuleFor(I => I.Subtotal).NotEmpty().NotNull().GreaterThan(0);
        RuleFor(I => I.Itbs).NotEmpty().NotNull().GreaterThan(0);
        RuleFor(I => I.Customer).NotEmpty().NotNull();
        RuleFor(I => I.User).NotEmpty().NotNull();
        RuleFor(I => I.Date).NotNull();
        RuleFor(I => I.DueDate).NotNull();
        RuleFor(I => I.CountProducts).NotNull().GreaterThanOrEqualTo(1);
        RuleFor(I => I.LProducts).NotNull().NotEmpty();


    }

}
