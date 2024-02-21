
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml.Export.ToCollection;
using ShopApi.Interface;
using ShopApi.Models;

namespace ShopApi.Repository;

public class ProductRepository(ShopContext context) : ICRUD<Product, long>
{
    public async Task Add(Product Source) => await context.Products.AddAsync(Source);
    public void Edit(Product Source)
    {
        context.Products.Attach(Source);
        context.Products.Entry(Source).State = EntityState.Modified;
    }

    public void Erase(Product Source)
    {
        context.Products.Attach(Source);
        context.Products.Entry(Source).State = EntityState.Deleted;
    }

    public async Task<IEnumerable<Product>> Get(long Key) => await context.Products.Where(b => b.Code==Key).Select(b => b).ToListAsync();

    public async Task Save()
    {
        await context.SaveChangesAsync();
    }

    public Task<Product> Track(Product Source)
    {
        throw new NotImplementedException();
    }
}