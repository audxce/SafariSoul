using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SafariSoul.Models;


namespace SafariSoul.Pages.ZooTransactionItemsCRUD
{
    public class EditModel : PageModel
    {
        private readonly SafariSoul.OfficalZooDbContext _context;

        public EditModel(SafariSoul.OfficalZooDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ZooTransactionItem ZooTransactionItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ZooTransactionItems == null)
            {
                return NotFound();
            }

            var zootransactionitem =  await _context.ZooTransactionItems.FirstOrDefaultAsync(m => m.TransactionId == id);
            if (zootransactionitem == null)
            {
                return NotFound();
            }
            ZooTransactionItem = zootransactionitem;
           ViewData["ItemId"] = new SelectList(_context.Inventories, "ItemId", "ItemId");
           ViewData["TransactionId"] = new SelectList(_context.ZooTransactions, "TransactionId", "TransactionId");
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

            _context.Attach(ZooTransactionItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZooTransactionItemExists(ZooTransactionItem.TransactionId))
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

        private bool ZooTransactionItemExists(int id)
        {
          return (_context.ZooTransactionItems?.Any(e => e.TransactionId == id)).GetValueOrDefault();
        }
    }
}
