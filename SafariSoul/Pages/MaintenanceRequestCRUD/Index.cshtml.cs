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
        private readonly SafariSoul.OfficalZooDbContext _context;

        public IndexModel(SafariSoul.OfficalZooDbContext context)
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
                .Include(m => m.FulfillerNavigation)
                .Include(m => m.LocationNavigation)
                .Include(m => m.RequesterNavigation).ToListAsync();
            }
        }
    }
}
