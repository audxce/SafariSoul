using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SafariSoul.Models;

namespace SafariSoul.Pages.ZooEventCRUD
{
    public class IndexModel : PageModel
    {
        private readonly SafariSoul.Models.ZooDbContext _context;

        public IndexModel(SafariSoul.Models.ZooDbContext context)
        {
            _context = context;
        }

        public IList<ZooEvent> ZooEvent { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ZooEvents != null)
            {
                ZooEvent = await _context.ZooEvents
                .Include(z => z.AnimalProgram)
                .Include(z => z.EducationalProgram)               
                .Include(z => z.EventLocation).ToListAsync();
            }
        }
    }
}
