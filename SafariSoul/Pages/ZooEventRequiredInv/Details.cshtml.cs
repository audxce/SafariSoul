using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SafariSoul;

namespace SafariSoul.Pages.ZooEventRequiredInv
{
    public class DetailsModel : PageModel
    {
        private readonly SafariSoul.OfficalZooDbContext _context;

        public DetailsModel(SafariSoul.OfficalZooDbContext context)
        {
            _context = context;
        }

      public ZooEventRequiredInventory ZooEventRequiredInventory { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ZooEventRequiredInventories == null)
            {
                return NotFound();
            }

            var zooeventrequiredinventory = await _context.ZooEventRequiredInventories.FirstOrDefaultAsync(m => m.EventId == id);
            if (zooeventrequiredinventory == null)
            {
                return NotFound();
            }
            else 
            {
                ZooEventRequiredInventory = zooeventrequiredinventory;
            }
            return Page();
        }
    }
}
