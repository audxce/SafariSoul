using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SafariSoul.Models;

public partial class OperatingHour
{
    public int DayId { get; set; }

    [DisplayName("Day of Week")]
    public string DayOfWeek { get; set; } = null!;

    [DisplayName("Opening Time")]
    public TimeOnly OpeningTime { get; set; }

    [DisplayName("Closing Time")]
    public TimeOnly ClosingTime { get; set; }

    [DisplayName("Created At")]
    public DateTime? CreatedAt { get; set; }

    [DisplayName("Updated At")]
    public DateTime? UpdatedAt { get; set; }
}
