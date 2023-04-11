using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SafariSoul.Models;

public partial class Dependent
{
    public int DependentId { get; set; }

    public int EmployeeId { get; set; }

    [DisplayName("First Name")]
    public string Fname { get; set; } = null!;

    [DisplayName("Birth Date")]
    public DateOnly Bdate { get; set; }

    [DisplayName("Gender")]
    public string? Gender { get; set; }

    [DisplayName("Phone Number")]
    public string? PhoneNum { get; set; }

    [DisplayName("Email Address")]
    public string? Email { get; set; }

    [DisplayName("Address")]
    public string? Address { get; set; }

    [DisplayName("Created At")]
    public DateTime? CreatedAt { get; set; }

    [DisplayName("Updated At")]
    public DateTime? UpdatedAt { get; set; }

    [DisplayName("Last Name")]
    public string Lname { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;

    [DisplayName("Full Name")]
    public string FullName
    {
        get { return Fname + " " + Lname; }
    }
}
