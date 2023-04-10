using System;
using System.Collections.Generic;

namespace SafariSoul.Models;

public partial class ZooUser
{
    public string UserName { get; set; } = null!;

    public int AuthenticationKey { get; set; }

    public string? UserType { get; set; }

    public int? EmployeeId { get; set; }

    public int? CustomerId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Employee? Employee { get; set; }
}
