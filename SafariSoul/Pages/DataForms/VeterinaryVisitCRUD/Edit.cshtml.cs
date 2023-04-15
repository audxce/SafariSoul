using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SafariSoul.Models;

namespace SafariSoul.Pages.VeterinaryVisitCRUD
{
    public class EditModel : PageModel
    {
        private readonly SafariSoul.Models.ZooDbContext _context;

        public EditModel(SafariSoul.Models.ZooDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public VeterinaryVisit VeterinaryVisit { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.VeterinaryVisits == null)
            {
                return NotFound();
            }

            var veterinaryvisit =  await _context.VeterinaryVisits.FirstOrDefaultAsync(m => m.VetVisitId == id);
            if (veterinaryvisit == null)
            {
                return NotFound();
            }
            VeterinaryVisit = veterinaryvisit;
           ViewData["Animal"] = new SelectList(_context.Animals, "AnimalId", "AnimalName");
           ViewData["VetId"] = new SelectList(_context.Employees.Where(e => e.Occupation == "Veterinarian"), "EmployeeId", "FullName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["Animal"] = new SelectList(_context.Animals, "AnimalId", "AnimalName");
                ViewData["VetId"] = new SelectList(_context.Employees.Where(e => e.Occupation == "Veterinarian"), "EmployeeId", "FullName");
                return Page();
            }

            _context.Attach(VeterinaryVisit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VeterinaryVisitExists(VeterinaryVisit.VetVisitId))
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

        private bool VeterinaryVisitExists(int id)
        {
          return (_context.VeterinaryVisits?.Any(e => e.VetVisitId == id)).GetValueOrDefault();
        }
    }
}
