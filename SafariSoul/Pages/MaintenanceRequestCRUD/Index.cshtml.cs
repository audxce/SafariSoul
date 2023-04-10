using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SafariSoul.Models;

namespace SafariSoul.Pages.MaintenanceRequestCRUD
{
    public class IndexModel : PageModel
    {
        private readonly SafariSoul.Models.ZooDbContext _context;

        public IndexModel(SafariSoul.Models.ZooDbContext context)
        {
            _context = context;
        }

        public IList<MaintenanceRequest> MaintenanceRequest { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.MaintenanceRequests != null)
            {
                MaintenanceRequest = await _context.MaintenanceRequests
                .Include(m => m.ExhibitNavigation)
                .Include(m => m.LocationNavigation).ToListAsync();
            }
        }
    }
}
