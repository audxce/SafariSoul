using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SafariSoul.Models;

namespace SafariSoul.Pages.ZooTransactionCRUD
{
    public class EditModel : PageModel
    {
        private readonly SafariSoul.OfficalZooDbContext _context;

        public EditModel(SafariSoul.OfficalZooDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ZooTransaction ZooTransaction { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ZooTransactions == null)
            {
                return NotFound();
            }

            var zootransaction =  await _context.ZooTransactions.FirstOrDefaultAsync(m => m.TransactionId == id);
            if (zootransaction == null)
            {
                return NotFound();
            }
            ZooTransaction = zootransaction;
           ViewData["Customer"] = new SelectList(_context.Customers, "CustomerId", "CustomerId");
           ViewData["Discount"] = new SelectList(_context.Discounts, "DiscountName", "DiscountName");
           ViewData["SellerId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ZooTransaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZooTransactionExists(ZooTransaction.TransactionId))
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

        private bool ZooTransactionExists(int id)
        {
          return (_context.ZooTransactions?.Any(e => e.TransactionId == id)).GetValueOrDefault();
        }
    }
}
