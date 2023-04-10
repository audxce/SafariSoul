﻿using System;
using System.Collections.Generic;

namespace SafariSoul.Models;

public partial class ZooTransactionItem
{
    public int MultiItemsId { get; set; }

    public int TransactionId { get; set; }

    public int ItemId { get; set; }

    public int? ItemQuantity { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Inventory Item { get; set; } = null!;

    public virtual ZooTransaction Transaction { get; set; } = null!;
}
