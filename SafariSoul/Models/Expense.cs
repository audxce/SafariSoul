using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SafariSoul.Models;

public partial class Expense
{
    public int ExpenseId { get; set; }

    [DisplayName("Expense Time")]
    public DateTime ExpenseTime { get; set; }

    public string Category { get; set; } = null!;

    [DisplayName("Expense Account")]
    public string? ExpenseAccount { get; set; }

    [DisplayName("Expense Amount")]
    public double ExpenseAmount { get; set; }

    [DisplayName("Vendor ID")]
    public int? VendorId { get; set; }

    [DisplayName("Employee ID")]
    public int? EmployeeId { get; set; }

    [DisplayName("Invoice ID")]
    public int? InvoiceId { get; set; }

    [DisplayName("Created At")]
    public DateTime? CreatedAt { get; set; }

    [DisplayName("Updated At")]
    public DateTime? UpdatedAt { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual ICollection<ExpenseItem> ExpenseItems { get; } = new List<ExpenseItem>();

    public virtual Vendor? Vendor { get; set; }
}
