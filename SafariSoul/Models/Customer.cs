using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SafariSoul.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    [DisplayName("First Name")]
    public string Fname { get; set; } = null!;

    [DisplayName("Middle Initial")]
    public string? Minit { get; set; }

    [DisplayName("Last Name")]
    public string Lname { get; set; } = null!;

    public string? Gender { get; set; }

    [DisplayName("Date of Birth")]
    public DateOnly? DateOfBirth { get; set; }

    [DisplayName("Phone Number")]
    public string? PhoneNo { get; set; }

    public string? Address { get; set; }

    public string? Email { get; set; }

    [DisplayName("Credit Card Number")]
    public string? CreditCardNo { get; set; }

    [DisplayName("Membership Level")]
    public string? MembershipLevel { get; set; }

    [DisplayName("Membership Start Date")]
    public DateOnly? MembershipStartDate { get; set; }

    [DisplayName("Is Donor?")]
    public bool? IsDonor { get; set; }

    [DisplayName("Created At")]
    public DateTime? CreatedAt { get; set; }

    [DisplayName("Updated At")]
    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Donation> Donations { get; } = new List<Donation>();

    [DisplayName("Membership Level")]
    public virtual Membership? MembershipLevelNavigation { get; set; }

    public virtual ICollection<ZooTransaction> ZooTransactions { get; } = new List<ZooTransaction>();

    public virtual ICollection<ZooUser> ZooUsers { get; } = new List<ZooUser>();

    [DisplayName("Full Name")]
    public string FullName
    {
        get { return Fname + " " + Lname; }
    }
}
