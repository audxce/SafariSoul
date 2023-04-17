using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SafariSoul.Models;

namespace SafariSoul.Pages.DataForms.ZooTransactionCRUD
{
    public class IndexModel : PageModel
    {
        private readonly SafariSoul.Models.ZooDbContext _context;

        public IndexModel(SafariSoul.Models.ZooDbContext context)
        {
            _context = context;
        }

        public IList<ZooTransaction> ZooTransaction { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ZooTransactions != null)
            {
                ZooTransaction = await _context.ZooTransactions
                .Include(z => z.Customer)
                .Include(z => z.Location)
                .Include(z => z.Seller).ToListAsync();
            }
        }
    }
}

