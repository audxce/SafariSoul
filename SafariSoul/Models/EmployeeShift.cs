using System;
using System.Collections.Generic;
using SafariSoul.Models;

namespace SafariSoul;

public partial class EmployeeShift
{
    public int EmployeeId { get; set; }

    public DateTime ShiftStart { get; set; }

    public DateTime? ShiftEnd { get; set; }

    public DateTime? LunchStart { get; set; }

    public DateTime? LunchEnd { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
