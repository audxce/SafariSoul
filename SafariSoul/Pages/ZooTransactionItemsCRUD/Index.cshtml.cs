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
    public class IndexModel : PageModel
    {
        private readonly SafariSoul.OfficalZooDbContext _context;

        public IndexModel(SafariSoul.OfficalZooDbContext context)
        {
            _context = context;
        }

        public IList<ZooTransactionItem> ZooTransactionItem { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ZooTransactionItems != null)
            {
                ZooTransactionItem = await _context.ZooTransactionItems
                .Include(z => z.Item)
                .Include(z => z.Transaction).ToListAsync();
            }
        }
    }
}
