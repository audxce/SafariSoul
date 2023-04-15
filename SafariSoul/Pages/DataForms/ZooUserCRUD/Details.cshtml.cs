using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SafariSoul.Models;

namespace SafariSoul.Pages.ZooUserCRUD
{
    public class DetailsModel : PageModel
    {
        private readonly SafariSoul.Models.ZooDbContext _context;

        public DetailsModel(SafariSoul.Models.ZooDbContext context)
        {
            _context = context;
        }

      public ZooUser ZooUser { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.ZooUsers == null)
            {
                return NotFound();
            }

            var zoouser = await _context.ZooUsers
                .Include(z => z.Customer)
                .Include(z => z.Employee)
                .FirstOrDefaultAsync(m => m.UserName == id);

            if (zoouser == null)
            {
                return NotFound();
            }
            else 
            {
                ZooUser = zoouser;
            }
            return Page();
        }
    }
}
