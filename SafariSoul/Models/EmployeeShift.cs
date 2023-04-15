using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SafariSoul.Models;

public partial class EmployeeShift
{
    public int ShiftId { get; set; }

    public int? EmployeeId { get; set; }

    [DisplayName("Shift Start")]
    public DateTime ShiftStart { get; set; }

    [DisplayName("Shift End")]
    public DateTime? ShiftEnd { get; set; }

    [DisplayName("Lunch Start")]
    public DateTime? LunchStart { get; set; }

    [DisplayName("Lunch End")]
    public DateTime? LunchEnd { get; set; }

    [DisplayName("Created At")]
    public DateTime? CreatedAt { get; set; }

    [DisplayName("Updated At")]
    public DateTime? UpdatedAt { get; set; }

    public virtual Employee? Employee { get; set; } = null!;
}
