using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SafariSoul.Models;

namespace SafariSoul.Pages.CustomerCRUD
{
    public class IndexModel : PageModel
    {
        private readonly SafariSoul.Models.ZooDbContext _context;

        public IndexModel(SafariSoul.Models.ZooDbContext context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Customers != null)
            {
                Customer = await _context.Customers
                .Include(c => c.MembershipLevelNavigation).ToListAsync();
            }
        }

        public async Task OnPostAsync()
        {
            var searchFname = Request.Form["searchFname"];
            var searchLname = Request.Form["searchLname"];
            var searchLevel = Request.Form["searchLevel"];
            var donorCheck = Request.Form["donorCheck"];

            if(!String.IsNullOrEmpty(searchFname))
            {
                Customer = await _context.Customers
                .Where(c => c.Fname.Contains(searchFname))
                .Include(c => c.MembershipLevelNavigation).ToListAsync();
            }
            if (!String.IsNullOrEmpty(searchLname))
            {
                Customer = await _context.Customers
                .Where(c => c.Lname.Contains(searchLname))
                .Include(c => c.MembershipLevelNavigation).ToListAsync();
            }
            if(!String.IsNullOrEmpty(searchLevel))
            {
                Customer = await _context.Customers
                .Where(c => c.MembershipLevel.Contains(searchLevel))
                .Include(c => c.MembershipLevelNavigation) .ToListAsync();
            }
        }
    }
}
