using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using ShopApi.DTOs.InvoiceDTOs;
using ShopApi.Interface;
namespace ShopApi.Controllers;

[Route("api/Invoices")]
[ApiController]
public class InvoiceController(IService<InvoiceDTO, long> Service, IGenerator generator) : ControllerBase
{
    [HttpGet]

    public async Task<ActionResult<IEnumerable<InvoiceDTO>>> GetInvoice([FromHeader] long Code = 0)
    {
        if (Code > 0)
        {
            var response = await Service.Get(Code);
            return response == null ? NotFound(Code) : Ok(response);

        }
        return BadRequest();

    }

    [HttpGet("Report")]
    public async Task<IActionResult> Report(DateTime date)
    {

        var data = await generator.DailyReport();
        Response.Headers.Append("Content-Disposition", $"Attachment; Filename ={data.Path}");
        Response.Headers.Append("Content-Type", "application/octet-stream}");


        return data == (null, null) ? NotFound() : Ok(data.file);



    }


    [HttpPost]
    public async Task<ActionResult<InvoiceDTO>> AddInvoice([FromBody] InvoiceDTO invoice)
    {
        var response = await Service.Add(invoice);
        return response == null ? BadRequest() : Ok(response);
    }


}