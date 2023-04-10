using System;
using System.Collections.Generic;

namespace SafariSoul.Models;

public partial class MaintenanceRequest
{
    public int TicketNo { get; set; }

    public string Details { get; set; } = null!;

    public int? Exhibit { get; set; }

    public int? Location { get; set; }

    public DateTime TimeRequested { get; set; }

    public DateTime? TimeFulfilled { get; set; }

    public string? Urgency { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Exhibit? ExhibitNavigation { get; set; }

    public virtual Location? LocationNavigation { get; set; }
}
