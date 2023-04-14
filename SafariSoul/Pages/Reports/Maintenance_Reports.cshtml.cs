using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySqlConnector;
using static SafariSoul.Pages.Reports.Accountant_ReportsModel;

namespace SafariSoul.Pages.Reports
{
    public class Maintenance_ReportsModel : PageModel
    {
        public IActionResult OnPost()
        {
            var reportType = Request.Form["reportType"];

            if (reportType == "Location by Urgency")
            {

                return OnGetLocbyUrg();
            }
            else if (reportType == "Location by Request Time")
            {
                // generate expense report
                return OnGetLocbyReq();
            }
            else if (reportType == "By Urgency")
            {
                // generate expense report
                return OnGetbyUrg();
            }
            else if (reportType == "By Request Time")
            {
                // generate expense report
                return OnGetbyReq();
            }
            else if (reportType == "Completed Request")
            {
                // generate expense report
                return OnGetIncom();
            }
            else
            {
                // handle error
                return Page();
            }
        }
        public IActionResult OnGetLocbyUrg()
        {
            List<MaintenanceReport> mainReport = new List<MaintenanceReport>();

            using (MySqlConnection connection = new MySqlConnection("Server=zoo-db-server.mysql.database.azure.com;UserID=audace;Password='37PE&CWYy9e@';Database=zoo_db;"))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(@"SELECT MR.Ticket_No as Ticket_Num, 
                                (case when MR.Location = L.Location_ID then L.Location_Name else 0 end) as Location, 
                                MR.Details as Details, MR.Urgency as Urgency, MR.Time_Requested as Requested_at
                            FROM maintenance_request MR, location L
                            WHERE MR.Location = L.Location_ID and MR.Time_Fulfilled IS NULL
                            Order by MR.Urgency and MR.Location", connection))
                {

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MaintenanceReport maintenanceReport = new MaintenanceReport();
                            maintenanceReport.Ticket_No = Convert.ToInt32(reader["Ticket_Num"]);
                            maintenanceReport.Location = reader["Location"].ToString();
                            //maintenanceReport.Exhibit = reader["Vendor_Name"].ToString();
                            maintenanceReport.Details = reader["Details"].ToString();
                            maintenanceReport.Urgency = Convert.ToInt32(reader["Urgency"]);
                            maintenanceReport.Time_Requested = Convert.ToDateTime(reader["Requested_at"]);

                            mainReport.Add(maintenanceReport);
                        }

                    }




                }

                ViewData["MaintenanceReportbyUrg"] = mainReport;

