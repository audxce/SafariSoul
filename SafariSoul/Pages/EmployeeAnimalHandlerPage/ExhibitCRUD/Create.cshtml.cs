using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SafariSoul.Models;

namespace SafariSoul.Pages.EmployeeAnimalHandlerPage.ExhibitCRUD
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
        ViewData["Location"] = new SelectList(_context.Locations, "LocationId", "LocationName");
        ViewData["MealContent"] = new SelectList(_context.Inventories, "ItemId", "ItemName");
        ViewData["Zookeeper"] = new SelectList(_context.Employees, "EmployeeId", "FullName");
            return Page();
        }

        [BindProperty]
        public Exhibit Exhibit { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Exhibits == null || Exhibit == null)
            {
                ViewData["Location"] = new SelectList(_context.Locations, "LocationId", "LocationName");
                ViewData["MealContent"] = new SelectList(_context.Inventories, "ItemId", "ItemName");
                ViewData["Zookeeper"] = new SelectList(_context.Employees, "EmployeeId", "FullName");
                return Page();
            }

            _context.Exhibits.Add(Exhibit);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
