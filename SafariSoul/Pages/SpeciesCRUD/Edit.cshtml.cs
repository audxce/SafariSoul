using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SafariSoul;
using SafariSoul.Models;

namespace SafariSoul.Pages.SpeciesCRUD
{
    public class EditModel : PageModel
    {
        private readonly SafariSoul.OfficalZooDbContext _context;

        public EditModel(SafariSoul.OfficalZooDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Species Species { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Species == null)
            {
                return NotFound();
            }

            var species =  await _context.Species.FirstOrDefaultAsync(m => m.SpeciesGenus == id);
            if (species == null)
            {
                return NotFound();
            }
            Species = species;
           ViewData["ExhibitNo"] = new SelectList(_context.Exhibits, "ExhibitNo", "ExhibitNo");
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

            _context.Attach(Species).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpeciesExists(Species.SpeciesGenus))
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

        private bool SpeciesExists(string id)
        {
          return (_context.Species?.Any(e => e.SpeciesGenus == id)).GetValueOrDefault();
        }
    }
}
