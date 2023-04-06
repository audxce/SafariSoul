using System;
using System.Collections.Generic;

namespace SafariSoul.Models;

public partial class DepartmentEducationProgram
{
    public int DeptId { get; set; }

    public int ProgramNo { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Department Dept { get; set; } = null!;

    public virtual EducationProgram ProgramNoNavigation { get; set; } = null!;
}
