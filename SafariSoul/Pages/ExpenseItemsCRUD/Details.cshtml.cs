using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SafariSoul.Models;

namespace SafariSoul.Pages.ExpenseItemsCRUD
{
    public class DetailsModel : PageModel
    {
        private readonly SafariSoul.Models.ZooDbContext _context;

        public DetailsModel(SafariSoul.Models.ZooDbContext context)
        {
            _context = context;
        }

      public ExpenseItem ExpenseItem { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ExpenseItems == null)
            {
                return NotFound();
            }

            var expenseitem = await _context.ExpenseItems.FirstOrDefaultAsync(m => m.MultiItemsId == id);
            if (expenseitem == null)
            {
                return NotFound();
            }
            else 
            {
                ExpenseItem = expenseitem;
            }
            return Page();
        }
    }
}
