using System;
using System.Collections.Generic;

namespace SafariSoul.Models;

public partial class DepartmentAnimalProgram
{
    public int DeptId { get; set; }

    public int AnimalProgramNum { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual AnimalCareProgram AnimalProgramNumNavigation { get; set; } = null!;

    public virtual Department Dept { get; set; } = null!;
}
