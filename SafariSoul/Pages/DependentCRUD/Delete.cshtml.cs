using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SafariSoul;

namespace SafariSoul.Pages.DependentCRUD
{
    public class DeleteModel : PageModel
    {
        private readonly SafariSoul.OfficalZooDbContext _context;

        public DeleteModel(SafariSoul.OfficalZooDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Dependent Dependent { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Dependents == null)
            {
                return NotFound();
            }

            var dependent = await _context.Dependents.FirstOrDefaultAsync(m => m.EmployeeId == id);

            if (dependent == null)
            {
                return NotFound();
            }
            else 
            {
                Dependent = dependent;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Dependents == null)
            {
                return NotFound();
            }
            var dependent = await _context.Dependents.FindAsync(id);

            if (dependent != null)
            {
                Dependent = dependent;
                _context.Dependents.Remove(Dependent);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
