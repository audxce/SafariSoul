using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SafariSoul.Models;

namespace SafariSoul.Pages.ZooEventCRUD
{
    public class CreateModel : PageModel
    {
        private readonly SafariSoul.Models.ZooDbContext _context;

        public CreateModel(SafariSoul.Models.ZooDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["AnimalProgramId"] = new SelectList(_context.AnimalCarePrograms, "AnimalProgramId", "ProgramName");
            ViewData["EducationalProgramId"] = new SelectList(_context.EducationPrograms, "EducationProgramId", "ProgramName");
            ViewData["EventLocationId"] = new SelectList(_context.Locations, "LocationId", "LocationName");

            ViewData["AnimalId"] = new SelectList(_context.Animals, "AnimalId", "AnimalName");
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FullName");
            return Page();
        }

        [BindProperty]
        public ZooEvent ZooEvent { get; set; } = default!;

        [BindProperty]
        public IList<ZooEventAnimalsInvolved> AnimalsInvolved { get; set; } = new List<ZooEventAnimalsInvolved> { new ZooEventAnimalsInvolved() };

        [BindProperty]
        public IList<ZooEventStaffInvolved> StaffInvolved { get; set; } = new List<ZooEventStaffInvolved> { new ZooEventStaffInvolved() };

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ZooEvents == null || ZooEvent == null)
            {
                ViewData["AnimalProgramId"] = new SelectList(_context.AnimalCarePrograms, "AnimalProgramId", "ProgramName");
                ViewData["EducationalProgramId"] = new SelectList(_context.EducationPrograms, "EducationProgramId", "ProgramName");
                ViewData["EventLocationId"] = new SelectList(_context.Locations, "LocationId", "LocationName");

                ViewData["AnimalId"] = new SelectList(_context.Animals, "AnimalId", "AnimalName");
                ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FullName");
                return Page();
            }

            _context.ZooEvents.Add(ZooEvent);
            await _context.SaveChangesAsync();

            foreach (var animalInvolved in AnimalsInvolved)
            {
                // Assign the generated ExpenseId to each ExpenseItem
                animalInvolved.EventId = ZooEvent.EventId;

                _context.ZooEventAnimalsInvolveds.Add(animalInvolved);
            }
            await _context.SaveChangesAsync();

            foreach (var staffInvolved in StaffInvolved)
            {
                // Assign the generated ExpenseId to each ExpenseItem
                staffInvolved.EventId = ZooEvent.EventId;

                _context.ZooEventStaffInvolveds.Add(staffInvolved);
            }
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
