using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SafariSoul.Models;

public partial class Department
{
    public string DeptName { get; set; }

    public int? ManagerId { get; set; }

    [DisplayName("Phone Number")]
    public string? PhoneNum { get; set; }

    [DisplayName("Email Address")]
    public string? Email { get; set; }

    public int? LocationId { get; set; }

    [DisplayName("Budget")]
    public int Budget { get; set; }

    [DisplayName("Created At")]
    public DateTime? CreatedAt { get; set; }

    [DisplayName("Updated At")]
    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();

    public virtual Location? Location { get; set; }

    public virtual Employee? Manager { get; set; }
}
