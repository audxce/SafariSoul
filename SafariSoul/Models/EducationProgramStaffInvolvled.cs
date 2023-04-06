using System;
using System.Collections.Generic;

namespace SafariSoul.Models;

public partial class EducationProgramStaffInvolvled
{
    public int ProgramNo { get; set; }

    public int EmployeeId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual EducationProgram ProgramNoNavigation { get; set; } = null!;
}
