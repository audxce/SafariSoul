using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SafariSoul.Models;

namespace SafariSoul.Pages
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {
        }

		private readonly SafariSoul.Models.ZooDbContext _context;

		public LoginModel(SafariSoul.Models.ZooDbContext context)
		{
			_context = context;
		}

		public IList<ZooUser> ZooUsers { get; set; } = default!;

		public async Task OnGetAsync()
		{
			if (_context.ZooUsers != null)
			{
				ZooUsers = await _context.ZooUsers.Include(a => a.UserName).ToListAsync();
			}
		}

		public async Task OnPostAsync()
		{
			var username = Request.Form["email"];
			var password = Request.Form["pass"];

			if (!String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(password))
			{
				//ZooUsers = await _context.ZooUsers.Where(a => a.UserName==username && a => a.AuthenticationKey==password));
			}
		}
	}
}
/*
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

        public IList<Animal> Animal { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Animals != null)
            {
                Animal = await _context.Animals.Include(a => a.SpeciesNavigation).ToListAsync();
            }
        }

        public async Task OnPostAsync()
        {
            var searchName = Request.Form["searchName"];
            var searchSpecies = Request.Form["searchSpecies"];

            if(!String.IsNullOrEmpty(searchName))
            {
                Animal = await _context.Animals.Where(a => a.AnimalName.Contains(searchName)).Include(a => a.SpeciesNavigation).ToListAsync();
            }
            if(!String.IsNullOrEmpty(searchSpecies))
            {
                Animal = await _context.Animals.Where(a => a.Species.Contains(searchSpecies)).Include(a => a.SpeciesNavigation).ToListAsync();
            }
        }
    }
}
 */