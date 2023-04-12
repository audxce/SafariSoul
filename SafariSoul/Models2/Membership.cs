using System;
using System.Collections.Generic;

namespace SafariSoul.Models2;

public partial class Membership
{
    public string MembershipLevel { get; set; } = null!;

    /// <summary>
    /// Yearly cost
    /// </summary>
    public float MembershipFee { get; set; }

    public string? Benefits { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Customer> Customers { get; } = new List<Customer>();
}
