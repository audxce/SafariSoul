using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SafariSoul;
using SafariSoul.Models;

namespace SafariSoul.Pages.EmployeeCRUD
{
    public class IndexModel : PageModel
    {
        private readonly SafariSoul.OfficalZooDbContext _context;

        public IndexModel(SafariSoul.OfficalZooDbContext context)
        {
            _context = context;
        }

        public string fnameFilter { get; set; }
        public string lnameFilter { get; set; }
        public string occupationFilter { get; set; }

        public IList<Employee> Employee { get;set; } = default!;

        public async Task OnGetAsync(string fnameSearch, string lnameSearch, string occupationSearch)
        {
            fnameFilter = fnameSearch;
            lnameFilter = lnameSearch;
            occupationFilter = occupationSearch;


            if (_context.Employees != null)
            {
                IQueryable<Employee> employeeIQ = from e in _context.Employees
                                                 select e;
                if(!String.IsNullOrEmpty(fnameSearch))
                {
                    employeeIQ = employeeIQ.Where(e => e.Fname.Contains(fnameSearch));
                }
                if(!String.IsNullOrEmpty(lnameSearch))
                {
                    employeeIQ = employeeIQ.Where(e => e.Lname.Contains(lnameSearch));
                }
                if(!String.IsNullOrEmpty(occupationSearch))
                {
                    employeeIQ = employeeIQ.Where(e => e.Occupation.Contains(occupationSearch));
                }
                Employee = await _context.Employees
                .Include(e => e.DeptNoNavigation)
                .Include(e => e.LocationNavigation)
                .Include(e => e.OccupationNavigation)
                .Include(e => e.Sup).ToListAsync();
            }
        }
    }
}
