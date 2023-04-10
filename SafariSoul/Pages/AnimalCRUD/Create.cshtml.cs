using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SafariSoul.Models;

namespace SafariSoul.Pages.AnimalCRUD
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
        ViewData["Father"] = new SelectList(_context.Animals.Where(a => a.Gender == "Male"), "AnimalId", "AnimalName");
        ViewData["Mother"] = new SelectList(_context.Animals.Where(a => a.Gender == "Female"), "AnimalId", "AnimalName");
        ViewData["SpeciesId"] = new SelectList(_context.Species, "SpeciesId", "CommonName");
            return Page();
        }

        [BindProperty]
        public Animal Animal { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Animals == null || Animal == null)
            {
                ViewData["Father"] = new SelectList(_context.Animals.Where(a => a.Gender == "Male"), "AnimalId", "AnimalName");
                ViewData["Mother"] = new SelectList(_context.Animals.Where(a => a.Gender == "Female"), "AnimalId", "AnimalName");
                ViewData["SpeciesId"] = new SelectList(_context.Species, "SpeciesId", "CommonName");
                return Page();
            }

            _context.Animals.Add(Animal);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
