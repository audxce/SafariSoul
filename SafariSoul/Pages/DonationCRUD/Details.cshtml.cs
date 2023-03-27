using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SafariSoul;

namespace SafariSoul.Pages.DonationCRUD
{
    public class DetailsModel : PageModel
    {
        private readonly SafariSoul.OfficalZooDbContext _context;

        public DetailsModel(SafariSoul.OfficalZooDbContext context)
        {
            _context = context;
        }

      public Donation Donation { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Donations == null)
            {
                return NotFound();
            }

            var donation = await _context.Donations.FirstOrDefaultAsync(m => m.DonationId == id);
            if (donation == null)
            {
                return NotFound();
            }
            else 
            {
                Donation = donation;
            }
            return Page();
        }
    }
}
