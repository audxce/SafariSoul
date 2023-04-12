using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SafariSoul.Models;

public partial class MaintenanceRequest
{
    [DisplayName("Ticket Number")]
    public int TicketNo { get; set; }

    public string Details { get; set; } = null!;

    [DisplayName("Exhibit")]
    public int? Exhibit { get; set; }

    [DisplayName("Location")]
    public int? Location { get; set; }

    [DisplayName("Time Requested")]
    public DateTime TimeRequested { get; set; }

    [DisplayName("Time Fulfilled")]
    public DateTime? TimeFulfilled { get; set; }

    public string? Urgency { get; set; }

    [DisplayName("Created At")]
    public DateTime? CreatedAt { get; set; }

    [DisplayName("Updated At")]
    public DateTime? UpdatedAt { get; set; }

    [DisplayName("Exhibit")]
    public virtual Exhibit? ExhibitNavigation { get; set; }

    [DisplayName("Location")]
    public virtual Location? LocationNavigation { get; set; }
}