                return Page();
            }




        }

        public IActionResult OnGetLocbyReq()
        {
            List<MaintenanceReport> mainReport2 = new List<MaintenanceReport>();

            using (MySqlConnection connection = new MySqlConnection("Server=zoo-db-server.mysql.database.azure.com;UserID=audace;Password='37PE&CWYy9e@';Database=zoo_db;"))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(@"SELECT MR.Ticket_No as Ticket_Num, 
                                (case when MR.Location = L.Location_ID then L.Location_Name else 0 end) as Location, 
                                MR.Details as Details, MR.Urgency as Urgency, MR.Time_Requested as Requested_at
                            FROM maintenance_request MR, location L
                            WHERE MR.Location = L.Location_ID and MR.Time_Fulfilled IS NULL
                            Order by MR.Time_Requested and MR.Location", connection))
                {

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MaintenanceReport maintenanceReport = new MaintenanceReport();
                            maintenanceReport.Ticket_No = Convert.ToInt32(reader["Ticket_Num"]);
                            maintenanceReport.Location = reader["Location"].ToString();
                            //maintenanceReport.Exhibit = reader["Vendor_Name"].ToString();
                            maintenanceReport.Details = reader["Details"].ToString();
                            maintenanceReport.Urgency = Convert.ToInt32(reader["Urgency"]);
                            maintenanceReport.Time_Requested = Convert.ToDateTime(reader["Requested_at"]);

                            mainReport2.Add(maintenanceReport);
                        }

                    }




                }

                ViewData["MaintenanceReportbyReq"] = mainReport2;

                return Page();
            }




        }

        public IActionResult OnGetbyUrg()
        {
            List<MaintenanceReport> mainReport2 = new List<MaintenanceReport>();

            using (MySqlConnection connection = new MySqlConnection("Server=zoo-db-server.mysql.database.azure.com;UserID=audace;Password='37PE&CWYy9e@';Database=zoo_db;"))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(@"SELECT MR.Ticket_No as Ticket_Num, (case when MR.Location = L.Location_ID then L.Location_Name else 0 end) as Location, MR.Details as Details, MR.Urgency as Urgency, MR.Time_Requested as Requested_at
                                        FROM maintenance_request MR, location L
                                        where MR.Location = L.Location_ID and MR.Time_Fulfilled IS NULL
                                        Order by  MR.Urgency DESC;", connection))
                {

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MaintenanceReport maintenanceReport = new MaintenanceReport();
                            maintenanceReport.Ticket_No = Convert.ToInt32(reader["Ticket_Num"]);
                            maintenanceReport.Location = reader["Location"].ToString();
                            //maintenanceReport.Exhibit = reader["Vendor_Name"].ToString();
                            maintenanceReport.Details = reader["Details"].ToString();
                            maintenanceReport.Urgency = Convert.ToInt32(reader["Urgency"]);
                            maintenanceReport.Time_Requested = Convert.ToDateTime(reader["Requested_at"]);

                            mainReport2.Add(maintenanceReport);
                        }

                    }




                }

                ViewData["MaintenanceReportUrg"] = mainReport2;

                return Page();
            }




        }
        public IActionResult OnGetbyReq()
        {
            List<MaintenanceReport> mainReport2 = new List<MaintenanceReport>();

            using (MySqlConnection connection = new MySqlConnection("Server=zoo-db-server.mysql.database.azure.com;UserID=audace;Password='37PE&CWYy9e@';Database=zoo_db;"))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(@"SELECT MR.Ticket_No as Ticket_Num, (case when MR.Location = L.Location_ID then L.Location_Name else 0 end) as Location, MR.Details as Details, MR.Urgency as Urgency, MR.Time_Requested as Requested_at
                                        FROM maintenance_request MR, location L
                                        where MR.Location = L.Location_ID and MR.Time_Fulfilled IS NULL
                                        Order by  MR.Time_Requested ASC;", connection))
                {

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MaintenanceReport maintenanceReport = new MaintenanceReport();
                            maintenanceReport.Ticket_No = Convert.ToInt32(reader["Ticket_Num"]);
                            maintenanceReport.Location = reader["Location"].ToString();
                            //maintenanceReport.Exhibit = reader["Vendor_Name"].ToString();
                            maintenanceReport.Details = reader["Details"].ToString();
                            maintenanceReport.Urgency = Convert.ToInt32(reader["Urgency"]);
                            maintenanceReport.Time_Requested = Convert.ToDateTime(reader["Requested_at"]);

                            mainReport2.Add(maintenanceReport);
                        }

                    }




                }

                ViewData["MaintenanceReportReq"] = mainReport2;

                return Page();
            }




        }
        public IActionResult OnGetIncom()
        {
            List<MaintenanceReport> mainReport2 = new List<MaintenanceReport>();

            using (MySqlConnection connection = new MySqlConnection("Server=zoo-db-server.mysql.database.azure.com;UserID=audace;Password='37PE&CWYy9e@';Database=zoo_db;"))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(@"SELECT MR.Ticket_No as Ticket_Num, (case when MR.Location = L.Location_ID then L.Location_Name else 0 end) as Location, MR.Details as Details, MR.Urgency as Urgency, MR.Time_Requested as Requested_at
                                        FROM maintenance_request MR, location L
                                        where MR.Location = L.Location_ID and MR.Time_Fulfilled IS NOT NULL
                                        Order by  MR.Urgency DESC;", connection))
                {

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MaintenanceReport maintenanceReport = new MaintenanceReport();
                            maintenanceReport.Ticket_No = Convert.ToInt32(reader["Ticket_Num"]);
                            maintenanceReport.Location = reader["Location"].ToString();
                            //maintenanceReport.Exhibit = reader["Vendor_Name"].ToString();
                            maintenanceReport.Details = reader["Details"].ToString();
                            maintenanceReport.Urgency = Convert.ToInt32(reader["Urgency"]);
                            maintenanceReport.Time_Requested = Convert.ToDateTime(reader["Requested_at"]);

                            mainReport2.Add(maintenanceReport);
                        }

                    }




                }

                ViewData["MaintenanceReportIncom"] = mainReport2;

                return Page();
            }




        }
    }
    public class MaintenanceReport
    {
        public int Ticket_No { get; set; }
        public string Location { get; set; }
        public string Details { get; set; }
        public int Urgency { get; set; }
        public int Exhibit { get; set; }
        public DateTime Time_Requested { get; set; }

    }
}
