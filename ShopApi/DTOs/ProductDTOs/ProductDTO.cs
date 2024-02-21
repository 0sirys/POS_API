

namespace ShopApi.DTOs.ProductDTOs;

public class ProductDTO
{
    public string Name { get; set; } = null!;

    public decimal Cost { get; set; }

    public decimal Price { get; set; }

    public string? Code { get; set; }

    public bool Type { get; set; }
}