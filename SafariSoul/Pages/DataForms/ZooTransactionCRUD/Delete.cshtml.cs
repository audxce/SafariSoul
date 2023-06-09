﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SafariSoul.Models;

namespace SafariSoul.Pages.DataForms.ZooTransactionCRUD
{
    public class DeleteModel : PageModel
    {
        private readonly SafariSoul.Models.ZooDbContext _context;

        public DeleteModel(SafariSoul.Models.ZooDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ZooTransaction ZooTransaction { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ZooTransactions == null)
            {
                return NotFound();
            }

            var zootransaction = await _context.ZooTransactions
                .Include(z => z.Customer)
                .Include(z => z.Location)
                .Include(z => z.Seller)
                .Include(z => z.ZooTransactionItems)
                .ThenInclude(zi => zi.Item)
                .FirstOrDefaultAsync(m => m.TransactionId == id);

            if (zootransaction == null)
            {
                return NotFound();
            }
            else
            {
                ZooTransaction = zootransaction;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ZooTransactions == null)
            {
                return NotFound();
            }
            var zootransaction = await _context.ZooTransactions.FindAsync(id);

            if (zootransaction != null)
            {
                ZooTransaction = zootransaction;
                _context.ZooTransactions.Remove(ZooTransaction);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
