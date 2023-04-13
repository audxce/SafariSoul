using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SafariSoul.Models;

public partial class ZooUser
{
    [DisplayName("User Name")]
    public string UserName { get; set; } = null!;

    [DisplayName("Authentication Key")]
    public string AuthenticationKey { get; set; }

    [DisplayName("User Type")]
    public string? UserType { get; set; }

    [DisplayName("Employee")]
    public int? EmployeeId { get; set; }

    [DisplayName("Customer")]
    public int? CustomerId { get; set; }

    [DisplayName("Created At")]
    public DateTime? CreatedAt { get; set; }

    [DisplayName("Updated At")]
    public DateTime? UpdatedAt { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Employee? Employee { get; set; }
}
