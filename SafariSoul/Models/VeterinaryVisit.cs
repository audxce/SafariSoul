using System;
using System.Collections.Generic;
using SafariSoul.Models;

namespace SafariSoul;

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

    public virtual Animal AnimalNavigation { get; set; } = null!;

    public virtual ICollection<Employee> Vets { get; } = new List<Employee>();
}
