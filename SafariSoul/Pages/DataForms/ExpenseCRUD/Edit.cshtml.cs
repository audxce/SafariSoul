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
    public class EditModel : PageModel
    {
        private readonly SafariSoul.Models.ZooDbContext _context;

        public EditModel(SafariSoul.Models.ZooDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Expense Expense { get; set; } = default!;

        [BindProperty]
        public List<ExpenseItem> ExpenseItems { get; set; } = new List<ExpenseItem>();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Expenses == null)
            {
                return NotFound();
            }
            ExpenseItems = await _context.ExpenseItems.Where(ei => ei.ExpenseId == id).ToListAsync();

            var expense =  await _context.Expenses.FirstOrDefaultAsync(m => m.ExpenseId == id);
            if (expense == null)
            {
                return NotFound();
            }
            Expense = expense;
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FullName");
            ViewData["VendorId"] = new SelectList(_context.Vendors, "VendorId", "VendorName");
            ViewData["ItemId"] = new SelectList(_context.Inventories, "ItemId", "ItemName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FullName");
                ViewData["VendorId"] = new SelectList(_context.Vendors, "VendorId", "VendorName");
                ViewData["ItemId"] = new SelectList(_context.Inventories, "ItemId", "ItemName");
                return Page();
            }

            _context.Attach(Expense).State = EntityState.Modified;

            // Update the related ExpenseItem objects
            foreach (var expenseItem in ExpenseItems)
            {
                _context.Update(expenseItem);
                await _context.SaveChangesAsync();
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpenseExists(Expense.ExpenseId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ExpenseExists(int id)
        {
          return (_context.Expenses?.Any(e => e.ExpenseId == id)).GetValueOrDefault();
        }
    }
}
