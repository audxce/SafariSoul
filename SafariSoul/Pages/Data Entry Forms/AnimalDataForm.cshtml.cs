using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace SafariSoul.Pages.Data_Entry_Forms
{
    public class AnimalData : PageModel
    {
        private readonly ZooDbContext _context;
        private readonly ILogger<AnimalData> _logger;

        public AnimalData(ZooDbContext context, ILogger<AnimalData> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Animal Animal { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.animal.Add(Animal);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Animal {AnimalName} added.", Animal.AnimalName);

            return RedirectToPage("/Index");
        }
    }

    public class Animal
    {
        [StringLength(30)]
        public string AnimalName { get; set; }

        [Required]
        [StringLength(30)]
        public string Genus { get; set; }

        [Required]
        [StringLength(30)]
        public string Species { get; set; }

        public string? UniqueDescriptors { get; set; }

        public DateOnly DOB { get; set; }

        [Required]
        public string Gender { get; set; }

        public string? DietaryRestrictions { get; set; }
    }
}