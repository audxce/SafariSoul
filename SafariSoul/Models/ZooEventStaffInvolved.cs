using System;
using System.Collections.Generic;

namespace SafariSoul.Models;

public partial class ZooEventStaffInvolved
{
    public int MultiStaffId { get; set; }

    public int EventId { get; set; }

    public int EmployeeId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual ZooEvent Event { get; set; } = null!;
}
