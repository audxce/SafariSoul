using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SafariSoul;

namespace SafariSoul.Pages.ExhibitCRUD
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
        ViewData["Location"] = new SelectList(_context.Locations, "LocationNum", "LocationNum");
        ViewData["Zookeeper"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId");
            return Page();
        }

        [BindProperty]
        public Exhibit Exhibit { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Exhibits == null || Exhibit == null)
            {
                return Page();
            }

            _context.Exhibits.Add(Exhibit);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
