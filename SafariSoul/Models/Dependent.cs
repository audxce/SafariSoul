using System;
using System.Collections.Generic;
using SafariSoul.Models;

namespace SafariSoul;

public partial class Dependent
{
    public int EmployeeId { get; set; }

    public string Fname { get; set; } = null!;

    public DateOnly Bdate { get; set; }

    public string? Gender { get; set; }

    public string? PhoneNum { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
