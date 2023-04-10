using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SafariSoul.Models;

namespace SafariSoul.Pages.OperatingHoursCRUD
{
    public class DetailsModel : PageModel
    {
        private readonly SafariSoul.Models.ZooDbContext _context;

        public DetailsModel(SafariSoul.Models.ZooDbContext context)
        {
            _context = context;
        }

      public OperatingHour OperatingHour { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.OperatingHours == null)
            {
                return NotFound();
            }

            var operatinghour = await _context.OperatingHours.FirstOrDefaultAsync(m => m.DayId == id);
            if (operatinghour == null)
            {
                return NotFound();
            }
            else 
            {
                OperatingHour = operatinghour;
            }
            return Page();
        }
    }
}
