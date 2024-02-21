namespace ShopApi.DTOs.InvoiceDTOs;

public class DueInvoiceDTO{
     public int Id { get; set; }

    public int? IdUser { get; set; }

    public long Code { get; set; }

    public string LProducts { get; set; } = null!;

    public int CountProducts { get; set; }

    public DateTime Date { get; set; }

    public decimal Subtotal { get; set; }

    public decimal Itbs { get; set; }

    public decimal Total { get; set; }

    public bool Type { get; set; }

    public DateTime? DueDate { get; set; }

    public int? Customer { get; set; }
}