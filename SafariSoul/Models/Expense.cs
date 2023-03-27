using System;
using System.Collections.Generic;

namespace SafariSoul.Models;

public partial class Expense
{
    public int ExpenseId { get; set; }

    public DateTime ExpenseTime { get; set; }

    public string Category { get; set; } = null!;

    public int? DeptId { get; set; }

    public string? ExpenseDescription { get; set; }

    public string? ExpenseAccount { get; set; }

    public double ExpenseAmount { get; set; }

    public int? VendorId { get; set; }

    public int? EmployeeNum { get; set; }

    public int? InvoiceNo { get; set; }

    public byte[]? ReceiptImage { get; set; }

    public virtual Department? Dept { get; set; }

    public virtual Employee? EmployeeNumNavigation { get; set; }

    public virtual ICollection<ExpenseItem> ExpenseItems { get; } = new List<ExpenseItem>();

    public virtual Vendor? Vendor { get; set; }
}
