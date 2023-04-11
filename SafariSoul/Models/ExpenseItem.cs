using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SafariSoul.Models;

public partial class ExpenseItem
{
    public int MultiItemsId { get; set; }

    public int ExpenseId { get; set; }

    [DisplayName("Item")]
    public int ItemId { get; set; }

    [DisplayName("Item Quantity")]
    public int ItemQuantity { get; set; }

    [DisplayName("Created At")]
    public DateTime? CreatedAt { get; set; }

    [DisplayName("Updated At")]
    public DateTime? UpdatedAt { get; set; }

    public virtual Expense Expense { get; set; } = null!;

    public virtual Inventory Item { get; set; } = null!;
}
