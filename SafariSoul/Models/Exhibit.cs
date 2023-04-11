using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SafariSoul.Models;

public partial class Exhibit
{
    public int ExhibitId { get; set; }

    [DisplayName("Exhibit Name")]
    public string ExhibitName { get; set; } = null!;

    public int Location { get; set; }

    [DisplayName("Is Indoor?")]
    public bool IsIndoors { get; set; }

    public int Zookeeper { get; set; }

    [DisplayName("Normal Temperature")]
    public float? NormalTemperature { get; set; }

    public float? Humidity { get; set; }

    [DisplayName("Feeding Time")]
    public TimeOnly FeedingTime { get; set; }

    [DisplayName("Meal Content")]
    public int MealContent { get; set; }

    [DisplayName("Meal Quantity")]
    public int? MealQuantity { get; set; }

    [DisplayName("Created At")]
    public DateTime? CreatedAt { get; set; }

    [DisplayName("Updated At")]
    public DateTime? UpdatedAt { get; set; }

    [DisplayName("Location")]
    public virtual Location LocationNavigation { get; set; } = null!;

    public virtual ICollection<MaintenanceRequest> MaintenanceRequests { get; } = new List<MaintenanceRequest>();

    [DisplayName("Meal Content")]
    public virtual Inventory MealContentNavigation { get; set; } = null!;

    public virtual ICollection<Species> Species { get; } = new List<Species>();

    [DisplayName("Zookeeper")]
    public virtual Employee ZookeeperNavigation { get; set; } = null!;
}
