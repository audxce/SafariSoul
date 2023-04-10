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
    public class IndexModel : PageModel
    {
        private readonly SafariSoul.Models.ZooDbContext _context;

        public IndexModel(SafariSoul.Models.ZooDbContext context)
        {
            _context = context;
        }

        public IList<ExpenseItem> ExpenseItem { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ExpenseItems != null)
            {
                ExpenseItem = await _context.ExpenseItems
                .Include(e => e.Expense)
                .Include(e => e.Item).ToListAsync();
            }
        }
    }
}
