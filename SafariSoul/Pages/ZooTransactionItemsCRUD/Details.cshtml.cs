using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SafariSoul.Models;


namespace SafariSoul.Pages.ZooTransactionItemsCRUD
{
    public class DetailsModel : PageModel
    {
        private readonly SafariSoul.OfficalZooDbContext _context;

        public DetailsModel(SafariSoul.OfficalZooDbContext context)
        {
            _context = context;
        }

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
    }
}
