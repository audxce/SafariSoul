using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SafariSoul;

namespace SafariSoul.Pages.ZooEventRequiredInv
{
    public class EditModel : PageModel
    {
        private readonly SafariSoul.OfficalZooDbContext _context;

        public EditModel(SafariSoul.OfficalZooDbContext context)
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

            var zooeventrequiredinventory =  await _context.ZooEventRequiredInventories.FirstOrDefaultAsync(m => m.EventId == id);
            if (zooeventrequiredinventory == null)
            {
                return NotFound();
            }
            ZooEventRequiredInventory = zooeventrequiredinventory;
           ViewData["EventId"] = new SelectList(_context.ZooEvents, "EventId", "EventId");
           ViewData["ItemId"] = new SelectList(_context.Inventories, "ItemId", "ItemId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ZooEventRequiredInventory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZooEventRequiredInventoryExists(ZooEventRequiredInventory.EventId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ZooEventRequiredInventoryExists(int id)
        {
          return (_context.ZooEventRequiredInventories?.Any(e => e.EventId == id)).GetValueOrDefault();
        }
    }
}
