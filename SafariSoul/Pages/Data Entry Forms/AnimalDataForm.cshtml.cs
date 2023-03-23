using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SafariSoul.Pages
{
    public class AnimalData : PageModel
    {
        [BindProperty]
        public AnimalData AnimalInput { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Store the input in the database or any other storage mechanism here

            return RedirectToPage("/Index");
        }
    }

    public class AnimaInput
    {
        [Required] // part of the System.ComponentModel.DataAnnotations namespace, and it is used to perform server-side validation of user input
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
