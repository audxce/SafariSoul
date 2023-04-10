using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SafariSoul.Models;

namespace SafariSoul.Pages.ExpenseItemsCRUD
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
        ViewData["ExpenseId"] = new SelectList(_context.Expenses, "ExpenseId", "ExpenseId");
        ViewData["ItemId"] = new SelectList(_context.Inventories, "ItemId", "ItemId");
            return Page();
        }

        [BindProperty]
        public ExpenseItem ExpenseItem { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ExpenseItems == null || ExpenseItem == null)
            {
                return Page();
            }

            _context.ExpenseItems.Add(ExpenseItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
