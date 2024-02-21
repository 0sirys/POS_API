using System;
using System.Collections.Generic;

namespace ShopApi.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Contry { get; set; }

    public string Phone { get; set; } = null!;

    public DateTime Date { get; set; }
}
