using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SafariSoul;
using SafariSoul.Models;

namespace SafariSoul.Pages.ExhibitCRUD
{
    public class DeleteModel : PageModel
    {
        private readonly SafariSoul.OfficalZooDbContext _context;

        public DeleteModel(SafariSoul.OfficalZooDbContext context)
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

            var exhibit = await _context.Exhibits.FirstOrDefaultAsync(m => m.ExhibitNo == id);

            if (exhibit == null)
            {
                return NotFound();
            }
            else 
            {
                Exhibit = exhibit;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Exhibits == null)
            {
                return NotFound();
            }
            var exhibit = await _context.Exhibits.FindAsync(id);

            if (exhibit != null)
            {
                Exhibit = exhibit;
                _context.Exhibits.Remove(Exhibit);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
