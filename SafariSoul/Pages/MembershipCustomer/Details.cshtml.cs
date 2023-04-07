using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SafariSoul;
using SafariSoul.Models;

namespace SafariSoul.Pages.MembershipCustomer
{
    public class DetailsModel : PageModel
    {
        private readonly SafariSoul.OfficalZooDbContext _context;

        public DetailsModel(SafariSoul.OfficalZooDbContext context)
        {
            _context = context;
        }

        public Membership Membership { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Memberships == null)
            {
                return NotFound();
            }

            var membership = await _context.Memberships.FirstOrDefaultAsync(m => m.MembershipLevel == id);
            if (membership == null)
            {
                return NotFound();
            }
            else
            {
                Membership = membership;
            }
            return Page();
        }
    }
}
