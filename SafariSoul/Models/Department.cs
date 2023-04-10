using System;
using System.Collections.Generic;

namespace SafariSoul.Models;

public partial class Department
{
    public string DeptName { get; set; } = null!;

    public int ManagerId { get; set; }

    public string? PhoneNum { get; set; }

    public string? Email { get; set; }

    public int? LocationId { get; set; }

    public int Budget { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();

    public virtual Location? Location { get; set; }

    public virtual Employee Manager { get; set; } = null!;
}
