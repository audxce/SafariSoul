using System;
using System.Collections.Generic;

namespace SafariSoul.Models2;

public partial class ZooEvent
{
    public int EventId { get; set; }

    public string? EventName { get; set; }

    public int? Capacity { get; set; }

    public DateTime? EventTime { get; set; }

    public float? AdmissionPrice { get; set; }

    public DateOnly? RegistrationDeadline { get; set; }

    public int? AnimalProgramId { get; set; }

    public int? EducationalProgramId { get; set; }

    public int? EventLocationId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual AnimalCareProgram? AnimalProgram { get; set; }

    public virtual EducationProgram? EducationalProgram { get; set; }

    public virtual Location? EventLocation { get; set; }

    public virtual ICollection<ZooEventAnimalsInvolved> ZooEventAnimalsInvolveds { get; } = new List<ZooEventAnimalsInvolved>();

    public virtual ICollection<ZooEventStaffInvolved> ZooEventStaffInvolveds { get; } = new List<ZooEventStaffInvolved>();

    public virtual ICollection<ZooTransactionEventTicket> ZooTransactionEventTickets { get; } = new List<ZooTransactionEventTicket>();
}
