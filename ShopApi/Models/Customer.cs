using System;
using System.Collections.Generic;

namespace ShopApi.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? LastName { get; set; }

    public string Dni { get; set; } = null!;

    public virtual ICollection<Invoice> InvoiceCustomerNavigations { get; set; } = new List<Invoice>();

    public virtual ICollection<Invoice> InvoiceIdUserNavigations { get; set; } = new List<Invoice>();
}
