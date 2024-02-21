using Riok.Mapperly.Abstractions;
using ShopApi.DTOs.GeneratorDTO;
using ShopApi.DTOs.InvoiceDTOs;
using ShopApi.DTOs.ProductDTOs;
using ShopApi.DTOs.UserDTOs;
using ShopApi.Models;

namespace ShopApi.Mappers;
[Mapper]
public partial class ProductDTOToEntity
{
    [MapperIgnoreTarget(nameof(@Product.Id))]
    public partial Product Mapp(ProductDTO Source);

}

[Mapper]
public partial class UserDTOToEntity
{
    [MapperIgnoreTarget(nameof(@User.Id))]

    public partial User Mapp(UserDTO Source);
}

[Mapper]
public partial class InvoiceDTOToEntity
{
    [MapperIgnoreTarget(nameof(@Invoice.Id))]
    [MapperIgnoreTarget(nameof(@Invoice.IdUserNavigation))]
    [MapperIgnoreTarget(nameof(@Invoice.CustomerNavigation))]
    [MapperIgnoreTarget(nameof(@Invoice.IdUser))]
    [MapperIgnoreTarget(nameof(@Invoice.Customer))]
    [MapperIgnoreSource(nameof(@InvoiceDTO.User))]
    [MapperIgnoreSource(nameof(@InvoiceDTO.Customer))]

    public partial Invoice Mapp(InvoiceDTO Source);
}

[Mapper]
public partial class EntityToUserDTO
{
    [MapperIgnoreSource(nameof(@User.Id))]


    public partial UserDTO Mapp(User Source);
}

[Mapper]
public partial class EntityToInvoiceDTO
{
    [MapperIgnoreSource(nameof(@Invoice.Id))]
    [MapperIgnoreSource(nameof(@Invoice.IdUser))]
    [MapperIgnoreSource(nameof(@Invoice.Customer))]
    [MapProperty(nameof(@Invoice.CustomerNavigation.Name), nameof(@InvoiceDTO.Customer))]
    [MapProperty(nameof(@Invoice.IdUserNavigation.Name), nameof(@InvoiceDTO.User))]

    public partial InvoiceDTO Mapp(Invoice Source);
}
[Mapper]
public partial class EntityToProducDTO
{
    [MapperIgnoreSource(nameof(@Product.Id))]
    public partial ProductDTO Mapp(Product Source);

}
[Mapper]
public partial class EntityToExODTO
{

    [MapperIgnoreSource(nameof(@Invoice.Id))]
    [MapperIgnoreSource(nameof(@Invoice.CountProducts))]
    [MapperIgnoreSource(nameof(@Invoice.CustomerNavigation))]
    [MapperIgnoreSource(nameof(@Invoice.IdUserNavigation))]
    [MapperIgnoreSource(nameof(@Invoice.IdUser))]
    [MapperIgnoreSource(nameof(@Invoice.LProducts))]
    [MapperIgnoreSource(nameof(@Invoice.DueDate))]

    public partial ExO Mapp(Invoice entity);
}