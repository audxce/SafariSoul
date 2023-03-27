using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SafariSoul.Models;

namespace SafariSoul.Pages.DonationCRUD
{
    public class IndexModel : PageModel
    {
        private readonly SafariSoul.OfficalZooDbContext _context;

        public IndexModel(SafariSoul.OfficalZooDbContext context)
        {
            _context = context;
        }

        public IList<Donation> Donation { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Donations != null)
            {
                Donation = await _context.Donations
                .Include(d => d.Donor).ToListAsync();
            }
        }
    }
}
