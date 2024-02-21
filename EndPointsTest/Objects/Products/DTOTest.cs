using ShopApi.DTOs.InvoiceDTOs;
using ShopApi.DTOs.ProductDTOs;
using ShopApi.DTOs.UserDTOs;
using ShopApi.Models;

namespace EndPointsTest.Objects.Products;

public class ProductsDTOTest
{

    public readonly ProductDTO DTOin = new()
    {
        Code = "111",
        Cost = 300,
        Name = "DTOin",
        Price = (decimal)(300 * 1.35),
        Type = true
    };

    public readonly ProductDTO DTOOut = new()
    {
        Code = "111",
        Cost = 300,
        Name = "DTOOut",
        Price = (decimal)(300 * 1.35),
        Type = true
    };

}

public class UserDTOTest
{
    public readonly UserDTO userDTOInput = new()
    {

        Name = "Carlos",
        Contry = "+1",
        Phone = "8095582929",
        Date = DateTime.Today.Date

    };
    public readonly UserDTO userDTOOutput = new()
    {
        Name = "CarlosSalio",
        Contry = "+1",
        Phone = "8095582929",
        Date = DateTime.Today.Date
    };


}
public class InvoiceDTOTest
{
    public readonly InvoiceDTO invoiceDTOInput = new()
    {
        Code = 255,
        CountProducts = 2,
        Customer = "alvertico",
        User = "CarlosEntro",
        Itbs = 30,
        LProducts = "Json of Products",
        Subtotal = 50,
        Total = 80,
        Type = false,

    };
    public readonly InvoiceDTO invoiceDTOOtupt = new()
    {
        Code = 255,
        CountProducts = 2,
        Customer = "alvertico",
        User = "Carlossalio",
        Itbs = 30,
        LProducts = "Json of Products",
        Subtotal = 50,
        Total = 80,
        Type = false,

    };
    public readonly Invoice reportentity = new()
    {
        Id = 1,
        Code = 255,
        CountProducts = 2,
        Customer = 1,
        Date = DateTime.Today,
        DueDate = null,
        IdUser = 1,
        Itbs = 30,
        LProducts = "Json of Products",
        Subtotal = 50,
        Total = 80,
        Type = false,
        Payment = 0,

    };
}