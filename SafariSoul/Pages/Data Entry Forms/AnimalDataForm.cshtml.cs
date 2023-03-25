using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SafariSoul.Models;

namespace SafariSoul.Pages.Data_Entry_Forms
{
    public class AnimalData : PageModel
    {
        private readonly OfficalZooDbContext _context;

        public AnimalData(OfficalZooDbContext context)
        {
            _context = context;

        }

        [BindProperty]
        public Animal Animal { get; set; } = default!;

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Animals.Add(Animal);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
}