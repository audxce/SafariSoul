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
    public class LoginModel : PageModel
    {
        public IActionResult OnPostc()
        {
            string connectionString = "Server = zoo - db - server.mysql.database.azure.com; UserID = audace; Password = '37PE&CWYy9e@'; Database = zoo_db;";
            MySqlConnection connection = new MySqlConnection(connectionString);

            string username = Request.Form["username"];
            string password = Request.Form["password"];

            MySqlCommand command = new MySqlCommand("SELECT * FROM zoo_user WHERE User_Name=@username AND Authentication_Key=@password", connection);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);

            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                string userType = reader.GetString("User_Type");

                switch (userType)
                {
                    case "Admin":
                        return RedirectToPage("Admin View");
                    case "Employee":
                        return RedirectToPage("Employee View");
                    case "Customer":
                        return RedirectToPage("Customer View");
                    case "Default":
                        return RedirectToPage("Default View");
                    default:
                        ModelState.AddModelError(string.Empty, "Invalid user type.");
                        break;
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password.");
            }

            return Page();
        }
    }
}
