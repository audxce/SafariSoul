using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SafariSoul.Models;

namespace SafariSoul.Pages.DepartmentCRUD
{
    public class IndexModel : PageModel
    {
        private readonly SafariSoul.Models.ZooDbContext _context;

        public IndexModel(SafariSoul.Models.ZooDbContext context)
        {
            _context = context;
        }

        public IList<Department> Department { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Departments != null)
            {
                Department = await _context.Departments
                .Include(d => d.Location)
                .Include(d => d.Manager).ToListAsync();
            }
        }

        public async Task OnPostAsync()
        {
            var searchName = Request.Form["searchName"];

            if (!String.IsNullOrEmpty(searchName))
            {
                Department = await _context.Departments
                .Where(d => d.DeptName.Contains(searchName))
                .Include(d => d.Location)
                .Include(d => d.Manager).ToListAsync();
            }
        }
    }
}
