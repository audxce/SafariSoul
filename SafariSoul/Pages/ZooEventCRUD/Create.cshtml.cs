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
            return Page();
        }

        [BindProperty]
        public ZooEvent ZooEvent { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ZooEvents == null || ZooEvent == null)
            {
                ViewData["AnimalProgramId"] = new SelectList(_context.AnimalCarePrograms, "AnimalProgramId", "ProgramName");
                ViewData["EducationalProgramId"] = new SelectList(_context.EducationPrograms, "EducationProgramId", "ProgramName");
                ViewData["EventLocationId"] = new SelectList(_context.Locations, "LocationId", "LocationName");
                return Page();
            }

            _context.ZooEvents.Add(ZooEvent);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
