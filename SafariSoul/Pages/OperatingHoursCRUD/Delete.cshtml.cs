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
    public class DeleteModel : PageModel
    {
        private readonly SafariSoul.Models.ZooDbContext _context;

        public DeleteModel(SafariSoul.Models.ZooDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.OperatingHours == null)
            {
                return NotFound();
            }
            var operatinghour = await _context.OperatingHours.FindAsync(id);

            if (operatinghour != null)
            {
                OperatingHour = operatinghour;
                _context.OperatingHours.Remove(OperatingHour);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
