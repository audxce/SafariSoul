using System;
using System.Collections.Generic;
using SafariSoul.Models;

namespace SafariSoul;

public partial class Vendor
{
    public int VendorId { get; set; }

    public string? VendorName { get; set; }

    public string? ProductsAndServices { get; set; }

    public string? ContractInformation { get; set; }

    public virtual ICollection<Expense> Expenses { get; } = new List<Expense>();

    public virtual ICollection<Inventory> Inventories { get; } = new List<Inventory>();
}
