using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SafariSoul.Models;

public partial class Inventory
{
    public int ItemId { get; set; }

    [DisplayName("Item Name")]
    public string ItemName { get; set; } = null!;

    public double? Price { get; set; }

    [DisplayName("Destination")]
    public int? Destination { get; set; }

    [DisplayName("Refrigeration Needs")]
    public string RefrigerationNeeds { get; set; } = null!;

    [DisplayName("Humidity Requirements")]
    public string? HumidityRequirements { get; set; }

    public int Quantity { get; set; }

    [DisplayName("Measurement Units")]
    public string MeasurementUnits { get; set; } = null!;

    [DisplayName("Reorder Threshold")]
    public int? ReorderThreshold { get; set; }

    [DisplayName("Reorder Quantity")]
    public int? ReorderQuantity { get; set; }

    public int? Supplier { get; set; }

    [DisplayName("Last Ordered")]
    public DateOnly? DateLastOrdered { get; set; }

    [DisplayName("Created At")]
    public DateTime? CreatedAt { get; set; }

    [DisplayName("Created At")]
    public DateTime? UpdatedAt { get; set; }

    [DisplayName("Destination")]
    public virtual Location? DestinationNavigation { get; set; } = null!;

    public virtual ICollection<Exhibit> Exhibits { get; } = new List<Exhibit>();

    public virtual ICollection<ExpenseItem> ExpenseItems { get; } = new List<ExpenseItem>();

    [DisplayName("Supplier")]
    public virtual Vendor? SupplierNavigation { get; set; } = null!;

    public virtual ICollection<ZooTransactionItem> ZooTransactionItems { get; } = new List<ZooTransactionItem>();
}
