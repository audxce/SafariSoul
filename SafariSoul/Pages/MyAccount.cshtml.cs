using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SafariSoul.Models;

namespace SafariSoul.Pages
{
    public class MyAccountModel : PageModel
    {
        /*private readonly SafariSoul.Models.ZooDbContext _context;

        public MyAccountModel(SafariSoul.Models.ZooDbContext context)
        {
            _context = context;
        }

        public Customer Customer { get; set; } = default!;
        string CID = "CustID";

        int id = Convert.ToInt32(CID);
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            id = int.Parse("CustID");
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                 .Include(c => c.MembershipLevelNavigation)
                 .FirstOrDefaultAsync(m => m.CustomerId == id);

            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                Customer = customer;
            }
            return Page();
        }*/
    }
}
