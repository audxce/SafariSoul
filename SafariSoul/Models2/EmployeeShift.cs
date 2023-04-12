﻿using System;
using System.Collections.Generic;

namespace SafariSoul.Models2;

public partial class EmployeeShift
{
    public int ShiftId { get; set; }

    public int? EmployeeId { get; set; }

    public DateTime ShiftStart { get; set; }

    public DateTime? ShiftEnd { get; set; }

    public DateTime? LunchStart { get; set; }

    public DateTime? LunchEnd { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Employee? Employee { get; set; }
}