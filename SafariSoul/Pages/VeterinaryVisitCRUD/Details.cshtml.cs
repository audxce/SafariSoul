using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SafariSoul.Models;

namespace SafariSoul.Pages.VeterinaryVisitCRUD
{
    public class DetailsModel : PageModel
    {
        private readonly SafariSoul.OfficalZooDbContext _context;

        public DetailsModel(SafariSoul.OfficalZooDbContext context)
        {
            _context = context;
        }

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
    }
}
