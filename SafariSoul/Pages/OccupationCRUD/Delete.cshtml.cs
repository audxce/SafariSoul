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
    public class DeleteModel : PageModel
    {
        private readonly SafariSoul.OfficalZooDbContext _context;

        public DeleteModel(SafariSoul.OfficalZooDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.Occupations == null)
            {
                return NotFound();
            }
            var occupation = await _context.Occupations.FindAsync(id);

            if (occupation != null)
            {
                Occupation = occupation;
                _context.Occupations.Remove(Occupation);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
