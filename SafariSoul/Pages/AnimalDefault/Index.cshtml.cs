using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SafariSoul.Models;

namespace SafariSoul.Pages.AnimalDefault
{
    public class IndexModel : PageModel
    {
        private readonly SafariSoul.OfficalZooDbContext _context;

        public IndexModel(SafariSoul.OfficalZooDbContext context)
        {
            _context = context;
        }

        public string nameFilter { get; set; }
        public string speciesFilter { get; set; }

        public IList<Animal> Animal { get; set; } = default!;

        public async Task OnGetAsync(string nameSearch, string speciesSearch)
        {
            nameFilter = nameSearch;
            speciesFilter = speciesSearch;

            if (_context.Animals != null)
            {
                IQueryable<Animal> animalIQ = from a in _context.Animals
                                              select a;
                if (!String.IsNullOrEmpty(nameSearch))
                {
                    animalIQ = animalIQ.Where(a => a.AnimalName.Contains(nameSearch));
                }
                if (!String.IsNullOrEmpty(speciesSearch))
                {
                    animalIQ = animalIQ.Where(a => a.Species.Contains(speciesSearch));
                }
                Animal = await _context.Animals
                .Include(a => a.SpeciesNavigation).ToListAsync();
            }
        }
    }
}
