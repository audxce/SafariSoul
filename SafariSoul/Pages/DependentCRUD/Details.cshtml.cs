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
    public class DetailsModel : PageModel
    {
        private readonly SafariSoul.OfficalZooDbContext _context;

        public DetailsModel(SafariSoul.OfficalZooDbContext context)
        {
            _context = context;
        }

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
    }
}
