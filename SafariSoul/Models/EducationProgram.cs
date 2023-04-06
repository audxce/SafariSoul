using System;
using System.Collections.Generic;

namespace SafariSoul.Models;

public partial class EducationProgram
{
    public int ProgramNo { get; set; }

    public string ProgramName { get; set; } = null!;

    public string? ProgramDescription { get; set; }

    public string? Feedback { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<DepartmentEducationProgram> DepartmentEducationPrograms { get; } = new List<DepartmentEducationProgram>();

    public virtual ICollection<EducationProgramAnimalsInvolved> EducationProgramAnimalsInvolveds { get; } = new List<EducationProgramAnimalsInvolved>();

    public virtual ICollection<EducationProgramStaffInvolvled> EducationProgramStaffInvolvleds { get; } = new List<EducationProgramStaffInvolvled>();

    public virtual ICollection<ZooEvent> ZooEvents { get; } = new List<ZooEvent>();
}
