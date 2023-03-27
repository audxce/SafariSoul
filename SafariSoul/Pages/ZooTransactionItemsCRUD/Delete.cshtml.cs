using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SafariSoul;

namespace SafariSoul.Pages.ZooTransactionItemsCRUD
{
    public class DeleteModel : PageModel
    {
        private readonly SafariSoul.OfficalZooDbContext _context;

        public DeleteModel(SafariSoul.OfficalZooDbContext context)
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

            var zootransactionitem = await _context.ZooTransactionItems.FirstOrDefaultAsync(m => m.TransactionId == id);

            if (zootransactionitem == null)
            {
                return NotFound();
            }
            else 
            {
                ZooTransactionItem = zootransactionitem;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ZooTransactionItems == null)
            {
                return NotFound();
            }
            var zootransactionitem = await _context.ZooTransactionItems.FindAsync(id);

            if (zootransactionitem != null)
            {
                ZooTransactionItem = zootransactionitem;
                _context.ZooTransactionItems.Remove(ZooTransactionItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
