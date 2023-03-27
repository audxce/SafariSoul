using System;
using System.Collections.Generic;

namespace SafariSoul;

public partial class ZooTransactionItem
{
    public int TransactionId { get; set; }

    public int ItemId { get; set; }

    public float? ItemQuantity { get; set; }

    public virtual Inventory Item { get; set; } = null!;

    public virtual ZooTransaction Transaction { get; set; } = null!;
}
