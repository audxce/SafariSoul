﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SafariSoul.Models;

namespace SafariSoul.Pages.DependentCRUD
{
    public class IndexModel : PageModel
    {
        private readonly SafariSoul.Models.ZooDbContext _context;

        public IndexModel(SafariSoul.Models.ZooDbContext context)
        {
            _context = context;
        }

        public IList<Dependent> Dependent { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Dependents != null)
            {
                Dependent = await _context.Dependents
                .Include(d => d.Employee).ToListAsync();
            }
        }
    }
}
