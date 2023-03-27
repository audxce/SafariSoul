using System;
using System.Collections.Generic;

namespace SafariSoul.Models;

public partial class Inventory
{
    public int ItemId { get; set; }

    public string ItemName { get; set; } = null!;

    public string? ItemDescription { get; set; }

    public double? Price { get; set; }

    public string Category { get; set; } = null!;

    public int Destination { get; set; }

    public string RefrigerationNeeds { get; set; } = null!;

    public string? HumidityRequirements { get; set; }

    public float Quantity { get; set; }

    public string MeasurementUnits { get; set; } = null!;

    public float? ReorderThreshold { get; set; }

    public float? ReorderQuantity { get; set; }

    public int Supplier { get; set; }

    public DateOnly? DateLastOrdered { get; set; }

    public virtual Location DestinationNavigation { get; set; } = null!;

    public virtual ICollection<ExhibitFeedingSchedule> ExhibitFeedingSchedules { get; } = new List<ExhibitFeedingSchedule>();

    public virtual ICollection<ExpenseItem> ExpenseItems { get; } = new List<ExpenseItem>();

    public virtual Vendor SupplierNavigation { get; set; } = null!;

    public virtual ICollection<ZooEventRequiredInventory> ZooEventRequiredInventories { get; } = new List<ZooEventRequiredInventory>();

    public virtual ICollection<ZooTransactionItem> ZooTransactionItems { get; } = new List<ZooTransactionItem>();
}
