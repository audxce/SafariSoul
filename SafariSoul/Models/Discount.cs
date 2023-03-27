using System;
using System.Collections.Generic;

namespace SafariSoul;

public partial class Discount
{
    public string DiscountName { get; set; } = null!;

    public float DiscountPercentage { get; set; }

    public virtual ICollection<ZooTransaction> ZooTransactions { get; } = new List<ZooTransaction>();
}
