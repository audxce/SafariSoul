using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SafariSoul;

namespace SafariSoul.Pages.MaintenanceRequestCRUD
{
    public class EditModel : PageModel
    {
        private readonly SafariSoul.OfficalZooDbContext _context;

        public EditModel(SafariSoul.OfficalZooDbContext context)
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

            var maintenancerequest =  await _context.MaintenanceRequests.FirstOrDefaultAsync(m => m.TicketNo == id);
            if (maintenancerequest == null)
            {
                return NotFound();
            }
            MaintenanceRequest = maintenancerequest;
           ViewData["Exhibit"] = new SelectList(_context.Exhibits, "ExhibitNo", "ExhibitNo");
           ViewData["Fulfiller"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId");
           ViewData["Location"] = new SelectList(_context.Locations, "LocationNum", "LocationNum");
           ViewData["Requester"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MaintenanceRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaintenanceRequestExists(MaintenanceRequest.TicketNo))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MaintenanceRequestExists(int id)
        {
          return (_context.MaintenanceRequests?.Any(e => e.TicketNo == id)).GetValueOrDefault();
        }
    }
}
