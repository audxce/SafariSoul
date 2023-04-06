using System;
using System.Collections.Generic;

namespace SafariSoul.Models;

public partial class VeterinaryVisitVetId
{
    public int VetVisitId { get; set; }

    public int VetId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Employee Vet { get; set; } = null!;

    public virtual VeterinaryVisit VetVisit { get; set; } = null!;
}
