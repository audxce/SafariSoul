using System;
using System.Collections.Generic;

namespace SafariSoul.Models2;

public partial class VeterinaryVisit
{
    public int VetVisitId { get; set; }

    public int? VetId { get; set; }

    public DateTime? TimeScheduled { get; set; }

    public DateTime? TimeAdmitted { get; set; }

    public DateTime? TimeDischarged { get; set; }

    public string? Urgency { get; set; }

    public int? Animal { get; set; }

    public string? AnimalCondition { get; set; }

    public string? AnimalTreatment { get; set; }

    public bool? FollowupNeeded { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Animal? AnimalNavigation { get; set; }

    public virtual Employee? Vet { get; set; }
}
