using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SafariSoul.Models;

public partial class ZooTransactionItem
{
    public int MultiItemsId { get; set; }

    [DisplayName("Transaction ID")]
    public int TransactionId { get; set; }

    [DisplayName("Item")]
    public int ItemId { get; set; }

    [DisplayName("Item Quantity")]
    public int? ItemQuantity { get; set; }

    [DisplayName("Created At")]
    public DateTime? CreatedAt { get; set; }

    [DisplayName("Updated At")]
    public DateTime? UpdatedAt { get; set; }

    public virtual Inventory Item { get; set; } = null!;

    public virtual ZooTransaction Transaction { get; set; } = null!;
}
