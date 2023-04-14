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
    public class DetailsModel : PageModel
    {
        private readonly SafariSoul.Models.ZooDbContext _context;

        public DetailsModel(SafariSoul.Models.ZooDbContext context)
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

            var employeeshift = await _context.EmployeeShifts
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(m => m.ShiftId == id);

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
