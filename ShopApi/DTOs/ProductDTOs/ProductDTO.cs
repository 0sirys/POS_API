

namespace ShopApi.DTOs.ProductDTOs;

public class ProductDTO
{
    public string Name { get; set; } = null!;

    public decimal Cost { get; set; }

    public decimal Price { get; set; }

    public long Code { get; set; }

    public bool Type { get; set; }
}