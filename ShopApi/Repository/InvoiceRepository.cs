using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using ShopApi.DTOs.InvoiceDTOs;
using ShopApi.DTOs.UserDTOs;
using ShopApi.Interface;
using ShopApi.Models;

namespace ShopApi.Repository;

public class InvoiceRepository(ShopContext context) : ICRUD<Invoice, long>
{
    public async Task Add(Invoice Source) => await context.Invoices.AddAsync(Source);

    public void Edit(Invoice Source)
    {
        context.Attach(Source);
        context.Entry(Source).State = EntityState.Modified;

    }
    public void Erase(Invoice Source)
    {
        context.Attach(Source);
        context.Entry(Source).State = EntityState.Deleted;
    }

    public async Task Save() => await context.SaveChangesAsync();

    public async Task<IEnumerable<Invoice>> Get(long Key) => await context.Invoices.Where(q => q.Code == Key).Select(b => b).ToListAsync();

    public Task<Invoice> Track(Invoice Source)
    {
        throw new NotImplementedException();
    }
}