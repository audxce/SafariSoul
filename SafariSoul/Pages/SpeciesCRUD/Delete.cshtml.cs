using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SafariSoul;
using SafariSoul.Models;

namespace SafariSoul.Pages.SpeciesCRUD
{
    public class DeleteModel : PageModel
    {
        private readonly SafariSoul.OfficalZooDbContext _context;

        public DeleteModel(SafariSoul.OfficalZooDbContext context)
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

            var species = await _context.Species.FirstOrDefaultAsync(m => m.SpeciesGenus == id);

            if (species == null)
            {
                return NotFound();
            }
            else 
            {
                Species = species;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.Species == null)
            {
                return NotFound();
            }
            var species = await _context.Species.FindAsync(id);

            if (species != null)
            {
                Species = species;
                _context.Species.Remove(Species);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
