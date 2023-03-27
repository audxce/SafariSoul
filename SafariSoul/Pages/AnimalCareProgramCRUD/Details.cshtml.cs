using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SafariSoul.Models;

namespace SafariSoul.Pages.AnimalCareProgramCRUD
{
    public class DetailsModel : PageModel
    {
        private readonly SafariSoul.OfficalZooDbContext _context;

        public DetailsModel(SafariSoul.OfficalZooDbContext context)
        {
            _context = context;
        }

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
    }
}
