using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SafariSoul.Models;

namespace SafariSoul.Pages.AnimalCRUD
{
    public class IndexModel : PageModel
    {
        private readonly SafariSoul.Models.ZooDbContext _context;

        public IndexModel(SafariSoul.Models.ZooDbContext context)
        {
            _context = context;
        }

        public IList<Animal> Animal { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Animals != null)
            {
                Animal = await _context.Animals
                .Include(a => a.FatherNavigation)
                .Include(a => a.MotherNavigation)
                .Include(a => a.Species).ToListAsync();
            }
        }

        public async Task OnPostAsync()
        {
            var searchName = Request.Form["searchName"];
            var searchSpecies = Request.Form["searchSpecies"];

            if (!String.IsNullOrEmpty(searchName))
            {
                Animal = await _context.Animals
                .Where(a => a.AnimalName.Contains(searchName))
                .Include(a => a.FatherNavigation)
                .Include(a => a.MotherNavigation)
                .Include(a => a.Species).ToListAsync();
            }
            if (!String.IsNullOrEmpty(searchSpecies))
            {
                Animal = await _context.Animals
                .Where(a => a.AnimalName.Contains(searchSpecies))
                .Include(a => a.FatherNavigation)
                .Include(a => a.MotherNavigation)
                .Include(a => a.Species).ToListAsync();
            }
        }
    }
}
