using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SafariSoul.Models;

namespace SafariSoul.Pages.DependentCRUD
{
    public class DetailsModel : PageModel
    {
        private readonly SafariSoul.Models.ZooDbContext _context;

        public DetailsModel(SafariSoul.Models.ZooDbContext context)
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

            var dependent = await _context.Dependents.FirstOrDefaultAsync(m => m.DependentId == id);
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
