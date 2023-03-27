using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SafariSoul;

namespace SafariSoul.Pages.ZooEventCRUD
{
    public class DetailsModel : PageModel
    {
        private readonly SafariSoul.OfficalZooDbContext _context;

        public DetailsModel(SafariSoul.OfficalZooDbContext context)
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

            var zooevent = await _context.ZooEvents.FirstOrDefaultAsync(m => m.EventId == id);
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
