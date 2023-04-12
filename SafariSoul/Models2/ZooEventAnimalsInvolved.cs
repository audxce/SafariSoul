using System;
using System.Collections.Generic;

namespace SafariSoul.Models2;

public partial class ZooEventAnimalsInvolved
{
    public int MultiAnimalId { get; set; }

    public int? EventId { get; set; }

    public int? AnimalId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Animal? Animal { get; set; }

    public virtual ZooEvent? Event { get; set; }
}
