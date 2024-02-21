namespace ShopApi.DTOs.InvoiceDTOs;

public class InvoiceDTO
{

    public string User { get; set; } = null!;
    public long Code { get; set; }

    public string LProducts { get; set; } = null!;

    public int CountProducts { get; set; }

    public DateTime Date { get; set; }

    public decimal Subtotal { get; set; }

    public decimal Itbs { get; set; }

    public decimal Total { get; set; }

    public bool Type { get; set; }

    public DateTime DueDate { get; set; }

    public decimal Payment { get; set; }

    public string Customer { get; set; } = null!;
}