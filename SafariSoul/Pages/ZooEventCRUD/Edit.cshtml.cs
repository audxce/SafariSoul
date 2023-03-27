using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SafariSoul;

namespace SafariSoul.Pages.ZooEventCRUD
{
    public class EditModel : PageModel
    {
        private readonly SafariSoul.OfficalZooDbContext _context;

        public EditModel(SafariSoul.OfficalZooDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ZooEvent ZooEvent { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ZooEvents == null)
            {
                return NotFound();
            }

            var zooevent =  await _context.ZooEvents.FirstOrDefaultAsync(m => m.EventId == id);
            if (zooevent == null)
            {
                return NotFound();
            }
            ZooEvent = zooevent;
           ViewData["AnimalProgramNo"] = new SelectList(_context.AnimalCarePrograms, "AnimalProgramNum", "AnimalProgramNum");
           ViewData["EducationalProgramNo"] = new SelectList(_context.EducationPrograms, "ProgramNo", "ProgramNo");
           ViewData["EventLocation"] = new SelectList(_context.Locations, "LocationNum", "LocationNum");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ZooEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZooEventExists(ZooEvent.EventId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ZooEventExists(int id)
        {
          return (_context.ZooEvents?.Any(e => e.EventId == id)).GetValueOrDefault();
        }
    }
}
