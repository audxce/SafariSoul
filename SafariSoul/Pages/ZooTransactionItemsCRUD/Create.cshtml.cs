using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SafariSoul.Models;


namespace SafariSoul.Pages.ZooTransactionItemsCRUD
{
    public class CreateModel : PageModel
    {
        private readonly SafariSoul.OfficalZooDbContext _context;

        public CreateModel(SafariSoul.OfficalZooDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ItemId"] = new SelectList(_context.Inventories, "ItemId", "ItemId");
        ViewData["TransactionId"] = new SelectList(_context.ZooTransactions, "TransactionId", "TransactionId");
            return Page();
        }

        [BindProperty]
        public ZooTransactionItem ZooTransactionItem { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ZooTransactionItems == null || ZooTransactionItem == null)
            {
                return Page();
            }

            _context.ZooTransactionItems.Add(ZooTransactionItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
