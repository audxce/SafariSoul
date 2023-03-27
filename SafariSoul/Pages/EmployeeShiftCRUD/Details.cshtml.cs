using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SafariSoul;

namespace SafariSoul.Pages.EmployeeShiftCRUD
{
    public class DetailsModel : PageModel
    {
        private readonly SafariSoul.OfficalZooDbContext _context;

        public DetailsModel(SafariSoul.OfficalZooDbContext context)
        {
            _context = context;
        }

      public EmployeeShift EmployeeShift { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.EmployeeShifts == null)
            {
                return NotFound();
            }

            var employeeshift = await _context.EmployeeShifts.FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employeeshift == null)
            {
                return NotFound();
            }
            else 
            {
                EmployeeShift = employeeshift;
            }
            return Page();
        }
    }
}
