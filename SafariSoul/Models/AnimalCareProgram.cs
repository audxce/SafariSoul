using System;
using System.Collections.Generic;
using SafariSoul.Models;

namespace SafariSoul;

public partial class AnimalCareProgram
{
    public int AnimalProgramNum { get; set; }

    public string ProgramName { get; set; } = null!;

    public string? ProgramDescription { get; set; }

    public string? ProgramResults { get; set; }

    public string? Feedback { get; set; }

    public virtual ICollection<ZooEvent> ZooEvents { get; } = new List<ZooEvent>();

    public virtual ICollection<Animal> Animals { get; } = new List<Animal>();

    public virtual ICollection<Department> Depts { get; } = new List<Department>();

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
