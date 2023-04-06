using System;
using System.Collections.Generic;

namespace SafariSoul.Models;

public partial class ZooEvent
{
    public int EventId { get; set; }

    public string? EventName { get; set; }

    public string? EventType { get; set; }

    public int? Capacity { get; set; }

    public int? NumberAttending { get; set; }

    public string? HostName { get; set; }

    public string? HostEmail { get; set; }

    public string? HostPhoneNum { get; set; }

    public DateTime? EventTime { get; set; }

    public float? AdmissionPrice { get; set; }

    public DateOnly? RegistrationDeadline { get; set; }

    public int? AnimalProgramNo { get; set; }

    public int? EducationalProgramNo { get; set; }

    public string? EventDescription { get; set; }

    public int? EventLocation { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual AnimalCareProgram? AnimalProgramNoNavigation { get; set; }

    public virtual EducationProgram? EducationalProgramNoNavigation { get; set; }

    public virtual Location? EventLocationNavigation { get; set; }

    public virtual ICollection<ZooEventAnimalsInvolved> ZooEventAnimalsInvolveds { get; } = new List<ZooEventAnimalsInvolved>();

    public virtual ICollection<ZooEventRequiredInventory> ZooEventRequiredInventories { get; } = new List<ZooEventRequiredInventory>();

    public virtual ICollection<ZooEventStaffInvolved> ZooEventStaffInvolveds { get; } = new List<ZooEventStaffInvolved>();

    public virtual ICollection<ZooTransactionEventTicket> ZooTransactionEventTickets { get; } = new List<ZooTransactionEventTicket>();
}
