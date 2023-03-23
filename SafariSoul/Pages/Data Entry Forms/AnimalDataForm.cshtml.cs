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
            Random rnd = new Random();
            int animalID = rnd.Next();

            string animalName = "";
            string genus = "";
            string species = "";
            string desc = "";
            DateTime dob = DateTime.Now;
            string gender = "";
            string diet = "";
            string rec = "";

            if (isPost)
            {
                animalName = Request.Form["AnimalName"];
                genus = Request.Form["Genus"];
                species = Request.Form["Species"];
                desc = Request.Form["UniqueDescriptors"];
                dob = Request.Form["DOB"];
                gender = Request.Form["gender"];
                diet = Request.Form["DietaryRestrictions"];
                rec = Request.Form["Recreation"];

                var db = Database.Open("zoo-db-server");
                var insertCommand = "INSERT INTO animal (Animal_ID, Animal_Name, Date_of_Birth, Dietary_Restrictions, Genus, Recreation, Species, Unique_Descriptors VALUES (@0, @1, @2, @3, @4, @5, @6, @7)";
                db.Execute(insertCommand, animalID, animalName, dob, diet, genus, rec, species, desc);
            }

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

        public DateTime DOB { get; set; }

        [Required]
        public string Gender { get; set; }

        public string? DietaryRestrictions { get; set; }
    }
}
