using System;
using System.Collections.Generic;
using SafariSoul.Models;

namespace SafariSoul.Pages.AnimalCRUD;

public partial class Occupation
{
    public string JobTitle { get; set; } = null!;

    public string JobDescription { get; set; } = null!;

    public string QualificationsRequired { get; set; } = null!;

    public double LowerSalaryRange { get; set; }

    public double UpperSalaryRange { get; set; }

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
