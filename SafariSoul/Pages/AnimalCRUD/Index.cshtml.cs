using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SafariSoul;
using SafariSoul.Models;

namespace SafariSoul.Pages.AnimalCRUD
{
    public class IndexModel : PageModel
    {
        private readonly SafariSoul.OfficalZooDbContext _context;

        public IndexModel(SafariSoul.OfficalZooDbContext context)
        {
            _context = context;
        }

        public string CurrentFilter { get; set; }

        public IList<Animal> Animal { get;set; } = default!;

        public async Task OnGetAsync(string searchString)
        {
            CurrentFilter = searchString;

            if (_context.Animals != null)
            {
                IQueryable<Animal> animalIQ = from a in _context.Animals
                                              select a;
                if(!String.IsNullOrEmpty(searchString))
                {
                    animalIQ = animalIQ.Where(a => a.AnimalID.Contains(searchString) || a => a.AnimalID.Contains(searchString) || a => a.Species.Contains(searchString));
                }
                Animal = await _context.Animals
                .Include(a => a.SpeciesNavigation).ToListAsync();
            }
        }
    }
}
