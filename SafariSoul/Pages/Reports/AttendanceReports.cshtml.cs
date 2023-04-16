using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.Scripting;
using MySqlConnector;
using System.Runtime.Intrinsics.X86;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace SafariSoul.Pages.Reports
{
    public class AttendanceReportsModel : PageModel
    {


        public IActionResult OnPost(DateTime fromDate, DateTime toDate)
        {
            var reportType = Request.Form["reportType"];

            if (reportType == "By Day of Week")
            {

                return OnGetWeek(fromDate, toDate);
            }
            else if (reportType == "By Month of Year")
            {
                // generate expense report
                return OnGetMonth(fromDate, toDate);
            }
            else if (reportType == "By Quarter of Year")
            {
                // generate expense report
                return OnGetQuarter(fromDate, toDate);
            }
            else
            {
                // handle error
                return Page();
            }
        }
        public IActionResult OnGetWeek(DateTime fromDate, DateTime toDate)
        {
            List<AttendanceReport> attReport = new List<AttendanceReport>();

            using (MySqlConnection connection = new MySqlConnection("Server=zoo-db-server.mysql.database.azure.com;UserID=audace;Password='37PE&CWYy9e@';Database=zoo_db;"))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(@"SELECT DAYNAME(General_Ticket_Date) AS day_of_week,  sum(General_Ticket_Quantity) as Ticket
                                FROM zoo_transaction where General_Ticket_Date between @FromDate and @ToDate
                                GROUP BY DAYNAME(General_Ticket_Date)
                                ORDER BY Ticket DESC;", connection))
                {
                    command.Parameters.AddWithValue("@FromDate", fromDate);
                    command.Parameters.AddWithValue("@ToDate", toDate);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AttendanceReport attendanceReport = new AttendanceReport();
                            attendanceReport.Day = reader["day_of_week"].ToString();
                            attendanceReport.NumOfTick = Convert.ToInt32(reader["Ticket"]);
                            //attendanceReports.Total_Spent = Convert.ToInt32(reader["Total_Spent"]);
                            //revenueReport.Location_ID = Convert.ToInt32(reader["Department_Location"]);
                            //revenueReport.Department_Name = reader["Department_Name"].ToString();
                            //revenueReport.Department_Budget = Convert.ToInt32(reader["Department_Budget"]);
                            attReport.Add(attendanceReport);
                        }

                    }




                }

                ViewData["AttendancebyWeek"] = attReport;

                return Page();
            }




        }

        public IActionResult OnGetMonth(DateTime fromDate, DateTime toDate)
        {
            List<AttendanceReport> attReport = new List<AttendanceReport>();

            using (MySqlConnection connection = new MySqlConnection("Server=zoo-db-server.mysql.database.azure.com;UserID=audace;Password='37PE&CWYy9e@';Database=zoo_db;"))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(@"SELECT YEAR(General_Ticket_Date) AS Year, MONTHNAME(General_Ticket_Date) AS Month,  sum(General_Ticket_Quantity) as Ticket
                                            FROM zoo_transaction where General_Ticket_Date between @FromDate and @ToDate
                                            GROUP BY Year, Month
                                            ORDER BY Ticket DESC;", connection))
                {
                    command.Parameters.AddWithValue("@FromDate", fromDate);
                    command.Parameters.AddWithValue("@ToDate", toDate);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AttendanceReport attendanceReport = new AttendanceReport();
                            attendanceReport.Year = reader["Year"].ToString();
                            attendanceReport.Month = reader["Month"].ToString();
                            attendanceReport.NumOfTick = Convert.ToInt32(reader["Ticket"]);
                            //attendanceReports.Total_Spent = Convert.ToInt32(reader["Total_Spent"]);
                            //revenueReport.Location_ID = Convert.ToInt32(reader["Department_Location"]);
                            //revenueReport.Department_Name = reader["Department_Name"].ToString();
                            //revenueReport.Department_Budget = Convert.ToInt32(reader["Department_Budget"]);
                            attReport.Add(attendanceReport);
                        }

                    }




                }

                ViewData["AttendancebyMonth"] = attReport;

                return Page();
            }




        }

        public IActionResult OnGetQuarter(DateTime fromDate, DateTime toDate)
        {
            List<AttendanceReport> attReport = new List<AttendanceReport>();

            using (MySqlConnection connection = new MySqlConnection("Server=zoo-db-server.mysql.database.azure.com;UserID=audace;Password='37PE&CWYy9e@';Database=zoo_db;"))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(@"SELECT YEAR(General_Ticket_Date) AS Year,QUARTER(General_Ticket_Date) as quarter, SUM(General_Ticket_Quantity ) as Ticket
                                            FROM zoo_transaction where General_Ticket_Date between @FromDate and @ToDate
                                            GROUP BY Year,quarter
                                            ORDER BY Ticket DESC;", connection))
                {
                    command.Parameters.AddWithValue("@FromDate", fromDate);
                    command.Parameters.AddWithValue("@ToDate", toDate);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AttendanceReport attendanceReport = new AttendanceReport();
                            attendanceReport.Year = reader["Year"].ToString();
                            attendanceReport.Quarters = 'Q' + reader["quarter"].ToString();
                            attendanceReport.NumOfTick = Convert.ToInt32(reader["Ticket"]);
                            //attendanceReports.Total_Spent = Convert.ToInt32(reader["Total_Spent"]);
                            //revenueReport.Location_ID = Convert.ToInt32(reader["Department_Location"]);
                            //revenueReport.Department_Name = reader["Department_Name"].ToString();
                            //revenueReport.Department_Budget = Convert.ToInt32(reader["Department_Budget"]);
                            attReport.Add(attendanceReport);
                        }

                    }




                }

                ViewData["AttendancebyQuarter"] = attReport;

                return Page();
            }




        }

    }

    public class AttendanceReport
    {
        public string Day { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string Quarters { get; set; }
        public int NumOfTick { get; set; }
    }
}
