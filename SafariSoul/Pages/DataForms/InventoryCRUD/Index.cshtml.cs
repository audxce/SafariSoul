using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SafariSoul.Models;

namespace SafariSoul.Pages.InventoryCRUD
{
    public class IndexModel : PageModel
    {
        private readonly SafariSoul.Models.ZooDbContext _context;

        public IndexModel(SafariSoul.Models.ZooDbContext context)
        {
            _context = context;
        }

        public IList<Inventory> Inventory { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Inventories != null)
            {
                Inventory = await _context.Inventories
                .Include(i => i.DestinationNavigation)
                .Include(i => i.SupplierNavigation).ToListAsync();
            }
        }
    }
}
