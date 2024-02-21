using ShopApi.DTOs.ProductDTOs;
using ShopApi.Interface;
using ShopApi.Mappers;
using ShopApi.Models;



namespace ShopApi.Services;

public class ProductServices(ICRUD<Product, long> repository) : IService<ProductDTO, long>
{
    private readonly EntityToProducDTO _ToDTO = new();
    private readonly ProductDTOToEntity _ToEntity = new();
    public async Task<ProductDTO> Add(ProductDTO source)
    {
        var product = _ToEntity.Mapp(source);
        await repository.Add(product);
        await repository.Save();
        return _ToDTO.Mapp(product);
    }

    public async Task<ProductDTO> Delete(ProductDTO source)
    {
        var product = _ToEntity.Mapp(source);
        repository.Erase(product);
        await repository.Save();
        return _ToDTO.Mapp(product);
    }

    public async Task<IEnumerable<ProductDTO>> Get(long Key)
    {
        var query = await repository.Get(Key);
        var response = query.Select(b => _ToDTO.Mapp(b)).ToList();
        return response;
    }



    public async Task<ProductDTO> Update(ProductDTO source)
    {
        var product = _ToEntity.Mapp(source);
        repository.Edit(product);
        await repository.Save();
        return _ToDTO.Mapp(product);
    }


}