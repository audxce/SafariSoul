﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SafariSoul;
using SafariSoul.Models;

namespace SafariSoul.Pages.EmployeeCRUD
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
        ViewData["DeptNo"] = new SelectList(_context.Departments, "DeptId", "DeptId");
        ViewData["Location"] = new SelectList(_context.Locations, "LocationNum", "LocationNum");
        ViewData["Occupation"] = new SelectList(_context.Occupations, "JobTitle", "JobTitle");
        ViewData["SupId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId");
            return Page();
        }

        [BindProperty]
        public Employee Employee { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Employees == null || Employee == null)
            {
                return Page();
            }

            _context.Employees.Add(Employee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}