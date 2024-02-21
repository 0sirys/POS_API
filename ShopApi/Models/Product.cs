using System;
using System.Collections.Generic;

namespace ShopApi.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal? Cost { get; set; }

    public decimal? Price { get; set; }

    public long Code { get; set; }

    public bool? Type { get; set; }
}
