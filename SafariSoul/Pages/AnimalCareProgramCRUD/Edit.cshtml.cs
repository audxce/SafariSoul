using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SafariSoul;

namespace SafariSoul.Pages.AnimalCareProgramCRUD
{
    public class EditModel : PageModel
    {
        private readonly SafariSoul.OfficalZooDbContext _context;

        public EditModel(SafariSoul.OfficalZooDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AnimalCareProgram AnimalCareProgram { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AnimalCarePrograms == null)
            {
                return NotFound();
            }

            var animalcareprogram =  await _context.AnimalCarePrograms.FirstOrDefaultAsync(m => m.AnimalProgramNum == id);
            if (animalcareprogram == null)
            {
                return NotFound();
            }
            AnimalCareProgram = animalcareprogram;
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

            _context.Attach(AnimalCareProgram).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalCareProgramExists(AnimalCareProgram.AnimalProgramNum))
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

        private bool AnimalCareProgramExists(int id)
        {
          return (_context.AnimalCarePrograms?.Any(e => e.AnimalProgramNum == id)).GetValueOrDefault();
        }
    }
}
