using System;
using System.Collections.Generic;

namespace SafariSoul;

public partial class LocationDaysClosed
{
    public int LocationNum { get; set; }

    public DateOnly DayClosed { get; set; }

    public virtual Location LocationNumNavigation { get; set; } = null!;
}
