using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SafariSoul.Models;

public partial class ZooEvent
{
    public int EventId { get; set; }

    [DisplayName("Event Name")]
    public string? EventName { get; set; }

    public int? Capacity { get; set; }

    [DisplayName("Event Time")]
    public DateTime? EventTime { get; set; }

    [DisplayName("Admission Price")]
    public float? AdmissionPrice { get; set; }

    [DisplayName("Registration Deadline")]
    public DateOnly? RegistrationDeadline { get; set; }

    [DisplayName("Animal Program")]
    public int? AnimalProgramId { get; set; }

    [DisplayName("Educational Program")]
    public int? EducationalProgramId { get; set; }

    [DisplayName("Event Location")]
    public int? EventLocationId { get; set; }

    [DisplayName("Created At")]
    public DateTime? CreatedAt { get; set; }

    [DisplayName("Updated At")]
    public DateTime? UpdatedAt { get; set; }

    [DisplayName("Animal Care Program")]
    public virtual AnimalCareProgram? AnimalProgram { get; set; }

    [DisplayName("Education Program")]
    public virtual EducationProgram? EducationalProgram { get; set; }

    [DisplayName("Event Location")]
    public virtual Location? EventLocation { get; set; }

    public virtual ICollection<ZooEventAnimalsInvolved> ZooEventAnimalsInvolveds { get; } = new List<ZooEventAnimalsInvolved>();

    public virtual ICollection<ZooEventStaffInvolved> ZooEventStaffInvolveds { get; } = new List<ZooEventStaffInvolved>();

    public virtual ICollection<ZooTransactionEventTicket> ZooTransactionEventTickets { get; } = new List<ZooTransactionEventTicket>();
}
