﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SafariSoul;

namespace SafariSoul.Pages.ZooUserCRUD
{
    public class EditModel : PageModel
    {
        private readonly SafariSoul.OfficalZooDbContext _context;

        public EditModel(SafariSoul.OfficalZooDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ZooUser ZooUser { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ZooUsers == null)
            {
                return NotFound();
            }

            var zoouser =  await _context.ZooUsers.FirstOrDefaultAsync(m => m.UserId == id);
            if (zoouser == null)
            {
                return NotFound();
            }
            ZooUser = zoouser;
           ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId");
           ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ZooUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZooUserExists(ZooUser.UserId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ZooUserExists(int id)
        {
          return (_context.ZooUsers?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
