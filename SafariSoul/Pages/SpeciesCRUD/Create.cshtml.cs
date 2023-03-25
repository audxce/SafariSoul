using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SafariSoul;
using SafariSoul.Models;

namespace SafariSoul.Pages.SpeciesCRUD
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
        ViewData["ExhibitNo"] = new SelectList(_context.Exhibits, "ExhibitNo", "ExhibitNo");
            return Page();
        }

        [BindProperty]
        public Species Species { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Species == null || Species == null)
            {
                return Page();
            }

            _context.Species.Add(Species);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
