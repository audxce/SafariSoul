using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SafariSoul.Models;

namespace SafariSoul.Pages.ExpenseItemsCRUD
{
    public class EditModel : PageModel
    {
        private readonly SafariSoul.Models.ZooDbContext _context;

        public EditModel(SafariSoul.Models.ZooDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ExpenseItem ExpenseItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ExpenseItems == null)
            {
                return NotFound();
            }

            var expenseitem =  await _context.ExpenseItems.FirstOrDefaultAsync(m => m.MultiItemsId == id);
            if (expenseitem == null)
            {
                return NotFound();
            }
            ExpenseItem = expenseitem;
           ViewData["ExpenseId"] = new SelectList(_context.Expenses, "ExpenseId", "ExpenseId");
           ViewData["ItemId"] = new SelectList(_context.Inventories, "ItemId", "ItemId");
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

            _context.Attach(ExpenseItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpenseItemExists(ExpenseItem.MultiItemsId))
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

        private bool ExpenseItemExists(int id)
        {
          return (_context.ExpenseItems?.Any(e => e.MultiItemsId == id)).GetValueOrDefault();
        }
    }
}
