using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySqlConnector;
using SafariSoul.Models;
using System.Text.RegularExpressions;

namespace SafariSoul.Pages.Reports
{
    public class Accountant_ReportsModel : PageModel
    {
        //public IActionResult OnGet()
        //{
        //    return Page();
        //}
        //public IActionResult OnPost()
        //{
        //    var fromDate = DateTime.Parse(Request.Form["FromDate"]);
        //    var toDate = DateTime.Parse(Request.Form["ToDate"]);

        //    return OnGet(fromDate, toDate);
        //}

        public IActionResult OnPost(DateTime fromDate, DateTime toDate)
        {
            var reportType = Request.Form["reportType"];

            if (reportType == "Revenue Report")
            {

                return OnGetRevenue(fromDate, toDate);
            }
            else if (reportType == "Expense Report")
            {
                // generate expense report
                return OnGetExpense(fromDate, toDate);
            }
            else
            {
                // handle error
                return Page();
            }
        }

        public IActionResult OnGetExpense(DateTime fromDate, DateTime toDate)
        {
            List<ExpenseReport> expReport = new List<ExpenseReport>();

            using (MySqlConnection connection = new MySqlConnection("Server=zoo-db-server.mysql.database.azure.com;UserID=audace;Password='37PE&CWYy9e@';Database=zoo_db;"))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(@"SELECT V.Vendor_Name as Vendor_Name, V.Vendor_ID as Vendor_ID,
                        SUM(CASE WHEN V.Vendor_ID = E.Vendor_ID AND E.Expense_ID = EI.Expense_ID THEN Expense_Amount ELSE 0 END) AS Total_Spent 
                    FROM vendor V, expense_items EI, expense E
                    WHERE (case when V.updated_at IS NULL then V.created_at else V.updated_at end) BETWEEN @FromDate AND @ToDate
                      AND E.Expense_ID = EI.Expense_ID
                      AND V.Vendor_ID = E.Vendor_ID
                      AND (case when E.updated_at IS NULL then E.created_at else E.updated_at end) BETWEEN @FromDate AND @ToDate
                    GROUP BY V.Vendor_ID

                    UNION

                    SELECT D.Dept_Name as Department_Name, D.Location_ID as Department_Location, D.Budget as Department_Budget
                    FROM department D
                    WHERE (case when D.updated_at IS NULL then D.created_at else D.updated_at end) BETWEEN @FromDate AND @ToDate;
                          ", connection))
                {
                    command.Parameters.AddWithValue("@FromDate", fromDate);
                    command.Parameters.AddWithValue("@ToDate", toDate);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ExpenseReport expenseReport = new ExpenseReport();
                            expenseReport.Vendor_ID = Convert.ToInt32(reader["Vendor_ID"]);
                            expenseReport.Vendor_Name = reader["Vendor_Name"].ToString();
                            expenseReport.Total_Spent = Convert.ToInt32(reader["Total_Spent"]);
                            //revenueReport.Location_ID = Convert.ToInt32(reader["Department_Location"]);
                            //revenueReport.Department_Name = reader["Department_Name"].ToString();
                            //revenueReport.Department_Budget = Convert.ToInt32(reader["Department_Budget"]);
                            expReport.Add(expenseReport);
                        }

                    }




                }

                ViewData["ExpenseReport"] = expReport;

                return Page();
            }




        }

        public IActionResult OnGetRevenue(DateTime fromDate, DateTime toDate)
        {
            List<RevenueReport> revReport = new List<RevenueReport>();

            using (MySqlConnection connection = new MySqlConnection("Server=zoo-db-server.mysql.database.azure.com;UserID=audace;Password='37PE&CWYy9e@';Database=zoo_db;"))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(@"SELECT CONCAT('Tickets Purchased by ', C.Fname, ' ', C.Lname) as Source_Name,
                            C.Customer_ID as Source_ID, SUM(General_Ticket_Quantity)*20 as Ticket
                        FROM zoo_transaction ZE
                        JOIN customer C ON C.Customer_ID = ZE.Customer_ID
                        WHERE ZE.created_at BETWEEN @FromDate AND  @ToDate
                       GROUP BY C.Customer_ID

                        UNION

                        SELECT CONCAT('Donated by ',C.Fname, ' ', C.Lname) as Source_Name, 
                               D.Donor_ID as Source_ID, 
                               sum(D.Amount_Donated) as Total_Revenue
                        FROM donation D
                        JOIN customer C ON C.Customer_ID = D.Donor_ID
                        WHERE D.created_at BETWEEN @FromDate AND @ToDate
                        GROUP BY C.Customer_ID;
                          ", connection))
                {
                    command.Parameters.AddWithValue("@FromDate", fromDate);
                    command.Parameters.AddWithValue("@ToDate", toDate);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            RevenueReport revenueReport = new RevenueReport();
                            revenueReport.Source_Name = reader["Source_Name"].ToString();
                            revenueReport.Source_ID = Convert.ToInt32(reader["Source_ID"]);
                            revenueReport.Total_Revenue = Convert.ToInt32(reader["Ticket"]);
                            //revenueReport.Location_ID = Convert.ToInt32(reader["Department_Location"]);
                            //revenueReport.Department_Name = reader["Department_Name"].ToString();
                            //revenueReport.Department_Budget = Convert.ToInt32(reader["Department_Budget"]);
                            revReport.Add(revenueReport);
                        }

                    }




                }

                ViewData["RevenueReport"] = revReport;

                return Page();
            }
        }


        public class ExpenseReport
        {
            public string Vendor_Name { get; set; }
            public int Vendor_ID { get; set; }
            public int Total_Spent { get; set; }
            public string Department_Name { get; set; }
            public int Location_ID { get; set; }
            public int Department_Budget { get; set; }
        }

        public class RevenueReport
        {
            public string Source_Name { get; set; }
            public int Source_ID { get; set; }
            public int Total_Revenue { get; set; }
        }


    }
}
