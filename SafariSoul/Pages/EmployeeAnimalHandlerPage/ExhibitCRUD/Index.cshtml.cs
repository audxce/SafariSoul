using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SafariSoul.Models;

namespace SafariSoul.Pages.EmployeeAnimalHandlerPage.ExhibitCRUD
{
    public class IndexModel : PageModel
    {
        private readonly SafariSoul.Models.ZooDbContext _context;

        public IndexModel(SafariSoul.Models.ZooDbContext context)
        {
            _context = context;
        }

        public IList<Exhibit> Exhibit { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Exhibits != null)
            {
                Exhibit = await _context.Exhibits
                .Include(e => e.LocationNavigation)
                .Include(e => e.MealContentNavigation)
                .Include(e => e.ZookeeperNavigation).ToListAsync();
            }
        }
    }
}
