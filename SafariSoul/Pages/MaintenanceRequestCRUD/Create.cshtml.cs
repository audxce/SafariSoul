using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SafariSoul;

namespace SafariSoul.Pages.MaintenanceRequestCRUD
{
    public class CreateModel : PageModel
    {
        private readonly SafariSoul.OfficalZooDbContext _context;

        public CreateModel(SafariSoul.OfficalZooDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["Exhibit"] = new SelectList(_context.Exhibits, "ExhibitNo", "ExhibitNo");
        ViewData["Fulfiller"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId");
        ViewData["Location"] = new SelectList(_context.Locations, "LocationNum", "LocationNum");
        ViewData["Requester"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId");
            return Page();
        }

        [BindProperty]
        public MaintenanceRequest MaintenanceRequest { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.MaintenanceRequests == null || MaintenanceRequest == null)
            {
                return Page();
            }

            _context.MaintenanceRequests.Add(MaintenanceRequest);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
