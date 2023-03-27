using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SafariSoul.Models;


namespace SafariSoul.Pages.ZooEventRequiredInv
{
    public class CreateModel : PageModel
    {
        private readonly SafariSoul.OfficalZooDbContext _context;

        public CreateModel(SafariSoul.OfficalZooDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["EventId"] = new SelectList(_context.ZooEvents, "EventId", "EventId");
        ViewData["ItemId"] = new SelectList(_context.Inventories, "ItemId", "ItemId");
            return Page();
        }

        [BindProperty]
        public ZooEventRequiredInventory ZooEventRequiredInventory { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ZooEventRequiredInventories == null || ZooEventRequiredInventory == null)
            {
                return Page();
            }

            _context.ZooEventRequiredInventories.Add(ZooEventRequiredInventory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
