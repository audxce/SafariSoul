using System;
using System.Collections.Generic;

namespace SafariSoul.Models;

public partial class OperatingHour
{
    public int DayId { get; set; }

    public string DayOfWeek { get; set; } = null!;

    public TimeOnly OpeningTime { get; set; }

    public TimeOnly ClosingTime { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
