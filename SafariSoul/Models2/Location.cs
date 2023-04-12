using System;
using System.Collections.Generic;

namespace SafariSoul.Models2;

public partial class Location
{
    public int LocationId { get; set; }

    public string LocationName { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Department> Departments { get; } = new List<Department>();

    public virtual ICollection<Exhibit> Exhibits { get; } = new List<Exhibit>();

    public virtual ICollection<Inventory> Inventories { get; } = new List<Inventory>();

    public virtual ICollection<MaintenanceRequest> MaintenanceRequests { get; } = new List<MaintenanceRequest>();

    public virtual ICollection<ZooEvent> ZooEvents { get; } = new List<ZooEvent>();

    public virtual ICollection<ZooTransaction> ZooTransactions { get; } = new List<ZooTransaction>();
}
