﻿using System;
using System.Collections.Generic;

namespace SafariSoul.Models;

public partial class MaintenanceRequest
{
    public int TicketNo { get; set; }

    public string Details { get; set; } = null!;

    public int? Room { get; set; }

    public int? Exhibit { get; set; }

    public int? Location { get; set; }

    public int? Requester { get; set; }

    public DateTime TimeRequested { get; set; }

    public int? Fulfiller { get; set; }

    public DateTime? TimeFulfilled { get; set; }

    public string? Urgency { get; set; }

    public virtual Exhibit? ExhibitNavigation { get; set; }

    public virtual Employee? FulfillerNavigation { get; set; }

    public virtual Location? LocationNavigation { get; set; }

    public virtual Employee? RequesterNavigation { get; set; }
}