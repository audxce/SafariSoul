using System;
using System.Collections.Generic;

namespace SafariSoul.Models2;

public partial class ZooUser
{
    public string UserName { get; set; } = null!;

    public string AuthenticationKey { get; set; } = null!;

    public string? UserType { get; set; }

    public int? EmployeeId { get; set; }

    public int? CustomerId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Employee? Employee { get; set; }
}
