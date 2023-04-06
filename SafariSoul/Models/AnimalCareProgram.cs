using System;
using System.Collections.Generic;

namespace SafariSoul.Models;

public partial class AnimalCareProgram
{
    public int AnimalProgramNum { get; set; }

    public string ProgramName { get; set; } = null!;

    public string? ProgramDescription { get; set; }

    public string? ProgramResults { get; set; }

    public string? Feedback { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<AnimalCareProgramAnimalsInvolved> AnimalCareProgramAnimalsInvolveds { get; } = new List<AnimalCareProgramAnimalsInvolved>();

    public virtual ICollection<AnimalCareProgramStaffInvolved> AnimalCareProgramStaffInvolveds { get; } = new List<AnimalCareProgramStaffInvolved>();

    public virtual ICollection<DepartmentAnimalProgram> DepartmentAnimalPrograms { get; } = new List<DepartmentAnimalProgram>();

    public virtual ICollection<ZooEvent> ZooEvents { get; } = new List<ZooEvent>();
}
