using System;
using System.Collections.Generic;

namespace SafariSoul.Models2;

public partial class Dependent
{
    public int DependentId { get; set; }

    public int? EmployeeId { get; set; }

    public string Fname { get; set; } = null!;

    public DateOnly Bdate { get; set; }

    public string? Gender { get; set; }

    public string? PhoneNum { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string Lname { get; set; } = null!;

    public virtual Employee? Employee { get; set; }
}
