﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SafariSoul.Models;

namespace SafariSoul.Pages.DataForms.EducationProgramCRUD
{
    public class DeleteModel : PageModel
    {
        private readonly SafariSoul.Models.ZooDbContext _context;

        public DeleteModel(SafariSoul.Models.ZooDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public EducationProgram EducationProgram { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.EducationPrograms == null)
            {
                return NotFound();
            }

            var educationprogram = await _context.EducationPrograms.FirstOrDefaultAsync(m => m.EducationProgramId == id);

            if (educationprogram == null)
            {
                return NotFound();
            }
            else 
            {
                EducationProgram = educationprogram;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.EducationPrograms == null)
            {
                return NotFound();
            }
            var educationprogram = await _context.EducationPrograms.FindAsync(id);

            if (educationprogram != null)
            {
                EducationProgram = educationprogram;
                _context.EducationPrograms.Remove(EducationProgram);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
