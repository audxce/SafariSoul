using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SafariSoul.Models;

namespace SafariSoul.Pages.EmployeeAnimalHandlerPage.AnimalCareProgramCRUD
{
    public class DetailsModel : PageModel
    {
        private readonly SafariSoul.Models.ZooDbContext _context;

        public DetailsModel(SafariSoul.Models.ZooDbContext context)
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

            var animalcareprogram = await _context.AnimalCarePrograms.FirstOrDefaultAsync(m => m.AnimalProgramId == id);
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
