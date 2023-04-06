using System;
using System.Collections.Generic;

namespace SafariSoul.Models;

public partial class VeterinaryVisit
{
    public int VetVisitId { get; set; }

    public DateTime? TimeScheduled { get; set; }

    public DateTime? TimeAdmitted { get; set; }

    public DateTime? TimeDischarged { get; set; }

    public string Urgency { get; set; } = null!;

    public int Animal { get; set; }

    public string? AnimalCondition { get; set; }

    public string? AnimalTreatment { get; set; }

    public bool? FollowupNeeded { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Animal AnimalNavigation { get; set; } = null!;

    public virtual ICollection<VeterinaryVisitVetId> VeterinaryVisitVetIds { get; } = new List<VeterinaryVisitVetId>();
}
