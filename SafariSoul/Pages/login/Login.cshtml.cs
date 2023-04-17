using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MySql.Data.MySqlClient;
using SafariSoul.Models;

namespace SafariSoul.Pages.Login
{
    public class LoginModel : PageModel
    {
        //create a session
        public const string SessionKeyName = "_Name";
        public const string SessionKeyType = "_Type";
        public const string SessionKeyCID = "_CustID";
        public const string SessionKeyEID = "_EmpID";
        private readonly ILogger<PageModel> _logger;
        public LoginModel(ILogger<PageModel> logger)
        {
            _logger = logger;
        }
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
                // Get the user type and ID
                string userType = reader.GetString("User_Type");
                //string customerID = reader.GetString("Customer_ID");
                //string employeeID = reader.GetString("Employee_ID");

                //update the session user
                HttpContext.Session.SetString(SessionKeyName, username);
                var name = HttpContext.Session.GetString(SessionKeyName);
                _logger.LogInformation("Session Name: {Name}", name);

                //update the session type
                HttpContext.Session.SetString(SessionKeyType, userType);
                var type = HttpContext.Session.GetString(SessionKeyType);
                _logger.LogInformation("Session Name: {Name}", type);

                //update the session customer ID
                //HttpContext.Session.SetString(SessionKeyCID, customerID);
                //var CID = HttpContext.Session.GetString(SessionKeyCID);
                //_logger.LogInformation("Session Name: {Name}", CID);

                //update the session employee ID
                //HttpContext.Session.SetString(SessionKeyEID, employeeID);
                //var EID = HttpContext.Session.GetString(SessionKeyEID);
                //_logger.LogInformation("Session Name: {Name}", EID);


                if (userType == "Admin")
                    Response.Redirect("/AdminPage");
                else if (userType == "Accountant")
                    Response.Redirect("/AccountantPage");
                else if(userType == "Animal Handler")
                    Response.Redirect("/AnimalHandlerPage");
                else if (userType == "Customer")
                    Response.Redirect("/CustomerPages/CustomerHome");
                else if (userType == "Other Employee")
                    Response.Redirect("/EmployeePage");
                else if (userType == "Human Resources")
                    Response.Redirect("/HumanResourcesPage");
                else if (userType == "Maintenance")
                    Response.Redirect("/MaintenancePage");
                else if (userType == "Sales")
                    Response.Redirect("/SalesPage");
                else
                    Response.Redirect("/Error");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password.");
            }

            return Page();
        }
    }
}
