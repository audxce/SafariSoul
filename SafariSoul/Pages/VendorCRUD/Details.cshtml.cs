using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SafariSoul;

namespace SafariSoul.Pages.VendorCRUD
{
    public class DetailsModel : PageModel
    {
        private readonly SafariSoul.OfficalZooDbContext _context;

        public DetailsModel(SafariSoul.OfficalZooDbContext context)
        {
            _context = context;
        }

      public Vendor Vendor { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Vendors == null)
            {
                return NotFound();
            }

            var vendor = await _context.Vendors.FirstOrDefaultAsync(m => m.VendorId == id);
            if (vendor == null)
            {
                return NotFound();
            }
            else 
            {
                Vendor = vendor;
            }
            return Page();
        }
    }
}
