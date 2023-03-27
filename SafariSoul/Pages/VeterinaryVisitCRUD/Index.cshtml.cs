using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SafariSoul;

namespace SafariSoul.Pages.VeterinaryVisitCRUD
{
    public class IndexModel : PageModel
    {
        private readonly SafariSoul.OfficalZooDbContext _context;

        public IndexModel(SafariSoul.OfficalZooDbContext context)
        {
            _context = context;
        }

        public IList<VeterinaryVisit> VeterinaryVisit { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.VeterinaryVisits != null)
            {
                VeterinaryVisit = await _context.VeterinaryVisits
                .Include(v => v.AnimalNavigation).ToListAsync();
            }
        }
    }
}
