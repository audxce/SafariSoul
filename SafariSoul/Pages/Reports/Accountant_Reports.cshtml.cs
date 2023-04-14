using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySqlConnector;

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
                    WHERE V.created_at BETWEEN @FromDate AND @ToDate
                      AND E.Expense_ID = EI.Expense_ID
                      AND V.Vendor_ID = E.Vendor_ID
                      AND E.created_at BETWEEN @FromDate AND @ToDate
                    GROUP BY V.Vendor_ID

                    UNION

                    SELECT D.Dept_Name as Department_Name, D.Location_ID as Department_Location, D.Budget as Department_Budget
                    FROM department D
                    WHERE D.created_at BETWEEN @FromDate AND @ToDate;
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
                using (MySqlCommand command = new MySqlCommand(@"SELECT ZE.Event_Name as Source_Name, 
                           ZE.Event_ID as Source_ID, 
                           sum(case when ZTT.Event_ID =ZE.Event_ID then ZTT.Ticket_Quantity * ZE.Admission_Price else 0 end )  as Total_Revenue
                        FROM zoo_event ZE
                        JOIN zoo_transaction_event_tickets ZTT ON ZE.Event_ID = ZTT.Event_ID
                        WHERE ZE.created_at BETWEEN @FromDate AND @ToDate
                        GROUP BY ZE.Event_ID

                        UNION

                        SELECT CONCAT(C.Fname, ' ', C.Lname) as Source_Name, 
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
                            revenueReport.Total_Revenue = Convert.ToInt32(reader["Total_Revenue"]);
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
