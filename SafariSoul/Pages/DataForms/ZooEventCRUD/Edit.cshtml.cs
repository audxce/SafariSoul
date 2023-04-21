using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SafariSoul.Models;

namespace SafariSoul.Pages.ZooEventCRUD
{
    public class EditModel : PageModel
    {
        private readonly SafariSoul.Models.ZooDbContext _context;

        public EditModel(SafariSoul.Models.ZooDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ZooEvent ZooEvent { get; set; } = default!;

        [BindProperty]
        public IList<ZooEventAnimalsInvolved> AnimalsInvolved { get; set; } = new List<ZooEventAnimalsInvolved> { new ZooEventAnimalsInvolved() };

        [BindProperty]
        public IList<ZooEventStaffInvolved> StaffInvolved { get; set; } = new List<ZooEventStaffInvolved> { new ZooEventStaffInvolved() };
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
           ViewData["AnimalProgramId"] = new SelectList(_context.AnimalCarePrograms, "AnimalProgramId", "ProgramName");
           ViewData["EducationalProgramId"] = new SelectList(_context.EducationPrograms, "EducationProgramId", "ProgramName");
           ViewData["EventLocationId"] = new SelectList(_context.Locations, "LocationId", "LocationName");
           ViewData["AnimalId"] = new SelectList(_context.Animals, "AnimalId", "AnimalName");
           ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FullName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["AnimalProgramId"] = new SelectList(_context.AnimalCarePrograms, "AnimalProgramId", "ProgramName");
                ViewData["EducationalProgramId"] = new SelectList(_context.EducationPrograms, "EducationProgramId", "ProgramName");
                ViewData["EventLocationId"] = new SelectList(_context.Locations, "LocationId", "LocationName");
                ViewData["AnimalId"] = new SelectList(_context.Animals, "AnimalId", "AnimalName");
                ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FullName");
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
