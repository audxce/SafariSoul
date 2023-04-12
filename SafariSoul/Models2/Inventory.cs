using System;
using System.Collections.Generic;

namespace SafariSoul.Models2;

public partial class Inventory
{
    public int ItemId { get; set; }

    public string ItemName { get; set; } = null!;

    public double? Price { get; set; }

    public int? Destination { get; set; }

    public string RefrigerationNeeds { get; set; } = null!;

    public string? HumidityRequirements { get; set; }

    public int Quantity { get; set; }

    public string MeasurementUnits { get; set; } = null!;

    public int? ReorderThreshold { get; set; }

    public int? ReorderQuantity { get; set; }

    public int? Supplier { get; set; }

    public DateOnly? DateLastOrdered { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Location? DestinationNavigation { get; set; }

    public virtual ICollection<Exhibit> Exhibits { get; } = new List<Exhibit>();

    public virtual ICollection<ExpenseItem> ExpenseItems { get; } = new List<ExpenseItem>();

    public virtual Vendor? SupplierNavigation { get; set; }

    public virtual ICollection<ZooTransactionItem> ZooTransactionItems { get; } = new List<ZooTransactionItem>();
}
