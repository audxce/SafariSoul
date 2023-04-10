using System;
using System.Collections.Generic;

namespace SafariSoul.Models;

public partial class ExpenseViewModel
{
    public Expense Expense { get; set; }
    public List<ExpenseItem> ExpenseItems { get; set; }
}
