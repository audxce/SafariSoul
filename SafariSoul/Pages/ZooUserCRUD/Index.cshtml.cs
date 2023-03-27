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
    public class IndexModel : PageModel
    {
        private readonly SafariSoul.OfficalZooDbContext _context;

        public IndexModel(SafariSoul.OfficalZooDbContext context)
        {
            _context = context;
        }

        public IList<ZooUser> ZooUser { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ZooUsers != null)
            {
                ZooUser = await _context.ZooUsers
                .Include(z => z.Customer)
                .Include(z => z.Employee).ToListAsync();
            }
        }
    }
}
