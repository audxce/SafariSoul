using System;
using System.Collections.Generic;
using SafariSoul.Models;

namespace SafariSoul;

public partial class ExpenseItem
{
    public int ExpenseId { get; set; }

    public int ItemId { get; set; }

    public float ItemQuantity { get; set; }

    public double ItemCost { get; set; }

    public virtual Expense Expense { get; set; } = null!;

    public virtual Inventory Item { get; set; } = null!;
}
