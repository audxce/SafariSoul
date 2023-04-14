using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using SafariSoul.Models;

namespace SafariSoul.Pages.Login
{
    /*public class LoginModel : PageModel
    {
        public IActionResult OnPost()
        {
            string connectionString = "Server=zoo-db-server.mysql.database.azure.com;UserID=audace;Password='37PE&CWYy9e@';Database=zoo_db;";
            MySqlConnection connection = new MySqlConnection(connectionString);

            // Get the username and password from the form
            string username = Request.Form["username"];
            string password = Request.Form["password"];

            // Check if the username and password are valid
            connection.Open();

            // Create a command to check if the username and password are valid
            MySqlCommand command = new MySqlCommand("SELECT * FROM zoo_user WHERE User_Name=@username AND Authentication_Key=@password", connection);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);

            // Execute the command
            command.ExecuteNonQuery();

            // Get the result of the command
            MySqlDataReader reader = command.ExecuteReader();

            // Check if the username and password are valid
            if (reader.Read())
            {
                // Get the user type
                string userType = reader.GetString("User_Type");
                switch (userType)
                {
                    // since we are still testing, we will just show a message that confirms what type of user is logged in
                    case "Admin":
                        return Content($"Admin Logged in");
                    case "Employee":
                        return Content($"Employee Logged in");
                    case "Customer":
                        return Content($"Customer Logged in");
                    default:
                        return Content($"Default Logged in");
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password.");
            }

            return Page();
        }
    }*/

    public class LoginModel : PageModel
    {
        public const string SessionKeyName = "_Name";

        private readonly ILogger<PageModel> _logger;

        public LoginModel(ILogger<PageModel> logger)
        {
            _logger = logger;
        }

        public async Task OnPost()
        {
            var username = Request.Form["Username"];

            if (!String.IsNullOrEmpty(username))
            {
                HttpContext.Session.SetString(SessionKeyName, username);
                //if (await _context.ZooUsers.Where(username == a.UserName))
                //ZooUsers = await _context.ZooUsers.Where(a => a.UserName==username && a => a.AuthenticationKey==password);
            }
        }
        /*public void OnGet()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyName)))
            {
                HttpContext.Session.SetString(SessionKeyName, "Default");
            }
            var name = HttpContext.Session.GetString(SessionKeyName);

            _logger.LogInformation("Session Name: {Name}", name);
        }*/
    }

}
