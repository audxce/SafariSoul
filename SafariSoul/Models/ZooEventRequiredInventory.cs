using System;
using System.Collections.Generic;

namespace SafariSoul;

public partial class ZooEventRequiredInventory
{
    public int EventId { get; set; }

    public int ItemId { get; set; }

    public float ItemQuantity { get; set; }

    public virtual ZooEvent Event { get; set; } = null!;

    public virtual Inventory Item { get; set; } = null!;
}
