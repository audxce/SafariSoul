using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SafariSoul.Models;

namespace SafariSoul.Pages.InventoryCRUD
{
    public class CreateModel : PageModel
    {
        private readonly SafariSoul.Models.ZooDbContext _context;

        public CreateModel(SafariSoul.Models.ZooDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {

        ViewData["Destination"] = new SelectList(_context.Locations, "LocationId", "LocationName");
        ViewData["Supplier"] = new SelectList(_context.Vendors, "VendorId", "VendorName");

            return Page();

        }

        [BindProperty]
        public Inventory Inventory { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid || _context.Inventories == null || Inventory == null)
            {

                ViewData["Destination"] = new SelectList(_context.Locations, "LocationId", "LocationName");
                ViewData["Supplier"] = new SelectList(_context.Vendors, "VendorId", "VendorName");

                return Page();
            }

            _context.Inventories.Add(Inventory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");

        }
    }
}
