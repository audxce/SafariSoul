using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SafariSoul.Models;

namespace SafariSoul.Pages.MaintenanceRequestCRUD
{
    public class CreateModel : PageModel
    {
        private readonly SafariSoul.Models.ZooDbContext _context;

        public CreateModel(SafariSoul.Models.ZooDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["Exhibit"] = new SelectList(_context.Exhibits, "ExhibitId", "ExhibitName");
            ViewData["Location"] = new SelectList(_context.Locations, "LocationId", "LocationName");
            return Page();
        }

        [BindProperty]
        public MaintenanceRequest MaintenanceRequest { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.MaintenanceRequests == null || MaintenanceRequest == null)
            {
                ViewData["Exhibit"] = new SelectList(_context.Exhibits, "ExhibitId", "ExhibitName");
                ViewData["Location"] = new SelectList(_context.Locations, "LocationId", "LocationName");
                return Page();
            }

            _context.MaintenanceRequests.Add(MaintenanceRequest);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
