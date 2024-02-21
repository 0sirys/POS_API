using System;
using System.Collections.Generic;

namespace ShopApi.Models;

public partial class DayReport
{
    public int Id { get; set; }

    public string Invoice { get; set; } = null!;

    public decimal Itbs { get; set; }

    public decimal Total { get; set; }

    public DateTime Date { get; set; }

    public string Code { get; set; } = null!;
}
