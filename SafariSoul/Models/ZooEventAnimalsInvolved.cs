using System;
using System.Collections.Generic;

namespace SafariSoul.Models;

public partial class ZooEventAnimalsInvolved
{
    public int EventId { get; set; }

    public int AnimalId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Animal Animal { get; set; } = null!;

    public virtual ZooEvent Event { get; set; } = null!;
}
