﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SafariSoul.Models;

namespace SafariSoul.Pages.ZooTransactionCRUD
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
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "FullName");
            ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "LocationName");
            ViewData["SellerId"] = new SelectList(_context.Employees, "EmployeeId", "FullName");
            return Page();
        }

        [BindProperty]
        public ZooTransaction ZooTransaction { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ZooTransactions == null || ZooTransaction == null)
            {
                ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "FullName");
                ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "LocationName");
                ViewData["SellerId"] = new SelectList(_context.Employees, "EmployeeId", "FullName");
                return Page();
            }

            _context.ZooTransactions.Add(ZooTransaction);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}