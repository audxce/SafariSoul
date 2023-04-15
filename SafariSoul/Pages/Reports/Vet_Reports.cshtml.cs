using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySqlConnector;

namespace SafariSoul.Pages.Reports
{
    public class Vet_ReportsModel : PageModel
    {
        public IActionResult OnPost()
        {
            var reportType = Request.Form["reportType"];

            if (reportType == "Incomplete Vet Visits")
            {

                return OnGetIncom();
            }
            else if (reportType == "Completed Vet Visits")
            {
                // generate expense report
                return OnGetCom();
            }
            
            else
            {
                // handle error
                return Page();
            }
        }
        public IActionResult OnGetIncom()
        {
            List<VetinarianReports> vetReports = new List<VetinarianReports>();

            using (MySqlConnection connection = new MySqlConnection("Server=zoo-db-server.mysql.database.azure.com;UserID=audace;Password='37PE&CWYy9e@';Database=zoo_db;"))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(@"SELECT (case when V.animal = A.Animal_ID then A.Animal_Name else 0 end) As Animal_Name, 
		                                                        V.Vet_Visit_ID,V.Urgency, V.Animal_Condition
                                                        FROM  veterinary_visit V, animal A
                                                        WHERE V.animal = A.Animal_ID  and V.Time_Discharged IS NULL
                                                        ORDER BY V.Urgency;", connection))
                {

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            VetinarianReports vetinarianReports = new VetinarianReports();
                            vetinarianReports.Animal_Name = reader["Location"].ToString();
                            vetinarianReports.Vet_Visit_ID = Convert.ToInt32(reader["Ticket_Num"]);
                            vetinarianReports.Animal_Condition = reader["Details"].ToString();
                            vetinarianReports.Urgency = Convert.ToInt32(reader["Urgency"]);
                            //vetinarianReports.Time_Requested = Convert.ToDateTime(reader["Requested_at"]);

                            vetReports.Add(vetinarianReports);
                        }

                    }




                }

                ViewData["VetReportIncompleted"] = vetReports;

                return Page();
            }

        }

        public IActionResult OnGetCom()
        {
            List<VetinarianReports> vetReports = new List<VetinarianReports>();

            using (MySqlConnection connection = new MySqlConnection("Server=zoo-db-server.mysql.database.azure.com;UserID=audace;Password='37PE&CWYy9e@';Database=zoo_db;"))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(@"SELECT (case when V.animal = A.Animal_ID then A.Animal_Name else 0 end) As Animal_Name, 
		                                                        V.Vet_Visit_ID as VID,V.Urgency as UGC, V.Animal_Condition as CON
                                                        FROM  veterinary_visit V, animal A
                                                        WHERE V.animal = A.Animal_ID  and V.Time_Discharged IS NULL
                                                        ORDER BY V.Urgency;", connection))
                {

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            VetinarianReports vetinarianReports = new VetinarianReports();
                            vetinarianReports.Animal_Name = reader["Animal_Name"].ToString();
                            vetinarianReports.Vet_Visit_ID = Convert.ToInt32(reader["VID"]);
                            vetinarianReports.Animal_Condition = reader["CON"].ToString();
                            vetinarianReports.Urgency = Convert.ToInt32(reader["UGC"]);
                            //vetinarianReports.Time_Requested = Convert.ToDateTime(reader["Requested_at"]);

                            vetReports.Add(vetinarianReports);
                        }

                    }




                }

                ViewData["VetReportCompleted"] = vetReports;

                return Page();
            }

        }

        public class VetinarianReports
        {
            public string Animal_Name { get; set; }
            public int Vet_Visit_ID { get; set; }
            public int Urgency { get; set; }
            public string Animal_Condition { get; set; }

        }
    }
}
