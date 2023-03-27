﻿using System;
using System.Collections.Generic;
using SafariSoul.Models;

namespace SafariSoul;

public partial class Exhibit
{
    public int ExhibitNo { get; set; }

    public int Location { get; set; }

    public bool IsIndoors { get; set; }

    public int Zookeeper { get; set; }

    /// <summary>
    /// Temperature in Fahrenheit
    /// </summary>
    public float? UpperTemperature { get; set; }

    /// <summary>
    /// Temperature in Fahrenheit
    /// </summary>
    public float? LowerTemperature { get; set; }

    /// <summary>
    /// Humidity in percentage
    /// </summary>
    public float? Humidity { get; set; }

    public string? Flora { get; set; }

    public virtual ICollection<ExhibitFeedingSchedule> ExhibitFeedingSchedules { get; } = new List<ExhibitFeedingSchedule>();

    public virtual Location LocationNavigation { get; set; } = null!;

    public virtual ICollection<MaintenanceRequest> MaintenanceRequests { get; } = new List<MaintenanceRequest>();

    public virtual ICollection<Species> Species { get; } = new List<Species>();

    public virtual Employee ZookeeperNavigation { get; set; } = null!;
}
