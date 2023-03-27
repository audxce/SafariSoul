using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SafariSoul.Pages.AnimalCRUD;

namespace SafariSoul.Pages.OccupationCRUD
{
    public class DetailsModel : PageModel
    {
        private readonly SafariSoul.OfficalZooDbContext _context;

        public DetailsModel(SafariSoul.OfficalZooDbContext context)
        {
            _context = context;
        }

      public Occupation Occupation { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Occupations == null)
            {
                return NotFound();
            }

            var occupation = await _context.Occupations.FirstOrDefaultAsync(m => m.JobTitle == id);
            if (occupation == null)
            {
                return NotFound();
            }
            else 
            {
                Occupation = occupation;
            }
            return Page();
        }
    }
}
