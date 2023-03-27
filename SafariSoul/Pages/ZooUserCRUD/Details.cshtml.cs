using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SafariSoul;

namespace SafariSoul.Pages.ZooUserCRUD
{
    public class DetailsModel : PageModel
    {
        private readonly SafariSoul.OfficalZooDbContext _context;

        public DetailsModel(SafariSoul.OfficalZooDbContext context)
        {
            _context = context;
        }

      public ZooUser ZooUser { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ZooUsers == null)
            {
                return NotFound();
            }

            var zoouser = await _context.ZooUsers.FirstOrDefaultAsync(m => m.UserId == id);
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
