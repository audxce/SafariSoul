using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SafariSoul.Models;

public partial class VeterinaryVisit
{
    public int VetVisitId { get; set; }

    [DisplayName("Veterinarian")]
    public int VetId { get; set; }

    [DisplayName("Time Scheduled")]
    public DateTime? TimeScheduled { get; set; }

    [DisplayName("Time Admitted")]
    public DateTime? TimeAdmitted { get; set; }

    [DisplayName("Time Discharged")]
    public DateTime? TimeDischarged { get; set; }

    public string? Urgency { get; set; }

    public int? Animal { get; set; }

    [DisplayName("Animal Condition")]
    public string? AnimalCondition { get; set; }

    [DisplayName("Animal Treatment")]
    public string? AnimalTreatment { get; set; }

    [DisplayName("Follow-up Needed")]
    public bool? FollowupNeeded { get; set; }

    [DisplayName("Created At")]
    public DateTime? CreatedAt { get; set; }

    [DisplayName("Updated At")]
    public DateTime? UpdatedAt { get; set; }

    [DisplayName("Animal")]
    public virtual Animal? AnimalNavigation { get; set; } = null!;

    public virtual Employee Vet { get; set; } = null!;
}
