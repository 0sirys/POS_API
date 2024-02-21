namespace ShopApi.DTOs.GeneratorDTO;


public class ExO
{

    public long Code { get; set; }
    public decimal Subtotal { get; set; }
    public decimal Itbs { get; set; }
    public decimal Total { get; set; }
    public decimal Payment { get; set; }
    public DateTime Date { get; set; }
    public string? Customer { get; set; }
    public bool Type { get; set; }


}