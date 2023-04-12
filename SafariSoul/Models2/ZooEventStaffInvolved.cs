using System;
using System.Collections.Generic;

namespace SafariSoul.Models2;

public partial class ZooEventStaffInvolved
{
    public int MultiStaffId { get; set; }

    public int? EventId { get; set; }

    public int? EmployeeId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual ZooEvent? Event { get; set; }
}
