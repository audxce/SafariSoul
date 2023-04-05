using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SafariSoul.Models;

namespace SafariSoul.Pages.ZooTransactionCustomer
{
    public class DetailsModel : PageModel
    {
        private readonly SafariSoul.OfficalZooDbContext _context;

        public DetailsModel(SafariSoul.OfficalZooDbContext context)
        {
            _context = context;
        }

        public ZooTransaction ZooTransaction { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ZooTransactions == null)
            {
                return NotFound();
            }

            var zootransaction = await _context.ZooTransactions.FirstOrDefaultAsync(m => m.TransactionId == id);
            if (zootransaction == null)
            {
                return NotFound();
            }
            else
            {
                ZooTransaction = zootransaction;
            }
            return Page();
        }
    }
}
