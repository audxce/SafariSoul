using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MySql.Data.MySqlClient;
using SafariSoul.Models;

namespace SafariSoul.Pages.Login
{
    public class SignupModel : PageModel
    {
        public IActionResult OnPost()
        {
            string connectionString = "Server=zoo-db-server.mysql.database.azure.com;UserID=audace;Password='37PE&CWYy9e@';Database=zoo_db;";
            MySqlConnection connection = new MySqlConnection(connectionString);

            // get the information from the form
            string Email = Request.Form["Email"];
            string Username = Request.Form["Username"];
            string AuthenticationKey = Request.Form["AuthenticationKey"];
            string ConfirmAuthenticationKey = Request.Form["ConfirmAuthenticationKey"];

            // first check if the authentication keys match
            if (AuthenticationKey != ConfirmAuthenticationKey)
            {
                return Content($"Passwords do not match");
            }

            // check if the username is already taken
            connection.Open();
            MySqlCommand checkUsernameCmd = new MySqlCommand("SELECT * FROM zoo_user WHERE User_Name=@username", connection);
            checkUsernameCmd.Parameters.AddWithValue("@username", Username);
            checkUsernameCmd.ExecuteNonQuery();
            MySqlDataReader reader = checkUsernameCmd.ExecuteReader();
            if (reader.HasRows)
            {
                return Content($"Username is already taken");
            }
            //close the connection
            connection.Close();

            // if we get here, we can add the user to the database
            connection.Open();
            MySqlCommand command = new MySqlCommand("INSERT INTO zoo_user (User_Name, Authentication_Key, User_Type) VALUES (@Username, @AuthenticationKey, 'Customer')", connection);
            command.Parameters.AddWithValue("@Username", Username);
            command.Parameters.AddWithValue("@AuthenticationKey", AuthenticationKey);
            command.ExecuteNonQuery();
            connection.Close();

            // once the user is added, return them to the login page
            return RedirectToPage("/Login/Login");
        }
    }
}
