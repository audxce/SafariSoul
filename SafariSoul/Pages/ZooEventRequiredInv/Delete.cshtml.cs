using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SafariSoul.Models;

namespace SafariSoul.Pages.ZooEventRequiredInv
{
    public class DeleteModel : PageModel
    {
        private readonly SafariSoul.OfficalZooDbContext _context;

        public DeleteModel(SafariSoul.OfficalZooDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ZooEventRequiredInventories == null)
            {
                return NotFound();
            }
            var zooeventrequiredinventory = await _context.ZooEventRequiredInventories.FindAsync(id);

            if (zooeventrequiredinventory != null)
            {
                ZooEventRequiredInventory = zooeventrequiredinventory;
                _context.ZooEventRequiredInventories.Remove(ZooEventRequiredInventory);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
