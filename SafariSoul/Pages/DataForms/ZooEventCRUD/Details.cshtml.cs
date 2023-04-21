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
    public class DetailsModel : PageModel
    {
        private readonly SafariSoul.Models.ZooDbContext _context;

        public DetailsModel(SafariSoul.Models.ZooDbContext context)
        {
            _context = context;
        }

      public ZooEvent ZooEvent { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ZooEvents == null)
            {
                return NotFound();
            }

            var zooevent = await _context.ZooEvents
             .Include(z => z.ZooEventAnimalsInvolveds)
             .ThenInclude(zi => zi.Animal)
             .ThenInclude(zi => zi.Species)
             .Include(z => z.ZooEventStaffInvolveds)
             .ThenInclude(zi => zi.Employee)
             .Include(z => z.AnimalProgram)
             .Include(z => z.EducationalProgram)
             .Include(z => z.EventLocation)           
             .FirstOrDefaultAsync(m => m.EventId == id);
            if (zooevent == null)
            {
                return NotFound();
            }
            else 
            {
                ZooEvent = zooevent;
            }
            return Page();
        }
    }
}
