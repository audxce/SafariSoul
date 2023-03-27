using System;
using System.Collections.Generic;

namespace SafariSoul.Models;

public partial class ZooUser
{
    public int UserId { get; set; }

    public int AuthenticationKey { get; set; }

    public string? UserName { get; set; }

    public string? UserType { get; set; }

    public int? EmployeeId { get; set; }

    public int? CustomerId { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Employee? Employee { get; set; }
}
