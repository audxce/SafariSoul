using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SafariSoul.Models;

public partial class ZooEventStaffInvolved
{
    public int MultiStaffId { get; set; }

    [DisplayName("Event")]
    public int EventId { get; set; }

    [DisplayName("Employee")]
    public int EmployeeId { get; set; }

    [DisplayName("Created At")]
    public DateTime? CreatedAt { get; set; }

    [DisplayName("Updated At")]
    public DateTime? UpdatedAt { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual ZooEvent Event { get; set; } = null!;
}
