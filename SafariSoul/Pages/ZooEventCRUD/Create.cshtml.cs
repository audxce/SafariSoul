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
        private readonly SafariSoul.OfficalZooDbContext _context;

        public CreateModel(SafariSoul.OfficalZooDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AnimalProgramNo"] = new SelectList(_context.AnimalCarePrograms, "AnimalProgramNum", "AnimalProgramNum");
        ViewData["EducationalProgramNo"] = new SelectList(_context.EducationPrograms, "ProgramNo", "ProgramNo");
        ViewData["EventLocation"] = new SelectList(_context.Locations, "LocationNum", "LocationNum");
            return Page();
        }

        [BindProperty]
        public ZooEvent ZooEvent { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ZooEvents == null || ZooEvent == null)
            {
                return Page();
            }

            _context.ZooEvents.Add(ZooEvent);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
