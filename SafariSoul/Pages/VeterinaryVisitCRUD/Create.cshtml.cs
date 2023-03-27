using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SafariSoul;

namespace SafariSoul.Pages.VeterinaryVisitCRUD
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
        ViewData["Animal"] = new SelectList(_context.Animals, "AnimalId", "AnimalId");
            return Page();
        }

        [BindProperty]
        public VeterinaryVisit VeterinaryVisit { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.VeterinaryVisits == null || VeterinaryVisit == null)
            {
                return Page();
            }

            _context.VeterinaryVisits.Add(VeterinaryVisit);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
