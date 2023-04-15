using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SafariSoul.Models;

namespace SafariSoul.Pages.SpeciesCRUD
{
    public class DetailsModel : PageModel
    {
        private readonly SafariSoul.Models.ZooDbContext _context;

        public DetailsModel(SafariSoul.Models.ZooDbContext context)
        {
            _context = context;
        }

      public Species Species { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Species == null)
            {
                return NotFound();
            }

            var species = await _context.Species
                .Include(s => s.Exhibit)
                .FirstOrDefaultAsync(m => m.SpeciesId == id);

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
    }
}
