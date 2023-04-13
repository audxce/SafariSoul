using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SafariSoul.Models;

namespace SafariSoul.Pages.EmployeeAnimalHandlerPage.VeterinaryVisitCRUD
{
    public class DeleteModel : PageModel
    {
        private readonly SafariSoul.Models.ZooDbContext _context;

        public DeleteModel(SafariSoul.Models.ZooDbContext context)
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

            var veterinaryvisit = await _context.VeterinaryVisits.FirstOrDefaultAsync(m => m.VetVisitId == id);

            if (veterinaryvisit == null)
            {
                return NotFound();
            }
            else 
            {
                VeterinaryVisit = veterinaryvisit;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.VeterinaryVisits == null)
            {
                return NotFound();
            }
            var veterinaryvisit = await _context.VeterinaryVisits.FindAsync(id);

            if (veterinaryvisit != null)
            {
                VeterinaryVisit = veterinaryvisit;
                _context.VeterinaryVisits.Remove(VeterinaryVisit);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
