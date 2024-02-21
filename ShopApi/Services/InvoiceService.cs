using ShopApi.DTOs.InvoiceDTOs;
using ShopApi.Interface;
using ShopApi.Models;
using ShopApi.Mappers;

namespace ShopApi.Services;

public class InvoiceService(ICRUD<Invoice, long> repository) : IService<InvoiceDTO, long>
{
    private readonly EntityToInvoiceDTO _ToDTO = new();
    private readonly InvoiceDTOToEntity _ToEntity = new();

    public async Task<InvoiceDTO> Add(InvoiceDTO source)
    {
        var invoice = _ToEntity.Mapp(source);
        await repository.Add(invoice);
        await repository.Save();
        var check = await repository.Get(invoice.Code);
        return _ToDTO.Mapp(check.FirstOrDefault()!);

    }
    public async Task<InvoiceDTO> Delete(InvoiceDTO source)
    {
        var invoice = _ToEntity.Mapp(source);
        repository.Erase(invoice);
        await repository.Save();
        return _ToDTO.Mapp(invoice);
    }
    public async Task<IEnumerable<InvoiceDTO>> Get(long Key)
    {
        var invoice = await repository.Get(Key);
        var response = invoice.Select(b => _ToDTO.Mapp(b));

        return response;
    }
    public async Task<InvoiceDTO> Update(InvoiceDTO source)
    {
        var invoice = _ToEntity.Mapp(source);
        repository.Edit(invoice);
        await repository.Save();
        var check = await repository.Get(invoice.Code);
        return _ToDTO.Mapp(check.FirstOrDefault()!);
    }

}