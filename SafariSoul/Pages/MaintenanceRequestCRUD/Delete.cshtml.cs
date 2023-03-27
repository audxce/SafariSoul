using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SafariSoul;

namespace SafariSoul.Pages.MaintenanceRequestCRUD
{
    public class DeleteModel : PageModel
    {
        private readonly SafariSoul.OfficalZooDbContext _context;

        public DeleteModel(SafariSoul.OfficalZooDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public MaintenanceRequest MaintenanceRequest { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.MaintenanceRequests == null)
            {
                return NotFound();
            }

            var maintenancerequest = await _context.MaintenanceRequests.FirstOrDefaultAsync(m => m.TicketNo == id);

            if (maintenancerequest == null)
            {
                return NotFound();
            }
            else 
            {
                MaintenanceRequest = maintenancerequest;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.MaintenanceRequests == null)
            {
                return NotFound();
            }
            var maintenancerequest = await _context.MaintenanceRequests.FindAsync(id);

            if (maintenancerequest != null)
            {
                MaintenanceRequest = maintenancerequest;
                _context.MaintenanceRequests.Remove(MaintenanceRequest);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
