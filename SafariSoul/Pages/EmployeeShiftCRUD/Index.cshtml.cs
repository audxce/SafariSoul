using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SafariSoul.Models;

namespace SafariSoul.Pages.EmployeeShiftCRUD
{
    public class IndexModel : PageModel
    {
        private readonly SafariSoul.OfficalZooDbContext _context;

        public IndexModel(SafariSoul.OfficalZooDbContext context)
        {
            _context = context;
        }

        public IList<EmployeeShift> EmployeeShift { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.EmployeeShifts != null)
            {
                EmployeeShift = await _context.EmployeeShifts
                .Include(e => e.Employee).ToListAsync();
            }
        }
    }
}
