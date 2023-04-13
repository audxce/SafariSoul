using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SafariSoul.Models;

namespace SafariSoul.Pages.EmployeeAnimalHandlerPage.ExhibitCRUD
{
    public class EditModel : PageModel
    {
        private readonly SafariSoul.Models.ZooDbContext _context;

        public EditModel(SafariSoul.Models.ZooDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Exhibit Exhibit { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Exhibits == null)
            {
                return NotFound();
            }

            var exhibit =  await _context.Exhibits.FirstOrDefaultAsync(m => m.ExhibitId == id);
            if (exhibit == null)
            {
                return NotFound();
            }
            Exhibit = exhibit;
           ViewData["Location"] = new SelectList(_context.Locations, "LocationId", "LocationName");
           ViewData["MealContent"] = new SelectList(_context.Inventories, "ItemId", "ItemName");
           ViewData["Zookeeper"] = new SelectList(_context.Employees, "EmployeeId", "FullName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["Location"] = new SelectList(_context.Locations, "LocationId", "LocationName");
                ViewData["MealContent"] = new SelectList(_context.Inventories, "ItemId", "ItemName");
                ViewData["Zookeeper"] = new SelectList(_context.Employees, "EmployeeId", "FullName");
                return Page();
            }

            _context.Attach(Exhibit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExhibitExists(Exhibit.ExhibitId))
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

        private bool ExhibitExists(int id)
        {
          return (_context.Exhibits?.Any(e => e.ExhibitId == id)).GetValueOrDefault();
        }
    }
}
