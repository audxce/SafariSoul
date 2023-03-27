using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SafariSoul;

namespace SafariSoul.Pages.AnimalCareProgramCRUD
{
    public class DeleteModel : PageModel
    {
        private readonly SafariSoul.OfficalZooDbContext _context;

        public DeleteModel(SafariSoul.OfficalZooDbContext context)
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

            var animalcareprogram = await _context.AnimalCarePrograms.FirstOrDefaultAsync(m => m.AnimalProgramNum == id);

            if (animalcareprogram == null)
            {
                return NotFound();
            }
            else 
            {
                AnimalCareProgram = animalcareprogram;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.AnimalCarePrograms == null)
            {
                return NotFound();
            }
            var animalcareprogram = await _context.AnimalCarePrograms.FindAsync(id);

            if (animalcareprogram != null)
            {
                AnimalCareProgram = animalcareprogram;
                _context.AnimalCarePrograms.Remove(AnimalCareProgram);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
