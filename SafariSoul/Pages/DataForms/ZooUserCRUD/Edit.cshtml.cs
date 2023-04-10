using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SafariSoul.Models;

namespace SafariSoul.Pages.ZooUserCRUD
{
    public class EditModel : PageModel
    {
        private readonly SafariSoul.Models.ZooDbContext _context;

        public EditModel(SafariSoul.Models.ZooDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ZooUser ZooUser { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.ZooUsers == null)
            {
                return NotFound();
            }

            var zoouser =  await _context.ZooUsers.FirstOrDefaultAsync(m => m.UserName == id);
            if (zoouser == null)
            {
                return NotFound();
            }
            ZooUser = zoouser;
           ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "FullName");
           ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FullName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "FullName");
                ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FullName");
                return Page();
            }

            _context.Attach(ZooUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZooUserExists(ZooUser.UserName))
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

        private bool ZooUserExists(string id)
        {
          return (_context.ZooUsers?.Any(e => e.UserName == id)).GetValueOrDefault();
        }
    }
}
