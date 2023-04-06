using System;
using System.Collections.Generic;

namespace SafariSoul.Models;

public partial class Discount
{
    public string DiscountName { get; set; } = null!;

    public float DiscountPercentage { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<ZooTransaction> ZooTransactions { get; } = new List<ZooTransaction>();
}
