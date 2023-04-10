using System;
using System.Collections.Generic;

namespace SafariSoul.Models;

public partial class Expense
{
    public int ExpenseId { get; set; }

    public DateTime ExpenseTime { get; set; }

    public string Category { get; set; } = null!;

    public string? ExpenseAccount { get; set; }

    public double ExpenseAmount { get; set; }

    public int? VendorId { get; set; }

    public int? EmployeeId { get; set; }

    public int? InvoiceId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual ICollection<ExpenseItem> ExpenseItems { get; } = new List<ExpenseItem>();

    public virtual Vendor? Vendor { get; set; }
}
