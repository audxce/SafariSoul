using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SafariSoul.Models;

namespace SafariSoul.Pages.ExpenseCRUD
{
    public class CreateModel : PageModel
    {
        private readonly SafariSoul.Models.ZooDbContext _context;

        public CreateModel(SafariSoul.Models.ZooDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FullName");
            ViewData["VendorId"] = new SelectList(_context.Vendors, "VendorId", "VendorName");
            ViewData["ItemId"] = new SelectList(_context.Inventories, "ItemId", "ItemName");
            return Page();
        }

        [BindProperty]
        public Expense Expense { get; set; } = default!;

        [BindProperty]
        public IList<ExpenseItem> ExpenseItems { get; set; } = new List<ExpenseItem> { new ExpenseItem() };

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Expenses == null || Expense == null)
            {
                ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FullName");
                ViewData["VendorId"] = new SelectList(_context.Vendors, "VendorId", "VendorName");
                ViewData["ItemId"] = new SelectList(_context.Inventories, "ItemId", "ItemName");
                return Page();
            }

            _context.Expenses.Add(Expense);
            await _context.SaveChangesAsync(); // Save Expense to generate ExpenseId

            foreach (var expenseItem in ExpenseItems)
            {
                // Assign the generated ExpenseId to each ExpenseItem
                expenseItem.ExpenseId = Expense.ExpenseId;

                _context.ExpenseItems.Add(expenseItem);
            }
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}
