using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SafariSoul.Models;

public partial class Vendor
{
    public int VendorId { get; set; }

    [DisplayName("Vendor Name")]
    public string? VendorName { get; set; }

    [DisplayName("Products and Services")]
    public string? ProductsAndServices { get; set; }

    [DisplayName("Contract Information")]
    public string? ContractInformation { get; set; }

    [DisplayName("Created At")]
    public DateTime? CreatedAt { get; set; }

    [DisplayName("Updated At")]
    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Expense> Expenses { get; } = new List<Expense>();

    public virtual ICollection<Inventory> Inventories { get; } = new List<Inventory>();
}
