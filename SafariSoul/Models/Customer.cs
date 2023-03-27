using System;
using System.Collections.Generic;
using SafariSoul.Models;

namespace SafariSoul;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string Fname { get; set; } = null!;

    public string? Minit { get; set; }

    public string Lname { get; set; } = null!;

    public string? Gender { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public string? PhoneNo { get; set; }

    public string? Address { get; set; }

    public string? Email { get; set; }

    public string? CreditCardNo { get; set; }

    public string? MembershipLevel { get; set; }

    public DateOnly? MembershipStartDate { get; set; }

    public bool? IsDonor { get; set; }

    public virtual ICollection<Donation> Donations { get; } = new List<Donation>();

    public virtual Membership? MembershipLevelNavigation { get; set; }

    public virtual ICollection<ZooTransaction> ZooTransactions { get; } = new List<ZooTransaction>();

    public virtual ICollection<ZooUser> ZooUsers { get; } = new List<ZooUser>();
}
