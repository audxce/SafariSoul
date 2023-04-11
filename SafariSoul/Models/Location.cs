using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SafariSoul.Models;

public partial class Location
{
    public int LocationId { get; set; }

    [DisplayName("Location Name")]
    public string LocationName { get; set; } = null!;

    [DisplayName("Created At")]
    public DateTime? CreatedAt { get; set; }

    [DisplayName("Updated At")]
    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Department> Departments { get; } = new List<Department>();

    public virtual ICollection<Exhibit> Exhibits { get; } = new List<Exhibit>();

    public virtual ICollection<Inventory> Inventories { get; } = new List<Inventory>();

    public virtual ICollection<MaintenanceRequest> MaintenanceRequests { get; } = new List<MaintenanceRequest>();

    public virtual ICollection<ZooEvent> ZooEvents { get; } = new List<ZooEvent>();

    public virtual ICollection<ZooTransaction> ZooTransactions { get; } = new List<ZooTransaction>();
}
