using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SafariSoul.Models;

public partial class Membership
{
    [DisplayName("Membership Level")]
    public string MembershipLevel { get; set; } = null!;

    [DisplayName("Membership Fee")]
    public float MembershipFee { get; set; }

    public string? Benefits { get; set; }

    [DisplayName("Created At")]
    public DateTime? CreatedAt { get; set; }

    [DisplayName("Updated At")]
    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Customer> Customers { get; } = new List<Customer>();
}
