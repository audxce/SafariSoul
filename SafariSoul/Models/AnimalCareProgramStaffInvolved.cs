using System;
using System.Collections.Generic;

namespace SafariSoul.Models;

public partial class AnimalCareProgramStaffInvolved
{
    public int AnimalProgramNum { get; set; }

    public int EmployeeId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual AnimalCareProgram AnimalProgramNumNavigation { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;
}
