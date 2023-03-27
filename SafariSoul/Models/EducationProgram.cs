using System;
using System.Collections.Generic;


namespace SafariSoul.Models;

public partial class EducationProgram
{
    public int ProgramNo { get; set; }

    public string ProgramName { get; set; } = null!;

    public string? ProgramDescription { get; set; }

    public int? RequiredInventory { get; set; }

    public string? Feedback { get; set; }

    public virtual ICollection<ZooEvent> ZooEvents { get; } = new List<ZooEvent>();

    public virtual ICollection<Animal> Animals { get; } = new List<Animal>();

    public virtual ICollection<Department> Depts { get; } = new List<Department>();

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
