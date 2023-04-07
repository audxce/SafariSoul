using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SafariSoul.Models;

namespace SafariSoul.Pages.EducationProgramCustomer
{
    public class IndexModel : PageModel
    {
        private readonly SafariSoul.OfficalZooDbContext _context;

        public IndexModel(SafariSoul.OfficalZooDbContext context)
        {
            _context = context;
        }

        public IList<EducationProgram> EducationProgram { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.EducationPrograms != null)
            {
                EducationProgram = await _context.EducationPrograms.ToListAsync();
            }
        }
    }
}
