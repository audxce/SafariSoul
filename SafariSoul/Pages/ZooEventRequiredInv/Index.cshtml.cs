using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SafariSoul;

namespace SafariSoul.Pages.ZooEventRequiredInv
{
    public class IndexModel : PageModel
    {
        private readonly SafariSoul.OfficalZooDbContext _context;

        public IndexModel(SafariSoul.OfficalZooDbContext context)
        {
            _context = context;
        }

        public IList<ZooEventRequiredInventory> ZooEventRequiredInventory { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ZooEventRequiredInventories != null)
            {
                ZooEventRequiredInventory = await _context.ZooEventRequiredInventories
                .Include(z => z.Event)
                .Include(z => z.Item).ToListAsync();
            }
        }
    }
}
