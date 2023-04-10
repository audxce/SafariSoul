using System;
using System.Collections.Generic;

namespace SafariSoul.Models;

public partial class Exhibit
{
    public int ExhibitId { get; set; }

    public string ExhibitName { get; set; } = null!;

    public int Location { get; set; }

    public bool IsIndoors { get; set; }

    public int Zookeeper { get; set; }

    public float? NormalTemperature { get; set; }

    public float? Humidity { get; set; }

    public TimeOnly FeedingTime { get; set; }

    public int MealContent { get; set; }

    public int? MealQuantity { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Location LocationNavigation { get; set; } = null!;

    public virtual ICollection<MaintenanceRequest> MaintenanceRequests { get; } = new List<MaintenanceRequest>();

    public virtual Inventory MealContentNavigation { get; set; } = null!;

    public virtual ICollection<Species> Species { get; } = new List<Species>();

    public virtual Employee ZookeeperNavigation { get; set; } = null!;
}
