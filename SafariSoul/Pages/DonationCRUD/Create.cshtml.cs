using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SafariSoul;

namespace SafariSoul.Pages.DonationCRUD
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
        ViewData["DonorId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId");
            return Page();
        }

        [BindProperty]
        public Donation Donation { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Donations == null || Donation == null)
            {
                return Page();
            }

            _context.Donations.Add(Donation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
