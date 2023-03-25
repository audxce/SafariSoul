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
    public class IndexModel : PageModel
    {
        private readonly SafariSoul.OfficalZooDbContext _context;

        public IndexModel(SafariSoul.OfficalZooDbContext context)
        {
            _context = context;
        }

        public IList<Species> Species { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Species != null)
            {
                Species = await _context.Species
                .Include(s => s.ExhibitNoNavigation).ToListAsync();
            }
        }
    }
}
