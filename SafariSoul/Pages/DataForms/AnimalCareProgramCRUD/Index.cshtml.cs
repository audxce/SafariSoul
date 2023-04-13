using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SafariSoul.Models;

namespace SafariSoul.Pages.AnimalCareProgramCRUD
{
    public class IndexModel : PageModel
    {
        private readonly SafariSoul.Models.ZooDbContext _context;

        public IndexModel(SafariSoul.Models.ZooDbContext context)
        {
            _context = context;
        }

        public IList<AnimalCareProgram> AnimalCareProgram { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.AnimalCarePrograms != null)
            {
                AnimalCareProgram = await _context.AnimalCarePrograms.ToListAsync();
            }
        }

        public async Task OnPostAsync()
        {
            var searchName = Request.Form["searchName"];

            if(!String.IsNullOrEmpty(searchName))
            {
                AnimalCareProgram = await _context.AnimalCarePrograms.Where(a => a.ProgramName.Contains(searchName)).ToListAsync();
            }
        }
    }
}
