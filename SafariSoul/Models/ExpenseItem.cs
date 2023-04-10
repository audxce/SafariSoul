using System;
using System.Collections.Generic;

namespace SafariSoul.Models;

public partial class ExpenseItem
{
    public int MultiItemsId { get; set; }

    public int ExpenseId { get; set; }

    public int ItemId { get; set; }

    public int ItemQuantity { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Expense Expense { get; set; } = null!;

    public virtual Inventory Item { get; set; } = null!;
}
